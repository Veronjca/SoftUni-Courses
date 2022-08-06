using System;
using System.Collections.Generic;
using System.Text;

namespace Footballers.DataProcessor.ExportDto
{
    public class ExportTeamDto
    {
        public string Name { get; set; }

        public List<ExportFootballerDto> Footballers { get; set; }
    }
}
