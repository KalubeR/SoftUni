using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ImportDtos
{
    [XmlType("Purchase")]
    public class PurchaseDto
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [XmlElement]
        [Required]
        public string Type { get; set; }

        [XmlElement]
        [Required]
        [RegularExpression(@"^[A-Z0-9]+-[A-Z0-9]+-[A-Z0-9]+$")]
        public string Key { get; set; }

        [XmlElement]
        [Required]
        public string Card { get; set; }

        [XmlElement]
        [Required]
        public string Date { get; set; }
    }
}