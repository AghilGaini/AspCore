﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPanel.ViewModels;

namespace WebPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var newUser = new IdentityUser
            {
                UserName = "aghil",
                Email = "aghil1373@gmail.com",
                EmailConfirmed = false,
            };

            if (!_userManager.Users.Any(r => r.UserName == newUser.UserName))
            {
                var ress = await _userManager.CreateAsync(newUser, "1qaz!QAZ");
            }

            var info = new UserViewModel()
            {
                Users = _userManager.Users.ToList()
            };

            info.Actions.Add(new ActionItem()
            {
                Title = "Manage Roles",
                Action = "CreateUserRole",
                Controller = "User",
            });

            return View(info);
        }

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(model.UserName);
                    if (user == null)
                    {
                        user = new IdentityUser()
                        {
                            Email = model.Email,
                            UserName = model.UserName
                        };

                        var res = await _userManager.CreateAsync(user, model.Password);
                        if (res.Succeeded)
                        {
                            return RedirectToAction("Index", "User");
                        }

                        foreach (var item in res.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                    else
                    {

                        ModelState.AddModelError("", "User Exist!");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "User Exist!");
                }
            }

            return View(model);
        }

        #endregion

        #region Create UserRole

        [HttpGet]
        public async Task<IActionResult> CreateUserRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new Exception("User Not Found");

            var allRoles = _roleManager.Roles.ToList();
            var userRole = new List<UserRoleViewModel>();

            foreach (var item in allRoles)
            {
                userRole.Add(new UserRoleViewModel()
                {
                    RoleID = item.Id,
                    RoleName = item.Name,
                    IsSelected = false
                });
            }
            ViewBag.UserName = user.UserName;
            return View(userRole);
        }

        [HttpPost]
        public IActionResult CreateUserRole(List<UserRoleViewModel> userRoles)
        {
            return View();
        }

        #endregion





    }
}
