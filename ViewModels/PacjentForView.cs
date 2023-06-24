using PsychoMedikAPI.Models.Abstract;

namespace PsychoMedikAPI.ViewModels
{
    public class PacjentForView : DescriptionTable
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public bool Plec { get; set; }
        public int? IdPracownika { get; set; }
        public string ImieNazwisko { get; set; }

    }
}