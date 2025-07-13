using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;

using ParkNet.Data.Entities;

 
namespace ParkNet.Pages.My.Subscriptions
{

        //[Authorize(Roles = "Client")]
        public class IndexModel : PageModel
        {
            //private readonly UserManager<ApplicationUser> _userManager;
            private readonly ApplicationDbContext _context;

            public IndexModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
            {
                
                _context = context;
            }

            [BindProperty]
            public AvencaInputModel Input { get; set; }
             public List<Subscription> Subscriptions { get; set; }
            public List<ParkingLot> ParkingLots { get; set; }
            public List<ParkingSpot> AvailableSpots { get; set; }

            public class AvencaInputModel
            {
                [Required]
                public int ParkingLotId { get; set; }
                public int SpotId { get; set; }
                public TypeBalance TypeBalance { get; set; }
            }
            public async Task<IActionResult> OnGetAsync()
            {
            Input = new AvencaInputModel();

            ParkingLots = _context.ParkingLots.ToList();
                AvailableSpots = _context.ParkingSpots
                    .Where(s => s.Busy) 
                    .ToList();
                return Page();
            }


     




        public async Task<IActionResult> OnPostAsync()
            {    //Input = new AvencaInputModel();
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (!ModelState.IsValid || string.IsNullOrEmpty(userId))
                {
                    await OnGetAsync();
                    return Page();
                }

                var duration = Input.TypeBalance switch
                {
                    TypeBalance.Mensal => TimeSpan.FromDays(30),
                    TypeBalance.Trimestral => TimeSpan.FromDays(90),
                    TypeBalance.Semestral => TimeSpan.FromDays(180),
                    TypeBalance.Anual => TimeSpan.FromDays(365),
                    _ => TimeSpan.FromDays(30)
                };

                var booking = new AvencaBooking
                {
                    UserId = userId,
                    SpotId = Input.SpotId,
                    ParkingLotId = Input.ParkingLotId,
                    TypeBalance = Input.TypeBalance,
                    EntryDate = DateTime.Now,
                    ExitDate = DateTime.Now.Add(duration)
                };

                // Marcar lugar como reservado
                var spot = await _context.ParkingSpots.FindAsync(Input.SpotId);
                if (spot != null)
                {
                    spot.Busy = false;
                }

                _context.AvencaBookings.Add(booking);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Subscriptions/MySubscriptions");
            }
        } 
}