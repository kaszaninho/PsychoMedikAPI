using PsychoMedikAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychoMedikAPI.Models
{
    public class Pacjent : DescriptionTable
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public bool Plec { get; set; }
        public int? IdPracownika { get; set; }
        [ForeignKey("IdPracownika")]
        public virtual Pracownik? Pracownik { get; set; }
        public ICollection<HistoriaChoroby>? HistoriaChoroby{ get; set; }

    }
}
