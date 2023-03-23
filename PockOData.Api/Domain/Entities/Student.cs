using PockOData.Api.Domain.Entities.Base;

namespace PockOData.Api.Domain.Entities;

public class Student : BaseEntity
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public int SchoolYear { get; set; }
    public Guid ClassRoomId { get; set; }
    public ClassRoom? ClassRoom { get; set; }

}