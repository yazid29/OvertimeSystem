using API.DTOs;
using API.DTOs.Accounts;
using API.Models;
using API.Services.Interfaces;
using API.Utilities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _aService;

    public AccountController(IAccountService accountService)
    {
        _aService = accountService;
    }

    [HttpGet("GetAllAccount")]
    public async Task<IActionResult> GetAllAsync()
    {
        var results = await _aService.GetAllAsync();

        if (!results.Any())
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Data Account Not Found")); // Data Not Found
        }

        return Ok(new ListResponseVM<AccountResponseDto>(StatusCodes.Status200OK,
                                               HttpStatusCode.OK.ToString(),
                                               "Data Account Found",
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
                                                  "Id Account Not Found")); // Data Not Found
        }

        return Ok(new SingleResponseVM<AccountResponseDto>(StatusCodes.Status200OK,
                                               HttpStatusCode.OK.ToString(),
                                               "Data Account Found",
                                               result));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(AccountRequestDto account)
    {
        var result = await _aService.CreateAsync(account);

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Account Created"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, AccountRequestDto account)
    {
        var result = await _aService.UpdateAsync(id, account);

        if (result == 0)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Id Account Not Found"
            )); // Data Not Found
        }

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Account Updated"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _aService.DeleteAsync(id);

        if (result == 0)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Id Account Not Found"
                                                 )); // Data Not Found
        }

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Account Deleted"));
    }
}