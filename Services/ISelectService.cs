﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMSGrupp3.Services
{
    public interface ISelectService
    {
        Task<IEnumerable<SelectListItem>> SelectCourses();
        Task<IEnumerable<SelectListItem>> SelectActivityTypes();
        Task<IEnumerable<SelectListItem>> SelectCourseSetSelected(int? selected);
        Task<IEnumerable<SelectListItem>> SelectedModule(int? id);
        Task<IEnumerable<SelectListItem>> SelectedActivity(int? id);
    }
}
