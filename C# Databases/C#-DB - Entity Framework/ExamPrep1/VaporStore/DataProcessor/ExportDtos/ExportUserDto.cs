using System.Collections.Generic;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDtos
{
    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public List<ExportPurchaseDto> PurchaseDtos { get; set; }

        [XmlElement]
        public decimal TotalSpent { get; set; }
    }
}