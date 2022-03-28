using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.Entities
{
	public class ActivityType
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Required]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "Description")]
		public string Description { get; set; }
		
		
	}
}
