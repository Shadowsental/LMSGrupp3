using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LMSGrupp3.Models.Entities
{
	public class Course
{
		[Key]
		[Required]
		public int Id { get; set; }
		public string Name { get; set; }
	public string Description { get; set; }
	public DateTime StartDate { get; set; }

		//NavProp
		public ICollection<Module> Modules { get; set; }
		public ICollection<UserCourse> Users { get; set; }
		
	}
}
