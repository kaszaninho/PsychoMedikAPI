using PsychoMedikAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychoMedikAPI.Models
{
    public class HistoriaChoroby : DescriptionTable
    {
        public int? IdPacjenta { get; set; }
        [ForeignKey("IdPacjenta")]
        public virtual Pacjent? Pacjent { get; set; }

        public int? IdChoroby { get; set; }
        [ForeignKey("IdChoroby")]
        public virtual Choroba? Choroba { get; set; }
        public int? IdPracownika { get; set; }
        [ForeignKey("IdPracownika")]
        public virtual Pracownik? Pracownik { get; set; }
        public DateTime? DataZdiagnozowania { get; set; }
        public DateTime? DataWyleczenia { get; set; }

    }
}
