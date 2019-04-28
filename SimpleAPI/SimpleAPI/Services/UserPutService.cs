using SimpleAPI.Models;
 using Dapper;
 using Npgsql;
 using System.Threading.Tasks;
 using SimpleAPI.Services.Interfaces;
 
 namespace SimpleAPI.Services
 {
     public class UserPutService : IUserPutService
     {
         private const string ConnectionString = 
             "host=localhost;port=5432;database=postgres;username=postgres;password=123";
 
         public Task Put(User user)
         {
             using (var connection = new NpgsqlConnection(ConnectionString))
             {
                 connection.Open();
                 return connection.ExecuteScalarAsync<User>
                     ("UPDATE modultest.users SET email = @email, nickname = @nickname, phone = @phone WHERE id = @id", user);
             }
         }
     }
 }