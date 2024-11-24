using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement.TrainerAndTrainerType.Controls
{
    public partial class ctrlTrainerDetails : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> onTrainerTypeSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void ClientSelected(int TrainerTypeID)
        {
            Action<int> handler = onTrainerTypeSelected;
            if (handler != null)
            {
                handler(TrainerTypeID); // Raise the event with the parameter
            }
        }
        clsTrainers _TrainerAccount;
        clsTrainerTypes _TrainerTypeInfo;
        bool _gbFilterEnabled = true;
        int _TrainerID = -1;
        int _TrainerTypeID = -1;
        public bool FilterEnabled
        {
            get { return _gbFilterEnabled; }
            set
            {
                value = _gbFilterEnabled;
                gbFilters.Enabled = value;
            }
        }
        public int TrainerID
        {
            get { return _TrainerID; }
        }

        public int TrainerTypeID
        {
            get { return _TrainerTypeID; }
        }
        public clsTrainers TrainerInfo
        {
            get { return _TrainerAccount; }
        }
        public clsTrainerTypes TrainerTypeInfo
        {
            get { return _TrainerTypeInfo; }
        }
        public ctrlTrainerDetails()
        {
            InitializeComponent();
        }
        private void FindNow()
        {
            //Way 1 :
            //If the You Load Data = send Data By prameters
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FillTrainerInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "Trainer ID":


                    FillTrainerInfo(int.Parse(txtFilterValue.Text));
                    break;

                case "TrainerType ID":


                    FillTrainerInfo(int.Parse(txtFilterValue.Text));
                    break;




                default:
                    break;
            }
            //Way 2 :
            //Notes:
            // If the User Want To Use THe Control From the Form 


            if (onTrainerTypeSelected != null && FilterEnabled)
                // Raise the event with a parameter
                onTrainerTypeSelected(this.TrainerTypeID);
        }
        void FillTrainerInfo(int ID)
        {

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    {
                        _TrainerAccount = clsTrainers.FindInfoByPersonID(ID);


                        if (_TrainerAccount == null) { 
                            MessageBox.Show("Person ID "+ ID.ToString()+" Not Exist","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
                       // userControl11.LoadPersonInfo(_TrainerAccount.PersonID);
                        _TrainerTypeInfo = clsTrainerTypes.GetFindInfoByTrainerID(_TrainerAccount.TrainerID);
                        if (_TrainerTypeInfo == null)
                            return;
                        break;

                    }
                case "Trainer ID":
                    {
                        _TrainerAccount = clsTrainers.FindInfoByTrainerID(ID);
                        if (_TrainerAccount == null)
                        {
                            MessageBox.Show("Trainer ID " + ID.ToString() + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                       // userControl11.LoadPersonInfo(_TrainerAccount.PersonID);
                        _TrainerTypeInfo = clsTrainerTypes.GetFindInfoByTrainerID(_TrainerAccount.TrainerID);
                        if (_TrainerTypeInfo == null)
                            return;
                        break;
                    }
                case "TrainerType ID":
                    {

                        _TrainerTypeInfo = clsTrainerTypes.GetFindInfoByTrainerTypeID(ID);
                        if (_TrainerTypeInfo == null)
                        {
                            MessageBox.Show("TrainerType ID " + ID.ToString() + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                      

                        _TrainerAccount = clsTrainers.FindInfoByTrainerID(_TrainerTypeInfo.TrainerID);
                        if (_TrainerAccount == null)
                            return;
                        ctrlPersonCard1.LoadPersonInfo(_TrainerAccount.PersonID);

                        //    userControl11.LoadPersonInfo(_TrainerAccount.PersonID);


                        break;
                    }
                default:
                    break;
            }
            lblTrainerID.Text = _TrainerAccount.TrainerID.ToString();
            lblSpeTrainerType.Text = _TrainerAccount.SpecialityTraining;
            //we Need to Display Only the Last Update 
            lblCreationDate.Text = _TrainerTypeInfo.LastUpdateDate.ToString();
            lblTrainerTypeID.Text = _TrainerTypeInfo.TrainerTypeID.ToString();
            lblTrainerMonthFees.Text = _TrainerTypeInfo.MonthTrainingfee.ToString();




        }

        private void btnFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    //that Mean Press ENTER in Key Board
            //    btnFind.PerformClick();
            //}

            ////this will allow only digits if person id is selected
            //if (cbFilterBy.Text == "Trainer ID" || cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "TrainerType ID")
            //    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            frmAddUpdateTrainerAndTrainerType frm = new frmAddUpdateTrainerAndTrainerType();
            frm.ShowDialog();
            frm.DataBack += BackDataEvent;
        }

        private void BackDataEvent(object sender, int TrainerTypeID)
        {
            cbFilterBy.SelectedIndex = 3;
            gbFilters.Enabled = false;
            txtFilterValue.Text = TrainerTypeID.ToString();
            FillTrainerInfo(TrainerTypeID);
        }
        public void LoadAccountInfoTrainerID(int TrainerID)
        {
            gbFilters.Enabled = false;
            cbFilterBy.SelectedIndex = 2;
            txtFilterValue.Text = TrainerID.ToString();
            FillTrainerInfo(TrainerID);
            int TrainerPersonID = clsTrainers.FindInfoByTrainerID(TrainerID).PersonID;
            ctrlPersonCard1.LoadPersonInfo(TrainerPersonID);
        }
        public void LoadAccountInfoByPersonID(int PersonID)
        {
            gbFilters.Enabled = false;
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FillTrainerInfo(PersonID);

        }
        public void LoadAccountInfoTrainerTypeID(int TrainerTypeID)
        {
            gbFilters.Enabled = false;
            cbFilterBy.SelectedIndex = 3;
            txtFilterValue.Text = TrainerID.ToString();
            FillTrainerInfo(TrainerTypeID);
        }

        private void ctrlTrainerDetails_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Focus();
            btnAddNewAccount.Enabled = true;
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //that Mean Press ENTER in Key Board
                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Trainer ID" || cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "TrainerType ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
