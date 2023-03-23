using PockOData.Api.Domain.Entities.Base;

namespace PockOData.Api.Domain.Entities;

public class ClassRoom : BaseEntity
{
    public string Name { get; set; }
    public Guid SchoolId { get; set; }
    public School School { get; set; }
    public IEnumerable<Teacher> Teachers { get; set; }
    public IEnumerable<Student> Students { get; set; }
}