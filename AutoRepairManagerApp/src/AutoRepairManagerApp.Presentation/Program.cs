using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Core.Services;
using AutoRepairManagerApp.Infrastructure.Services;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AutoRepairDbContext>(dbContextOptionsBuilder =>
{
    var connectionString = builder.Configuration.GetConnectionString("MsSql");
    dbContextOptionsBuilder.UseSqlServer(connectionString, options =>
    {
        options.MigrationsAssembly("AutoRepairManagerApp.Infrastructure");
    });
});



builder.Services.AddTransient<IEmailRepository, EmailEfCoreRepository>();
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddTransient<IAdminRepository, AdminEfCoreRepository>();
builder.Services.AddTransient<IAdminService, AdminService>();

builder.Services.AddTransient<IAutoRepairRepository, AutoRepairEfCoreRepository>();
builder.Services.AddTransient<IAutoRepairService, AutoRepairService>();

builder.Services.AddTransient<IIdentityRepository, IdentityEfCoreRepository>();
builder.Services.AddTransient<IIdentityService, IdentityService>();

builder.Services.AddTransient<ILogRepository, LogEfCoreRepository>();
builder.Services.AddTransient<ILogService, LogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AutoRepair}/{action=Index}/{id?}");

app.Run();
