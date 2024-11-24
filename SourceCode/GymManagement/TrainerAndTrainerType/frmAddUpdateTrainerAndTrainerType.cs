using BusinessLayer;
using GymManagement.GlobalClasses;
using GymManagement.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement.TrainerAndTrainerType
{
    public partial class frmAddUpdateTrainerAndTrainerType : Form
    {
        public delegate void DataBackEventHandler(object sender, int TrainerTypeID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        int _TrainerID = -1;
        int _TrainerTypeID = -1;
        clsTrainers _TrainerAccount;
        clsTrainerTypes _TrainerTypes;
        clsPerson _Person;
        public enum enMode { AddNew = 1, Update = 2 }
        public enum enGender { Male = 0, Female = 1 }
        private enMode Mode;
        public frmAddUpdateTrainerAndTrainerType(int TrainerID, int TrainerTypeID)
        {
            InitializeComponent();
            _TrainerID = TrainerID;
            _TrainerTypeID = TrainerTypeID;
            Mode = enMode.Update;
        }
        public frmAddUpdateTrainerAndTrainerType()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        private void _FillContriesInComboBox()
        {
            DataTable dtCountries = clsCountries.GetAllCountriesList();
            foreach (DataRow Row in dtCountries.Rows)
            {

                cbCountry.Items.Add(Row["CountryName"]);
            }
        }
        private void _ResetDefaultValue()
        {

            _FillContriesInComboBox();
            if (Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add Trainer ";
                _TrainerAccount = new clsTrainers();
                _TrainerTypes = new clsTrainerTypes();
                _Person = new clsPerson();

            }
            else
            {
                lblTitle.Text = "Update Trainer";
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
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-16);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
         
            cbCountry.SelectedIndex = cbCountry.FindString("Algeria");

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
            lblCreationDate.Text = clsDataFormat.DateToShort(DateTime.Now);



        }
        private void _LoadData()
        {
            _TrainerAccount = clsTrainers.FindInfoByTrainerID(_TrainerID);
            _TrainerTypes = clsTrainerTypes.GetFindInfoByTrainerTypeID(_TrainerTypeID);
            _Person = clsPerson.GetPersonInfoByPersonID(_TrainerAccount.PersonID);
            if ((_TrainerAccount == null && _TrainerTypes == null) || (_TrainerAccount == null || _TrainerTypes == null))
            {
                MessageBox.Show("Trainer Account " + _TrainerID + " Is Not Find ");
                this.Close();
                return;
            }
            lblPersonID.Text = _TrainerAccount._PersonInfo.PersonID.ToString();
            txtFirstName.Text = _TrainerAccount._PersonInfo.FirstName;
            txtLastName.Text = _TrainerAccount._PersonInfo.LastName;
            txtNationalNo.Text = _TrainerAccount._PersonInfo.NationalNO;
            txtEmail.Text = _TrainerAccount._PersonInfo.Email;
            txtAddress.Text = _TrainerAccount._PersonInfo.address;
            txtPhone.Text = _TrainerAccount._PersonInfo.PhoneNumber;
            dtpDateOfBirth.Value = _TrainerAccount._PersonInfo.BirthDay;
            if (_TrainerAccount._PersonInfo.Gender == 0)
                rbMale.Enabled = true;
            else
            {
                rbFemale.Checked = true;

            }
            cbCountry.SelectedIndex = cbCountry.FindString(_TrainerAccount._PersonInfo._CountryInfo.CountryName);
            lblTrainerID.Text = _TrainerAccount.TrainerID.ToString();
            txtSpecialityTrainerType.Text = _TrainerAccount.SpecialityTraining;
            txtTrainerTypeName.Text = _TrainerTypes.TrainerTypeName;
            lblCreationDate.Text = _TrainerTypes.LastUpdateDate.ToShortDateString();
            txtMothTrainerFees.Text = _TrainerTypes.MonthTrainingfee.ToString();
            if (_TrainerAccount._PersonInfo.ImagePath != null)
            {

                pbPersonImage.ImageLocation = _TrainerAccount._PersonInfo.ImagePath;

            }
            llRemoveImage.Visible = (_TrainerAccount._PersonInfo.ImagePath != null);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some filed Are Not Valide ! Put the Mous in the Red Icon(s) to see the error notice ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!_HandlePersonImage())
                return;
            int CountryID = clsCountries.FindCountryInfoByCountryName(cbCountry.Text).CountryID;

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
                _TrainerAccount.PersonID = _Person.PersonID;
                _TrainerAccount.SpecialityTraining = txtSpecialityTrainerType.Text;
                _TrainerAccount.RegistrationDate = DateTime.Now;
                _TrainerAccount.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (_TrainerAccount.Save())
                {
                    _TrainerTypes.TrainerID = _TrainerAccount.TrainerID;
                    _TrainerTypes.TrainerTypeName = txtTrainerTypeName.Text;
                    _TrainerTypes.MonthTrainingfee = decimal.Parse(txtMothTrainerFees.Text);
                    _TrainerTypes.LastUpdateDate = DateTime.Now;
                    _TrainerTypes.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                    if (_TrainerTypes.Save())
                    {
                        if (Mode == enMode.AddNew)
                            MessageBox.Show("Trainer added Succeefully with TrainerID " + _TrainerAccount.TrainerID + " \nAnd Trainer TypeID " + _TrainerTypes.TrainerID
                                    , "Created Done ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Trainer Update Succeefully with TrainerID " + _TrainerAccount.TrainerID + " \nAnd Trainer TypeID " + _TrainerTypes.TrainerID
                                  , "Training Section Updated ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DataBack?.Invoke(this, _TrainerTypes.TrainerTypeID);
                        btnSave.Enabled = false;
                    }
                    else
                        MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
                MessageBox.Show("Error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmAddUpdateTrainerAndTrainerType_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (Mode == enMode.Update)
                _LoadData();
        }
    }
}