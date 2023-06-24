using PsychoMedikAPI.Models;
using PsychoMedikAPI.Models.Abstract;
using PsychoMedikApp.Helpers;

namespace PsychoMedikAPI.ViewModels
{
    public class WizytaForView : DescriptionTable
    {
        // dzien, opacjent, lekarz,(godzina rozpoczecia?)
        public DateTime? DataWizyty { get; set; }
        public int? IdPacjenta { get; set; }
        public string? ImieNazwiskoPacjenta { get; set; }
        public int? IdPracownika { get; set; }
        public string? ImieNazwiskoPracownika { get; set; }
        public int? IdPokoju { get; set; }
        public string? NumerPokoju { get; set; }

        public static explicit operator Wizyta(WizytaForView wizytaForView)
        {
            var result = new Wizyta().CopyProperties(wizytaForView);
            return result;
        }
        public static implicit operator WizytaForView(Wizyta wizyta)
        {
            var result = new WizytaForView().CopyProperties(wizyta);
            if (wizyta.Pracownik != null)
            {
                result.ImieNazwiskoPracownika = wizyta.Pracownik.Imie + " " + wizyta.Pracownik.Nazwisko;
            }
            if (wizyta.Pacjent != null)
            {
                result.ImieNazwiskoPacjenta = wizyta.Pacjent.Imie + " " + wizyta.Pacjent.Nazwisko;
            }
            return result;
        }
    }
}
