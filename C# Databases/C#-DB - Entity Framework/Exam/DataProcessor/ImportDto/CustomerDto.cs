using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class CustomerDto
    {
        [XmlElement]
        [Required]
        [MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [XmlElement]
        [Required]
        [MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [XmlElement]
        [Range(12, 110)]
        [Required]
        public int Age { get; set; }

        [XmlElement]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [Required]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public List<TicketDto> TicketDtos { get; set; }
    }
}
