using PsychoMedikAPI.Data;
using PsychoMedikAPI.ViewModels;

namespace PsychoMedikAPI.BusinessLogic
{
    public class HistoriaChorobyB
    {
        public static async Task WalidujIWypelnijHistorie(HistoriaChorobyForView historia, PsychoMedikAPIContext context)
        {
            if (context.Pracownik == null)
            {
                throw new Exception("Entity set 'PsychoMedikAPIContext.Pracownik'  is null.");
            }
            if (context.Pacjent == null)
            {
                throw new Exception("Entity set 'PsychoMedikAPIContext.Pacjent'  is null.");
            }
            if (context.Choroba == null)
            {
                throw new Exception("Entity set 'PsychoMedikAPIContext.Pacjent'  is null.");
            }
            if (string.IsNullOrEmpty(historia.ImieNazwiskoPracownika))
            {
                var pracownik = await context.Pracownik.FindAsync(historia.IdPracownika);
                if (pracownik == null)
                {
                    throw new Exception("Pracownik is null.");
                }
                historia.ImieNazwiskoPracownika = pracownik.Imie + " " + pracownik.Nazwisko;
            }
            if (string.IsNullOrEmpty(historia.NazwaChoroby))
            {
                var choroba = await context.Choroba.FindAsync(historia.IdChoroby);
                if (choroba == null)
                {
                    throw new Exception("Choroba is null.");
                }
                historia.NazwaChoroby = choroba.Nazwa;
            }
            if (string.IsNullOrEmpty(historia.ImieNazwiskoPacjenta))
            {
                var pacjent = await context.Pacjent.FindAsync(historia.IdPacjenta);
                if (pacjent == null)
                {
                    throw new Exception("Pacjent is null.");
                }
                historia.ImieNazwiskoPacjenta = pacjent.Imie + " " + pacjent.Nazwisko;
            }

        }
    }
}
