using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class clsTrainers
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int TrainerID {  get; set; }
        public int PersonID { get; set; }
        public string SpecialityTraining { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int CreatedByUserID { get; set; }

        public clsPerson  _PersonInfo;

        public clsTrainers() 
        {
         this.TrainerID = -1;
         this.PersonID = -1;
         this.SpecialityTraining = "";
         this.RegistrationDate = DateTime.MinValue;
         this.CreatedByUserID = -1;
         Mode = enMode.AddNew;    
        
        }
        private clsTrainers(int TrainerID , int PersonID , string SepcialityTraining  ,DateTime RegistrationDate,int CreatedByUserID)
        {
            this.TrainerID=TrainerID;
            this.PersonID=PersonID;
            this.SpecialityTraining= SepcialityTraining;
            this.RegistrationDate = RegistrationDate;
            this.CreatedByUserID = CreatedByUserID;
            _PersonInfo = clsPerson.GetPersonInfoByPersonID(this.PersonID);
            Mode =enMode.Update;


        }
        public static clsTrainers FindInfoByTrainerID(int TrainerID)
        {
            int PersonID = -1; string SpecialityTraining = ""; DateTime RegistraingDate = DateTime.MinValue; int CreatedByUserID = -1;
            bool IsFound = clsDateTrainers.FindTrainerInfoByTrainerID
           (TrainerID, ref PersonID, ref SpecialityTraining, ref RegistraingDate, ref CreatedByUserID
           );
            if (IsFound)
                return new clsTrainers(TrainerID, PersonID, SpecialityTraining, RegistraingDate, CreatedByUserID);
            else
                return null;
        }
        public static clsTrainers FindInfoByPersonID(int PersonID)
        {
            int TrainerID = -1; string SpecialityTraining = ""; DateTime RegistraingDate = DateTime.MinValue; int CreatedByUserID = -1;
            bool IsFound = clsDateTrainers.FindTrainerInfoByTrainerID
           (TrainerID, ref PersonID, ref SpecialityTraining, ref RegistraingDate, ref CreatedByUserID
           );
            if (IsFound)
                return new clsTrainers(TrainerID, PersonID, SpecialityTraining, RegistraingDate, CreatedByUserID);
            else
                return null;
        }
        private bool _AddNewTrainer()
        {

            this.TrainerID = clsDateTrainers.AddNewTrainer
            (this.PersonID, this.SpecialityTraining, this.RegistrationDate, this.CreatedByUserID);

            return (this.TrainerID != -1);
        }
        private bool _UpdateAddNewInfoBy()
        {

            return clsDateTrainers.UpdateTrainerByTrainerID
            (this.TrainerID, this.PersonID, this.SpecialityTraining, this.RegistrationDate, this.CreatedByUserID);

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTrainer())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateAddNewInfoBy();

            }

            return false;
        }
        public static bool DeleteTrainerID(int TrainerID)
        {

            return clsDateTrainers.DeleteTrainerByID(TrainerID);
        }
        public static bool IsExistTrainerID(int TrainerID)
        {

            return clsDateTrainers.IsExistTrainerByID(TrainerID);
        }
        public static DataTable GetAllTrainerIDList()
        {

            return clsDateTrainers.GetAllTrainersList();
        }
    }
}
