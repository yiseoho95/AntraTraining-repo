using System;
using System.Collections.Generic;
using System.Text;
using Antra.CompanyApp.Data.Models;
using System.Data;
using System.Data.SqlClient;
namespace Antra.CompanyApp.Data.Repository
{
   
    public class EmpRepository : IRepository<Employee>
    {

        DbHelper dbHelper;
        public EmpRepository()
        {
            dbHelper = new DbHelper();
        }

        public int Update(Employee item)
        {

            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spUpdateEmp";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@name", item.EName);
            cmd.Parameters.AddWithValue("@sal", item.Salary);
            cmd.Parameters.AddWithValue("@did", item.DeptId);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = conn;

            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public int Insert(Employee item)
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spInsertEmp";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@name", item.EName);
            cmd.Parameters.AddWithValue("@sal", item.Salary);
            cmd.Parameters.AddWithValue("@did", item.DeptId);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = conn;

            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

       

        public int Delete(int id)
        {
            string cmd = "spDeleteEmployeeById";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return dbHelper.ExecuteDMLStatements(cmd, parameters, CommandType.StoredProcedure);


        }

        public IEnumerable<Employee> GetAll()
        {
            SqlConnection conn = new SqlConnection(DbHelper.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Dept Order By Id";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employeeCollection = new List<Employee>();
            while (reader.Read())
            {
                Employee e = new Employee();
                e.Id = Convert.ToInt32(reader["Id"]);
                e.EName = Convert.ToString(reader["EName"]);
                e.DeptId = Convert.ToInt32(reader["DeptId"]);
                e.Salary = Convert.ToDecimal(reader["Salary"]);
                employeeCollection.Add(e);
            }

            conn.Close();

            return employeeCollection;
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }
    }

}
