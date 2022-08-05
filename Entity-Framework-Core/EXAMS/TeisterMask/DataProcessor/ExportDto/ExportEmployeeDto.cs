using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
   public class ExportEmployeeDto
    {
        public string Username { get; set; }

        public List<ExportTaskDto> Tasks { get; set; }
    }
}
