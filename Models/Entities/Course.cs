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

		[Required]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Course Description")]
		public string Description { get; set; }

		[Display(Name = "Startdatum")]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }


		[Display(Name = "Modules")]
		public ICollection<Module> Modules { get; set; }

		[Display(Name = "User")]
		public ICollection<UserCourse> Users { get; set; }
		
	}
}
