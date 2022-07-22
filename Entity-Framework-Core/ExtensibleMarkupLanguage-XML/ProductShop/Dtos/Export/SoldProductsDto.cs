using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    public class SoldProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<ExportSoldProductsDto> Products { get; set; }
    }
}
