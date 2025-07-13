using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ParkNet.Data.Entities
{

   
    public class Subscription

    {

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }


    }
}
