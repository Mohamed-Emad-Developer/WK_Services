using MediatR;
using WK_Services.Domain.Core.Bus;

namespace WK_Services.Domain.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        protected Message()
        {
            MessageType = GetType().Name;
        }
    }

 

    public abstract class MessageUserService : IRequest<IdentityResultViewModel>
    {
        public string MessageType { get; protected set; }

        public MessageUserService()
        {
            MessageType = GetType().Name;
        }
    } 
     
}
