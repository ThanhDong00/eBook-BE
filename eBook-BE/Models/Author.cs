namespace eBook_BE.Models
{
    public class Author:BaseEntity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
