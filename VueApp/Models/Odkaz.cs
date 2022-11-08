namespace VueApp.Models
{
    public class Odkaz
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? Text { get; set; }
        public string? Popis { get; set; }
        public int TypOdkazu { get; set; }
        public string? SkupinaOdkazu { get; set; }
        public string? BlokOdkazu { get; set; }
        public int Poradi { get; set; }
        public bool Zverejnit { get; set; }
        public bool NoveOkno { get; set; }
        public bool ProPrihlasene { get; set; }


    }
}
