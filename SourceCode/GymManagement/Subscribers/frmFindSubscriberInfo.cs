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
    public partial class frmFindSubscriberInfo : Form
    {
        int _AccountID = -1;
        public frmFindSubscriberInfo()
        {
            InitializeComponent();
        }
        public frmFindSubscriberInfo(int AccountID)
        {
            InitializeComponent();
            _AccountID = AccountID;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void frmFindSubscriberInfo_Load(object sender, EventArgs e)
        {
            if (_AccountID != -1)
            {

                ctrlFindSubscriber1.LoadAccountInfoAccountID(_AccountID);

            }
        }
    }
}
