using PsychoMedikAPI.Models.Abstract;

namespace PsychoMedikAPI.Models
{
    public class Objaw : DictionaryTable
    {
        public ICollection<Choroba>? Choroby { get; set; }
    }
}
