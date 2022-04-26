using Database.Domain.Interfaces;
using DatabaseAccess.EFCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace WebPanel.Filters
{
    public class CustomAuthorization : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _permision;
        private readonly string _rolesName;
        private static UserManager<ApplicationUser> _userManager;
        private static RoleManager<IdentityRole> _roleManager;
        private static IUnitOfWorkRepository _unitOfWorkRepository;
        private static List<IdentityRole> _roles;
        private static List<ApplicationUser> _users;

        public CustomAuthorization(string permision, string rolesName = "")
        {
            this._permision = permision;
            this._rolesName = rolesName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var services = context.HttpContext.RequestServices;

            #region Initial

            //if (_userManager == null)
            _userManager = (UserManager<ApplicationUser>)services.GetService(typeof(UserManager<ApplicationUser>));

            //if (_roleManager == null)
            _roleManager = (RoleManager<IdentityRole>)services.GetService(typeof(RoleManager<IdentityRole>));

            //if (_rolePermisionRepository == null)
            _unitOfWorkRepository = (IUnitOfWorkRepository)services.GetService(typeof(IUnitOfWorkRepository));

            if (_roles == null)
                _roles = _roleManager.Roles.ToList();

            if (_users == null)
                _users = _userManager.Users.ToList();

            #endregion

            if (context == null)
                return;

            var user = context.HttpContext.User;
            if (user == null)
                return;

            if (user.Identity.Name == null)
                return;

            if (_permision == null)
                return;

            var userIdentity = _users.FirstOrDefault(r => r.UserName == user.Identity.Name);
            if (userIdentity == null)
                return;

            if (userIdentity.IsAdmin.ToBoolean())
                return;

            var userRolesName = _userManager.GetRolesAsync(userIdentity).Result;
            if (userRolesName == null)
                context.Result = new ForbidResult();

            var roles = _roles.Where(r => userRolesName.Any(x => x == r.Name)).ToList();

            if (roles.Count == 0)
                context.Result = new ForbidResult();

            if (_rolesName.IsNotNull())
            {
                var rolesName = _rolesName.Split(',');
                roles = roles.Where(r => rolesName.Any(x => x.IsEqual(r.Name, false))).ToList();
            }

            if (roles.Count == 0)
                context.Result = new ForbidResult();

            var rolePermisions = _unitOfWorkRepository._rolePermisionRepository.GetByRoleIds(roles.Select(r => r.Id).ToList());

            if (rolePermisions == null)
                context.Result = new ForbidResult();

            var permisions = _unitOfWorkRepository._permisionRepository.GetByPermisionIds(rolePermisions.Select(r => r.PermisionId).ToList());

            if (permisions == null)
                context.Result = new ForbidResult();

            if (!permisions.Any(r => r.Value == _permision))
                context.Result = new ForbidResult();

            return;
        }
    }
}
