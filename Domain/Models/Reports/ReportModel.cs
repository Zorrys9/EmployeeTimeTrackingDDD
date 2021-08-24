﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Reports
{
    public class ReportModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfHour { get; set; }
        public int Recycling { get; set; }
        public string ReasonForRecycling { get; set; }
        public string DescriptionWork { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
