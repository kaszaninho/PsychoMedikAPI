using PsychoMedikAPI.Models;
using PsychoMedikAPI.ViewModels;
using PsychoMedikApp.Helpers;

namespace PsychoMedikAPI.BusinessLogic
{
    public static class ConvertB
    {
        public static PracownikForView ConvertPracownikToPracownikForView(Pracownik pracownik)
        {
            return new PracownikForView
            {
                NazwaStanowisko = pracownik?.Stanowisko?.Nazwa ?? string.Empty,
            }.CopyProperties(pracownik);
        }
        public static HistoriaChorobyForView ConvertHistoriaChorobyToHistoriaChorobyForView(HistoriaChoroby historiaChoroby)
        {
            return new HistoriaChorobyForView
            {
                ImieNazwiskoPracownika = historiaChoroby?.Pracownik?.Imie + historiaChoroby?.Pracownik?.Nazwisko ?? string.Empty,
                ImieNazwiskoPacjenta = historiaChoroby?.Pacjent?.Imie + historiaChoroby?.Pacjent?.Nazwisko ?? string.Empty,
                NazwaChoroby = historiaChoroby?.Choroba?.Nazwa ?? string.Empty
            }.CopyProperties(historiaChoroby);
        }
        public static HarmonogramForView ConvertHarmonogramToHarmonogramForView(Harmonogram harmonogram)
        {
            return new HarmonogramForView
            {
                ImieNazwiskoPracownika = harmonogram?.Pracownik?.Imie + harmonogram?.Pracownik?.Nazwisko ?? string.Empty
            }.CopyProperties(harmonogram);
        }
        public static PacjentForView ConvertPacjentToPacjentForView(Pacjent pacjent)
        {
            return new PacjentForView
            {
                ImieNazwiskoPracownikaProwadzacego = pacjent?.Pracownik?.Imie + pacjent?.Pracownik?.Nazwisko ?? string.Empty
            }.CopyProperties(pacjent);
        }
        public static WizytaForView ConvertWizytaToWizytaForView(Wizyta wizyta)
        {
            return new WizytaForView
            {
                ImieNazwiskoPacjenta = wizyta?.Pacjent?.Imie + wizyta?.Pacjent?.Nazwisko ?? string.Empty,
                ImieNazwiskoPracownika = (wizyta?.Pracownik?.Imie + " " + wizyta?.Pracownik?.Nazwisko) ?? string.Empty,
                NumerPokoju = wizyta?.Pokoj?.Nazwa ?? string.Empty,
            }.CopyProperties(wizyta);
        }
    }
}

