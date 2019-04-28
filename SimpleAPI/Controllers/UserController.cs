using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.BusinessLogic;
using SimpleAPI.Models;
using MassTransit;
using SimpleAPI.Commands;

namespace SimpleAPI.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {        
            private readonly GetUsersInfoRequestHandler _getUserInfoRequestHandler;
            private readonly PutUserInfoRequestHandler _putUserInfoRequestHandler;
            private readonly IBus _bus;

            public UserController(GetUsersInfoRequestHandler getUserInfoRequestHandler,
                                  PutUserInfoRequestHandler putUserInfoRequestHandler,
                                  IBus bus)
            {
                _getUserInfoRequestHandler = getUserInfoRequestHandler;
                _putUserInfoRequestHandler = putUserInfoRequestHandler;
                _bus = bus;

            }

            [HttpGet("{id}")]
            public Task<User> GetUserInfo(Guid id)
            {
                return _getUserInfoRequestHandler.Handle(id);
            }       
            
            [HttpPut("{id}")]
            public async Task<IActionResult> PutUserInfo([FromBody] User usr1)
            {
                var endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost/yo"));
                await endpoint.Send(new PutUser(){usr = usr1});
                return new StatusCodeResult(200);;


            }
    }
}