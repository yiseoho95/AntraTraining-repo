using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Company.Data.Models;
using System.Threading.Tasks;

namespace Company.Data.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
        #region sync
        public int Insert(Movie item)
        {
            //Unmanaged code => cannot use Garbage collector need to use Dispose()
            // the Using keyword automatically calls upon the Dispose();
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "INSERT INTO Movie VALUES(@Title, @Overview, @Tagline, @Budget, @Revenue, @ImdbUrl, @TmdbUrl, @PosterUrl, @BackdropUrl, @OriginalLanguage, @ReleaseDate, @Runtime, @Price, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy)";
                return connection.Execute(cmd, item);
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) 
            {
                string cmd = "SELECT Id, Title, Overview, Tagline, Budget, Revenue, ImdbUrl, TmdbUrl, PosterUrl, BackdropUrl, OriginalLanguage, ReleaseDate, Runtime, Price, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy FROM Movie";
                return connection.Query<Movie>(cmd);
            }

        }

        public Movie GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) 
            {
                string cmd = "SELECT Id, Title, Overview, Tagline, Budget, Revenue, ImdbUrl, TmdbUrl, PosterUrl, BackdropUrl, OriginalLanguage, ReleaseDate, RunTime, Price, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy FROM Movie WHERE id = @id";
                return connection.QueryFirstOrDefault<Movie>(cmd, new { id = id });
            }

        }

        public int Update(Movie item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "UPDATE Movies SET Title = @Title, Overview = @Overview, Tagline = @Tagline, Budget = @Budget, Revenue = @Revenue, ImdbUrl = @ImdbUrl, TmdbUrl = @TmdbUrl, PosterUrl = @PosterUrl, BackdropUrl = @BackdropUrl, OriginalLanguage = @OriginalLanguage, ReleaseDate = @ReleaseDate, RunTime = @RunTime, Price = @Price, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate, CreatedBy = @CreatedBy, UpdatedBy = @UpdatedBy WHERE id = @id";
                return connection.Execute(cmd, item);
            }
            
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "DELETE FROM Movie WHERE id = @id";
                return connection.Execute(cmd, new { id = id });
            }

        }
        #endregion

        #region async
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Title, Overview, Tagline, Budget, Revenue, ImdbUrl, TmdbUrl, PosterUrl, BackdropUrl, OriginalLanguage, ReleaseDate, Runtime, Price, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy FROM Movie";
                var res = await connection.QueryAsync<Movie>(cmd);
                return res;
            }
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, Title, Overview, Tagline, Budget, Revenue, ImdbUrl, TmdbUrl, PosterUrl, BackdropUrl, OriginalLanguage, ReleaseDate, RunTime, Price, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy FROM Movie WHERE id = @id";
                var res = await connection.QueryFirstOrDefaultAsync<Movie>(cmd, new { id  = id});
                return res;
            }
        }

        public async Task<int> InsertAsync(Movie item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "INSERT INTO Movie VALUES(@Title, @Overview, @Tagline, @Budget, @Revenue, @ImdbUrl, @TmdbUrl, @PosterUrl, @BackdropUrl, @OriginalLanguage, @ReleaseDate, @Runtime, @Price, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy)";
                var res = await connection.ExecuteAsync(cmd, item);
                return res;
            }
        }

        public async Task<int> UpdateAsync(Movie item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "UPDATE Movies SET Title = @Title, Overview = @Overview, Tagline = @Tagline, Budget = @Budget, Revenue = @Revenue, ImdbUrl = @ImdbUrl, TmdbUrl = @TmdbUrl, PosterUrl = @PosterUrl, BackdropUrl = @BackdropUrl, OriginalLanguage = @OriginalLanguage, ReleaseDate = @ReleaseDate, RunTime = @RunTime, Price = @Price, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate, CreatedBy = @CreatedBy, UpdatedBy = @UpdatedBy WHERE id = @id";
                var res = await connection.ExecuteAsync(cmd, item);

                return res;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "DELETE FROM Movie WHERE id = @id";
                var res = await connection.ExecuteAsync(cmd, new { id = id });
                return res;
            }
        }
        #endregion
    }
}
