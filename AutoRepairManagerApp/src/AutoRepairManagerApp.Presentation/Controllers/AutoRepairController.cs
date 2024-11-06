using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using AutoRepairManagerApp.Core.DTO;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Services;

namespace AutoRepairManagerApp.Presentation.Controllers;

public class AutoRepairController : Controller
{

    private readonly IConfiguration autoRepairDirConfiguration;
    private readonly IAutoRepairService autoRepairService;
    private readonly IIdentityService identityService;
    public AutoRepairController(IAutoRepairService autoRepairService, IIdentityService identityService, IConfiguration autoRepairDirConfiguration)
    {
        this.autoRepairService = autoRepairService;
        this.identityService = identityService;
        this.autoRepairDirConfiguration = autoRepairDirConfiguration;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        //base.HttpContext.Response.Cookies.Delete("CurrentAutoRepairId");
        var autoRepairs = await this.autoRepairService.GetAllAsync();
        return View(autoRepairs);
    }

    [HttpGet]
    [ActionName("GetByName")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByName(string? name)
    {
        var booksByName = await this.autoRepairService.GetByNameAsync(name);
        return View("Index", booksByName);
    }

    [HttpGet]
    [ActionName("GetById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(Guid id)
    {
        var autoRepairById = await this.autoRepairService.GetByIdAsync(id);
        // var commentDtos = this.autoRepairService.GetComments(bookById.Id);

        // var bookComments = new BookComment
        // {
        //     book = bookById,
        //     comments = commentDtos
        // };

        Guid userId;
        var hashedSenderId = base.HttpContext.Request.Cookies["CurrentUserId"];

        if (string.IsNullOrWhiteSpace(hashedSenderId) == false)
        {
            Guid.TryParse(hashedSenderId, out userId);
            var user = await identityService.GetByIdAsync(userId);
        }       
        else{
            ViewBag.InPurchased = false;
            ViewBag.InWishlist = false;
        }

        base.HttpContext.Response.Cookies.Append("CurrentAutoRepairId", autoRepairById.Id.ToString());
        ViewBag.avatarDirPath = autoRepairDirConfiguration["StaticFileRoutes:Avatars"];
        return View("Description");
    }

    [HttpPost]
    [ActionName("Add")]
    [Route("api/[controller]/[action]/")]
    [Authorize("RequireAdminAccess")]
    public async Task<IActionResult> Add([FromForm] AutoRepair newAutoRepair, IFormFile layout, IFormFile bookFile)
    {
        try
        {
            newAutoRepair.Id = new Guid();
            // newAutoRepair.AddedDate = DateTime.Now;


            await this.autoRepairService.AddAsync(newAutoRepair);
            if (bookFile != null)
            {
                var extension = Path.GetExtension(bookFile.FileName);
                using var newFileStream = System.IO.File.Create($"{autoRepairDirConfiguration["StaticFileRoutes:AutoRepairs"]}{newAutoRepair.Id}{extension}");
                await bookFile.CopyToAsync(newFileStream);
            }
            var layoutFilePath = $"{autoRepairDirConfiguration["StaticFileRoutes:Layouts"]}{newAutoRepair.Id}";

            if (layout == null)
            {
                var defaultLayoutUrl = "https://static.vecteezy.com/system/resources/previews/000/357/095/non_2x/vector-book-icon.jpg";

                var uri = new Uri(defaultLayoutUrl);
                var extension = Path.GetExtension(uri.AbsolutePath);

                using var httpClient = new HttpClient();
                HttpResponseMessage response = null;

                try
                {
                    response = await httpClient.GetAsync(defaultLayoutUrl);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException e)
                {
                    throw new Exception("Error fetching default layout from the internet: " + e.Message);
                }

                using var newFileStream = System.IO.File.Create(layoutFilePath + extension);
                await response.Content.CopyToAsync(newFileStream);
            }
            else
            {
                var extension = Path.GetExtension(layout.FileName);

                using var newFileStream = System.IO.File.Create(layoutFilePath + extension);
                await layout.CopyToAsync(newFileStream);
            }
        }
        catch (Exception ex)
        {
            TempData["error"] = ex.Message;
        }

        return base.RedirectToAction("Index");
    }



    
    [HttpGet]
    [ActionName("DeleteAutoRepair")]
    [Authorize("RequireAdminAccess")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (ModelState.IsValid)
        {
            await this.autoRepairService.DeleteAsync(id);
            return base.RedirectToAction("Index");
        }

        return Forbid();
    }
}
