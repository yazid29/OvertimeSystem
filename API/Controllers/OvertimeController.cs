using API.DTOs.Overtimes;
using API.Services.Interfaces;
using API.Utilities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Data Account Not Found")); // Data Not Found
        }

        return Ok(new ListResponseVM<OvertimeResponseDto>(StatusCodes.Status200OK,
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

        return Ok(new SingleResponseVM<OvertimeResponseDto>(StatusCodes.Status200OK,
                                               HttpStatusCode.OK.ToString(),
                                               "Data Account Found",
                                               result));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(OvertimeRequestDto entity)
    {
        var result = await _aService.CreateAsync(entity);

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Account Created"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, OvertimeRequestDto entity)
    {
        var result = await _aService.UpdateAsync(id, entity);

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