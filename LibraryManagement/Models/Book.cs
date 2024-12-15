using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int PublicationYear { get; set; }
        public required string ISBN { get; set; }
        public required string Genre { get; set; }
        public required string Publisher { get; set; }
        public int PageCount { get; set; }
        public required string Language { get; set; }
        public required string Summary { get; set; }
        public int AvailableCopies { get; set; }
    }
}
