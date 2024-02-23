using API.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("overtime")]
public class OvertimeController : ControllerBase
{
    private readonly IOvertimeService _aService;

    public OvertimeController(IOvertimeService overtimeService)
    {
        _aService = overtimeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var results = await _aService.GetAllAsync();

        if (!results.Any())
        {
            return NotFound("Data Not Found"); // Data Not Found
        }

        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _aService.GetByIdAsync(id);

        if (result is null)
        {
            return NotFound("Data Not Found"); // Data Not Found
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(Overtime entity)
    {
        var result = await _aService.CreateAsync(entity);

        return Ok("Overtime Created");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, Overtime entity)
    {
        var result = await _aService.UpdateAsync(id, entity);

        if (result == 0)
        {
            return NotFound("Id not found!");
        }

        return Ok("Overtime Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _aService.DeleteAsync(id);

        if (result == 0)
        {
            return NotFound("Id not found!");
        }

        return Ok("Overtime Deleted");
    }
}