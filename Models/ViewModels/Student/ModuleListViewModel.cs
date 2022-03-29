﻿using LMSGrupp3.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels.Student
{
    public class ModuleListViewModel
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
