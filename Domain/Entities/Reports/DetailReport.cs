﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Reports
{
    public class DetailReport
    {
        public string FullNameEmployee { get; set; }
        public string PositionEmployee { get; set; }
        public int NumberOfHour { get; set; }
        public bool Recycling { get; set; }
        public DateTime Date { get; set; }
        public string DescriptionWork { get; set; }
    }
}
