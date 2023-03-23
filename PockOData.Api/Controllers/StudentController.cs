using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using PockOData.Api.Domain.Entities;
using PockOData.Api.Domain.Interfaces;
using PockOData.Api.Infra.Context;

namespace PockOData.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ODataController
{
    private IRepository<Student> _studentRepository;
    private DataContext _context;

    public StudentController(IRepository<Student> studentRepository, DataContext context)
    {
        _studentRepository = studentRepository;
        _context = context;
    }

    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_context.Student);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student model)
    {
        await _studentRepository.Create(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Student model)
    {
        await _studentRepository.Update(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _studentRepository.Delete(id);
        return Ok();
    }
}