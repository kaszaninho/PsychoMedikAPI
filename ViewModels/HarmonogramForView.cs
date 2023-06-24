using PsychoMedikAPI.Models.Abstract;

namespace PsychoMedikAPI.ViewModels
{
    public class HarmonogramForView : BaseDatatable
    {
        public int? IdPracownika { get; set; }
        public string? ImieNazwiskoPracownika { get; set; }
        public DateTime? DataPracy { get; set; }
        public int? GodzinaRozpoczecia { get; set; }
        public int? GodzinaZakonczenia { get; set; }
    }
}
