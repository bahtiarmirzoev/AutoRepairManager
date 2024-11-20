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

builder.Services.AddDataProtection();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactAppPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
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

app.UseAuthorization();

app.MapControllers(); 

app.Run();
