using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDtos
{
    [XmlType("Purchase")]
    public class ExportPurchaseDto
    {
        [Required]
        [XmlElement]
        public string Card { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{3}$")]
        [XmlElement]
        public string Cvc { get; set; }

        [Required]
        [XmlElement]
        public string Date { get; set; }

        public ExportGameDto Game { get; set; }
    }
}