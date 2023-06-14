using PsychoMedikAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychoMedikAPI.ViewModels
{
    public class HarmonogramForView : BaseDatatable
    {
        public int? IdPracownika { get; set; }
        public string? ImieNazwiskoPracownika { get; set; }
        public int? DzienRoku { get; set; }
        public int? GodzinaRozpoczecia { get; set; }
        public int? GodzinaZakonczenia { get; set; }

    }
}
