namespace NetCore_Project.DTO
{
    public class BaseModel
    {
        public long Id { get; set; }
        public long? StatusId { get; set; }
        public Guid? RowId { get; set; }
        public bool? Used { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
