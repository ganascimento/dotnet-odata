using PockOData.Api.Domain.Entities.Base;

namespace PockOData.Api.Domain.Entities;

public class School : BaseEntity
{
    public string Name { get; set; }
    public string Street { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public IEnumerable<ClassRoom>? ClassRooms { get; set; }
}