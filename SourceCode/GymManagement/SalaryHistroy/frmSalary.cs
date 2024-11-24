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

namespace GymManagement.SalaryHistroy
{
    public partial class frmSalary : Form
    {
        private static DataTable _dtSubscribersHistroyList;
        public frmSalary()
        {
            InitializeComponent();
        }

        private void frmSalary_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;

           
              
            
        }
        private void btnSlected_Click(object sender, EventArgs e)
        {
            _dtSubscribersHistroyList = clsSubscriberAccounts.GetHistorySalarySubsribersList(dateTimePicker1.Value);

            dgvSHistory.DataSource = _dtSubscribersHistroyList;
            lblRecordsCount.Text = dgvSHistory.Rows.Count.ToString();
            if (dgvSHistory.Rows.Count > 0)
            {
                dgvSHistory.Columns[0].HeaderText = "Account ID";
                dgvSHistory.Columns[0].Width = 50;

                dgvSHistory.Columns[1].HeaderText = "Full Name";
                dgvSHistory.Columns[1].Width = 180;


                dgvSHistory.Columns[2].HeaderText = "Subscriber Amount";
                dgvSHistory.Columns[2].Width = 100;

                dgvSHistory.Columns[3].HeaderText = "Creation Date";
                dgvSHistory.Columns[3].Width = 200;

                dgvSHistory.Columns[4].HeaderText = "End Subscriber Date";
                dgvSHistory.Columns[4].Width = 200;

                dgvSHistory.Columns[5].HeaderText = "Is Paid";
                dgvSHistory.Columns[5].Width = 100;

                dgvSHistory.Columns[6].HeaderText = "Created By User";
                dgvSHistory.Columns[6].Width = 100;

                decimal Total = clsSubscriberAccounts.GetTotalSubscribersHistoryAmount(dateTimePicker1.Value);
                txtTotal.Text = Total.ToString();
                txtTotal.Enabled = false;
            }
            else
            {
                MessageBox.Show("Subscribers Since Date " + dateTimePicker1.Value.ToShortDateString() + " Not Fount ", "Not Found ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
