using PsychoMedikAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychoMedikAPI.Models
{
    public class Harmonogram : BaseDatatable
    {
        public int? IdPracownika { get; set; }
        [ForeignKey("IdPracownika")]
        public virtual Pracownik? Pracownik{ get; set; }
        public DateTime? DataPracy { get; set; }
        public int? GodzinaRozpoczecia { get; set; }
        public int? GodzinaZakonczenia { get; set; }

    }
}
