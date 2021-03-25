using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Company.Data.Models;

namespace Company.Data.Repository
{
    public class MovieCastRepository : IRepository<MovieCast>
    {
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "DELETE FROM MovieCast WHERE MovieId = @id";
                return connection.Execute(cmd, new { id = id });
            }
        }

        public IEnumerable<MovieCast> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                // string cmd = "Select e.Id,e.EName, e.Salary,e.DeptId,d.Id,d.DName,d.Loc  from Employee e inner join Dept d on e.DeptId = d.Id";
                //return connection.Query<Employee, Dept, Employee>(cmd, (e, d) => { e.Dept = d; return e; });
                string cmd = "SELECT m.Id, c.Id, mc.Character FROM MovieCast mc INNER JOIN Movie m on mc.MovieId = m.Id INNER JOIN Cast c on mc.CastId = c.Id";
                return connection.Query<MovieCast, Movie, Cast, MovieCast>(cmd, (mc, m, c)=> { mc.Movie = m; mc.Cast = c; return mc; });
            }
        }

        public MovieCast GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT MovieId, CastId, Character FROM MovieCast WHERE MovieId = @id";
                return connection.QueryFirstOrDefault<MovieCast>(cmd, new { id = id });
            }
        }

        public int Insert(MovieCast item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "INSERT INTO MovieCast VALUES( @MovieId, @CastId, @Character)";
                return connection.Execute(cmd, item);
            }
        }

        public int Update(MovieCast item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "UPDATE MovieCast SET MovieId = @MovieId, CastId = @CastId, Character = @Character WHERE MovieId = @id";
                return connection.Execute(cmd, item);
            }
        }
    }
}
