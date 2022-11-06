using System;

namespace BookstoreApi.Models
{
    public class Book
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Authors { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Publisher { get; set; } = string.Empty;
        public int ISBN { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public float Price { get; set; }
        public Category? Category { get; set; }
    }
}
