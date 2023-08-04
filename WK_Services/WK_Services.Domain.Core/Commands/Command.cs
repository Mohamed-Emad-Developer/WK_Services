using WK_Services.Domain.Core.Events;

namespace WK_Services.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime TimeSpan { get; protected set; }
        protected Command()
        {
            TimeSpan = DateTime.Now;
        }
    }

  
     
}
