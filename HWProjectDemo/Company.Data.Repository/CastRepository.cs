using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Company.Data.Models;
using System.Threading.Tasks;

namespace Company.Data.Repository
{
    public class CastRepository : IRepository<Cast>
    {
        #region sync
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "DELETE FROM Cast WHERE id = @id";
                return connection.Execute(cmd, new { id = id });
            }
        }

        public IEnumerable<Cast> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Name, Gender, TmdbUrl, ProfilePath FROM Cast";
                return connection.Query<Cast>(cmd);
            }
        }

        public Cast GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Name, Gender, TmdbUrl, ProfilePath FROM Cast WHERE id = @id";
                return connection.QueryFirstOrDefault<Cast>(cmd, new { id = id });
            }
        }

        public int Insert(Cast item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "INSERT INTO Cast VALUES( @Name, @Gender, @TmdbUrl, @ProfilePath )";
                return connection.Execute(cmd, item);
            }
        }

        public int Update(Cast item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "UPDATE Cast SET Id = @Id, Name = @Name, Gender = @Gender, TmdbUrl = @TmdbUrl, ProfilePath = @ProfilePath WHERE id = @id";
                return connection.Execute(cmd, item);
            }
        }
        #endregion

        #region async
        public async Task<IEnumerable<Cast>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Name, Gender, TmbdUrl, ProfilePath FROM Cast";
                var res = await connection.QueryAsync<Cast>(cmd);
                return res;
            }
        }

        public async Task<Cast> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Name, Gender, TmdbUrl, ProfilePath FROM Cast WHERE id = @id";
                var res = await connection.QueryFirstOrDefaultAsync<Cast>(cmd, new { id = id });
                return res;
            }
        }

        public async Task<int> InsertAsync(Cast item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "INSERT INTO Cast VALUES (@Name, @Gender, @TmdbUrl, @ProfilePath)";
                var res = await connection.ExecuteAsync(cmd, item);
                return res;
            }
        }

        public async Task<int> UpdateAsync(Cast item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "UPDATE Cast SET Id = @Id, Name = @Name, Gender = @Gender, TmdbUrl = @TmdbUrl, ProfilePath = @ProfilePath WHERE id = @id";
                var res = await connection.ExecuteAsync(cmd, item);

                return res;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "DELETE FROM Cast WHERE id = @id";
                var res = await connection.ExecuteAsync(cmd, new { id = id });
                return res;
            }
        }
        #endregion
    }
}
