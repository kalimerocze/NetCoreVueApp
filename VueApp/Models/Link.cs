using System.ComponentModel.DataAnnotations;

namespace VueApp.Models
{
    /// <summary>
    /// Entity of links
    /// </summary>
    public class Link
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        public int Type { get; set; }
        public string? GrouOfLinks { get; set; }
        public string? BlockOfLinks { get; set; }
        public int Order { get; set; }
        public bool Published { get; set; }
        public bool OpenToNewWindow { get; set; }
        public bool ForLoggedUserOnly { get; set; }


    }
}
