using Bogus;
using Microsoft.EntityFrameworkCore;
using PockOData.Api.Domain.Entities;

namespace PockOData.Api.Infra.Seeds;

public static class ClassRoomSeed
{
    public static List<Guid> Seed(ModelBuilder modelBuilder, List<Guid> schoolIds)
    {
        var faker = new Faker();
        var classRoomIds = new List<Guid>();

        schoolIds.ForEach(schoolId =>
        {
            for (var i = 0; i < 3; i++)
            {
                var id = Guid.NewGuid();
                classRoomIds.Add(id);
                modelBuilder.Entity<ClassRoom>().HasData(
                    new ClassRoom
                    {
                        Id = id,
                        Name = $"Room {faker.Random.Number(25)}",
                        SchoolId = schoolId
                    }
                );
            }
        });

        return classRoomIds;
    }
}