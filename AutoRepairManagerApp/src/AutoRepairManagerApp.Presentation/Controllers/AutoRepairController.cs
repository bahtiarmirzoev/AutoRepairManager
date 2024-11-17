using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Services;

namespace AutoRepairManagerApp.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoRepairController : ControllerBase
{
    private readonly IConfiguration autoRepairDirConfiguration;
    private readonly IAutoRepairService autoRepairService;
    private readonly IIdentityService identityService;

    public AutoRepairController(
        IAutoRepairService autoRepairService, 
        IIdentityService identityService, 
        IConfiguration autoRepairDirConfiguration)
    {
        this.autoRepairService = autoRepairService;
        this.identityService = identityService;
        this.autoRepairDirConfiguration = autoRepairDirConfiguration;
    }

    [HttpGet("AutoRepairs")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var autoRepairs = await this.autoRepairService.GetAllAsync();
        return Ok(autoRepairs);
    }

    [HttpGet("AutoRepair")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByName([FromQuery] string? name)
    {
        var servicesByName = await this.autoRepairService.GetByNameAsync(name);
        return Ok(servicesByName); 
    }

    [HttpGet("AutoRepair/{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        var autoRepairById = await this.autoRepairService.GetByIdAsync(id);

        if (autoRepairById == null)
            return NotFound();

        return Ok(autoRepairById);

    }

    [HttpPost("Add")]
    [Authorize("AdminAccess")]
    public async Task<IActionResult> Add([FromForm] AutoRepair newAutoRepair)//, IFormFile layout)
    {
        try
        {
            newAutoRepair.Id = Guid.NewGuid();
            await this.autoRepairService.AddAsync(newAutoRepair);

           // var layoutFilePath = $"{autoRepairDirConfiguration["StaticFileRoutes:Layouts"]}{newAutoRepair.Id}";
            // if (layout != null)
            // {
            //     var extension = Path.GetExtension(layout.FileName);
            //     using var newFileStream = System.IO.File.Create(layoutFilePath + extension);
            //     await layout.CopyToAsync(newFileStream);
            // }

            return CreatedAtAction(nameof(GetById), new { id = newAutoRepair.Id }, newAutoRepair); // Returns 201 Created
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("Delete/{id}")]
    [Authorize("AdminAccess")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await this.autoRepairService.DeleteAsync(id);
        return NoContent(); 
    }
}