namespace VueApp.Models
{
    /// <summary>
    /// Entity of files
    /// </summary>
    public class File
    {
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public string? ArticleId { get; set; }
        public string? Folder { get; set; }


    }
}
