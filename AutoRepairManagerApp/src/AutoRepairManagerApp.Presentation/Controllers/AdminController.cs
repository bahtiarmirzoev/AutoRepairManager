using System.Data.SqlClient;
using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using AutoRepairManagerApp.Presentation.Models;

namespace AutoRepairManagerApp.Infrastructure.Controllers;

[Authorize(Roles = "Admin")]

public class AdminController : Controller
{

    private readonly IAutoRepairService autoRepairService;
    private readonly IIdentityService identityService;
    private readonly IAdminService adminService;
    public AdminController(IConfiguration configuration, IAutoRepairService autoRepairService, IIdentityService identityService, IAdminService adminService)
    {
        this.autoRepairService = autoRepairService;
        this.identityService = identityService;
        this.adminService = adminService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> GetUsers()
    {
        var users = await this.identityService.GetAllAsync();
        return base.View(users);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    [ActionName("DeleteUser")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await this.identityService.DeleteAsync(id);
        return base.RedirectToAction("GetUsers");
    }


    [HttpGet]
    [ActionName("GetRepairOrders")]
    public async Task<IActionResult> GetRepairOrders()
    {
        return base.View(await this.adminService.GetAllRepairOrdersAsync());
    }
}
