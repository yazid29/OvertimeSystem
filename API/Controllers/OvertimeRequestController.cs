using API.DTOs.OvertimeRequests;
using API.Services.Interfaces;
using API.Utilities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[ApiController]
[Route("overtimeRequest")]
public class OvertimeRequestController : ControllerBase
{
    private readonly IOvertimeRequestService _aService;

    public OvertimeRequestController(IOvertimeRequestService overReqService)
    {
        _aService = overReqService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var results = await _aService.GetAllAsync();

        if (!results.Any())
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Data Employee Not Found")); // Data Not Found
        }

        return Ok(new ListResponseVM<OvertimeReqResponseDto>(StatusCodes.Status200OK,
                                               HttpStatusCode.OK.ToString(),
                                               "Data Employee Found",
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
                                                  "Id Employee Not Found")); // Data Not Found
        }

        return Ok(new SingleResponseVM<OvertimeReqResponseDto>(StatusCodes.Status200OK,
                                               HttpStatusCode.OK.ToString(),
                                               "Data Employee Found",
                                               result));
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(OvertimeReqRequestDto entity)
    {
        var result = await _aService.CreateAsync(entity);

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Employee Created"));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, OvertimeReqRequestDto entity)
    {
        var result = await _aService.UpdateAsync(id, entity);

        if (result == 0)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Id Employee Not Found"
            )); // Data Not Found
        }

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Employee Updated"));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _aService.DeleteAsync(id);

        if (result == 0)
        {
            return NotFound(new MessageResponseVM(StatusCodes.Status404NotFound,
                                                  HttpStatusCode.NotFound.ToString(),
                                                  "Id Employee Not Found"
                                                 )); // Data Not Found
        }

        return Ok(new MessageResponseVM(StatusCodes.Status200OK,
                                        HttpStatusCode.OK.ToString(),
                                        "Employee Deleted"));
    }
}