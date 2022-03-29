using LMSGrupp3.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels.Student
{
    public class CurrentViewModel
    {
        public Entities.ActivityModel ActivityModel { get; set; }
        public Course Course { get; set; }


        public ICollection<CurrentAssignmentsViewModel> Assignments { get; set; }
        public Module Module { get; set; }
    }
}