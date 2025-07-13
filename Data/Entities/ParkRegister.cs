using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ParkNet.Data.Entities
{
    public class ParkRegister
    {
        [Key]
        public int Id { get; set; }
      

        public DateTime EntryTime { get; set; }          
        public DateTime? ExitTime { get; set; }


      
        public string UserId { get; set; }             
        public virtual ApplicationUser User { get; set; }


        public int SpotId { get; set; }                  
        public virtual ParkingSpot Spot { get; set; }


    }
}
