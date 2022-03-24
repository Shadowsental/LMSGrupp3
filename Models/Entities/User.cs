﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LMSGrupp3.Models.Entities
{
	public class User : IdentityUser
{

		public string Name { get; set; }

		public ICollection<UserCourse> Courses { get; set; }
		
		

	}
}
