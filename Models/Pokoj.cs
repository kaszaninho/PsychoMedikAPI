using PsychoMedikAPI.Models.Abstract;

namespace PsychoMedikAPI.Models
{
    public class Pokoj : DictionaryTable
    {
        public ICollection<Wizyta>? Wizyty { get; set; }
    }
}
