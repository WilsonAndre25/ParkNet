using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data.Entities;

namespace ParkNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }

        public DbSet <Floor> Floors { get; set; }
        public DbSet <ParkingLot> ParkingLots { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public  DbSet< Subscription> Subscriptions { get; set; }               
        public DbSet <ParkRegister> ParkRegisters { get; set; }
        public DbSet<AvencaBooking> AvencaBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(u => u.Balance)
                .HasColumnType("decimal(10,2)");

            builder.Entity<AvencaBooking>()
                .HasOne(b => b.ParkingSpot)
                .WithMany(p => p.AvencaBooking)
                .HasForeignKey(b => b.SpotId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AvencaBooking>()
                .HasOne(b => b.User)
                .WithMany() // Ou .WithMany(u => u.AvencaBookings) se quiser mapear no ApplicationUser
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AvencaBooking>()
                .HasOne(b => b.ParkingLot)
                .WithMany()
                .HasForeignKey(b => b.ParkingLotId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ParkingSpot>()
                .HasOne(p => p.Floor)
                .WithMany(f => f.ParkingSpot)
                .HasForeignKey(p => p.FloorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Floor>()
                .HasOne(f => f.ParkingLot)
                .WithMany(p => p.Floor)
                .HasForeignKey(f => f.ParkingLotId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<ParkRegister>()
               .HasOne(p => p.Spot)
               .WithMany()
               .HasForeignKey(p => p.SpotId)
               .OnDelete(DeleteBehavior.Restrict);  

            builder.Entity<ParkRegister>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ParkRegister>()
              .HasOne(pr => pr.User)
              .WithMany()
              .HasForeignKey(pr => pr.UserId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ParkRegister>()
                .HasOne(pr => pr.Spot)
                .WithMany(p => p.ParkRegisters)
                .HasForeignKey(pr => pr.SpotId)
                .OnDelete(DeleteBehavior.Restrict);


        }






    }
}
