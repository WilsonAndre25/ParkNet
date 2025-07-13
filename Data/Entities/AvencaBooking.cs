using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ParkNet.Data.Entities
{
    
    
    public enum TypeBalance {Mensal,Trimestral, Semestral, Anual }

    public class AvencaBooking
    {
        
        public int Id { get; set; }
        public TypeBalance TypeBalance { get; set; }
        // FKs
        [Required]
       
        [Column(TypeName = "Datetime2(0)")]
        public DateTime EntryDate { get; set; }

        [Column(TypeName = "Datetime2(0)")]
        public DateTime ExitDate { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual  ApplicationUser User { get; set; }
    
        [ForeignKey("ParkingSpot")]
        public int SpotId { get; set; }
        public virtual ParkingSpot ParkingSpot { get; set; }

        [ForeignKey("ParkingLot")]
        public int ParkingLotId { get; set; }
        public virtual ParkingLot ParkingLot { get; set; }



    }
}
