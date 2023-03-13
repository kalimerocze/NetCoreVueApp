namespace VueApp.Models
{
    public class Kontakt
    {
        public Guid Id { get; set; }
        public string? Jmeno { get; set; }
        public string? Prijmeni { get; set; }
        public string? Telefon { get; set; }
        public bool Aktivni { get; set; }
        public string? Mesto { get; set; }
       

    }
}
