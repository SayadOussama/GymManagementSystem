using BusinessLayer;
using GymManagement.GlobalClasses;
using GymManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement.Subscribers
{
    public partial class frmAddNewUpdateSubscriber : Form
    {

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int AccountID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 1, Update = 2 }
        public enum enGender { Male = 0, Female = 1 }
        private enMode Mode;
        int _PersonID = -1;
        clsPerson _Person;
        clsSubscriberAccounts _SubscriberAccount;
        int _AccountID = -1;
        decimal _TrainerFee = 0;
        decimal _SubscribeAmount = 0; 
        public frmAddNewUpdateSubscriber()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public  frmAddNewUpdateSubscriber(int AccountID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _AccountID = AccountID;
        }

        private void _FillContriesInComboBox()
        {
            DataTable dtCountries = clsCountries.GetAllCountriesList();
            foreach (DataRow Row in dtCountries.Rows)
            {

                cbCountry.Items.Add(Row["CountryName"]);
            }
        }

        private void _FillTrainerTypes()
        {
            DataTable dtTrainerTypes = clsTrainerTypes.GetAllTrainerTypesList();
            foreach (DataRow Row in dtTrainerTypes.Rows)
            {

                cbTrainers.Items.Add(Row["TrainerTypeName"]);
            }
        }

        private void _FillSubscriberTypes()
        {
            DataTable dtSubscriberTypes = clsSubscriptions.GetAllSubscribeList();
            foreach (DataRow Row in dtSubscriberTypes.Rows)
            {

                cbSubscribeTypesName.Items.Add(Row["SubscribeName"]);
            }
        }
        private void _ResetDefaultValue()
        {
            _FillSubscriberTypes();
            _FillContriesInComboBox();
            chkTrainerSelected.Checked = false;
            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Subscriber";
                _SubscriberAccount = new clsSubscriberAccounts();
                _Person = new clsPerson();

            }
            else
            {
                lblTitle.Text = "Update Subscriber";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            cbTrainers.Enabled = false;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-16);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            cbCountry.SelectedIndex = cbCountry.FindString("Algeria");
            cbSubscribeTypesName.SelectedIndex = 0;
            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
            lblSubscribeStartDate.Text = clsDataFormat.DateToShort(DateTime.Now);
            lblSubscribEndDate.Text = clsDataFormat.DateToShort(DateTime.Now.AddDays(30));
            rbIsPaid.Checked = true;


        }

        private void cbTrainers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chkTrainerSelected.Checked == false)
                cbTrainers.Visible = false;
            else 
                cbTrainers.Visible = true;
            
            
            //if the User Change the Combo Box 

           _TrainerFee =  clsTrainerTypes.GetFindInfoByTrainerTypeName(cbTrainers.Text.ToString()).MonthTrainingfee;
            lblTotalAmount.Text = (_SubscribeAmount + _TrainerFee).ToString();
        }

        private void _LoadData()
        {
            _SubscriberAccount = clsSubscriberAccounts.GetAccountInfoByAccountID(_AccountID);
            if (_SubscriberAccount == null)
            {
                MessageBox.Show("the Account ID you Choosing " + _AccountID + " Is Not Find ");
                this.Close();
                return;
            }
            txtFirstName.Text = _SubscriberAccount.PersonInfo.FirstName;
            txtLastName.Text = _SubscriberAccount.PersonInfo.LastName;
            txtNationalNo.Text = _SubscriberAccount.PersonInfo.NationalNO;
            txtEmail.Text = _SubscriberAccount.PersonInfo.Email;
            txtAddress.Text = _SubscriberAccount.PersonInfo.address;
            txtPhone.Text = _SubscriberAccount.PersonInfo.PhoneNumber;
            dtpDateOfBirth.Value = _SubscriberAccount.PersonInfo.BirthDay;
            if (_SubscriberAccount.PersonInfo.Gender == 0)
                rbMale.Enabled = true;
            else { 
                rbFemale.Checked = true;
                
            }
            cbCountry.SelectedIndex = cbCountry.FindString(_SubscriberAccount.PersonInfo._CountryInfo.CountryName);

            if (_SubscriberAccount.PersonInfo.ImagePath != null)
            {
                pbPersonImage.ImageLocation = _SubscriberAccount.PersonInfo.ImagePath;
            }
            llRemoveImage.Visible = (_SubscriberAccount.PersonInfo.ImagePath != null);

            lblAccountID.Text = _SubscriberAccount.AccountID.ToString();
            lblSubscribeStartDate.Text = _SubscriberAccount.CreationDate.ToShortDateString();
            lblSubscribEndDate.Text = _SubscriberAccount.EndDateSubscriber.ToShortDateString();
            if (_SubscriberAccount.TrainerTypeID != -1)
            {
                chkTrainerSelected.Checked = true;
                cbTrainers.SelectedIndex = cbTrainers.FindString(_SubscriberAccount.TrainerTypeInfo.TrainerTypeName);
                _TrainerFee = _SubscriberAccount.TrainerTypeInfo.MonthTrainingfee;
            }
            if (_SubscriberAccount.IsPaid)
                rbIsPaid.Checked = true;
            else
            { 
            rbIsPaid.Checked = false;
            rbNotPaid.Checked = true;
            }
            
            cbSubscribeTypesName.SelectedIndex = cbSubscribeTypesName.FindString(_SubscriberAccount.SubscriptionsInfo.SubscribeName);

            _SubscribeAmount = _SubscriberAccount.SubscriptionsInfo.SubscribeFee;

            //if(_SubscriberAccount.TrainerTypeID != -1 )
            //{ 
            // _TrainerFee = _SubscriberAccount.TrainerTypeInfo.MonthTrainingfee;
            // chkTrainerSelected.Checked = true;
            //}
            if (_TrainerFee <= 0)
                _TrainerFee = 0;

            lblTotalAmount.Text = (_SubscribeAmount + _TrainerFee).ToString();


        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to female incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to female incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //if txt is Empty
            if (txtEmail.Text.Trim() == "")
                return;

            //get validation 
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "this field is required!");
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
            //Make Sure NationalNo Not Use it 
            //if we are in Update Mode               if we are in add  New Mode will Check is have person with National No
            if (txtNationalNo.Text.Trim() != _Person.NationalNO && clsPerson.IsPersonExistByNationalNo(txtNationalNo.Text.Trim()))

            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National No Is Allready Exist ");
            }
            else
            {

                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void rbSelectTrainer_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                //Delete Process
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        //Colud Not  the File  Delete
                    }
                }
                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();
                    //will Change ImageLcationName to GUID and copy to Directory 
                    if (Util.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        //replace the current image name = to new Name with Guid 
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;

                    }
                    else
                    {
                        MessageBox.Show("Error Copy Image File ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }




            }
            // if image source  == Image Path or Is Null
            return true;
        }

        private void frmAddNewUpdateSubscriber_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some filed Are Not Valide ! Put the Mous in the Red Icon(s) to see the error notice ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!_HandlePersonImage())
                return;
             int CountryID= clsCountries.FindCountryInfoByCountryName(cbCountry.Text).CountryID;
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNO = txtNationalNo.Text.Trim();
            _Person.PhoneNumber = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.address = txtAddress.Text.Trim();
            _Person.BirthDay = dtpDateOfBirth.Value;
            if (rbMale.Checked)
                _Person.Gender = (byte)enGender.Male;
            else
                _Person.Gender = (byte)enGender.Female;
            _Person.NationalCountryID = CountryID;
            if (_Person.Save())
            {

                    _SubscriberAccount.PersonID= _Person.PersonID;
                   
                if (chkTrainerSelected.Checked) { 
                    _SubscriberAccount.TrainerTypeID = cbTrainers.SelectedIndex + 1;
                    _TrainerFee = clsTrainerTypes.GetTrainingAmount(_SubscriberAccount.TrainerTypeID);
                    
                }
                else
                { 
                    _SubscriberAccount.TrainerTypeID = -1;
                    _TrainerFee = 0;

                }
                _SubscriberAccount.SubscribeID = cbSubscribeTypesName.SelectedIndex + 1;
                _SubscribeAmount = clsSubscriptions.GetSubscribeAmountByID(cbSubscribeTypesName.SelectedIndex + 1);

                _SubscriberAccount.SubscribeMonthAmount = _SubscribeAmount + _TrainerFee; 
           


                //you Shouldn't You change the Date Of Subscribe Account in Update Mode 

                if (Mode == enMode.AddNew) {
                _SubscriberAccount.CreationDate = DateTime.Now;
                _SubscriberAccount.EndDateSubscriber = DateTime.Now.AddDays(30);
                }

                //Note 
                //
                //in the Update Mode YOu Can Update Payment Status and Trainer Type and Subscruber Method
                //
                if (rbIsPaid.Checked)
                _SubscriberAccount.IsPaid = true;
                else
                _SubscriberAccount.IsPaid = false;
                _SubscriberAccount.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (Mode == enMode.AddNew)
                {
                    if (_SubscriberAccount.Save())
                        MessageBox.Show("New Subscriber Account Add Successfuly with SubscriberID " + _SubscriberAccount.AccountID, "Add New Subscriber", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblAccountID.Text = _SubscriberAccount.AccountID.ToString();
                    lblPersonID.Text = _SubscriberAccount.PersonID.ToString();

                }
                else
                {
                    if (_SubscriberAccount.Save())
                        MessageBox.Show("Update Subscriber Account Done Successfuly with SubscriberID " + _SubscriberAccount.AccountID, "Update Subscriber", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

             
            }

            btnSave.Enabled = false;
        }

        private void chkTrainerSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrainerSelected.Checked == true) {
                _FillTrainerTypes();
               cbTrainers.Enabled = true;
                cbTrainers.SelectedItem = 1;
                ////if the User Check and encheck the chkbox
                                                         //by Default 1ID 
                _TrainerFee = clsTrainerTypes.GetFindInfoByTrainerTypeID(1).MonthTrainingfee;
                lblTotalAmount.Text = (_SubscribeAmount + _TrainerFee).ToString();
            }
            else
            {
                cbTrainers.Text = "None";
                cbTrainers.Enabled = false;
                
                _TrainerFee = 0;
                lblTotalAmount.Text =  (_SubscribeAmount + _TrainerFee).ToString();


            }
        }

        private void cbSubscribeTypesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Mode == enMode.AddNew) 
           _SubscribeAmount =  clsSubscriptions.FindSubscriptionInfoByID(cbSubscribeTypesName.SelectedIndex+1).SubscribeFee;
            lblTotalAmount.Text = (_SubscribeAmount + _TrainerFee).ToString()  ;
        }
    }
    }



