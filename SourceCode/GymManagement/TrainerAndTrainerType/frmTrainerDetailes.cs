using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement.TrainerAndTrainerType
{
    public partial class frmTrainerDetailes : Form
    {
        int _TrainerID = -1; 
        int _TrainerType = -1;
        public frmTrainerDetailes()
        {
            InitializeComponent();
        }
        public frmTrainerDetailes(int trainerID)
        {
            InitializeComponent();
            _TrainerID = trainerID;
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTrainerDetailes_Load(object sender, EventArgs e)
        {
            if(_TrainerID != -1)
                ctrlTrainerDetails1.LoadAccountInfoTrainerID(_TrainerID);
        }
    }
}
