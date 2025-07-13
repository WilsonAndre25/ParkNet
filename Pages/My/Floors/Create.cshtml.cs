using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.My.Floors
{
    public class CreateModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public CreateModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ParkingLotId"] = new SelectList(_context.ParkingLots, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Floor Floor { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Floors.Add(Floor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
