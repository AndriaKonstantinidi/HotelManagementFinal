using Microsoft.EntityFrameworkCore;
using HotelManagement.Room;
using HotelManagement.Booking;
using HotelManagement.Payment;

namespace HotelManagement.Guest
{
    public class GuestsDbContext :DbContext
    {
        public GuestsDbContext(DbContextOptions<GuestsDbContext> options)
          : base(options)
        {

        }

        public DbSet<Guests> Guest { get; set; }
        public DbSet<Rooms> Room { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Payments> Payment { get; set; }
    }
}
