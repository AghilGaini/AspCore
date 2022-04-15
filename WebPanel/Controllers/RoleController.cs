using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebPanel.ViewModels;

namespace WebPanel.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
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

            var res = _roleManager.Roles.ToList();
            return View(res);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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


    }
}
