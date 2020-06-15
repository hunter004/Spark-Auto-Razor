using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.Pages.ServiceTypes
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            //constructor using dependency injection
            _db = db;
        }

        //type to retrieve from database
        public IList<ServiceType> ServiceType { get; set; }

        public async Task<IActionResult> OnGet()
        {
            //retrieve service types from the db
            //using Async method provided by .NET core
            ServiceType = await _db.ServiceType.ToListAsync();

            //retrieve service types and return the page
            return Page();
        }
    }
}