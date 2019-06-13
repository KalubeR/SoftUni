using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Projection")]
    public class ProjectionDto
    {
        [XmlElement]
        [Required]
        public int MovieId { get; set; }

        [XmlElement]
        [Required]
        public int HallId { get; set; }

        [XmlElement]
        [Required]
        public string DateTime{ get; set; }
    }
}
