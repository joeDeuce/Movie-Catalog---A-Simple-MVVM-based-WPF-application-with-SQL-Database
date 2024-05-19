using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTime
{
    public class CountRepository
    {
        public List<CurrentRoster> CountRepo { get; set; }
        
        public CountRepository()
        {
            CountRepo = GetCountRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<CurrentRoster> GetCountRepo()
        {
            List<CurrentRoster> listOfInmates = new List<CurrentRoster>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from tBaseline", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    CurrentRoster m = new CurrentRoster
                    {
                        GDCNum = (int)row["GDCNum"],
                        FirstName = row["FirstNAme"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Dorm = (short)row["Dorm"],
                        Bed = (short)row["Bed"],
                        LastUpdate = (DateTime)row["LastUpdate"]
                    };

                    listOfInmates.Add(m);
                }

                return listOfInmates;
            }
        }

        /*
         * Function: Return records that matches the Search Query String
         * with the help of stored procedure
         */
        public List<CurrentRoster> GetCountRepoSearch(string searchQuery)
        {
            List<CurrentRoster> listOfInmates = new List<CurrentRoster>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecords", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("TitlePhrase", SqlDbType.VarChar)
                {
                    Value = searchQuery
                };
                query.Parameters.Add(param);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    CurrentRoster m = new CurrentRoster
                    {
                        GDCNum = (int)row["id"],
                        FirstName = row["FirstNAme"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Dorm = (int)row["Dorm"],
                        Bed = (int)row["Bed"],
                        LastUpdate = (DateTime)row["LastUpdate"]
                    };
                    listOfInmates.Add(m);
                }
                return listOfInmates;
            }
        }

        public List<CurrentRoster> GetAllMovies()
        {
            List<CurrentRoster> listOfInmates = new List<CurrentRoster>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }
                SqlCommand query = new SqlCommand("retRecords", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("TitlePhrase", SqlDbType.VarChar)
                {
                    Value = "*"
                };
                query.Parameters.Add(param);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    CurrentRoster m = new CurrentRoster
                    {
                        GDCNum = (int)row["id"],
                        FirstName = row["FirstNAme"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Dorm = (int)row["Dorm"],
                        Bed = (int)row["Bed"],
                        LastUpdate = (DateTime)row["LastUpdate"]
                    };
                    listOfInmates.Add(m);
                }
                return listOfInmates;
            }
        }

        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void AddNewRecord(CurrentRoster inmateRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in CountTime->Properties-?Settings.settings");
                }
                else if (inmateRecord == null)
                    throw new Exception("The passed argument 'movieRecord' is null");

                SqlCommand query = new SqlCommand("addRecord", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pGDCNum", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pFirstName", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pLastName", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pDorm", SqlDbType.Int);
                SqlParameter param5 = new SqlParameter("pBed", SqlDbType.Int);

                param1.Value = inmateRecord.GDCNum;
                param2.Value = inmateRecord.FirstName;
                param3.Value = inmateRecord.LastName;
                param4.Value = inmateRecord.Dorm;
                param5.Value = inmateRecord.Bed;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);

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
                SqlParameter param1 = new SqlParameter("pId", SqlDbType.Int)
                {
                    Value = id
                };
                query.Parameters.Add(param1);
                
                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Updates the CurrentRoster Record with reference to supplied id
         * with the help of stored procedure
         */
        public void UpdateRecord(CurrentRoster inmateRecord)
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
                SqlParameter param1 = new SqlParameter("pGDCNum", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pFirstName", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pLastName", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pDorm", SqlDbType.Int);
                SqlParameter param5 = new SqlParameter("pBed", SqlDbType.Int);


                param1.Value = inmateRecord.GDCNum;
                param2.Value = inmateRecord.FirstName;
                param3.Value = inmateRecord.LastName;
                param4.Value = inmateRecord.Dorm;
                param5.Value = inmateRecord.Bed;

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