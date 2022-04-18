using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebPanel.ViewModels.Permision;

namespace WebPanel.Controllers
{
    public class PermisionController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public PermisionController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RolePermision(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            return View(role);

        }
    }
}
