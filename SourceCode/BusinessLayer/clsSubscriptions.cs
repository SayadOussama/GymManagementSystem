using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsSubscriptions
    {

        public int SubscribeID { get; set; }
        public string SubscribeName { get; set; }
        public decimal SubscribeFee { get; set; }
        public int CreatedByUserID { get; set; }
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public clsSubscriptions()
        {
            this.SubscribeID = -1;
            this.SubscribeName = "";
            this.SubscribeFee = -1;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        private clsSubscriptions(int subscribeID, string subscriptionName, decimal subscribeFee, int createdByUserID)
        {
            this.SubscribeID = subscribeID;
            this.SubscribeName = subscriptionName;
            this.SubscribeFee = subscribeFee;
            this.CreatedByUserID = createdByUserID;
            Mode = enMode.Update    ;
        }
        public static clsSubscriptions FindSubscriptionInfoByID(int SubscribeID)
        {
            string SubscribeName = ""; decimal SubscribeFee = -1; int CreatedByUserID = -1;
            bool IsFound = clsDataSubscriptions.GetSubscriptionInfoBySubscribeID
           (SubscribeID, ref SubscribeName, ref SubscribeFee, ref CreatedByUserID
           );
            if (IsFound)
                return new clsSubscriptions(SubscribeID, SubscribeName, SubscribeFee, CreatedByUserID);
            else
                return null;
        }

        private bool _AddNewsInfoBySubscribeID()
        {

            this.SubscribeID = clsDataSubscriptions.AddNewSubscribe
            (this.SubscribeName, this.SubscribeFee, this.CreatedByUserID);

            return (this.SubscribeID != -1);
        }
        private bool _UpdatesSubscriptionInfoByID()
        {

            return clsDataSubscriptions.UpdateInfoBySubscribeID
            (this.SubscribeID, this.SubscribeName, this.SubscribeFee, this.CreatedByUserID);

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewsInfoBySubscribeID())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatesSubscriptionInfoByID();


            }
            return false;
        }

        public static bool DeleteSubscribeID(int SubscribeID)
        {

            return clsDataSubscriptions.DeleteSubscribeBySubscribeID(SubscribeID);
        }
        public static bool IsExistSubscriptionByID(int SubscribeID)
        {

            return clsDataSubscriptions.IsExistSubscribeBySubscribeID(SubscribeID);
        }

        public static decimal GetSubscribeAmountByID(int SubscribeID)
        {

            return clsDataSubscriptions.GetSubscribeMonthAmountByID(SubscribeID);
        }
        public static DataTable GetAllSubscribeList()
        {

            return clsDataSubscriptions.GetAllSubscribesList();
        }
    }
}
