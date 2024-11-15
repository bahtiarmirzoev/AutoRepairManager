using AutoRepairManagerApp.Core.Models;
using AutoRepairManagerApp.Core.Repositories;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore.DbContexts;
using AutoRepairManagerApp.Core.DTO;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using AutoRepairManagerApp.Core.Models.Relations;
using AutoRepairManagerApp.Core.Enums;


namespace AutoRepairManagerApp.Infrastructure.Repositories.EfCore;

public class IdentityEfCoreRepository : IIdentityRepository
{
    private readonly AutoRepairDbContext dbContext;
    public IdentityEfCoreRepository(AutoRepairDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<User?> Login(LogInDTO loginDto)
    {
        var user = dbContext.Users.FirstOrDefault(x => x.Email == loginDto.Email && x.Password == loginDto.Password);
        if(user == null) return null;
        var role = await GetRole(user.Id);
        return user;
    }

    public async Task<Guid?> Registration(RegistrationDTO registrationDto)
    {
        if (dbContext.Users.FirstOrDefault(u => u.Email.ToLower() == registrationDto.Email.ToLower()) == null)
        {
            var user = new User
            {
                Name = Regex.Replace(registrationDto.Name.ToLower(), @"^\w", m => m.Value.ToUpper()),
                Surname = Regex.Replace(registrationDto.Surname.ToLower(), @"^\w", m => m.Value.ToUpper()),
                Email = registrationDto.Email,
                Password = registrationDto.Password,
                EmailVerified = false
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.UserRoles.AddAsync(new UserRole
            {
                UserId = user.Id,
                RoleId = (int)UserRoleEnum.User
            });
            await dbContext.SaveChangesAsync();
            return user.Id;
        }
        return null;
    }

    public async Task<string> GetRole(Guid userId)
    {
        var roleId = dbContext.UserRoles.FirstOrDefault(x => x.UserId == userId).RoleId;
        return ((UserRoleEnum)roleId).ToString();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        var userRole = await dbContext.UserRoles.FindAsync(id);
        if (user != null)
        {
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
        }
        if (userRole != null)
        {
            dbContext.UserRoles.Remove(userRole);
            await dbContext.SaveChangesAsync();
        }
    }

    public Task<string> GenerateEmailConfirmationTokenAsync(User user)
    {
        var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        return Task.FromResult(token);
    }

    // public async Task<bool> ConfirmEmailAsync(User user, string code)
    // {
    //     // Реализуйте подтверждение токена
    //     if (user.EmailConfirmationToken == code)
    //     {
    //         user.EmailConfirmed = true;
    //         await UpdateUserAsync(user);
    //         return true;
    //     }
    //     return false;
    // }

    public async Task<IEnumerable<User>?> GetAllAsync()
    {
        return dbContext.Users;
    }


    public async Task SendUserRequest(RepairOrder repairOrder){
        await dbContext.RepairOrders.AddAsync(repairOrder);
        await dbContext.SaveChangesAsync();
    }


    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return dbContext.Users.FirstOrDefault(u => u.Id == userId);
    }


    Task<UserRole> IIdentityRepository.GetRole(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task SendRepairOrder(RepairOrder repairOrder)
    {
        throw new NotImplementedException();
    }
}