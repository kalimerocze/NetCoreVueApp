using System.ComponentModel.DataAnnotations;

namespace VueApp.Models
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Author { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime PublishedTo { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool ForLoggedUserOnly { get; set; }
        public string? Attachment { get; set; }
        public string? Order { get; set; }
        public int Type { get; set; }

    }
}
