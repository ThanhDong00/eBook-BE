﻿namespace eBook_BE.Models
{
    public class Publisher: BaseEntity
    {
        //public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
