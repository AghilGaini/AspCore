using Database.Domain.Interfaces;
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
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public PermisionController(RoleManager<IdentityRole> roleManager,
            IUnitOfWorkRepository unitOfWorkRepository)
        {
            this._roleManager = roleManager;
            this._unitOfWorkRepository = unitOfWorkRepository;
        }

        public async Task<IActionResult> Index(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            var allPermisions = _unitOfWorkRepository._permisionRepository.GetAll();

            var allclaims = await _roleManager.GetClaimsAsync(role);

            var rolePermision = new RolePermisionViewModel()
            {
                RoleId = roleId
            };

            foreach (var item in allPermisions)
            {

                if (allclaims.Any(r => r.Type == item.Title && r.Value == item.Value))
                {
                    rolePermision.Claims.Add(new ClaimInfo()
                    {
                        Title = item.Title,
                        Value = item.Value,
                        IsSelected = true
                    });
                }
                else
                {
                    rolePermision.Claims.Add(new ClaimInfo()
                    {
                        Title = item.Title,
                        Value = item.Value,
                        IsSelected = false
                    });
                }
            }

            return View(rolePermision);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RolePermisionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            var allClaims = await _roleManager.GetClaimsAsync(role);


            foreach (var item in model.Claims)
            {
                if (allClaims.Any(r => r.Type == item.Title && r.Value == item.Value) && !item.IsSelected)
                {
                    await _roleManager.RemoveClaimAsync(role, new Claim(item.Title, item.Value));
                }
                else if (!allClaims.Any(r => r.Type == item.Title && r.Value == item.Value) && item.IsSelected)
                {
                    await _roleManager.AddClaimAsync(role, new Claim(item.Title, item.Value));
                }
            }

            return RedirectToAction("Index", "Role", new { roleId = role.Id });
        }

    }
}
