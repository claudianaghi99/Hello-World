namespace HelloWorldWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HelloWorldWeb.Data;
    using HelloWorldWeb.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class UsersController : Controller
    {
        private UserManager<IdentityUser> userManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            ViewData["Administrators"] = await userManager.GetUsersInRoleAsync("Administrators");
            return View(await userManager.Users.ToListAsync());
        }

        public async Task<IActionResult> AssignAdminRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "Administrators");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AssignUsualRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, "Administrators");
            return RedirectToAction(nameof(Index));
        }
    }
}
