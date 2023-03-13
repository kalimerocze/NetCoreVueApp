namespace VueApp.Models
{
    public class Novinka
    {
        public Guid Id { get; set; }
        public string? Nadpis { get; set; }
        public string? Text { get; set; }
        public string? Autor { get; set; }
        public DateTime PublikovanoDne { get; set; }
        public DateTime PublikovanoDo { get; set; }
        public DateTime VytvorenoDne { get; set; }
        public bool ProPrihlasene { get; set; }
        public string? Priloha { get; set; }
        public string? Poradi { get; set; }
        public int TypClanku { get; set; }

    }
}
