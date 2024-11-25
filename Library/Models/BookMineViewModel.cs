﻿namespace Library.Models
{
    public class BookMineViewModel
    {
        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}
