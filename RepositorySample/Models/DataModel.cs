using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RepositorySample.Models
{
    public class DataModel
    {
        SqlConnection sqlconnection;
        SqlCommand sqlcommand;
        public DataModel()
        {
            sqlconnection = new SqlConnection();
            sqlconnection.ConnectionString =
                "data source =.; initial catalog = Repository; integrated security = true";
            sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
        }
        public List<string> GetStudent()
        {
            List<string> db = new List<string>();
            sqlcommand.CommandText = "select * from Student";
            sqlconnection.Open();
            SqlDataReader datareader = sqlcommand.ExecuteReader();
            if (datareader.HasRows)
            {
                while (datareader.Read())
                {
                    string getAll =
$"{datareader["StudentName"].ToString()},{datareader["StudentAge".ToString()]},{datareader["StudentAverage"].ToString()}";

                    db.Add(getAll);
                }
            }
            datareader.Close();
            sqlconnection.Close();

            return db;
        }
        public int AddStudent(string Name , int Age , int Average)
        {
            sqlcommand.CommandText = $"insert into Student Values (N'{Name}',{Age},{Average})";
            sqlconnection.Open();
            int Result = sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            return Result;
        }

        public int RemoveStudent(string name)
        {
            sqlcommand.CommandText = $"delete Student where StudentName = '{name}' ";
            sqlconnection.Open();
            SqlDataReader datareader = sqlcommand.ExecuteReader();
            if (datareader.HasRows != null)
            {
                return 1;
            }
            if (datareader.HasRows == null)
            {
                return 0;
            }
            datareader.Close();
            sqlconnection.Close();
            return 0;
        }







    }
}