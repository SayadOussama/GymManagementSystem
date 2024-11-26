using BusinessLayer;
using GymManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement.Subscribers.Controls
{
    public partial class ctrlFindSubscriber : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnAccountSelected;
        // Create a protected method to raise the event with a parameter



        protected virtual void ClientSelected(int AccountID)
        {
            Action<int> handler = OnAccountSelected;
            if (handler != null)
            {
                handler(AccountID); // Raise the event with the parameter
            }
        }
        clsSubscriberAccounts _SubscriberAccount;
        int _AccountID = -1;
        bool _gbFilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _gbFilterEnabled; }
            set
            {
                value = _gbFilterEnabled;
                gbFilters.Enabled = value;
            }
        }
        public int AccountID
        {
            get { return _AccountID; }
        }
        public clsSubscriberAccounts SubscriberInfo
        {
            get { return _SubscriberAccount; }
        }
       
            public ctrlFindSubscriber()
        {
            InitializeComponent();
        }
        private void FindNow()
        {
            //Way 1 :
            //If the You Load Data = send Data By prameters
            switch (cbFilterBy.Text)
            {
                case "Account ID":
                    FillSubscribeSction(int.Parse(txtFilterValue.Text));

                    break;

                case "Person ID":
                   // userControl11.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    FillSubscribeSction(int.Parse(txtFilterValue.Text));
                    break;
               
                default:
                    break;
            }
            //Way 2 :
            //Notes:
            // If the User Want To Use THe Control From the Form 


            if (OnAccountSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnAccountSelected(this.AccountID);
        }

        void FillSubscribeSction(int ID)
        {

            switch (cbFilterBy.Text)
            {
                case "Account ID":
                    {
                        _SubscriberAccount = clsSubscriberAccounts.GetAccountInfoByAccountID(ID);
                       
                        if (_SubscriberAccount == null)
                            return;
                        ctrlPersonCard1.LoadPersonInfo(_SubscriberAccount.PersonID);
                        
                        break;

                       }
                case "Person ID":
                    {
                        _SubscriberAccount = clsSubscriberAccounts.GetAccountInfoByPersonID(ID);
                        if (_SubscriberAccount == null)
                            return;
                        break;
                    }
                default:
                    break;
            }


            lblAccountID.Text = _SubscriberAccount.AccountID.ToString();
            gbTrainer.Enabled = false;
            gbSubscribeType.Enabled = false;
            lblSubscribeStartDate.Text = _SubscriberAccount.CreationDate.ToShortDateString();
            lblSubscribEndDate.Text = _SubscriberAccount.EndDateSubscriber.ToShortDateString();
            if (_SubscriberAccount.TrainerTypeID != -1)
            {
                string TrainerTypeName= clsTrainerTypes.GetFindInfoByTrainerTypeID(_SubscriberAccount.TrainerTypeID).TrainerTypeName;

                lblTrainerChooice.Text = TrainerTypeName;
            }
            else
            {

                lblTrainerChooice.Text = "No Selected";
            }
            string Subscriber = clsSubscriptions.FindSubscriptionInfoByID(_SubscriberAccount.SubscribeID).SubscribeName;
               lblSubscribeTypeChooice.Text = Subscriber;
            if (_SubscriberAccount.IsPaid && _SubscriberAccount.EndDateSubscriber > DateTime.Now)
            {
                lblIsPaid.Text = "Is Piad";
                pbIsPaid.Image = Resources.checkedTruePaid;

                pbIsActive.Image = Resources.Green_Light;
                lblIsActive.Text = "Is Active";
                lblIsActive.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblIsPaid.Text = "Not Paid";
                pbIsPaid.Image = Resources.CheckFalsePaid;

                pbIsActive.Image = Resources.Red_Light;
                lblIsActive.Text = "Is Not Active";
                lblIsActive.ForeColor = Color.Red;
            }

            lblTotalAmount.Text = _SubscriberAccount.SubscribeMonthAmount.ToString();





        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                //that Mean Press ENTER in Key Board
                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Account ID" || cbFilterBy.Text == "Person ID" )
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ctrlFindSubscriber_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Focus();
            btnAddNewAccount.Enabled = true;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        private void btnAddNewAccount_Click_1(object sender, EventArgs e)
        {
            frmAddNewUpdateSubscriber frm1 = new frmAddNewUpdateSubscriber();
            frm1.DataBack += DataBackEvent; // Subscribe to the event
            frm1.ShowDialog();
        }

        private void DataBackEvent(object sender, int AccountID)
        {
            cbFilterBy.SelectedIndex = 1;
            gbFilters.Enabled = false; 
            txtFilterValue.Text = AccountID.ToString();
            FillSubscribeSction(AccountID);
        }
        public void LoadAccountInfoAccountID(int AccountID)
        {
            gbFilters.Enabled = false;
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = AccountID.ToString();
            FillSubscribeSction(AccountID);

        }
        public void LoadAccountInfoByPersonID(int PersonID)
        {
            gbFilters.Enabled = false;
            cbFilterBy.SelectedIndex = 2;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();

        }
    }
}
