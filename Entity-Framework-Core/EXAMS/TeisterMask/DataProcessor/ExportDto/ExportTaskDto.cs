﻿using System;
using System.Collections.Generic;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ExportDto
{
   public class ExportTaskDto
    {
        public string TaskName { get; set; }

        public string OpenDate { get; set; }

        public string DueDate { get; set; }

        public string LabelType { get; set; }
        public string ExecutionType { get; set; }

        
    }
}
