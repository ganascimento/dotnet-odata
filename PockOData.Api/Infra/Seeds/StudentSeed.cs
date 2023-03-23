using Bogus;
using Microsoft.EntityFrameworkCore;
using PockOData.Api.Domain.Entities;

namespace PockOData.Api.Infra.Seeds;

public static class StudentSeed
{
    public static void Seed(ModelBuilder modelBuilder, List<Guid> classRoomIds)
    {
        var faker = new Faker();

        classRoomIds.ForEach(classRoomId =>
        {
            for (var i = 0; i < 20; i++)
            {
                modelBuilder.Entity<Student>().HasData(
                    new Student
                    {
                        Id = Guid.NewGuid(),
                        Name = faker.Name.FullName(),
                        BirthDate = faker.Date.Between(new DateTime(2010, 1, 1), new DateTime(2023, 1, 1)),
                        SchoolYear = faker.Random.Number(8) + 1,
                        ClassRoomId = classRoomId
                    }
                );
            }
        });
    }
}