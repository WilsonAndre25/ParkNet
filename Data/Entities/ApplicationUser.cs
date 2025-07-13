using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ParkNet.Data.Entities
{

  
    public  class ApplicationUser : IdentityUser 
    {
        [Required]
        public string DrivingLicense { get; set; }
        [Required]
        public string CreditCard { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Balance { get; set; }
        public List<Subscription> Subscriptions { get; set; } = new();
        public List<ParkingLot> ParkingHistory { get; set; } = new();
        public string UserType => "Client";

    }
}
