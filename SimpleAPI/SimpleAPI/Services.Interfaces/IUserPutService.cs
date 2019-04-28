using SimpleAPI.Models;
using System.Threading.Tasks;

namespace SimpleAPI.Services.Interfaces
{
    public interface IUserPutService
    {
        Task Put(User user);
    }
}