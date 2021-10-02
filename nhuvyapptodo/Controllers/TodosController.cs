using nhuvyapptodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace nhuvyapptodo.Controllers
{
    public class TodosController : Controller
    {
        private ApplicationDbContext _context;
        public TodosController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var todos = _context.Todos.ToList();
            return View(todos);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}