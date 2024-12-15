using LibraryManagement.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new IdentityUser { UserName = model.Username, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) return RedirectToAction("Index");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }


        public async Task<IActionResult> Update(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var model = new UserViewModel
            {
                Username = user.UserName!,
                Email = user.Email!,
                Password = "********"
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, UserViewModel model)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.Email = model.Email;
            user.UserName = model.Username;
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded) return RedirectToAction("Index");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }


        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded) return RedirectToAction("Index");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditRoles(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if (user == null) return NotFound();
            var model = new UserRolesViewModel
            {
                Id = user.Id,
                Username = user.UserName!,
                Roles = userManager.GetRolesAsync(user).Result,
                AllRoles = roleManager.Roles.Select(r => r.Name).ToList()
            };
            return View(model);
        }
    }
}
