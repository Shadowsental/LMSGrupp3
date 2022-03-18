﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.Entities
{
	public class Course
{
	public int Id { get; set; }
	public string Name{ get; set; }
	public string Description { get; set; }
	public DateTime StartDate { get; set; }

		//NavProp
		public ICollection<Module> Modules { get; set; }
		public ICollection<User> Users { get; set; }
		public ICollection<Document> Documents { get; set; }

	}
}
