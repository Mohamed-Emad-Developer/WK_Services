using WK_Services.Domain.Models.BaseEntities;

namespace WK_Services.Domain.Models
{
    public class Service : BaseEnttity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
