﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsimulation_i32vv1.Entities
{
    class DeathProbability
    {
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public double P { get; set; }
    }
}