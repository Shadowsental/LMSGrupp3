using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMSGrupp3.Models.Entities
{
	public class Module
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public DateTime StartTime { get; set; }
	public DateTime EndTime { get; set; }

		//NavProp
		public Course Course { get; set; }
		public ICollection<ActivityModel> ModuleActivities { get; set; }
		

		//FK
		public int CourseId { get; set; }


	}
}