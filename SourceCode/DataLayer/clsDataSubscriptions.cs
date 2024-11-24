using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class clsDataSubscriptions
    {
        public static bool GetSubscriptionInfoBySubscribeID(int SubscribeID, ref string SubscribeName, ref decimal SubscribeFee, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); 
            string query = "SELECT * FROM Subscriptions WHERE SubscribeID= @SubscribeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubscribeID ", SubscribeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; 
                    SubscribeName = (string)reader["SubscribeName"];
                    SubscribeFee = (decimal)reader["SubscribeFee"];
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
        public static int AddNewSubscribe(string SubscribeName, decimal SubscribeFee, int CreatedByUserID)
        {
            int SubscribeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Subscriptions ( SubscribeName ,SubscribeFee ,CreatedByUserID )
         VALUES ( @SubscribeName , @SubscribeFee , @CreatedByUserID )
         SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubscribeName", SubscribeName);
            command.Parameters.AddWithValue("@SubscribeFee", SubscribeFee);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    SubscribeID = insertedID;
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
            return SubscribeID;
   }
        public static bool UpdateInfoBySubscribeID(int SubscribeID, string SubscribeName, decimal SubscribeFee, int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update Subscriptions  
           set  
           SubscribeName  = @SubscribeName ,
            SubscribeFee  = @SubscribeFee ,
            CreatedByUserID  = @CreatedByUserID 
            where SubscribeID = @SubscribeID;";
            SqlCommand command = new SqlCommand(query, connection); 
            command.Parameters.AddWithValue("@SubscribeID", SubscribeID);
            command.Parameters.AddWithValue("@SubscribeName", SubscribeName);
            command.Parameters.AddWithValue("@SubscribeFee", SubscribeFee);
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
        public static bool DeleteSubscribeBySubscribeID(int SubscribeID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Delete Subscriptions  
           where SubscribeID  = @SubscribeID";

             SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubscribeID ", SubscribeID);
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
        public static bool IsExistSubscribeBySubscribeID(int SubscribeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM Subscriptions  
             where SubscribeID = @SubscribeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubscribeID ", SubscribeID);

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
        public static DataTable GetAllSubscribesList()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select Subscriptions.SubscribeID , Subscriptions.SubscribeName , Subscriptions.SubscribeFee , Users.Username
from Subscriptions 
inner join Users on Subscriptions.CreatedByUserID = Users.UserID
Order By SubscribeID DESC  ";

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
        public static decimal GetSubscribeMonthAmountByID(int SubscribeID)

        {
            //** You Must declare var string To Loaded With First Name You Looking For

            decimal SubscribeFee = -1;

            //SqlConnection they there Objective Doing the Connectivity with Data Base


            //the Necessary information To Get Access To Database 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            //Write Your Query                                          //the parametrize (will Looking For)

            string Query = "select SubscribeFee from Subscriptions where SubscribeID = @SubscribeID";


            //Prepare To Execute Comment 

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@SubscribeID", SubscribeID);

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
                    SubscribeFee = decimal.Parse(Result.ToString());

                }
                else//If Not Find
                {
                    SubscribeFee = -1;
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
            return SubscribeFee;

        }
    }
}
