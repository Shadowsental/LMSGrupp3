using LMSGrupp3.Models.Entities;
using System.Collections.Generic;


namespace LMSGrupp3.Models.ViewModels
{
    public class ModuleDetailsViewModel
    {

        public Module Module { get; set; }
        public List<Entities.Document> Documents { get; set; }
        public Entities.ActivityModel ActivityModel { get; set; }
        public User AppUser { get; set; }
    }
}

