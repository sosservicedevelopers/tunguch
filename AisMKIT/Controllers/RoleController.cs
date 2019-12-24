using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AisMKIT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AisMKIT.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        /// 
        /// Injecting Role Manager
        /// 
        /// 
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] IdentityRole role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var roles = await roleManager.FindByIdAsync(id);
                    roles.Name = role.Name;
                    var result = await roleManager.UpdateAsync(roles);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.First().ToString());
                        return View(role);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                   throw;
                }
              
            }
            return View(role);
        }

        public async Task<IActionResult> UserIndex()
        {
            var users = userManager.Users.ToList();
            List<UserView> lst = new List<UserView>();
            foreach (var item in users)
            {
                ApplicationUser ap =await userManager.FindByIdAsync(item.Id);
                var roles = await userManager.GetRolesAsync(ap);
                string st = (roles.Count == 0 ? "No Roles" : string.Join(", ", roles));
                //foreach (var it in roles)
                //{
                //    st += it + ",";
                //}
                lst.Add(new UserView { Id = ap.Id, UserName = ap.UserName, Roles = st });
            }
            return View(lst);
        }

    }
}