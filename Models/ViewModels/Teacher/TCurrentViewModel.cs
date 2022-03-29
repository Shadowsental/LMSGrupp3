using LMSGrupp3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels.Teacher
{
    public class TCurrentViewModel
    {
        public Entities.ActivityModel Activity { get; set; }
        public Course Course { get; set; }
        public ICollection<TAssignmentsViewModel> Assignments { get; set; }
        public Module Module { get; set; }
        public string Finished { get; set; }
        public DateTime DueDate { get; set; }
    }
}
