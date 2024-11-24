using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement.TrainerAndTrainerType
{
    public partial class frmTrainerManagmentSection : Form
    {

        private static DataTable _dtAllTrainers;
        public frmTrainerManagmentSection()
        {
            InitializeComponent();
        }

        private void frmTrainerManagmentSection_Load(object sender, EventArgs e)
        {
            _dtAllTrainers = clsTrainers.GetAllTrainerIDList();
            dgvTrainers.DataSource = _dtAllTrainers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvTrainers.Rows.Count.ToString();

            if (dgvTrainers.Rows.Count > 0)
            {
                dgvTrainers.Columns[0].HeaderText = "Trainer ID";
                dgvTrainers.Columns[0].Width = 50;

                dgvTrainers.Columns[1].HeaderText = "Trainer Name";
                dgvTrainers.Columns[1].Width = 200;

                dgvTrainers.Columns[2].HeaderText = "Speciality Training";
                dgvTrainers.Columns[2].Width = 200;

                dgvTrainers.Columns[3].HeaderText = "Training Type Name";
                dgvTrainers.Columns[3].Width = 200;


                dgvTrainers.Columns[4].HeaderText = "Month Training Fees";
                dgvTrainers.Columns[4].Width = 150;

                dgvTrainers.Columns[5].HeaderText = "Last Update Date";
                dgvTrainers.Columns[5].Width = 150;

                dgvTrainers.Columns[6].HeaderText = "Created By User";
                dgvTrainers.Columns[6].Width = 150;

               

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
               


                case "Trainer ID":
                    FilterColumn = "TrainerID";
                    break;
                case "Trainer Name":
                    FilterColumn = "TrainerName";
                    break;
                case "Speciality Training":
                    FilterColumn = "SpecialityTraining";
                    break;
                case "TrainerType Name":
                    FilterColumn = "TrainerTypeName";
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
            if (FilterColumn == "TrainerID")
                //in this case we deal with string not number.
                
            _dtAllTrainers.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllTrainers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllTrainers.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Trainer ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddSubscriber_Click(object sender, EventArgs e)
        {
            frmAddUpdateTrainerAndTrainerType frm = new frmAddUpdateTrainerAndTrainerType();
            frm.ShowDialog();
        }

        private void trainerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TrainerID = (int)dgvTrainers.CurrentRow.Cells[0].Value;
            clsTrainers TrainerInfo = clsTrainers.FindInfoByTrainerID(TrainerID);
            if (TrainerInfo != null)
            {
                frmTrainerDetailes frm = new frmTrainerDetailes(TrainerID);
                frm.ShowDialog();
                

            }
            else
                MessageBox.Show("Trainer Account with ID " + TrainerID.ToString() + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void updateTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TrainerID = (int)dgvTrainers.CurrentRow.Cells[0].Value;
            clsTrainers TrainerInfo = clsTrainers.FindInfoByTrainerID(TrainerID);
            if (TrainerInfo != null)
            {
                clsTrainerTypes TrainerSpecility = clsTrainerTypes.GetFindInfoByTrainerTypeID(TrainerID);
                frmAddUpdateTrainerAndTrainerType frm = new frmAddUpdateTrainerAndTrainerType(TrainerID, TrainerSpecility.TrainerTypeID);
                frm.ShowDialog();
                frmTrainerManagmentSection_Load(null, null);

            }
            else
                MessageBox.Show("Trainer Account with ID " + TrainerID.ToString() + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
