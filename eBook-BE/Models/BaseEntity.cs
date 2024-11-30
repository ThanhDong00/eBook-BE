namespace eBook_BE.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
        public bool IsDeleted { get; set; } = false;
    }
}
