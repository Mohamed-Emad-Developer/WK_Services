using WK_Services.Domain.Core.Commands;

namespace WK_Services.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<bool> SendCommand<T>(T command) where T : Command;
 
    }

    
      
}
