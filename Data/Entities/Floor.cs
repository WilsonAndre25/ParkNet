using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace ParkNet.Data.Entities
{


   
   
    public class Floor

    {
        
        [Key]
       public int Id { get; set; }
        public int  FloorNumber { get; set; }
       

        [ForeignKey("ParkingLotId")]
        public int ParkingLotId { get; set; }
        public virtual ParkingLot ParkingLot { get; set; }

        public virtual ICollection<ParkingSpot> ParkingSpot { get; set; }

    }
}
