using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.My.AvencaBookings
{
    public class DetailsModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public DetailsModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public AvencaBooking AvencaBooking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avencabooking = await _context.AvencaBookings.FirstOrDefaultAsync(m => m.Id == id);

            if (avencabooking is not null)
            {
                AvencaBooking = avencabooking;

                return Page();
            }

            return NotFound();
        }
    }
}
