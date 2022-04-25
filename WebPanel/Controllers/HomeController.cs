using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using WebPanel.Filters;

namespace WebPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkRepository _context;

        public HomeController(IUnitOfWorkRepository context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            new PermisionManager().SetPermisions(_context);
            var res = _context._cityRepository.GetAll();
            return View(res);
        }

        [CustomAuthorization(permision: PermisionManager.Permisions.Home_Test_HttpGet)]
        public IActionResult Test()
        {
            Response.StatusCode = 404;
            throw new Exception("Test Error Message");

            return View();
        }

    }
}
