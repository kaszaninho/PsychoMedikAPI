using PsychoMedikAPI.Models.Abstract;

namespace PsychoMedikAPI.Models
{
    public class Choroba : DictionaryTable
    {
        public ICollection<Objaw>? Objawy { get; set; }
        public ICollection<HistoriaChoroby>? HistoriaChorob{ get; set; }

    }
}
