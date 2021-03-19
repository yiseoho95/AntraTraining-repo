using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Models;
using System.Data;
using System.Data.SqlClient;

namespace Antra.CompanyApp.Data.Repository
{
    public class DeptRepository : IRepository<Dept>
    {
        DbHelper dbHelper; 

        public DeptRepository()
        {
            dbHelper = new DbHelper();
        }
        public int Insert(Dept item)
        {
            string cmd = "Insert into Dept values(@id, @dname, @loc)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@dname", item.DName);
            parameters.Add("@loc", item.Loc);
            parameters.Add("@id", item.Id);
            return dbHelper.ExecuteDMLStatements(cmd, parameters);
        }

        public int Update(Dept item)
        {
            string cmd = "UPDATE Dept set DName = @dname, City = @loc Where Id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", item.Id);
            parameters.Add("@dname", item.DName);
            parameters.Add("@loc", item.Loc);
            return dbHelper.ExecuteDMLStatements(cmd, parameters);
        }

        public int Delete(int id)
        {
            string cmd = "DELETE FROM Dept WHERE Id = @id;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return dbHelper.ExecuteDMLStatements(cmd, parameters);
        }
        public IEnumerable<Dept> GetAll()
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Id, Dname, City from Dept Order By Id";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Dept> deptCollection = new List<Dept>();
            while(reader.Read())
            {
                Dept d = new Dept();
                d.Id = Convert.ToInt32(reader["Id"]);
                d.DName = Convert.ToString(reader["DName"]);
                d.Loc = Convert.ToString(reader["City"]);
                deptCollection.Add(d);
            }

            conn.Close();

            return deptCollection;
        }

        public Dept GetById(int id)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Id, Dname, City from Dept";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            Dept d = new Dept();
            if (reader.Read())
            {
        
                d.Id = Convert.ToInt32(reader["Id"]);
                d.DName = Convert.ToString(reader["DName"]);
                d.Loc = Convert.ToString(reader["City"]);
           
            }

            conn.Close();

            return d;
        }

        //public int Insert(Dept item)
        //{
        //    SqlConnection connection = new SqlConnection(DbHelper.ConnectionString);
        //    connection.Open();

        //    SqlCommand command = new SqlCommand();
        //    command.CommandText = "Insert into Dept values(@Id, @dname, @loc)";
        //    command.Parameters.AddWithValue("@Id", item.Id);
        //    command.Parameters.AddWithValue("@dname",item.DName);
        //    command.Parameters.AddWithValue("@loc", item.Loc);

        //    command.Connection = connection;

        //    int result = command.ExecuteNonQuery(); //use it for insert,update,delete

        //    connection.Close();
        //    return result;
        //}

        //public int Update(Dept item)
        //{
        //    SqlConnection connection = new SqlConnection(DbHelper.ConnectionString);
        //    connection.Open();

        //    SqlCommand command = new SqlCommand();
        //    command.CommandText = "UPDATE Dept set DName = @dname, City = @loc Where Id = @id";
        //    command.Parameters.AddWithValue("@id", item.Id);
        //    command.Parameters.AddWithValue("@dname", item.DName);
        //    command.Parameters.AddWithValue("@loc", item.Loc);

        //    command.Connection = connection;

        //    int result = command.ExecuteNonQuery(); //use it for insert,update,delete

        //    connection.Close();
        //    return result;
        //}

        //public int Delete(Dept item)
        //{
        //    SqlConnection connection = new SqlConnection(DbHelper.ConnectionString);
        //    connection.Open();

        //    SqlCommand command = new SqlCommand();
        //    command.CommandText = "DELETE FROM Dept WHERE DName = @dname;";
        //    command.Parameters.AddWithValue("@dname", item.DName);

        //    command.Connection = connection;

        //    int result = command.ExecuteNonQuery(); //use it for insert,update,delete

        //    connection.Close();
        //    return result;
        //}
    }
}
