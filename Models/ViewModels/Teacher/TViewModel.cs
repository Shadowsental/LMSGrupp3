using LMSGrupp3.Models.Entities;
using LMSGrupp3.Models.ViewModels.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels.Teacher
{
    public class TViewModel
    {
        //public Course Course { get; set; }
        public TCurrentViewModel Current { get; set; }
        public IEnumerable<TAssignmentListViewModel> AssignmentList { get; set; }
        public IEnumerable<TModuleViewModel> ModuleList { get; set; }
        public IEnumerable<ActivityListViewModel> ActivityList { get; set; }
    }
}