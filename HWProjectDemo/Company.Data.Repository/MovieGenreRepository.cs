using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Company.Data.Models;

namespace Company.Data.Repository
{
    public class MovieGenreRepository : IRepository<MovieGenre>
    {
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "DELETE FROM MovieGenre WHERE MovieId = @id";
                return connection.Execute(cmd, new { id = id });
            }
        }

        public IEnumerable<MovieGenre> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT m.Id, g.Id FROM MovieGenre mg INNER JOIN Movie m on mg.MovieId = m.Id INNER JOIN Genre g on mg.GenreId = g.Id";
                return connection.Query<MovieGenre, Movie, Genre, MovieGenre>(cmd, (mg, m, g) => { mg.Movie = m; mg.Genre = g; return mg; });
            }
        }

        public MovieGenre GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT MovieId, GenreId FROM MovieGenre WHERE MovieId = @id";
                return connection.QueryFirstOrDefault<MovieGenre>(cmd, new { id = id });
            }
        }

        public int Insert(MovieGenre item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "INSERT INTO MovieGenre VALUES( @MovieId, @GenreId)";
                return connection.Execute(cmd, item);
            }
        }

        public int Update(MovieGenre item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "UPDATE MovieGenre SET MovieId = @MovieId, GenreId = @GenreId WHERE MovieId = @id";
                return connection.Execute(cmd, item);
            }
        }
    }
}
