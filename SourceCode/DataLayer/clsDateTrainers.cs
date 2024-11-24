using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class clsDateTrainers
    {
        public static bool FindTrainerInfoByTrainerID(int TrainerID, ref int PersonID, ref string SpecialityTraining, ref DateTime RegistraingDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Trainers WHERE TrainerID= @TrainerID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerID ", TrainerID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; PersonID = (int)reader["PersonID"];
                    SpecialityTraining = (string)reader["SpecialityTraining"];
                    RegistraingDate = (DateTime)reader["RegistraingDate"];
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
        public static bool FindTrainerInfoByPersonID(ref int TrainerID, int PersonID, ref string SpecialityTraining, ref DateTime RegistraingDate, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Trainers WHERE PersonID= @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID ", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true; TrainerID = (int)reader["TrainerID"];
                    SpecialityTraining = (string)reader["SpecialityTraining"];
                    RegistraingDate = (DateTime)reader["RegistraingDate"];
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
        public static int AddNewTrainer(int PersonID, string SpecialityTraining, DateTime RegistraingDate, int CreatedByUserID)
        {
            int TrainerID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Trainers ( PersonID ,SpecialityTraining ,RegistraingDate ,CreatedByUserID)
VALUES ( @PersonID , @SpecialityTraining , @RegistraingDate , @CreatedByUserID )
SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@SpecialityTraining", SpecialityTraining);
            command.Parameters.AddWithValue("@RegistraingDate", RegistraingDate);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TrainerID = insertedID;
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
            return TrainerID;
      }
        public static bool UpdateTrainerByTrainerID(int TrainerID, int PersonID, string SpecialityTraining, DateTime RegistraingDate, int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update Trainers  
             set  
             PersonID  = @PersonID ,
             SpecialityTraining  = @SpecialityTraining ,
             RegistraingDate  = @RegistraingDate ,
             CreatedByUserID  = @CreatedByUserID 
             where TrainerID = @TrainerID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerID", TrainerID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@SpecialityTraining", SpecialityTraining);
            command.Parameters.AddWithValue("@RegistraingDate", RegistraingDate);
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
        public static bool IsExistTrainerByID(int TrainerID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM Trainers  
             where TrainerID = @TrainerID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerID ", TrainerID);

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
        public static bool DeleteTrainerByID(int TrainerID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Delete Trainers  
                           where TrainerID  = @TrainerID";

             SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TrainerID ", TrainerID);
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
        public static DataTable GetAllTrainersList()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
Select Trainers.TrainerID, People.FirstName +' '+ People.LastName as TrainerName,Trainers.SpecialityTraining , TrainerTypes.TrainerTypeName,
TrainerTypes.MonthTrainingFee, TrainerTypes.LastUpdateDate, Users.Username as CreatedByUser
from Trainers
Inner Join People on Trainers.PersonID =People.PersonID
Inner Join TrainerTypes on TrainerTypes.TrainerID =  Trainers.TrainerID
Inner Join Users on TrainerTypes.CreatedByUserID = Users.UserID
Order  By Trainers.TrainerID DESC ";

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


    }
}
