using API.Models;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _aService;

    public AccountController(IAccountService accountService)
    {
        _aService = accountService;
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
    public async Task<IActionResult> CreateAsync(Account account)
    {
        var result = await _aService.CreateAsync(account);

        return Ok("Account Created");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, Account account)
    {
        var result = await _aService.UpdateAsync(id, account);

        if (result == 0)
        {
            return NotFound("Id not found!");
        }

        return Ok("Account Updated");
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