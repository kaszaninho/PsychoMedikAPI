using PsychoMedikAPI.Models.Abstract;

namespace PsychoMedikAPI.ViewModels
{
    public class HistoriaChorobyForView : DescriptionTable
    {
        public int? IdPacjenta { get; set; }
        public string? ImieNazwiskoPacjenta { get; set; }
        public int? IdChoroby { get; set; }
        public string? NazwaChoroby { get; set; }
        public int? IdPracownika { get; set; }
        public string? ImieNazwiskoPracownika { get; set; }
        public DateTime? DataZdiagnozowania { get; set; }
        public DateTime? DataWyleczenia { get; set; }
    }
}
