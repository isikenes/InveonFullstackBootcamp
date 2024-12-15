using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager) : Controller
    {


        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            var result = await roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded) return RedirectToAction("Index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string roleName)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            role.Name = roleName;
            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded) return RedirectToAction("Index");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var result = await roleManager.DeleteAsync(role);

            if (result.Succeeded) return RedirectToAction("Index");
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            var result = await userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded) return RedirectToAction("EditRoles", "Users", new { id = userId });
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }

        [HttpPost("RemoveRole")]
        public async Task<IActionResult> RemoveRole(string userId, string roleName)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            var result = await userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded) return RedirectToAction("EditRoles", "Users", new { id = userId });
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }
    }
}
