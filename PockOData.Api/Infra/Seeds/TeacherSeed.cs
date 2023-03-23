using Bogus;
using Microsoft.EntityFrameworkCore;
using PockOData.Api.Domain.Entities;

namespace PockOData.Api.Infra.Seeds;

public static class TeacherSeed
{
    private static List<string> Subjects = new List<string>{
        "English",
        "Math",
        "History",
        "Geography",
        "Sciences"
    };

    public static void Seed(ModelBuilder modelBuilder, List<Guid> classRoomIds)
    {
        var faker = new Faker();


        classRoomIds.ForEach(classRoomId =>
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = Guid.NewGuid(),
                    Name = faker.Name.FullName(),
                    BirthDate = faker.Date.Between(new DateTime(1970, 1, 1), new DateTime(2000, 1, 1)),
                    Subject = Subjects[faker.Random.Number(4)],
                    ClassRoomId = classRoomId
                }
            );
        });
    }
}