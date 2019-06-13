using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class CardDto
    {
        [Required]
        [RegularExpression(@"^[0-9]+ [0-9]+ [0-9]+ [0-9]+$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }
}