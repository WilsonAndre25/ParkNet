using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.My.AvencaBookings
{
    public class EditModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public EditModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AvencaBooking AvencaBooking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avencabooking =  await _context.AvencaBookings.FirstOrDefaultAsync(m => m.Id == id);
            if (avencabooking == null)
            {
                return NotFound();
            }
            AvencaBooking = avencabooking;
           ViewData["ParkingLotId"] = new SelectList(_context.ParkingLots, "Id", "Name");
           ViewData["SpotId"] = new SelectList(_context.ParkingSpots, "Id", "Id");
           ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AvencaBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvencaBookingExists(AvencaBooking.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AvencaBookingExists(int id)
        {
            return _context.AvencaBookings.Any(e => e.Id == id);
        }
    }
}
