using Travel.Data;
using Travel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext appContext;


        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext appContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.appContext = appContext;
        }
        [HttpGet("GetALLusers")]
        public async Task<IActionResult> GetALLUsers()
        {
            var user = await userManager.Users.Select(u => new
            {
                u.UserName,
                u.Fullname,
                u.Email,
                u.EmailConfirmed,

                u.LockoutEnd,
                IsActive = u.LockoutEnd == null
            }).ToListAsync();
            return Ok(user);
        }
    }

}
