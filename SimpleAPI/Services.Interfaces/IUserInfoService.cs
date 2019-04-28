using System;
using System.Threading.Tasks;
using SimpleAPI.Models;


namespace SimpleAPI.Services.Interfaces
{
    public interface IUserInfoService
    {
        Task<User> GetById(Guid id);
    }
}