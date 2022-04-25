using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utilities;
using WebPanel.Filters;
using WebPanel.ViewModels;

namespace WebPanel.Controllers
{
    [Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Role_Index_HttpGet)]
        public async Task<IActionResult> Index()
        {
            if (!_roleManager.Roles.Any(r => r.Name == "admin"))
            {
                var role = new IdentityRole()
                {
                    Name = "admin"
                };
                await _roleManager.CreateAsync(role);
            }

            var info = new RoleViewModel()
            {
                Roles = _roleManager.Roles.ToList()
            };

            info.Actions.Add(new ActionItem()
            {
                Title = "Manage Users",
                Action = "CreateRoleUser",
                Controller = "Role",
            });

            info.Actions.Add(new ActionItem()
            {
                Title = "Manage Permisions",
                Action = "Index",
                Controller = "Permision",
            });

            return View(info);
        }

        [HttpGet]
        [CustomAuthorization(permision: PermisionManager.Permisions.Role_Create_HttpGet)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorization(permision: PermisionManager.Permisions.Role_Create_HttpPost)]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByNameAsync(model.RoleName);
                if (role == null)
                {
                    role = new IdentityRole()
                    {
                        Name = model.RoleName
                    };

                    var res = await _roleManager.CreateAsync(role);

                    if (res.Succeeded)
                    {
                        return RedirectToAction("Index", "Role");
                    }
                    else
                    {
                        foreach (var item in res.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }

                }
                else
                    ModelState.AddModelError("", "Role Exist!");
            }
            return View(model);
        }

        [HttpGet]
        [CustomAuthorization(permision: PermisionManager.Permisions.Role_CreateRoleUser_HttpGet)]
        public async Task<IActionResult> CreateRoleUser(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                throw new Exception("Role not found");

            var allUsers = _userManager.Users.ToList();
            var roleUser = new RoleUserViewModel();

            foreach (var item in allUsers)
            {
                var newInfo = new UserInfoModel()
                {
                    UserId = item.Id,
                    UserName = item.UserName
                };

                if (await _userManager.IsInRoleAsync(item, role.Name))
                    newInfo.IsSelected = true;
                else
                    newInfo.IsSelected = false;

                roleUser.UserInfo.Add(newInfo);
            }
            ViewBag.RoleTitle = role.Name;
            return View(roleUser);
        }

        [HttpPost]
        [CustomAuthorization(permision: PermisionManager.Permisions.Role_CreateRoleUser_HttpPost)]
        public async Task<IActionResult> CreateRoleUser(RoleUserViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            foreach (var item in model.UserInfo)
            {
                var user = _userManager.Users.FirstOrDefault(r => r.Id == item.UserId);
                if (user == null)
                    continue;

                if (item.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.Name);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
            }

            return RedirectToAction("Index", "Role");

        }

    }
}
