using System;
using Application.Data;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api")]
public class PropertyController(PropertyService propertyService) : ControllerBase
{
    [HttpGet("property-types")]
    public async Task<ActionResult> ActiveProperties()
    {
        try
        {
            var activeProperties = propertyService.GetAllActiveProperties();
            return Ok(activeProperties);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", detail = ex.Message });
        }
    }

    [HttpGet("valuation-requests")]
    public async Task<ActionResult> RequestValuations()
    {
        try
        {
            var valuations = propertyService.GetAllValuations();
            return Ok(valuations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", detail = ex.Message });
        }
    }

    [HttpGet("valuation-requests/{id}")]
    public async Task<ActionResult> RequestValuations(int id)
    {
        try
        {
            var result = propertyService.GetValuationRequestDto(id);
            if (result == null)
            {
                return NotFound(new { message = "Valuation request not found" });
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", detail = ex.Message });
        }
    }

    [HttpPost("create-valuation")]
    public async Task<ActionResult> CreateValuationRequest([FromBody] CreateValuationRequestDto dto)
    {
        var result = propertyService.CreateValuationRequest(dto);

        // create request
        return Ok(result);
    }

    [HttpPut("update-valuation/{id}/status")]
    public async Task<ActionResult> UpdateValuationRequest(int id, [FromBody] UpdateStatusDto dto)
    {
        var request = propertyService.GetValuationRequest(id);
        if (request == null)
        {
            return NotFound(new { message = "Valuation request not found" });
        }

        try
        {
            propertyService.UpdateValuationRequest(id, dto.Status);
            return Ok("Successful");
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
