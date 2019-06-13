using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class UsersDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUserAndProductDto[] Users { get; set; }
    }
}