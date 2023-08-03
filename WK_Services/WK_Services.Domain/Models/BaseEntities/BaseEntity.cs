namespace WK_Services.Domain.Models.BaseEntities
{
    public abstract class BaseEnttity
    {
        public int Id { get; set; }
        public DateTime CreatedDateOnUtc { get; set; }
        public DateTime UpdatedDateOnUtc { get; set; }
    }
}
