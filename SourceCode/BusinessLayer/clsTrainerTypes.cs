using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class clsTrainerTypes
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int TrainerTypeID {  get; set; }
        public int TrainerID { get; set; }
        public string TrainerTypeName { get; set; }
        public decimal MonthTrainingfee { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int CreatedByUserID { get; set; }


        public clsTrainers _TrainerInfo; 
        public clsTrainerTypes()
        {
            this.TrainerTypeID = -1; 
            this.TrainerID = -1;
            this.TrainerTypeName = "";
            this.MonthTrainingfee = -1;
            this.LastUpdateDate = DateTime.MinValue;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;


        }
        private clsTrainerTypes(int TrainerTypeID , int TrainerID , string TrainerTypeName ,  decimal MonthTrainingfee, DateTime LastUpdateDate , int CreatedByUserID) 
        {
            this.TrainerTypeID = TrainerTypeID;
            this.TrainerID = TrainerID;
            this.TrainerTypeName = TrainerTypeName;
            this.MonthTrainingfee = MonthTrainingfee;
            this.LastUpdateDate = LastUpdateDate;
            this.CreatedByUserID = CreatedByUserID;
            _TrainerInfo = clsTrainers.FindInfoByTrainerID(TrainerID);
            Mode =enMode.Update;
            
        
        
        }



        public static clsTrainerTypes GetFindInfoByTrainerTypeID(int TrainerTypeID)
        {
            int TrainerID = -1; string TrainerTypeName = ""; decimal MonthTrainingFee = -1; DateTime LastUpdateDate = DateTime.MinValue; int CreatedByUserID = -1;
            bool IsFound = clsDataTrainerTypes.FindTrainerTypeByID
           (TrainerTypeID, ref TrainerID, ref TrainerTypeName, ref MonthTrainingFee, ref LastUpdateDate, ref CreatedByUserID
           );
            if (IsFound)
                return new clsTrainerTypes(TrainerTypeID, TrainerID, TrainerTypeName, MonthTrainingFee, LastUpdateDate, CreatedByUserID);
            else
                return null;
        }


        public static clsTrainerTypes GetFindInfoByTrainerTypeName(string TrainerTypeName)
        {
            int TrainerTypeID = -1; int TrainerID = -1; decimal MonthTrainingFee = -1; DateTime LastUpdateDate = DateTime.MinValue; int CreatedByUserID = -1;
            bool IsFound = clsDataTrainerTypes.FindTrainerTypeInfoByTrainerTypeName
           (ref TrainerTypeID, ref TrainerID, TrainerTypeName, ref MonthTrainingFee, ref LastUpdateDate, ref CreatedByUserID
           );
            if (IsFound)
                return new clsTrainerTypes(TrainerTypeID, TrainerID, TrainerTypeName, MonthTrainingFee, LastUpdateDate, CreatedByUserID);
            else
                return null;
        }

        public static clsTrainerTypes GetFindInfoByTrainerID(int TrainerID)
        {
            int TrainerTypeID = -1; string TrainerTypeName = ""; decimal MonthTrainingFee = -1; DateTime LastUpdateDate = DateTime.MinValue; int CreatedByUserID = -1;
            bool IsFound = clsDataTrainerTypes.FindTrainerTypeInfoByTrainerID
           (ref TrainerTypeID,  TrainerID, ref TrainerTypeName, ref MonthTrainingFee, ref LastUpdateDate, ref CreatedByUserID
           );
            if (IsFound)
                return new clsTrainerTypes(TrainerTypeID, TrainerID, TrainerTypeName, MonthTrainingFee, LastUpdateDate, CreatedByUserID);
            else
                return null;
        }
        private bool _AddNewTrainerType()
        {

            this.TrainerTypeID = clsDataTrainerTypes.AddNewTrainerType
            (this.TrainerID, this.TrainerTypeName, this.MonthTrainingfee, this.LastUpdateDate, this.CreatedByUserID);

            return (this.TrainerTypeID != -1);
        }

        private bool _UpdateTrainerTypeID()
        {

            return clsDataTrainerTypes.UpdateTrainerTypeByID
            (this.TrainerTypeID, this.TrainerID, this.TrainerTypeName, this.MonthTrainingfee, this.LastUpdateDate, this.CreatedByUserID);

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTrainerType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTrainerTypeID();

            }

            return false;
        }

        public static bool DeleteTrainerTypeID(int TrainerTypeID)
        {

            return clsDataTrainerTypes.DeleteTrainerTypeByID(TrainerTypeID);
        }
        public static decimal GetTrainingAmount(int TrainerTypeID)
        {

            return clsDataTrainerTypes.GetTrainingAmountByID(TrainerTypeID);
        }
        public static DataTable GetAllTrainerTypesList()
        {

            return clsDataTrainerTypes.GetAllTrainerTypes();
        }





    }
}
