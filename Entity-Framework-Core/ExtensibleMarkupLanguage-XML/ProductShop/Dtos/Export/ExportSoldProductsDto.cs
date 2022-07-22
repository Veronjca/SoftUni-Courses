using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Product")]
    public class ExportSoldProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }
    }
}
