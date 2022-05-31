using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class ExportPrisonerDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        [MinLength(3), MaxLength(20)]
        public string FullName { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        //TODO: Array or Element
        [XmlArray("EncryptedMessages")]
        public MessageDto[] Messages { get; set; }
    }
}
