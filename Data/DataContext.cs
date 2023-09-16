using Microsoft.EntityFrameworkCore;
using SportsComplexWebAPI.Models;

namespace SportsComplexWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Administrator> Administrators => Set<Administrator>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<ClientSeasonTicket> ClientSeasonTickets => Set<ClientSeasonTicket>();
        public DbSet<ClientTraining> ClientTrainings => Set<ClientTraining>();
        public DbSet<Coach> Coaches => Set<Coach>();
        public DbSet<CoachContact> CoachContacts => Set<CoachContact>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<Gym> Gyms => Set<Gym>();
        public DbSet<SeasonTicket> SeasonTickets => Set<SeasonTicket>();
        public DbSet<Section> Sections => Set<Section>();
        public DbSet<Training> Trainings => Set<Training>();
        public DbSet<User> Users => Set<User>();
    }
}
