using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("ContractStartDate")]
        public string ContractStartDate { get; set; }

        [Required]
        [XmlElement("ContractEndDate")]
        public string ContractEndDate { get; set; }

        [Required]
        [XmlElement("PositionType")]
        public int PositionType { get; set; }

        [Required]
        [XmlElement("BestSkillType")]
        public int BestSkillType { get; set; }
    }
}
