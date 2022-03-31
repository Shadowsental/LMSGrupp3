using LMSGrupp3.Data;
using LMSGrupp3.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGupp3.Services
{
    public class SelectService : ISelectService
    {

        private ApplicationDbContext context;


        public SelectService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SelectListItem>> SelectCourses()
        {
            return await context.Course
                .OrderBy(c => c.Name)
                .Select(n =>
            new SelectListItem()
            {
                Text = n.Name,
                Value = n.Id.ToString()
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> SelectedModule(int? id)
        {
            return await context.Module
                .Where(n => n.Id == id)
                .Select(n =>
            new SelectListItem()
            {
                Text = n.Name,
                Value = n.Id.ToString(),
                Selected = true
            })
            .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> SelectedActivity(int? id)
        {
            return await context.ActivityModel
                .Where(n => n.Id == id)
                .Select(n =>
            new SelectListItem()
            {
                Text = n.Name,
                Value = n.Id.ToString(),
                Selected = true
            })
            .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> SelectActivityTypes()
        {
            return await context.ActivityType.Select(n =>
            new SelectListItem()
            {
                Text = n.Name,
                Value = n.Id.ToString()
            }).ToListAsync();
        }

        // Pre-select the course given as argument
        public async Task<IEnumerable<SelectListItem>> SelectCourseSetSelected(int? selected)
        {
            var selectList = await SelectCourses();
            if (selected == null)
            {
                return selectList;
            }
            var theSelected = selectList.Where(s => s.Value == selected.ToString()).FirstOrDefault();
            theSelected.Selected = true;
            return selectList;
        }
    }
}
