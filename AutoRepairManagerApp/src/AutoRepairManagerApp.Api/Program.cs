using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Core.Services;
using AutoRepairManagerApp.Infrastructure.Services;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore.DbContexts;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AutoRepairDbContext>(dbContextOptionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("MsSql");
    dbContextOptionsBuilder.UseSqlServer(connectionString, options =>
    {
        options.MigrationsAssembly("AutoRepairManagerApp.Infrastructure");
    });
});

const string LocalHostUrl = "http://localhost:5271";

builder.Services.AddScoped<IEmailRepository, EmailEfCoreRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<IAdminRepository, AdminEfCoreRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddScoped<IAutoRepairRepository, AutoRepairEfCoreRepository>();
builder.Services.AddScoped<IAutoRepairService, AutoRepairService>();

builder.Services.AddScoped<IIdentityRepository, IdentityEfCoreRepository>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddScoped<ILogRepository, LogEfCoreRepository>();
builder.Services.AddScoped<ILogService, LogService>();


builder.Services.AddDataProtection();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactAppPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:3001" ) 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var assetsDirPath = builder.Configuration["StaticFileRoutes:Assets"];
var avatarsDirPath = builder.Configuration["StaticFileRoutes:Avatars"];

if (!Directory.Exists(assetsDirPath))
{
    try
    {
        Directory.CreateDirectory(assetsDirPath);
        Directory.CreateDirectory($"{assetsDirPath}/Avatars");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error while initializing folder: {ex.Message}");
    }
}

if (!Directory.Exists(avatarsDirPath))
{
    try
    {
        Directory.CreateDirectory(avatarsDirPath);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error while initializing folder: {ex.Message}");
    }
}

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAccess", policyBuilder =>
    {
        policyBuilder.RequireRole("Admin");
    });
    options.AddPolicy("ModeratorAccess", policyBuilder =>
    {
        policyBuilder.RequireRole("Moderator");
    });
    options.AddPolicy("UserAccess", policyBuilder =>
    {
        policyBuilder.RequireRole("User");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ReactAppPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); 

app.Run();
