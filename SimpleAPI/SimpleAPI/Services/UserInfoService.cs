using System;
using System.Threading.Tasks;
using Dapper;
using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;
using Npgsql;

namespace SimpleAPI.Services
{
    public class UserInfoService : IUserInfoService
    {
        private const string ConnectionString =
            "host=localhost;port=5432;database=postgres;username=postgres;password=123";

        public async Task<User> GetById(Guid id)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                return await connection.QuerySingleAsync<User>(
                    "SELECT * FROM modultest.users WHERE Id = @id", new {id});
            }
        }
    }
}
