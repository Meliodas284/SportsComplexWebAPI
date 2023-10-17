using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Administrator> Administartors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<PurchasedSubscription> PurchasedSubscriptions { get; set; }
    }
}
