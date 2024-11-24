using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class clsDataSubscriberAccounts
    {
        public static bool GetDInfoByAccountID(int AccountID, ref int PersonID, ref int TrainerTypeID,ref int SubscribeID ,ref decimal SubscribeMonthAmount, ref DateTime CreationDate, ref DateTime EndDateSubscriber, ref bool IsPaid, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); string query = "SELECT * FROM SubscriberAccounts WHERE AccountID= @AccountID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID ", AccountID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; PersonID = (int)reader["PersonID"];

                    if (reader["TrainerTypeID"] != DBNull.Value)
                        TrainerTypeID = (int)reader["TrainerTypeID"];
                    else
                        TrainerTypeID = -1;
                    SubscribeID = (int)reader["SubscribeID"];
                    SubscribeMonthAmount = (decimal)reader["SubscribeMonthAmount"];
                    CreationDate = (DateTime)reader["CreationDate"];
                    EndDateSubscriber = (DateTime)reader["EndDateSubscriber"];
                    IsPaid = (bool)reader["IsPaid"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool FindAccountInfoByPersonID(ref int AccountID, int PersonID, ref int TrainerTypeID, ref int SubscribeID, ref decimal SubscribeMonthAmount, ref DateTime CreationDate, ref DateTime EndDateSubscriber, ref bool IsPaid, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); 
            string query = "SELECT * FROM People WHERE PersonID= @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID ", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    AccountID = (int)reader["AccountID"];
                    if (reader["TrainerTypeID"] != DBNull.Value)
                        TrainerTypeID = (int)reader["TrainerTypeID"];
                    else
                        TrainerTypeID = -1;
                    SubscribeID = (int)reader["SubscribeID"];
                    SubscribeMonthAmount = (decimal)reader["SubscribeMonthAmount"];
                    CreationDate = (DateTime)reader["CreationDate"];
                    EndDateSubscriber = (DateTime)reader["EndDateSubscriber"];
                    IsPaid = (bool)reader["IsPaid"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewAccount(int PersonID, int TrainerTypeID,int SubscribeID, decimal SubscribeMonthAmount, DateTime CreationDate, DateTime EndDateSubscriber, bool IsPaid, int CreatedByUserID)
        {
            int AccountID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO SubscriberAccounts ( PersonID ,TrainerTypeID, SubscribeID,SubscribeMonthAmount ,CreationDate ,EndDateSubscriber ,IsPaid ,CreatedByUserID )
VALUES ( @PersonID , @TrainerTypeID ,@SubscribeID, @SubscribeMonthAmount , @CreationDate , @EndDateSubscriber , @IsPaid , @CreatedByUserID)
SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            if (TrainerTypeID != -1 && TrainerTypeID != null)
                command.Parameters.AddWithValue("@TrainerTypeID", TrainerTypeID);
            else
                command.Parameters.AddWithValue("@TrainerTypeID", System.DBNull.Value);

           
            command.Parameters.AddWithValue("@SubscribeID", SubscribeID);
            command.Parameters.AddWithValue("@SubscribeMonthAmount", SubscribeMonthAmount);
            command.Parameters.AddWithValue("@CreationDate", CreationDate);
            command.Parameters.AddWithValue("@EndDateSubscriber", EndDateSubscriber);
            command.Parameters.AddWithValue("@IsPaid", IsPaid);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    AccountID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }
            finally
            {
                connection.Close();
            }
            return AccountID;
  }
        public static bool UpdateAccountInfoByAccountID(int AccountID, int PersonID, int TrainerTypeID,int SubscribeID, decimal SubscribeMonthAmount, DateTime CreationDate, DateTime EndDateSubscriber, bool IsPaid, int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update SubscriberAccounts  
set  
PersonID  = @PersonID ,
TrainerTypeID  = @TrainerTypeID ,
SubscribeID =@SubscribeID ,
SubscribeMonthAmount  = @SubscribeMonthAmount ,
CreationDate  = @CreationDate ,
EndDateSubscriber  = @EndDateSubscriber ,
IsPaid  = @IsPaid ,
CreatedByUserID  = @CreatedByUserID 
where AccountID = @AccountID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID", AccountID);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            if (TrainerTypeID != -1 && TrainerTypeID != null)
                command.Parameters.AddWithValue("@TrainerTypeID", TrainerTypeID);
            else
                command.Parameters.AddWithValue("@TrainerTypeID", System.DBNull.Value);
            command.Parameters.AddWithValue("@SubscribeID", SubscribeID);
            command.Parameters.AddWithValue("@SubscribeMonthAmount", SubscribeMonthAmount);
            command.Parameters.AddWithValue("@CreationDate", CreationDate);
            command.Parameters.AddWithValue("@EndDateSubscriber", EndDateSubscriber);
            command.Parameters.AddWithValue("@IsPaid", IsPaid);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;

            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static bool DeleteInfoByAccountID(int AccountID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Delete SubscriberAccounts  
                 where AccountID  = @AccountID";

             SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID ", AccountID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);


            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }
        public static bool IsExistAccountByAccountID(int AccountID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM SubscriberAccounts  
             where AccountID = @AccountID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountID ", AccountID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;

            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool IsExistAccountByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM SubscriberAccounts  
             where PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID ", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;

            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static DataTable GetAllAccounts()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select SubscriberAccounts.AccountID,People.FirstName +' '+People.FirstName as FullName ,case WHEN People.Gender = 0 then 'Male'when People.Gender = 1 then 'Female' end as Gender, Subscriptions.SubscribeName , SubscriberAccounts.SubscribeMonthAmount,
SubscriberAccounts.CreationDate,SubscriberAccounts.EndDateSubscriber , SubscriberAccounts.IsPaid,Users.Username
from SubscriberAccounts
Inner Join People on SubscriberAccounts.PersonID = People.PersonID

inner Join Subscriptions on SubscriberAccounts.SubscribeID = Subscriptions.SubscribeID
Inner Join Users on SubscriberAccounts.CreatedByUserID = Users.UserID
Order by AccountID DESC";


           SqlCommand command = new SqlCommand(query, connection);
           
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
             //   return false;

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static DataTable GetSubscribersSalaryHistroy(DateTime CreationDate)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select SubscriberAccounts.AccountID,People.FirstName +' '+People.FirstName as FullName ,
SubscriberAccounts.SubscribeMonthAmount,
SubscriberAccounts.CreationDate,SubscriberAccounts.EndDateSubscriber,SubscriberAccounts.IsPaid,Users.Username
from SubscriberAccounts 
Inner Join People on SubscriberAccounts.PersonID = People.PersonID
Inner Join Users on SubscriberAccounts.CreatedByUserID = Users.UserID
where ( SubscriberAccounts.CreationDate >= @CreationDate and SubscriberAccounts.IsPaid= 1) 
Order by AccountID DESC ";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CreationDate ", CreationDate);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                //   return false;

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static decimal GetTotalAmountSalary(DateTime CreationDate)

        {
            //** You Must declare var string To Loaded With First Name You Looking For

            decimal TotalAmount = -1;

            //SqlConnection they there Objective Doing the Connectivity with Data Base


            //the Necessary information To Get Access To Database 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            //Write Your Query                                          //the parametrize (will Looking For)

            string Query = @"select Sum (SubscribeMonthAmount) from SubscriberAccounts
where ( SubscriberAccounts.CreationDate >= @CreationDate  and SubscriberAccounts.IsPaid= 1)";


            //Prepare To Execute Comment 

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CreationDate", CreationDate);

            try
            {
                //Open the Gate to Get Access to Database 
                connection.Open();

                //**
                //**We Use Here Execute Scalar
                //**

                object Result = command.ExecuteScalar();

                if (Result != null)//IF Find 
                {
                    TotalAmount = decimal.Parse(Result.ToString());
                }
                else//If Not Find
                {
                    TotalAmount = -1;
                }

                connection.Close();

            }
            //Must Apply catch Because if the Data base Get ERROR Will Display it on the Screen 
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
            //IMPORTANT:
            //Return First name Must Be At The End of function 
            return TotalAmount;

        }
        public static DataTable GetAllSubscriberswithTrainer()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select SubscriberAccounts.AccountID,People.FirstName +' '+People.FirstName as FullName ,case WHEN People.Gender = 0 then 'Male'when People.Gender = 1 then 'Female' end as Gender,TrainerTypes.TrainerTypeName, Subscriptions.SubscribeName , SubscriberAccounts.SubscribeMonthAmount,
SubscriberAccounts.CreationDate,SubscriberAccounts.EndDateSubscriber , SubscriberAccounts.IsPaid,Users.Username
from SubscriberAccounts
Inner Join People on SubscriberAccounts.PersonID = People.PersonID
inner join TrainerTypes on TrainerTypes.TrainerTypeID =SubscriberAccounts.TrainerTypeID
inner Join Subscriptions on SubscriberAccounts.SubscribeID = Subscriptions.SubscribeID
Inner Join Users on SubscriberAccounts.CreatedByUserID = Users.UserID
Order by AccountID DESC";


            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                //   return false;

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }


        public static bool DesactiveAutoSubscribers()
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @" Update  SubscriberAccounts
 
 set SubscriberAccounts.IsPaid = 0


where SubscriberAccounts.EndDateSubscriber < GETDATE() ";

            SqlCommand command = new SqlCommand(query, connection);
            
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);


            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }



















    }
}
