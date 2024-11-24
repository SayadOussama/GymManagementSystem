using BusinessLayer;
using GymManagement.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement.Subscriptions
{
    public partial class frmAddUpdateSubscription : Form
    {
         public enum enMode { AddNew= 1 , Update = 2 };
        public enMode Mode = enMode.AddNew ;
        clsSubscriptions _Subscription;
        int _SubscribeID = -1;
        public frmAddUpdateSubscription(int SubscribeID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _SubscribeID = SubscribeID;
        }
        public frmAddUpdateSubscription()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        void SetDefaultValue()
        {

            _Subscription = new clsSubscriptions();
            if (Mode == enMode.AddNew)
                lblTitle.Text = "Add New Subscription";
            else
                lblTitle.Text = "Update Subscription";

            txtSubscribeName.Text = "";
            txtSubscribeFee.Text = "";

        }
        void LoadData()
        {
            clsSubscriptions _Subscription = clsSubscriptions.FindSubscriptionInfoByID(_SubscribeID);
            if(_Subscription != null )
            {
                lblSubscribeID.Text = _Subscription.SubscribeID.ToString();
                txtSubscribeName.Text = _Subscription.SubscribeName.ToString();
                txtSubscribeFee.Text = _Subscription.SubscribeFee.ToString();
            
            }
            else 
                MessageBox.Show("Subcription Info Not Exist ", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmAddUpdateSubscription_Load(object sender, EventArgs e)
        {
            SetDefaultValue();
            if (Mode != enMode.AddNew)
                LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some filed Are Not Valide ! Put the Mous in the Red Icon(s) to see the error notice ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _Subscription.SubscribeName = txtSubscribeName.Text;
            _Subscription.SubscribeFee  = decimal.Parse(txtSubscribeFee.Text);
            _Subscription.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if (_Subscription.Save())
            {
                lblSubscribeID.Text = _Subscription.SubscribeID.ToString();
                MessageBox.Show("Subscribe Created Successfuly " + _Subscription.SubscribeID.ToString(), "Save ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }


        }

        private void txtValidateEmpty(object sender, CancelEventArgs e)
        {
            //will appling for all Text box we Have in this from 
            TextBox Temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtSubscribeFee_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txtSubscribeFee_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
