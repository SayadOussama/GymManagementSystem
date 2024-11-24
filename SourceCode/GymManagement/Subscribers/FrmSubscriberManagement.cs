﻿using BusinessLayer;
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

namespace GymManagement.Subscribers
{
    public partial class FrmSubscriberManagement : Form
    {
        private static DataTable _dtAllSubscriber;

        public FrmSubscriberManagement()
        {
            InitializeComponent();
        }

        private void FrmSubscriberManagement_Load(object sender, EventArgs e)
        {
            _dtAllSubscriber = clsSubscriberAccounts.GetAllAccountIDList();
            dgvSubscribers.DataSource = _dtAllSubscriber;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvSubscribers.Rows.Count.ToString();

            if(dgvSubscribers.Rows.Count > 0 )
            {
                dgvSubscribers.Columns[0].HeaderText = "Account ID";
                dgvSubscribers.Columns[0].Width = 50;

                dgvSubscribers.Columns[1].HeaderText = "Full Name";
                dgvSubscribers.Columns[1].Width = 200;

                dgvSubscribers.Columns[2].HeaderText = "Gender";
                dgvSubscribers.Columns[2].Width = 50;

                dgvSubscribers.Columns[3].HeaderText = "Subscriber Type";
                dgvSubscribers.Columns[3].Width = 150;


                dgvSubscribers.Columns[4].HeaderText = "Subscriber Amount";
                dgvSubscribers.Columns[4].Width = 150;

                dgvSubscribers.Columns[5].HeaderText = "Creation Date";
                dgvSubscribers.Columns[5].Width = 150;

                dgvSubscribers.Columns[6].HeaderText = "End Subscriber Date";
                dgvSubscribers.Columns[6].Width = 150;

                dgvSubscribers.Columns[7].HeaderText = "Is Paid";
                dgvSubscribers.Columns[7].Width = 80;

                dgvSubscribers.Columns[8].HeaderText = "Created By User";
                dgvSubscribers.Columns[8].Width = 100;

            }




        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "Is Paid")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;


            }
            if (cbFilterBy.Text == "Gender")
            {
                txtFilterValue.Visible = false;
                cbGender.Visible = true;
                cbGender.Focus();
                cbGender.SelectedIndex = 0;


            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;
                cbGender.Visible= false;
                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false; 
                }
                else 
                    txtFilterValue.Enabled = true;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }



        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Account ID":
                    FilterColumn = "AccountID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Is Paid":
                    FilterColumn = "IsPaid";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllSubscriber.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAllSubscriber.Rows.Count.ToString();
                return;
            }
            if (FilterColumn != "FullName")
                //in this case we deal with numbers not string.
                _dtAllSubscriber.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllSubscriber.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllSubscriber.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ValueSelected = cbIsActive.Text;
            string FilterColumn = "IsPaid";
            switch (ValueSelected)
            {
                case "All":
                    break;
                case "Yes":
                    ValueSelected = "1";
                    break;
                case "No":
                    ValueSelected = "0";
                    break;
            }

            if (ValueSelected == "All")
                _dtAllSubscriber.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllSubscriber.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, ValueSelected);

            lblRecordsCount.Text = _dtAllSubscriber.Rows.Count.ToString();

        }

        private void subscriberInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AccountID = (int)dgvSubscribers.CurrentRow.Cells[0].Value;
            clsSubscriberAccounts Subscriber = clsSubscriberAccounts.GetAccountInfoByAccountID(AccountID);
            if (Subscriber != null )
            {
                frmFindSubscriberInfo frm = new frmFindSubscriberInfo(AccountID);
                frm.ShowDialog();

            }
            else
                MessageBox.Show("Account with ID " + AccountID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void renewSubscriberAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AccountID = (int)dgvSubscribers.CurrentRow.Cells[0].Value;
            clsSubscriberAccounts Subscriber = clsSubscriberAccounts.GetAccountInfoByAccountID(AccountID);
            if (Subscriber != null )
            {
                if (Subscriber.EndDateSubscriber <= DateTime.Now)
                {
                    Subscriber.CreationDate = DateTime.Now;
                    Subscriber.EndDateSubscriber = DateTime.Now.AddDays(30);
                    Subscriber.IsPaid = true;
                    Subscriber.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                    if (Subscriber.Save())
                    {
                        MessageBox.Show("Renew Account Successfully Subscriber with ID " + AccountID + "\nNewCreation Date : "+ Subscriber.CreationDate.ToShortDateString()
                            +" And Expiration Date : "+Subscriber.EndDateSubscriber.ToShortDateString(), "Renew Account ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmSubscriberManagement_Load(null, null);
                    }
                    else
                        MessageBox.Show("Have Problem Issue ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Account with ID " + AccountID + " not Attend the Expiration Date Yet \n the Expiration Date is : "+Subscriber.EndDateSubscriber.ToShortDateString(), "Account Not Attend the Expairation Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Account with ID " + AccountID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void updateSubscriberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AccountID = (int)dgvSubscribers.CurrentRow.Cells[0].Value;
            clsSubscriberAccounts Subscriber = clsSubscriberAccounts.GetAccountInfoByAccountID(AccountID);
            if (Subscriber != null)
            {
                frmAddNewUpdateSubscriber frm = new frmAddNewUpdateSubscriber(AccountID);
                frm.ShowDialog();
                FrmSubscriberManagement_Load(null, null);
            }
            else
                MessageBox.Show("Account with ID " + AccountID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Account ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteSubscriberAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AccountID = (int)dgvSubscribers.CurrentRow.Cells[0].Value;
            clsSubscriberAccounts Subscriber = clsSubscriberAccounts.GetAccountInfoByAccountID(AccountID);
            if (Subscriber != null)
            {
                if (Subscriber.DeleteSubscriberAccount())
                {
                    if (Subscriber.PersonInfo.DeletePersonByPersonID()) { 
                    MessageBox.Show("Account With ID " + AccountID + " Delete Successfuly ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmSubscriberManagement_Load(null, null);
                    }
                    else
                        MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                    MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Account with ID " + AccountID + " Not Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddSubscriber_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateSubscriber frm = new frmAddNewUpdateSubscriber();
            frm.ShowDialog();
            FrmSubscriberManagement_Load(null, null);
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ValueSelected = cbGender.Text;
            string FilterColumn = "Gender";
            switch (ValueSelected)
            {
                case "All":
                    break;
                case "Male":
                    ValueSelected = "Male";
                    break;
                case "Female":
                    ValueSelected = "Female";
                    break;
            }

            if (ValueSelected == "All")
                _dtAllSubscriber.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllSubscriber.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, ValueSelected);

            lblRecordsCount.Text = _dtAllSubscriber.Rows.Count.ToString();
        }
    }
}
