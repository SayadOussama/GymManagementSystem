using BusinessLayer;
using GymManagement.TrainerAndTrainerType;
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
    public partial class frmSubscriptionManagement : Form
    {
        private static DataTable _dtAllTrainers;
        public frmSubscriptionManagement()
        {
            InitializeComponent();
        }

        private void frmSubscriptionManagement_Load(object sender, EventArgs e)
        {
            _dtAllTrainers = clsSubscriptions.GetAllSubscribeList();
            dgvTrainers.DataSource = _dtAllTrainers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvTrainers.Rows.Count.ToString();

            if (dgvTrainers.Rows.Count > 0)
            {
                dgvTrainers.Columns[0].HeaderText = "Trainer ID";
                dgvTrainers.Columns[0].Width = 50;

                dgvTrainers.Columns[1].HeaderText = "Subscribe Name";
                dgvTrainers.Columns[1].Width = 200;

                dgvTrainers.Columns[2].HeaderText = "Subscribe fee";
                dgvTrainers.Columns[2].Width = 200;

                dgvTrainers.Columns[3].HeaderText = "Created by User ";
                dgvTrainers.Columns[3].Width = 200;



            }
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

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {



                case "Subscribe ID":
                    FilterColumn = "SubscribeID";
                    break;
                case "Subscribe Name":
                    FilterColumn = "SubscribeName";
                    break;
            
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllTrainers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAllTrainers.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "SubscribeID")
                //in this case we deal with string not number.

                _dtAllTrainers.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllTrainers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllTrainers.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Subscribe ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnAddSubscription_Click(object sender, EventArgs e)
        {
            frmAddUpdateSubscription frm =new frmAddUpdateSubscription();
            frm.ShowDialog();
            frmSubscriptionManagement_Load(null, null);

        }

        private void subscribptionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SubscripeID = (int)dgvTrainers.CurrentRow.Cells[0].Value;
            frmSubscrptionDetails frm =new frmSubscrptionDetails();
            frm.LoadSubscriptionInfo(SubscripeID);
            frm.ShowDialog();

        }

        private void addNewSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateSubscription frm = new frmAddUpdateSubscription();
            frm.ShowDialog();
            frmSubscriptionManagement_Load(null, null);
        }

        private void updateSubcriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SubscripeID = (int)dgvTrainers.CurrentRow.Cells[0].Value;
            clsSubscriptions SubscriptionInfo = clsSubscriptions.FindSubscriptionInfoByID(SubscripeID);
            if (SubscriptionInfo != null)
            {
                frmAddUpdateSubscription frm = new frmAddUpdateSubscription(SubscripeID);
                frm.ShowDialog();
                frmSubscriptionManagement_Load(null, null);

            }
            else
                MessageBox.Show("Trainer Account with ID " + SubscripeID.ToString() + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
