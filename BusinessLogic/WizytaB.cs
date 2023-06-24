using PsychoMedikAPI.Data;
using PsychoMedikAPI.ViewModels;

namespace PsychoMedikAPI.BusinessLogic
{
    public class WizytaB
    {
        public static async Task WalidujIWypelnijWizyte(WizytaForView wizyta, PsychoMedikAPIContext context)
        {
            if (context.Pracownik == null)
            {
                throw new Exception("Entity set 'PsychoMedikAPIContext.Pracownik'  is null.");
            }
            if (context.Pacjent == null)
            {
                throw new Exception("Entity set 'PsychoMedikAPIContext.Pacjent'  is null.");
            }
            if (string.IsNullOrEmpty(wizyta.ImieNazwiskoPracownika))
            {
                var pracownik = await context.Pracownik.FindAsync(wizyta.IdPracownika);
                if (pracownik == null)
                {
                    throw new Exception("Pracownik is null.");
                }
                wizyta.ImieNazwiskoPracownika = pracownik.Imie + " " + pracownik.Nazwisko;
            }
            if (string.IsNullOrEmpty(wizyta.ImieNazwiskoPacjenta))
            {
                var pacjent = await context.Pacjent.FindAsync(wizyta.IdPacjenta);
                if (pacjent == null)
                {
                    throw new Exception("Pacjent is null.");
                }
                wizyta.ImieNazwiskoPacjenta = pacjent.Imie + " " + pacjent.Nazwisko;
            }

        }
    }
}
