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

namespace ParkNet.Pages.My.ParkRegisters
{
    public class EditModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public EditModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ParkRegister ParkRegister { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkregister =  await _context.ParkRegisters.FirstOrDefaultAsync(m => m.Id == id);
            if (parkregister == null)
            {
                return NotFound();
            }
            ParkRegister = parkregister;
           ViewData["SpotId"] = new SelectList(_context.ParkingSpots, "Id", "Id");
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
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

            _context.Attach(ParkRegister).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkRegisterExists(ParkRegister.Id))
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

        private bool ParkRegisterExists(int id)
        {
            return _context.ParkRegisters.Any(e => e.Id == id);
        }
    }
}
