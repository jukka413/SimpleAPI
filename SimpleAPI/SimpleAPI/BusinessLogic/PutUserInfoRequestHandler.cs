using System;
using System.Threading.Tasks;
using SimpleAPI.Models;
using SimpleAPI.Services.Interfaces;

namespace SimpleAPI.BusinessLogic
{
    public class PutUserInfoRequestHandler
    {
        private readonly IUserPutService _userPutService;

        public PutUserInfoRequestHandler(IUserPutService userPutService)
        {
            _userPutService = userPutService;
        }

        public Task Handle(User user)
        {
            return _userPutService.Put(user);
        }
    }
}