using Microsoft.EntityFrameworkCore;

namespace ShelterApi.Models
{
    public class ShelterApiContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public ShelterApiContext(DbContextOptions<ShelterApiContext> options) : base(options)
        {
        }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Pet>()
            .HasData(
            new Pet { PetId = 1, Name = "Leonard", Species = "Ball Python", Age = 3 }
            );
    }

        internal object GetPets(PagedParameters petParameters)
        {
            throw new NotImplementedException();
        }
    }
}