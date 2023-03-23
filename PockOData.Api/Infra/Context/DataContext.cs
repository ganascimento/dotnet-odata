using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PockOData.Api.Domain.Entities;
using PockOData.Api.Infra.Seeds;

namespace PockOData.Api.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var schoolIds = SchoolSeed.Seed(modelBuilder);
        var classRoomIds = ClassRoomSeed.Seed(modelBuilder, schoolIds);
        TeacherSeed.Seed(modelBuilder, classRoomIds);
        StudentSeed.Seed(modelBuilder, classRoomIds);
    }

    public DbSet<Student> Student { get; set; }
    public DbSet<School> School { get; set; }
    public DbSet<ClassRoom> ClassRoom { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
}