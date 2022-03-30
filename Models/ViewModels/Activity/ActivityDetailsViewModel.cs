using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMSGrupp3.Models.Entities;

namespace LMSGrupp3.Models.ViewModels.Activity
{
    public class ActivityDetailsViewModel
    {
        public Entities.ActivityModel ActivityModel { get; set; }
        public List<User> Students { get; set; }

    }
}
