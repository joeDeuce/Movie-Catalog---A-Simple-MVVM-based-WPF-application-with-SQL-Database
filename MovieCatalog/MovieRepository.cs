using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTime
{
    public class MovieRepository
    {
        public List<CurrentRoster> movieRepository { get; set; }
        
        public MovieRepository()
        {
            movieRepository = GetMovieRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<CurrentRoster> GetMovieRepo()
        {
            List<CurrentRoster> listOfMovies = new List<CurrentRoster>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from CurrentRoster", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    CurrentRoster m = new CurrentRoster();
                    m.GDCNum = (int)row["id"];
                    m.Title = row["Title"].ToString();
                    m.LastName = (int)row["ReleaseYear"];
                    m.FirstName = row["Genre"].ToString();
                    m.Duration = (int)row["Duration"];

                    listOfMovies.Add(m);
                }

                return listOfMovies;
            }
        }

        /*
         * Function: Return records that matches the Search Query String
         * with the help of stored procedure
         */
        public List<CurrentRoster> GetMovieRepoSearch(string searchQuery)
        {
            List<CurrentRoster> listOfMovies = new List<CurrentRoster>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecords", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("TitlePhrase", SqlDbType.VarChar);
                param.Value = searchQuery;
                query.Parameters.Add(param);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    CurrentRoster m = new CurrentRoster();
                    m.GDCNum = (int)row["id"];
                    m.Title = row["Title"].ToString();
                    m.LastName = (int)row["ReleaseYear"];
                    m.FirstName = row["Genre"].ToString();
                    m.Duration = (int)row["Duration"];
                    listOfMovies.Add(m);
                }
                return listOfMovies;
            }
        }

        public List<CurrentRoster> GetAllMovies()
        {
            List<CurrentRoster> listOfMovies = new List<CurrentRoster>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecords", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("TitlePhrase", SqlDbType.VarChar);
                param.Value = "*";
                query.Parameters.Add(param);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    CurrentRoster m = new CurrentRoster();
                    m.GDCNum = (int)row["id"];
                    m.Title = row["Title"].ToString();
                    m.LastName = (int)row["ReleaseYear"];
                    m.FirstName = row["Genre"].ToString();
                    m.Duration = (int)row["Duration"];
                    listOfMovies.Add(m);
                }
                return listOfMovies;
            }
        }

        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void addNewRecord(CurrentRoster movieRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }
                else if (movieRecord == null)
                    throw new Exception("The passed argument 'movieRecord' is null");

                SqlCommand query = new SqlCommand("addRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pTitle", SqlDbType.VarChar);
                SqlParameter param2 = new SqlParameter("pReleaseYear", SqlDbType.Int);
                SqlParameter param3 = new SqlParameter("pGenre", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pDuration", SqlDbType.Int);

                param1.Value = movieRecord.Title;
                param2.Value = movieRecord.LastName;
                param3.Value = movieRecord.FirstName;
                param4.Value = movieRecord.Duration;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Deletes the record with reference to supplied id
         * with the help of stored procedure
         */
        public void DelRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);
                
                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Updates the CurrentRoster Record with reference to supplied id
         * with the help of stored procedure
         */
        public void UpdateRecord(CurrentRoster movieRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pTitle", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pReleaseYear", SqlDbType.Int);
                SqlParameter param4 = new SqlParameter("pGenre", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pDuration", SqlDbType.Int);

                param1.Value = movieRecord.GDCNum;
                param2.Value = movieRecord.Title;
                param3.Value = movieRecord.LastName;
                param4.Value = movieRecord.FirstName;
                param5.Value = movieRecord.Duration;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);

                query.ExecuteNonQuery();
            }
        }
    }
}