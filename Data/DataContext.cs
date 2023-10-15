using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        DbSet<User> Users { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Coach> Coaches { get; set; }
        DbSet<Administrator> Administartors { get; set; }
        DbSet<Section> Sections { get; set; }
        DbSet<Gym> Gyms { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<PurchasedSubscription> PurchasedSubscriptions { get; set; }
    }
}
