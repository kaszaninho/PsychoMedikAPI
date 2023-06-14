using PsychoMedikAPI.Models;
using PsychoMedikAPI.Models.Abstract;

namespace PsychoMedikAPI.ViewModels
{
    public class PracownikForView : DescriptionTable
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public DateTime? DataRezygnacji { get; set; }
        public bool Plec { get; set; }
        public string StanCywilny { get; set; }
        public int? IdStanowiska { get; set; }
        public string? NazwaStanowisko { get; set; }
    }
}
