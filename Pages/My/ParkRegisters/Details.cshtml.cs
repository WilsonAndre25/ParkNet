using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.My.ParkRegisters
{
    public class DetailsModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public DetailsModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ParkRegister ParkRegister { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkregister = await _context.ParkRegisters.FirstOrDefaultAsync(m => m.Id == id);

            if (parkregister is not null)
            {
                ParkRegister = parkregister;

                return Page();
            }

            return NotFound();
        }
    }
}
