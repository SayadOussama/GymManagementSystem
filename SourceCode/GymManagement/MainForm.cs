using BusinessLayer;
using GymManagement.GlobalClasses;
using GymManagement.Login;
using GymManagement.SalaryHistroy;
using GymManagement.Subscribers;
using GymManagement.Subscriptions;
using GymManagement.TrainerAndTrainerType;
using GymManagement.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class Main : Form
    {
        frmLogin _LogFrom;
        public Main(frmLogin frm)
        {
            InitializeComponent();
            _LogFrom = frm;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _LogFrom.Show();
            this.Close();
           
            
        }

        private void addNewSubscriberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUpdateSubscriber frm = new frmAddNewUpdateSubscriber();
            frm.ShowDialog();
        }

        private void findSubscriberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindSubscriberInfo frm = new frmFindSubscriberInfo();
            frm.ShowDialog();
        }

        private void subscriberManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //THIS function will Desactivate all Subscribers account which end the Month of Subscription 
            clsSubscriberAccounts.GetAutoSubscribersDesiactive();
            ////////////////////////////////////////////////////////////////////////////

            FrmSubscriberManagement frm = new FrmSubscriberManagement();
            frm.ShowDialog();   
        }

        private void addNewTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateTrainerAndTrainerType frm = new frmAddUpdateTrainerAndTrainerType();
            frm.ShowDialog();
        }

        private void findTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrainerDetailes frm = new frmTrainerDetailes();
            frm.ShowDialog();
        }

        private void trainerManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrainerManagmentSection frm = new frmTrainerManagmentSection();
            frm.ShowDialog();
        }

   
        private void subscribersWithTrainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubscribersWithTrainer frm = new frmSubscribersWithTrainer();
            frm.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void addNewSubscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmAddUpdateSubscription frm = new frmAddUpdateSubscription();
            frm.ShowDialog();
        }

        private void subscriptionInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubscrptionDetails frm = new frmSubscrptionDetails();
            frm.ShowDialog();
        }

        private void subscriptionManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubscriptionManagement frm = new frmSubscriptionManagement();
            frm.ShowDialog();
        }

        private void salaryHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void salaryHistoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalary History = new frmSalary();
            History.Show();
        }

        private void historyOfSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void addNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmUserManagement frm = new frmUserManagement();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateAndTime.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
            lblDateAndTime.Refresh();
        }

   

        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDateAndTime.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
            lblCurrentUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void Main_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
            lblDateAndTime.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
            lblCurrentUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void Main_Load_2(object sender, EventArgs e)
        {
            timer1.Start();
            lblDateAndTime.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
            lblCurrentUser.Text = clsGlobal.CurrentUser.UserName;
        }
    }
}
