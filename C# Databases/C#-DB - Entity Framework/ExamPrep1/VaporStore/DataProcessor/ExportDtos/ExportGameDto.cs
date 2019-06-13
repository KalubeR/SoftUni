using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDtos
{
    [XmlType("Game")]
    public class ExportGameDto
    {
        [Required]
        [XmlAttribute("title")]
        public string Title { get; set; }

        [Required]
        [XmlElement]
        public string Genre { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        [XmlElement]
        public decimal Price { get; set; }
    }
}