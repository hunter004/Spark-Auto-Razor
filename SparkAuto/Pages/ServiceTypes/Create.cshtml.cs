using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SparkAuto.Data;
using SparkAuto.Models;

namespace SparkAuto.Pages.ServiceTypes
{
    public class CreateModel : PageModel
    {
        //db instanc
        private readonly ApplicationDbContext _db;

        //add the service type to use in all create pieces - bind property so it won't be needed explicitly passed
        [BindProperty]
        public ServiceType ServiceType { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            //no retriving here, so just return the page
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //expecting servicetype on the post - server side validation
            if (!ModelState.IsValid)
            {
                //invalid model ~missing required fields~ returns the page
                return Page();
            }

            //add servicetype & save changes to db
            _db.ServiceType.Add(ServiceType);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}