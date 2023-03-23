using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PockOData.Api.Domain.Entities.Base;

namespace PockOData.Api.Domain.Entities;

public class Teacher : BaseEntity
{
    public string Name { get; set; }
    public string Subject { get; set; }
    public DateTime BirthDate { get; set; }
    public Guid ClassRoomId { get; set; }
    public ClassRoom ClassRoom { get; set; }
}