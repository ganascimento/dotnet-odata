using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using PockOData.Api.Domain.Entities;
using PockOData.Api.Domain.Interfaces;
using PockOData.Api.Infra.Context;

namespace PockOData.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SchoolController : ODataController
{
    private IRepository<School> _schoolRepository;
    private DataContext _context;

    public SchoolController(IRepository<School> schoolRepository, DataContext context)
    {
        _schoolRepository = schoolRepository;
        _context = context;
    }

    [EnableQuery]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.School);
    }

    [HttpPost]
    public async Task<IActionResult> Create(School model)
    {
        await _schoolRepository.Create(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(School model)
    {
        await _schoolRepository.Update(model);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Update(Guid id)
    {
        await _schoolRepository.Delete(id);
        return Ok();
    }
}