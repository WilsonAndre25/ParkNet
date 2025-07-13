using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.My.Floors
{
    public class IndexModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public IndexModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Floor> Floor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Floor = await _context.Floors
                .Include(f => f.ParkingLot).ToListAsync();
        }
    }
}
