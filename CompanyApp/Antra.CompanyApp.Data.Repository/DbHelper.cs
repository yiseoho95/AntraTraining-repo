using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Antra.CompanyApp.Data.Repository
{
    class DbHelper
    {
        public const string ConnectionString = @"Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True";
    
        public int ExecuteDMLStatements(string statement, Dictionary<string,object> parameters, CommandType cmdType = CommandType.Text)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = statement;
            cmd.CommandType = cmdType;
            if(parameters != null)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }

            cmd.Connection = connection;

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return result;
        }
    }
}
