using System.ComponentModel.DataAnnotations;
using WK_Services.Domain.Models.BaseEntities;

namespace WK_Services.Domain.Models
{
    public class Service : BaseEnttity
    {
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }
    }
}
