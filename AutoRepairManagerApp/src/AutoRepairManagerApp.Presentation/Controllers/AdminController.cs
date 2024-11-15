using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using AutoRepairManagerApp.Presentation.Models;
using AutoRepairManagerApp.Core.Enums;

namespace AutoRepairManagerApp.Presentation.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController] 
public class AdminController : ControllerBase
{
    private readonly IAutoRepairService autoRepairService;
    private readonly IIdentityService identityService;
    private readonly IAdminService adminService;

    public AdminController(IAutoRepairService autoRepairService, IIdentityService identityService, IAdminService adminService)
    {
        this.autoRepairService = autoRepairService;
        this.identityService = identityService;
        this.adminService = adminService;
    }

    [HttpGet("Dashboard")]
    public async Task<IActionResult> Index()
    {
        return Ok("Admin dashboard placeholder");
    }

    [HttpGet("Users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await this.identityService.GetAllAsync();
        return Ok(users); 
    }

    [HttpGet("RepairOrders")]
    public async Task<IActionResult> GetRepairOrders()
    {
        var repairOrders = await this.adminService.GetAllRepairOrdersAsync();
        return Ok(repairOrders); 
    }

    [HttpDelete("Users/{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await this.identityService.DeleteAsync(id);
        return NoContent();
    }

    [NonAction] 
    public IActionResult Error()
    {
        return Problem("An error occurred in the AdminController.");
    }
}
