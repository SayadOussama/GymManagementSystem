using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsSubscribeSalary
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int SalaryID { get; set; }
        public int SubscribeAccountID { get; set; }
        public DateTime PaidSalaryDate { get; set; }

        public decimal Amount { get; set; }

        public int CreatedByUserID { get; set; }

        public clsSubscribeSalary()
        {
            this.SalaryID = -1;
            this.SubscribeAccountID = -1;
            this.PaidSalaryDate = DateTime.MinValue;
            this.Amount = -1;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;

        }
        private clsSubscribeSalary(int salaryID, int subscribeAccountID, DateTime paidSalaryDate, decimal amount, int createdByUserID)
        {

            this.SalaryID = salaryID;
            this.SubscribeAccountID = subscribeAccountID;
            this.PaidSalaryDate = paidSalaryDate;
            this.Amount = amount;
            this.CreatedByUserID = createdByUserID;
            Mode = enMode.Update;
        }

        public static clsSubscribeSalary GetFindInfoBySalaryID(int SalaryID)
        {
            int SubscribeAccountID = -1; DateTime PaidSalaryDate = DateTime.MinValue; decimal Amount = -1; int CreatedByUserID = -1;
            bool IsFound = clsDataSubscribeSalary.FindSubscrubeSalaryInfoBySalaryID
           (SalaryID, ref SubscribeAccountID, ref PaidSalaryDate, ref Amount, ref CreatedByUserID
           );
            if (IsFound)
                return new clsSubscribeSalary(SalaryID, SubscribeAccountID, PaidSalaryDate, Amount, CreatedByUserID);
            else
                return null;
        }

        private bool _AddNewSalaryBySalaryID()
        {

            this.SalaryID = clsDataSubscribeSalary.AddAddNewSalary
            (this.SubscribeAccountID, this.PaidSalaryDate, this.Amount, this.CreatedByUserID);

            return (this.SalaryID != -1);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSalaryBySalaryID())
                    {
                      Mode = enMode.Update; 
                        return true;

                    }
                    else
                    {
                        return false;
                    }

            }
            return false;
        }
        public static DataTable GetAllSalaryIDList()
        {

            return clsDataSubscribeSalary.GetAllSalarysList();
        }

        public static bool IsExistSalaryByID(int SalaryID)
        {

            return clsDataSubscribeSalary.IsSalaryExistBySalaryID(SalaryID);
        }

    }
}
