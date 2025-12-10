using Travel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Travel.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for all entities
        public DbSet<City> Cities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table names to lowercase
            modelBuilder.Entity<City>().ToTable("cities");
            modelBuilder.Entity<Hotel>().ToTable("hotels");
            modelBuilder.Entity<Reservation>().ToTable("reservations");
            modelBuilder.Entity<Payment>().ToTable("payments");
            modelBuilder.Entity<Review>().ToTable("reviews");
            modelBuilder.Entity<Favorite>().ToTable("favorites");
            modelBuilder.Entity<SearchHistory>().ToTable("search_history");

            // Configure City entity
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId);
                entity.Property(e => e.CityName).IsRequired();
            });

            // Configure Hotel entity
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(e => e.HotelId);
                entity.Property(e => e.Name).IsRequired();
               // entity.Property(e => e.Country).IsRequired();
                entity.Property(h => h.StarRating).HasPrecision(3, 1);

                // Configure relationship with City
                entity.HasOne(h => h.CityNavigation)
                    .WithMany(c => c.Hotels)
                    .HasForeignKey(h => h.CityId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Configure Reservation entity
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.ReservationId);
                
                // Configure relationship with User
                entity.HasOne(r => r.User)
                    .WithMany(u => u.Reservations)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                // Configure relationship with Hotel
                entity.HasOne(r => r.Hotel)
                    .WithMany(h => h.Reservations)
                    .HasForeignKey(r => r.HotelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Payment entity
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);
                
                // Configure relationship with Reservation
                entity.HasOne(p => p.Reservation)
                    .WithMany(r => r.Payments)
                    .HasForeignKey(p => p.ReservationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Review entity
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ReviewId);
                
                // Configure relationship with User
                entity.HasOne(r => r.User)
                    .WithMany(u => u.Reviews)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                // Configure relationship with Hotel
                entity.HasOne(r => r.Hotel)
                    .WithMany(h => h.Reviews)
                    .HasForeignKey(r => r.HotelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Favorite entity
            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => e.FavoriteId);
                
                // Configure relationship with User
                entity.HasOne(f => f.User)
                    .WithMany(u => u.Favorites)
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                // Configure relationship with Hotel
                entity.HasOne(f => f.Hotel)
                    .WithMany(h => h.Favorites)
                    .HasForeignKey(f => f.HotelId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                // Create unique constraint to prevent duplicate favorites
                entity.HasIndex(f => new { f.UserId, f.HotelId }).IsUnique();
            });

            // Configure SearchHistory entity
            modelBuilder.Entity<SearchHistory>(entity =>
            {
                entity.HasKey(e => e.SearchId);
                
                // Configure relationship with User
                entity.HasOne(s => s.User)
                    .WithMany(u => u.SearchHistories)
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
