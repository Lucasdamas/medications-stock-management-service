using MedicationsStoreAPI.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicationsStoreAPI.Database.Context
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<Medication> MedicationsStore { get; set; }
    }
}