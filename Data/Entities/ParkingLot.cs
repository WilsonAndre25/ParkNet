using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ParkNet.Data.Entities
{
    public class ParkingLot
    {
        [Key]
        public int Id { get; set; }
     

        [Required]
        public string Name { get; set; }  
        public string FloorName { get; set; }
        public int FloorNumber { get; set; }
       
       public virtual ICollection<Floor> Floor { get; set; }

    }
}
