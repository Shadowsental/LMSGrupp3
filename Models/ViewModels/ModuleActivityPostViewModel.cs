﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels
{
    public class ModuleActivityPostViewModel
    {
        public IEnumerable<ActivityPostViewModel> Data { get; set; }
        public ModulePostViewModel Module { get; set; }
    }
}