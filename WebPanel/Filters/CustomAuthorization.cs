using Database.Domain.Interfaces;
using DatabaseAccess.EFCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace WebPanel.Filters
{
    public class CustomAuthorization : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _permision;
        private static UserManager<ApplicationUser> _userManager;
        private static RoleManager<IdentityRole> _roleManager;
        private static IUnitOfWorkRepository _unitOfWorkRepository;
        private static List<IdentityRole> _roles;
        private static List<ApplicationUser> _users;

        public CustomAuthorization(string permision)
        {
            this._permision = permision;
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

            var roleNames = _userManager.GetRolesAsync(userIdentity).Result;
            if (roleNames == null)
                return;

            var roles = _roles.Where(r => roleNames.Any(x => x == r.Name)).ToList();

            var rolePermisions = _unitOfWorkRepository._rolePermisionRepository.GetByRoleIds(roles.Select(r => r.Id).ToList());

            if (rolePermisions == null)
                return;

            var permisions = _unitOfWorkRepository._permisionRepository.GetByPermisionIds(rolePermisions.Select(r => r.PermisionId).ToList());

            if (permisions == null)
                return;

            if (!permisions.Any(r => r.Value == _permision))
                context.Result = new ForbidResult();

            return;
        }
    }
}
