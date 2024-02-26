using API.DTOs.AccountRoles;
using API.Services.Interfaces;
using API.Utilities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Data AccountRole Not Found")); // Data Not Found
        }

        return Ok(new ListResponseVM<AccountRoleResponseDto>(StatusCodes.Status200OK,
                                               HttpStatusCode.OK.ToString(),
                                               "Data AccountRole Found",
                                               results.ToList()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _aService.GetByIdAsync(id);

        if (result is null)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Id AccountRole Not Found")); // Data Not Found
        }

        return Ok(new SingleResponseVM<AccountRoleResponseDto>(StatusCodes.Status200OK,
                                               HttpStatusCode.OK.ToString(),
                                               "Data AccountRole Found",
                                               result));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(AccountRoleRequestDto account)
    {
        var result = await _aService.CreateAsync(account);

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "AccountRole Created"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, AccountRoleRequestDto account)
    {
        var result = await _aService.UpdateAsync(id, account);

        if (result == 0)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Id AccountRole Not Found"
            )); // Data Not Found
        }

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "AccountRole Updated"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _aService.DeleteAsync(id);

        if (result == 0)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Id AccountRole Not Found"
                                                 )); // Data Not Found
        }

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "AccountRole Deleted"));
    }
}