using Bogus;
using Microsoft.EntityFrameworkCore;
using PockOData.Api.Domain.Entities;

namespace PockOData.Api.Infra.Seeds;

public static class SchoolSeed
{
    public static List<Guid> Seed(ModelBuilder modelBuilder)
    {
        var faker = new Faker();
        var schoolIds = new List<Guid>();

        for (var i = 0; i < 4; i++)
        {
            var id = Guid.NewGuid();
            schoolIds.Add(id);

            modelBuilder.Entity<School>().HasData(
                new School
                {
                    Id = id,
                    Name = faker.Name.FullName(),
                    Street = faker.Address.StreetName(),
                    City = faker.Address.City(),
                    District = faker.Address.City(),
                    State = faker.Address.State()
                }
            );
        }

        return schoolIds;
    }
}