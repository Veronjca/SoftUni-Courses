using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Footballer")]
    public class ExportFootballerWithCoachDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }
    }
}
