using SimpleAPI.Models;

namespace SimpleAPI.Commands
{
    public class PutUser : IPutUser
    {
        public User usr { get; set; }
    }
}