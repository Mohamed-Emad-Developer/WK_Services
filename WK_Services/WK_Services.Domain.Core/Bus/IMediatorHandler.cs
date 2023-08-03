using WK_Services.Domain.Core.Commands;

namespace WK_Services.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task<IdentityResultViewModel> SendUserCommand<T>(T command) where T : CommandUserService; 
    }

    public class IdentityResultViewModel
    {
        public IEnumerable<ErrorRequestViewModel> Errors { get; set; }
        public bool Succeeded { get; set; }
        public string UserId { get; set; }
     
    }
     
    public class ErrorRequestViewModel
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
      
}
