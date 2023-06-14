using System.ComponentModel.DataAnnotations;

namespace PsychoMedikAPI.Models.Abstract
{
    public class DictionaryTable : DescriptionTable
    {
        [Required(ErrorMessage = "Wpisz Nazwe!")]
        public string Nazwa { get; set; } = null!;
    }
}
