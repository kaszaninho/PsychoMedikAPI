using System.ComponentModel.DataAnnotations;

namespace PsychoMedikAPI.Models.Abstract
{
    public class BaseDatatable
    {
        [Key]
        public int Id { get; set; }
        public bool CzyAktywny { get; set; }
        public DateTime? DataUtworzenia { get; set; } = DateTime.Now;
        public DateTime? DataModyfikacji { get; set; } = DateTime.Now;
    }
}