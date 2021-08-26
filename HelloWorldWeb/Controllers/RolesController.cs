namespace HelloWorldWeb.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RolesController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        // injection
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // GET: RolesController
        public ActionResult Index()
        {
            return View(roleManager.Roles);
        }

    /*    // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    */

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View(new IdentityRole()); // object
        }

        // POST: RolesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(IdentityRole role)
        {
            try
            {
                await roleManager.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
