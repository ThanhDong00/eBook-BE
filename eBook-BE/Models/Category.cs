﻿namespace eBook_BE.Models
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}
