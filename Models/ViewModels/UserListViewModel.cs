using LMSGrupp3.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace LMSGrupp3.Models.ViewModels
{
    public class UserListViewModel
    {
        public string UserId { get; set; }
       
        public string Name { get; set; }
        public string Email { get; set; }
        public Course Course{ get; set; }

        public bool IsTeacher { get; set; }



    }
}
