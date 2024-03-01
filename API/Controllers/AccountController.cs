using API.DTOs.Accounts;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using API.Utilities.Handlers;
using API.Utilities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;


[Authorize]
[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _aService;


    public AccountController(IAccountService accountService, IEmployeeRepository employeeRepository, IAccountRepository accRepository)
    {
        _aService = accountService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginDto entity)
    {
        var result = await _aService.LoginAsync(entity);

        if (result == 0)
        {
            return BadRequest(new MessageResponseVM(StatusCodes.Status400BadRequest,
                                                  HttpStatusCode.BadRequest.ToString(),
                                                  "Email or Password Do Not Match"
                                                 ));
        }
        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Login Success"));
    }
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordDto entity)
    {
        var result = await _aService.ForgotPasswordAsync(entity);
        
        if (result == 0)
        {
            return BadRequest(new MessageResponseVM(StatusCodes.Status400BadRequest,
                                                  HttpStatusCode.BadRequest.ToString(),
                                                  "Email Not Found"
                                                 ));
        }
        return Ok(new SingleResponseVM<ForgotPasswordResponseDto>(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Code OTP Has Been Sent",new ForgotPasswordResponseDto(result)));
    }
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePasswordAsync(ChangePasswordRequestDto entity)
    {
        var result = await _aService.ChangePasswordAsync(entity);
        if (result == 0)
        {
            return BadRequest(new MessageResponseVM(StatusCodes.Status400BadRequest,
                                                  HttpStatusCode.BadRequest.ToString(),
                                                  "Email or Password Do Not Match"
                                                 ));
        }
        else if (result == 2)
        {
            return BadRequest(new MessageResponseVM(StatusCodes.Status400BadRequest,
                                                  HttpStatusCode.BadRequest.ToString(),
                                                  "OTP Code Has Been Used"
                                                 ));
        }else if (result == 3)
        {
            return BadRequest(new MessageResponseVM(StatusCodes.Status400BadRequest,
                                                  HttpStatusCode.BadRequest.ToString(),
                                                  "OTP Code Has Been Expired"
                                                 ));
        }
        else if (result == 4)
        {
            return BadRequest(new MessageResponseVM(StatusCodes.Status400BadRequest,
                                                  HttpStatusCode.BadRequest.ToString(),
                                                  "Incorrect OTP"
                                                 ));
        }
        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "New Password Has Been Created"));
    }
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterDto entity)
    {
        var result = await _aService.RegisterAsync(entity);
        if(result == 0)
        {
            return BadRequest(new MessageResponseVM(StatusCodes.Status400BadRequest,
                                                  HttpStatusCode.BadRequest.ToString(),
                                                  "Password and Confirm Password Does Not Match"
                                                 ));
        }else if (result == 2)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Role Not Found"
                                                 ));
        }
        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Account Created"));
    }

    [HttpDelete("remove-role")]
    public async Task<IActionResult> RemoveRoleAsync(RemoveAccountRoleRequestDto removeAccountRoleRequestDto)
    {
        var result = await _aService.RemoveRoleAsync(removeAccountRoleRequestDto);

        if (result == 0)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Id Role Account Not Found"
                                                 )); // Data Not Found
        }

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Role  Account Deleted"));
    }

    [HttpPost("add-role")]
    public async Task<IActionResult> AddRoleAsync(AddAccountRoleRequestDto addAccountRoleRequestDto)
    {
        var result = await _aService.AddAccountRoleAsync(addAccountRoleRequestDto);

        if (result == 0)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Account Id Not Found"
                                                 )); // Data Not Found
        }

        if (result == -1)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Role Id Not Found"
                                                 )); // Data Not Found
        }

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Role Added"));
    }

    [HttpGet]
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