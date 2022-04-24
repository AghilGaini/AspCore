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

        [CustomAuthorization(permision: "25A67B3C-EAB9-45FF-A4CE-DF63B627C64F")]
        public IActionResult Index()
        {
            new PermisionManager().SetPermisions(_context);
            var res = _context._cityRepository.GetAll();
            return View(res);
        }

        [CustomAuthorization(permision: "AB7826A4-C5A3-4462-BFC7-841B1D7A918F")]
        public IActionResult Test()
        {
            Response.StatusCode = 404;
            throw new Exception("Test Error Message");

            return View();
        }

    }
}
