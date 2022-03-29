using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.ViewModels.Teacher
{
    public class TAssignmentsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Is Finished")]
        public double Finished { get; set; }
        [DisplayName("Due Time")]
        public DateTime DueTime { get; set; }
    }
}