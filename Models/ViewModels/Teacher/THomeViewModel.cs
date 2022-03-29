using System;
using System.Collections.Generic;
using LMSGrupp3.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels.Teacher
{
    public class THomeViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}
