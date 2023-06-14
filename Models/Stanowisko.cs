using PsychoMedikAPI.Models.Abstract;

namespace PsychoMedikAPI.Models
{
    public class Stanowisko : DictionaryTable
    {
        // specjalizacja lekarza/pielegniarki w nazwie stanowiska(DictionaryTable)
        public ICollection<Pracownik>? Pracownicy { get; set; }

    }
}
