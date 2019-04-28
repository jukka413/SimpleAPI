using System.Threading.Tasks;
using MassTransit;
using SimpleAPI.BusinessLogic;
using SimpleAPI.Commands;

namespace SimpleAPI.Consumers
{
    public class PutUserConsumer : IConsumer<PutUser>
    {
        private readonly PutUserInfoRequestHandler _putUserInfoRequestHandler;
        
        public PutUserConsumer(PutUserInfoRequestHandler putUserInfoRequestHandler)
        {
            _putUserInfoRequestHandler = putUserInfoRequestHandler;
        }
        public async Task Consume(ConsumeContext<PutUser> context)
        {
            var user =  context.Message.usr;

            await _putUserInfoRequestHandler.Handle(user);

        }
    }
}