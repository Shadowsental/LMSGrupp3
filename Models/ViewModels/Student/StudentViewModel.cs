using LMSGrupp3.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels.Student
{
    public class StudentViewModel
    {
       public IEnumerable<AssignmentListViewModel>? AssignmentList { get; set; }
        public IEnumerable<ModuleListViewModel>? ModuleList { get; set; }
        public IEnumerable<ActivityListViewModel>? ActivityList { get; set; }
        public User User { get; set; }
        public CurrentViewModel CurrentViewModel { get; set; }
    }
}
