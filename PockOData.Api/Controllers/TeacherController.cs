using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using PockOData.Api.Domain.Entities;
using PockOData.Api.Domain.Interfaces;
using PockOData.Api.Infra.Context;

namespace PockOData.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ODataController
{
    private IRepository<Teacher> _teacherRepository;
    private DataContext _context;

    public TeacherController(IRepository<Teacher> teacherRepository, DataContext context)
    {
        _teacherRepository = teacherRepository;
        _context = context;
    }

    [EnableQuery]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Teacher);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Teacher model)
    {
        await _teacherRepository.Create(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Teacher model)
    {
        await _teacherRepository.Update(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _teacherRepository.Delete(id);
        return Ok();
    }
}