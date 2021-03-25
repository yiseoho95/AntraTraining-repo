using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Company.Data.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Company.Data.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        #region sync 
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "DELETE FROM Genre WHERE id = @id";
                return connection.Execute(cmd, new { id = id });
            }
        }

        public IEnumerable<Genre> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Name FROM Genre";
                return connection.Query<Genre>(cmd);
            }
        }

        public Genre GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Name FROM Genre WHERE id = @id";
                return connection.QueryFirstOrDefault<Genre>(cmd, new { id = id });
            }
        }

        public int Insert(Genre item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "INSERT INTO Genre VALUES( @Name )";
                return connection.Execute(cmd, item);
            }
        }

        public int Update(Genre item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "UPDATE Genre SET Id = @Id, Name = @Name WHERE Id = @Id";
                return connection.Execute(cmd, item);
            }
        }
        #endregion

        #region async
        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Name FROM Genre";
                var res = await connection.QueryAsync<Genre>(cmd);
                return res;
            }
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            using(SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Name FROM Genre WHERE id = @id";
                var res = await connection.QueryFirstOrDefaultAsync<Genre>(cmd);
                return res;
            }
        }

        public async Task<int>InsertAsync(Genre item)
        {
            using(SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "INSERT INTO Genre VALUES (@Name)";
                var res = await connection.ExecuteAsync(cmd, item);
                return res;
            }
        }

        public async Task<int> UpdateAsync(Genre item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "UPDATE Genre SET Id = @Id, Name = @Name WHERE Id = @Id";
                var res = await connection.ExecuteAsync(cmd,item);
               
                return res;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "DELETE FROM Genre WHERE id = @id";
                var res = await connection.ExecuteAsync(cmd, new { id = id});
                return res;
            }
        }
        #endregion
    }
}
