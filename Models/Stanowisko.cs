using PsychoMedikAPI.Models.Abstract;

namespace PsychoMedikAPI.Models
{
    public class Stanowisko : DictionaryTable
    {
        public ICollection<Pracownik>? Pracownicy { get; set; }
    }
}
