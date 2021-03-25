using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using Company.Data.Models;

namespace Company.Data.Repository
{
    public class UserRepository : IRepository<User>
    {
        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString)) 
            {
                string cmd = "DELETE FROM User WHERE id = @id";
                return connection.Execute(cmd, new { id = id });
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, HashedPassword, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDate, LockoutEnabled, AccessFailedCount, FirstName, LastName, DateOfBirth, Salt, IsLocked, LastLogInDate FROM User";
                return connection.Query<User>(cmd);
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "SELECT Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, HashedPassword, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDate, LockoutEnabled, AccessFailedCount, FirstName, LastName, DateOfBirth, Salt, IsLocked, LastLogInDate FROM User WHERE id = @id";
                return connection.QueryFirstOrDefault<User>(cmd, new { id = id });
            }
        }

        public int Insert(User item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "INSERT INTO User VALUES( @UserName, @NormalizedUserName, @Email, @NormalizedEmail, @EmailConfirmed, @HashedPassword, @SecurityStamp, @ConcurrencyStamp, @PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled, @LockoutEndDate, @LockoutEnabled, @AccessFailedCount, @FirstName, @LastName, @DateOfBirth, @Salt, @IsLocked, @LastLogInDate)";
                return connection.Execute(cmd, item);
            }
        }

        public int Update(User item)
        {
            using (SqlConnection connection = new SqlConnection(DbHelper.ConnectionString))
            {
                string cmd = "UPDATE User SET Id = @Id, UserName = @UserName, NormalizedUserName = @NormalizedUserName, Email = @Email, NormalizedEmail = @NormalizedEmail, EmailConfirmed = @EmailConfirmed, HashedPassword = @HashedPassword, SecurityStamp = @SecurityStamp, ConcurrencyStamp = @ConcurrencyStamp, PhoneNumber = @PhoneNumber, PhoneNumberConfirmed = @PhoneNumberConfirmed, TwoFactorEnabled = @TwoFactorEnabled, LockoutEndDate = @LockoutEndDate, LockoutEnabled = @LockoutEnabled, AccessFailedCount = @AccessFailedCount, FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Salt = @Salt, IsLocked = @IsLocked, LastLogInDate = @LastLogInDate WHERE id = @id";
                return connection.Execute(cmd, item);
            }
        }
    }
}
