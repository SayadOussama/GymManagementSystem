using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer
{
    public  class clsSubscriberAccounts
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int AccountID { get; set; }
        public int PersonID { get; set; }
        public int TrainerTypeID { get; set; }
        public int SubscribeID { get; set; }
        public decimal SubscribeMonthAmount { get; set; }
       
        public DateTime CreationDate { get; set; }
        public DateTime EndDateSubscriber { get; set; }

        public bool IsPaid { get; set; }

        public int CreatedByUserID { get; set; }

        public clsPerson PersonInfo;

        public clsTrainerTypes TrainerTypeInfo ;
        public clsSubscriptions SubscriptionsInfo;
        public clsSubscriberAccounts()
        {
            this.AccountID = -1;
            this.PersonID = -1;
            this.TrainerTypeID = -1;
            this.SubscribeID = -1;
            this.SubscribeMonthAmount = -1;
            this.CreationDate = DateTime.MinValue;
            this.EndDateSubscriber = DateTime.MinValue;
            this.IsPaid = false;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        private clsSubscriberAccounts( int accountID, int personID, int trainerTypeID,int subscribeID, decimal subscribeMonthAmount, DateTime creationDate, DateTime endDateSubscriber, bool isPaid, int createdbyUserID)
        {
            
            this.AccountID = accountID;
            this.PersonID = personID;
            this.TrainerTypeID = trainerTypeID;
            this.SubscribeID = subscribeID;
            this.SubscribeMonthAmount = subscribeMonthAmount;
            this.CreationDate = creationDate;
            this.EndDateSubscriber = endDateSubscriber;
            this.IsPaid = isPaid;
            this.CreatedByUserID = createdbyUserID;
            Mode = enMode.Update;
            PersonInfo =clsPerson.GetPersonInfoByPersonID(this.PersonID);
            SubscriptionsInfo = clsSubscriptions.FindSubscriptionInfoByID(this.SubscribeID);

            if (this.TrainerTypeID != -1)
                TrainerTypeInfo = clsTrainerTypes.GetFindInfoByTrainerTypeID(this.TrainerTypeID);
            else
                TrainerTypeInfo = null;


        }
        public static clsSubscriberAccounts GetAccountInfoByAccountID(int AccountID)
        {
            int PersonID = -1; int TrainerTypeID = -1;int SubscribeID = -1; decimal SubscribeMonthAmount = -1; DateTime CreationDate = DateTime.MinValue; DateTime LastPaidDate = DateTime.MinValue; bool IsPaid = false; int CreatedByUserID = -1;
            bool IsFound = clsDataSubscriberAccounts.GetDInfoByAccountID
           (AccountID, ref PersonID, ref TrainerTypeID, ref SubscribeID, ref SubscribeMonthAmount, ref CreationDate, ref LastPaidDate, ref IsPaid, ref CreatedByUserID
           );
            if (IsFound)
                return new clsSubscriberAccounts(AccountID, PersonID, TrainerTypeID, SubscribeID, SubscribeMonthAmount, CreationDate, LastPaidDate, IsPaid, CreatedByUserID);
            else
                return null;
        }

        public static clsSubscriberAccounts GetAccountInfoByPersonID(int PersonID)
        {
            int AccountID = -1; int TrainerTypeID = -1; int SubscribeID = -1; decimal SubscribeMonthAmount = -1; DateTime CreationDate = DateTime.MinValue; DateTime LastPaidDate = DateTime.MinValue; bool IsPaid = false; int CreatedByUserID = -1;
            bool IsFound = clsDataSubscriberAccounts.FindAccountInfoByPersonID
           (ref AccountID,  PersonID, ref TrainerTypeID, ref SubscribeID , ref SubscribeMonthAmount, ref CreationDate, ref LastPaidDate, ref IsPaid, ref CreatedByUserID
           );
            if (IsFound)
                return new clsSubscriberAccounts(AccountID, PersonID, TrainerTypeID, SubscribeID, SubscribeMonthAmount, CreationDate, LastPaidDate, IsPaid, CreatedByUserID);
            else
                return null;
        }
        private bool _AddNewSubscriberAccount()
        {

            this.AccountID = clsDataSubscriberAccounts.AddNewAccount
            (this.PersonID, this.TrainerTypeID,this.SubscribeID, this.SubscribeMonthAmount, this.CreationDate, this.EndDateSubscriber, this.IsPaid, this.CreatedByUserID);

            return (this.AccountID != -1);
        }
        private bool _UpdateSubscriberAccountInfoBy()
        {

            return clsDataSubscriberAccounts.UpdateAccountInfoByAccountID
            (this.AccountID, this.PersonID, this.TrainerTypeID,this.SubscribeID, this.SubscribeMonthAmount, this.CreationDate, this.EndDateSubscriber, this.IsPaid, this.CreatedByUserID );

        }
       static public bool GetAutoSubscribersDesiactive()
        {

            return clsDataSubscriberAccounts.DesactiveAutoSubscribers();


        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSubscriberAccount())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                    case enMode.Update:

                   return  _UpdateSubscriberAccountInfoBy();
                   

            }
            return false ;
        }

        public  bool DeleteSubscriberAccount()
        {

            return clsDataSubscriberAccounts.DeleteInfoByAccountID(this.AccountID);
        }
        public static bool IsExistAccountByID(int AccountID)
        {

            return clsDataSubscriberAccounts.IsExistAccountByAccountID(AccountID);
        }
        public static bool IsExistAccountByPersonID(int PersonID)
        {

            return clsDataSubscriberAccounts.IsExistAccountByPersonID(PersonID);
        }
        public static DataTable GetAllAccountIDList()
        {

            return clsDataSubscriberAccounts.GetAllAccounts();
        }
        public static DataTable GetAllSubscriberswithTrainer()
        {

            return clsDataSubscriberAccounts.GetAllSubscriberswithTrainer();
        }

        public static DataTable GetHistorySalarySubsribersList(DateTime CreationDate )
        {

            return clsDataSubscriberAccounts.GetSubscribersSalaryHistroy(CreationDate);
        }
        public static decimal GetTotalSubscribersHistoryAmount(DateTime CreationDate)
        {

            return clsDataSubscriberAccounts.GetTotalAmountSalary(CreationDate);
        }
    }
}
