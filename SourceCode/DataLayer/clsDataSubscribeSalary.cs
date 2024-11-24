using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class clsDataSubscribeSalary
    {
        public static bool FindSubscrubeSalaryInfoBySalaryID(int SalaryID, ref int SubscribeAccountID, ref DateTime PaidSalaryDate, ref decimal Amount, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM SubscribeSalary WHERE SalaryID= @SalaryID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SalaryID ", SalaryID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    SubscribeAccountID = (int)reader["SubscribeAccountID"];
                    PaidSalaryDate = (DateTime)reader["PaidSalaryDate"];
                    Amount = (decimal)reader["Amount"];
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
        public static int AddAddNewSalary(int SubscribeAccountID, DateTime PaidSalaryDate, decimal Amount, int CreatedByUserID)
        {
            int SalaryID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO SubscribeSalary ( SubscribeAccountID ,PaidSalaryDate ,Amount ,CreatedByUserID )
             VALUES ( @SubscribeAccountID , @PaidSalaryDate , @Amount , @CreatedByUserID )
             SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SubscribeAccountID", SubscribeAccountID);
            command.Parameters.AddWithValue("@PaidSalaryDate", PaidSalaryDate);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    SalaryID = insertedID;
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
            return SalaryID;
  }
        public static bool IsSalaryExistBySalaryID(int SalaryID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM SubscribeSalary  
             where SalaryID = @SalaryID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SalaryID ", SalaryID);

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
        public static DataTable GetAllSalarysList()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM SubscribeSalary  ";

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
              //    return false;

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}
