namespace VueApp.Models
{
    /// <summary>
    /// Entity of contatcs
    /// </summary>
    public class Contact
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public bool Active { get; set; }
        public string? City { get; set; }
       

    }
}
