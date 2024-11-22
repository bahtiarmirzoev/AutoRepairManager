using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using AutoRepairManagerApp.Core.DTO;
using System.Security.Cryptography;
using AutoRepairManagerApp.Core.Services;
using System.Text;
using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Infrastructure.Services;
using System.Net.Mail;
using System.Net;

namespace AutoRepairManagerApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : Controller
{
    private readonly IIdentityService identityService;
    private readonly IAutoRepairService autoRepairService;
    private readonly IEmailService emailService;
    private string verificationCode;

    private readonly IConfiguration avatarDirConfiguration;

    private readonly IDataProtector dataProtector;
    public IdentityController(IIdentityService identityService, IDataProtectionProvider dataProtectionProvider, IConfiguration avatarDirConfiguration, IAutoRepairService autoRepairService, IEmailService emailService)
    {
        this.identityService = identityService;
        this.dataProtector = dataProtectionProvider.CreateProtector("identity");
        this.avatarDirConfiguration = avatarDirConfiguration;
        this.autoRepairService = autoRepairService;
        this.emailService = emailService;
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromForm] LogInDTO loginDto)
    {
        try
        {
            loginDto.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(loginDto.Password));
            var user = await identityService.Login(loginDto);

            if (user == null)
            {
                return Unauthorized(new { message = "Incorrect login or password!" });
            }
            string token = GuidEncryptor.EncryptGuid(user.Id);

            //var hashedUserId = dataProtector.Protect(user.Id.ToString());
            // var claims = new[]
            // {
            //     new Claim(ClaimTypes.Email, user.Email),
            //     new Claim(ClaimTypes.Name, user.Name),
            //     new Claim("Id", hashedUserId)
            // };
            // var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            // var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            //HttpContext.Response.Cookies.Append("CurrentUserId", user.Id.ToString());

            return Ok(new { message = "Login successful", userId = token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("Logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        //HttpContext.Response.Cookies.Delete("CurrentUserId");
        //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return Ok(new { message = "Logged out successfully" });
    }

    [HttpPost("Registration")]
    [AllowAnonymous]
    public async Task<IActionResult> Registration([FromForm] RegistrationDTO registrationDto)//, IFormFile? avatar)
    {
        try
        {
            registrationDto.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(registrationDto.Password));
            var userId = await identityService.Registration(registrationDto);
            if (userId == null)
                return Conflict(new { message = "This email is already in use" });

            // var avatarFilePath = $"{avatarDirConfiguration["StaticFileRoutes:Avatars"]}{userId}";
            // var extension = avatar != null ? Path.GetExtension(avatar.FileName) : ".jpg";

            // using var newFileStream = System.IO.File.Create(avatarFilePath + extension);
            // if (avatar != null)
            // {
            //     await avatar.CopyToAsync(newFileStream);
            // }
            // else
            // {
            //     using var httpClient = new HttpClient();
            //     var response = await httpClient.GetAsync("https://wallpapers.com/images/hd/blank-default-pfp-wue0zko1dfxs9z2c.jpg");
            //     await response.Content.CopyToAsync(newFileStream);
            // }

            return Ok(new { message = "Registration successful" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("User/{token}")]
    public async Task<IActionResult> GetUserById(string token)
    {
        Guid id;
        try
        {
            id = GuidEncryptor.DecryptGuid(token);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to decrypt token: {ex.Message}");
            return BadRequest(new { message = "Invalid token" });
        }
        System.Console.WriteLine(id);
        var user = await identityService.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        return Ok(new { user = user });
    }

    [HttpPost("SendEmail")]
    [Authorize]
    public async Task<IActionResult> SendEmail([FromQuery] string userEmail, [FromQuery] string subject)
    {
        try
        {
            var verificationCode = emailService.GenerateVerificationCode();
            var message = $"Your verification code: {verificationCode}";

            await emailService.SendEmailAsync(userEmail, subject, message);
            TempData["VerificationCode"] = verificationCode;

            return Ok(new { message = "Email sent successfully", verificationCode });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Failed to send email", error = ex.Message });
        }
    }

    [HttpPost("VerifyEmail")]
    [Authorize]
    public async Task<IActionResult> VerifyEmail([FromBody] string enteredCode)
    {
        var storedCode = TempData["VerificationCode"] as string;
        if (string.IsNullOrEmpty(enteredCode) || enteredCode != storedCode)
        {
            return BadRequest(new { message = "The entered code is incorrect" });
        }

        await emailService.VerifyEmail(new Guid(HttpContext.Request.Cookies["CurrentUserId"]));
        return Ok(new { message = "Email verified successfully" });
    }
}

