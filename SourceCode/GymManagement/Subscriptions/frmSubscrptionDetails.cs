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

namespace GymManagement.Subscriptions
{
    public partial class frmSubscrptionDetails : Form
    {
        public frmSubscrptionDetails()
        {
            InitializeComponent();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
       
            
        }

        private void frmSubscrptionDetails_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtSubscribeFee.Enabled = false;
            txtSubscribeName.Enabled = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            clsSubscriptions _SubscriptionInfo = clsSubscriptions.FindSubscriptionInfoByID(int.Parse(txtFilterValue.Text));
            if (_SubscriptionInfo != null)
            {
                lblSubscribeID.Text = _SubscriptionInfo.SubscribeID.ToString();
                txtSubscribeName.Text = _SubscriptionInfo.SubscribeName.ToString();
                txtSubscribeFee.Text = _SubscriptionInfo.SubscribeFee.ToString();
            }
            else 
                MessageBox.Show("Subscription with ID "+ txtFilterValue.Text + "Not Exist ", "Not Exist", MessageBoxButtons.OK , MessageBoxIcon.Error);

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");
            if (cbFilterBy.Text == "None")
            {
                txtFilterValue.Enabled = false;
            }
            else
                txtFilterValue.Enabled = true;
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                //that Mean Press ENTER in Key Board
                btnFind.PerformClick();
            }
            if (cbFilterBy.Text == "Subscribe ID" )
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        public void LoadSubscriptionInfo(int subscriptionID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Enabled = true;
            int SubscriptionID = 0;
            SubscriptionID = subscriptionID;
            if (SubscriptionID != 0)
            {
               
                txtFilterValue.Text = subscriptionID.ToString();
                gbFilter.Enabled = false;
                clsSubscriptions _SubscriptionInfo = clsSubscriptions.FindSubscriptionInfoByID(SubscriptionID);
                if (_SubscriptionInfo != null)
                {
                    lblSubscribeID.Text = _SubscriptionInfo.SubscribeID.ToString();
                    txtSubscribeName.Text = _SubscriptionInfo.SubscribeName.ToString();
                    txtSubscribeFee.Text = _SubscriptionInfo.SubscribeFee.ToString();
                }
                else
                    MessageBox.Show("Subscription with ID " + txtFilterValue.Text + "Not Exist ", "Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnFind.Enabled= false;
            }
        }
    }
}
