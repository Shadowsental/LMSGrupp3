﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels.Teacher
{
    public class TModuleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }
        public bool IsCurrentModule { get; set; }
    }
}
