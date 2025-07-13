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
    public class IndexModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public IndexModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AvencaBooking> AvencaBooking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AvencaBooking = await _context.AvencaBookings
                .Include(a => a.ParkingLot)
                .Include(a => a.ParkingSpot)
                .Include(a => a.User).ToListAsync();
        }
    }
}
