using API.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("accountrole")]
public class AccountRoleController : ControllerBase
{
    private readonly IAccountRoleService _aService;

    public AccountRoleController(IAccountRoleService accountRoleService)
    {
        _aService = accountRoleService;
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
    public async Task<IActionResult> CreateAsync(AccountRole accRole)
    {
        var result = await _aService.CreateAsync(accRole);

        return Ok("AccountRole Created");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, AccountRole accRole)
    {
        var result = await _aService.UpdateAsync(id, accRole);

        if (result == 0)
        {
            return NotFound("Id not found!");
        }

        return Ok("AccountRole Updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _aService.DeleteAsync(id);

        if (result == 0)
        {
            return NotFound("Id not found!");
        }

        return Ok("Employee Deleted");
    }
}