using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class clsDataTrainerTypes
    {
        public static bool FindTrainerTypeByID(int TrainerTypeID, ref int TrainerID, ref string TrainerTypeName, ref decimal MonthTrainingFee, ref DateTime LastUpdateDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM TrainerTypes WHERE TrainerTypeID= @TrainerTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerTypeID ", TrainerTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    TrainerID = (int)reader["TrainerID"];
                    TrainerTypeName = (string)reader["TrainerTypeName"];
                    MonthTrainingFee = (decimal)reader["MonthTrainingFee"];
                    LastUpdateDate = (DateTime)reader["LastUpdateDate"];
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

        public static bool FindTrainerTypeInfoByTrainerTypeName(ref int TrainerTypeID, ref int TrainerID, string TrainerTypeName, ref decimal MonthTrainingFee, ref DateTime LastUpdateDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString); 
            string query = "SELECT * FROM TrainerTypes WHERE TrainerTypeName= @TrainerTypeName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerTypeName ", TrainerTypeName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    TrainerTypeID = (int)reader["TrainerTypeID"];
                    TrainerID = (int)reader["TrainerID"];
                    MonthTrainingFee = (decimal)reader["MonthTrainingFee"];
                    LastUpdateDate = (DateTime)reader["LastUpdateDate"];
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

        public static bool FindTrainerTypeInfoByTrainerID(ref int TrainerTypeID,  int TrainerID, ref string TrainerTypeName, ref decimal MonthTrainingFee, ref DateTime LastUpdateDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM TrainerTypes WHERE TrainerID= @TrainerID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerID ", TrainerID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    TrainerTypeID = (int)reader["TrainerTypeID"];
                    TrainerTypeName = (string)reader["TrainerTypeName"];
                    MonthTrainingFee = (decimal)reader["MonthTrainingFee"];
                    LastUpdateDate = (DateTime)reader["LastUpdateDate"];
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


        public static int AddNewTrainerType(int TrainerID, string TrainerTypeName, decimal MonthTrainingFee, DateTime LastUpdateDate, int CreatedByUserID)
        {
            int TrainerTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO TrainerTypes ( TrainerID ,TrainerTypeName ,MonthTrainingFee ,LastUpdateDate ,CreatedByUserID )
           VALUES ( @TrainerID , @TrainerTypeName , @MonthTrainingFee , @LastUpdateDate , @CreatedByUserID )
          SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerID", TrainerID);
            command.Parameters.AddWithValue("@TrainerTypeName", TrainerTypeName);
            command.Parameters.AddWithValue("@MonthTrainingFee", MonthTrainingFee);
            command.Parameters.AddWithValue("@LastUpdateDate", LastUpdateDate);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TrainerTypeID = insertedID;
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
            return TrainerTypeID;
             }
        public static bool DeleteTrainerTypeByID(int TrainerTypeID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Delete TrainerTypes  
             where TrainerTypeID  = @TrainerTypeID";

             SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TrainerTypeID ", TrainerTypeID);
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
        public static bool UpdateTrainerTypeByID(int TrainerTypeID, int TrainerID, string TrainerTypeName, decimal MonthTrainingFee, DateTime LastUpdateDate, int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update TrainerTypes  
            set  
           TrainerID  = @TrainerID ,
           TrainerTypeName  = @TrainerTypeName ,
           MonthTrainingFee  = @MonthTrainingFee ,
           LastUpdateDate  = @LastUpdateDate ,
           CreatedByUserID  = @CreatedByUserID 
           where TrainerTypeID = @TrainerTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerTypeID", TrainerTypeID);
            command.Parameters.AddWithValue("@TrainerID", TrainerID);
            command.Parameters.AddWithValue("@TrainerTypeName", TrainerTypeName);
            command.Parameters.AddWithValue("@MonthTrainingFee", MonthTrainingFee);
            command.Parameters.AddWithValue("@LastUpdateDate", LastUpdateDate);
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

        public static bool IsExistTrainerTypeByID(int TrainerTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM TrainerTypes  
             where TrainerTypeID = @TrainerTypeID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerTypeID ", TrainerTypeID);

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
        public static DataTable GetAllTrainerTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM TrainerTypes  ";

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
               // return false;

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static decimal GetTrainingAmountByID(int TrainerTypeID)

        {
            //** You Must declare var string To Loaded With First Name You Looking For

            decimal MonthTrainingFee = -1;

            //SqlConnection they there Objective Doing the Connectivity with Data Base


            //the Necessary information To Get Access To Database 
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            //Write Your Query                                          //the parametrize (will Looking For)

            string Query = "select MonthTrainingFee from TrainerTypes where TrainerTypeID = @TrainerTypeID";


            //Prepare To Execute Comment 

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TrainerTypeID", TrainerTypeID);

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
                    MonthTrainingFee = decimal.Parse(Result.ToString());

                }
                else//If Not Find
                {
                    MonthTrainingFee = -1;
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
            return MonthTrainingFee;

        }
    }
}
