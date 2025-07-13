using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.My.ParkingSpots
{
    public class DeleteModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public DeleteModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ParkingSpot ParkingSpot { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingspot = await _context.ParkingSpots.FirstOrDefaultAsync(m => m.Id == id);

            if (parkingspot is not null)
            {
                ParkingSpot = parkingspot;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingspot = await _context.ParkingSpots.FindAsync(id);
            if (parkingspot != null)
            {
                ParkingSpot = parkingspot;
                _context.ParkingSpots.Remove(ParkingSpot);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
