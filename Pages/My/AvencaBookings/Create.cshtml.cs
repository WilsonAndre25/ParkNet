using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkNet.Data;
using ParkNet.Data.Entities;
using ParkNet.Pages.Shared;

namespace ParkNet.Pages.My.AvencaBookings
{
    
        public class CreateModel : PageModelBase
    {
            private readonly ApplicationDbContext _context;

            public CreateModel(ApplicationDbContext context)
            {
                _context = context;
            }

            [BindProperty]
            public AvencaBooking AvencaBooking { get; set; } = default!;

            public IActionResult OnGet()
            {
            // Preenche DropDowns

                //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewData["SpotId"] = new SelectList(_context.ParkingSpots.Where(p => p.Busy == true), "Id", "Id");
                ViewData["ParkingLotId"] = new SelectList(_context.ParkingLots, "Id", "Name");

                return Page();
            }

            public async Task<IActionResult> OnPostAsync()
            {
                 if (!ModelState.IsValid)
                  { 
                   return Page();
                  }

                AvencaBooking.UserId = this.UserId;



                 // Obtem o ID do usuário autenticado
                 // var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            //  if (string.IsNullOrEmpty(userId))
            // {
            //   ModelState.AddModelError(string.Empty, "Usuário não autenticado.");
            //  return Page();
            // }

                _context.AvencaBookings.Add(AvencaBooking);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");


            }
        }

}
