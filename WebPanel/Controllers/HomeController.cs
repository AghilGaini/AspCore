using Database.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;

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

        public IActionResult Test()
        {
            return View();
        }

    }
}
