using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleWebApplication.Data;
using SampleWebApplication.Models;

namespace SampleWebApplication.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly SampleWebApplication.Data.ApplicationDbContext _context;

        public DeleteModel(SampleWebApplication.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);

            if (order != null)
            {
                Order = order;
                _context.Order.Remove(Order);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
