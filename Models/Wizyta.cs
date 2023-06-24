using PsychoMedikAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychoMedikAPI.Models
{
    public class Wizyta : DescriptionTable
    {
        public DateTime? DataWizyty { get; set; }
        public int? IdPacjenta { get; set; }
        [ForeignKey("IdPacjenta")]
        public virtual Pacjent? Pacjent { get; set; }
        public int? IdPracownika { get; set; }
        [ForeignKey("IdPracownika")]
        public virtual Pracownik? Pracownik { get; set; }
        public int? IdPokoju { get; set; }
        [ForeignKey("IdPokoju")]
        public virtual Pokoj? Pokoj { get; set; }
    }
}
