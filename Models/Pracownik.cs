using PsychoMedikAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychoMedikAPI.Models
{
    public class Pracownik : DescriptionTable
    {
        public string Imie{ get; set; }
        public string Nazwisko{ get; set; }
        public DateTime DataUrodzenia{ get; set; }
        public DateTime DataZatrudnienia{ get; set; }
        public DateTime? DataRezygnacji { get; set; }    
        public bool Plec { get; set; }
        public string StanCywilny{ get; set; }
            // placa moze bedzie tutaj wykorzystywana
        public int? IdStanowiska { get; set; }
        [ForeignKey("IdStanowiska")]
        public virtual Stanowisko? Stanowisko { get; set; }
        public ICollection<Pacjent>? Pacjenci { get; set; }
        public ICollection<Harmonogram>? Harmonogram { get; set; }
        // public int? Doswiadczenie { get; set; } - dodatkowy field wyswietlany podczas prezentacji
        // szczegolow pracownika

    }
}
