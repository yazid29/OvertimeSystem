using API.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("role")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _service;

    public RoleController(IRoleService roleService)
    {
        _service = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var results = await _service.GetAllAsync();

        if (!results.Any())
        {
            return NotFound("Data Not Found"); // Data Not Found
        }

        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result is null)
        {
            return NotFound("Data Not Found"); // Data Not Found
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(Role entity)
    {
        var result = await _service.CreateAsync(entity);

        return Ok("Role Created");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, Role entity)
    {
        var result = await _service.UpdateAsync(id, entity);

        if (result == 0)
        {
            return NotFound("Id not found!");
        }

        return Ok("Role Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _service.DeleteAsync(id);

        if (result == 0)
        {
            return NotFound("Id not found!");
        }

        return Ok("Role Deleted");
    }
}