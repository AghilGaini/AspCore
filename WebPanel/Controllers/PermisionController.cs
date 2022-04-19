using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> Index(string roleId)
        {

            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            var claims = await _roleManager.GetClaimsAsync(role);

            if (claims.Count == 0)
            {
                var newClaim = new System.Security.Claims.Claim("Permision", "12345");
                var res = await _roleManager.AddClaimAsync(role, newClaim);

                if (res.Succeeded)
                {
                    return View();
                }
            }

            var permisions = Utilities.PermisionManager.GetPrmisions();

            var rolePermision = new RolePermisionViewModel()
            {
                RoleId = roleId
            };

            foreach (var item in permisions)
            {

                if (claims.Any(r => r.Type == "Permision" && r.Value == item.Value))
                {
                    rolePermision.Claims.Add(new ClaimInfo()
                    {
                        Title = item.Key,
                        IsSelected = true
                    });
                }
                else
                {
                    rolePermision.Claims.Add(new ClaimInfo()
                    {
                        Title = item.Key,
                        IsSelected = false
                    });
                }
            }

            return View(rolePermision);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRolePermision(RolePermisionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            var allClaims = await _roleManager.GetClaimsAsync(role);

            foreach (var item in model.Claims)
            {
            }

            return View();
        }

    }
}
