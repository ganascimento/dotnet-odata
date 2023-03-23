using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using PockOData.Api.Domain.Entities;
using PockOData.Api.Domain.Interfaces;
using PockOData.Api.Infra.Context;

namespace PockOData.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassRoomController : ODataController
{
    private IRepository<ClassRoom> _classRoomRepository;
    private DataContext _context;

    public ClassRoomController(IRepository<ClassRoom> classRoomRepository, DataContext context)
    {
        _classRoomRepository = classRoomRepository;
        _context = context;
    }

    [EnableQuery]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.ClassRoom);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ClassRoom model)
    {
        await _classRoomRepository.Create(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(ClassRoom model)
    {
        await _classRoomRepository.Update(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _classRoomRepository.Delete(id);
        return Ok();
    }
}