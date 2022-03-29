﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels.Student
{
    public class CurrentAssignmentsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Is Finished")]
        public bool? IsFinished { get; set; }
        [DisplayName("Due Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DueTime { get; set; }
    }
}