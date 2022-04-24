using Database.Domain.Entities;
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

            var allRolePermisions = _unitOfWorkRepository._rolePermisionRepository.GetByRoleId(roleId);

            var allPermisions = _unitOfWorkRepository._permisionRepository.GetAll();


            var rolePermision = new RolePermisionViewModel()
            {
                RoleId = roleId
            };

            foreach (var item in allPermisions)
            {

                if (allRolePermisions.Any(r => r.PermisionId == item.ID))
                {
                    rolePermision.Claims.Add(new PermisionInfo()
                    {
                        Title = item.Title,
                        Value = item.Value,
                        PermisionId = item.ID,
                        IsSelected = true
                    });
                }
                else
                {
                    rolePermision.Claims.Add(new PermisionInfo()
                    {
                        Title = item.Title,
                        Value = item.Value,
                        PermisionId = item.ID,
                        IsSelected = false
                    });
                }
            }

            ViewBag.RoleName = role.Name;
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

            var allRolePermisions = _unitOfWorkRepository._rolePermisionRepository.GetByRoleId(role.Id);

            _unitOfWorkRepository._rolePermisionRepository.RemoveRange(allRolePermisions);
            _unitOfWorkRepository.Complete();

            var newRolePermisions = new List<RolePermisionDomain>();

            foreach (var item in model.Claims)
            {
                if (!item.IsSelected)
                    continue;

                newRolePermisions.Add(new RolePermisionDomain()
                {
                    PermisionId = item.PermisionId,
                    RoleId = role.Id
                });
            }

            _unitOfWorkRepository._rolePermisionRepository.AddRange(newRolePermisions);
            _unitOfWorkRepository.Complete();

            return RedirectToAction("Index", "Role", new { roleId = role.Id });
        }

    }
}
