using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkNet.Data.Entities
{


    public enum VehicleType { Carro,Moto }
    public class ParkingSpot

    {
        [Key]

        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public bool Booking { get; set; } = false;
        public bool Busy { get; set; } = false;

        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; }
        //public virtual ApplicationUser User { get; set; }
       
        public virtual ICollection<AvencaBooking> AvencaBooking { get; set; } = new List<AvencaBooking>();
        public virtual ICollection<ParkRegister> ParkRegisters { get; set; } = new List<ParkRegister>();

    }
}
