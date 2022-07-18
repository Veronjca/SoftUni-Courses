using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Category")]
    public class CategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
