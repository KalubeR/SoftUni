﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Ticket")]
    public class TicketDto
    {
        [XmlElement]
        [Required]
        public int ProjectionId { get; set; }

        [XmlElement]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [Required]
        public decimal Price { get; set; }
    }
}
