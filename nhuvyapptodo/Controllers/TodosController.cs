using nhuvyapptodo.Models;
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

        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }

            var newTodo = new Todo()
            {
                Description = todo.Description,
                DueDate = todo.DueDate
            };

            _context.Todos.Add(newTodo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Todos");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }

            _context.Todos.Remove(todoInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Todos");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }

            return View(todoInDb);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == id);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }

            return View(todoInDb);
        }

        [HttpPost]
        public ActionResult Edit(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }
            var todoInDb = _context.Todos.SingleOrDefault(t => t.Id == todo.Id);
            if (todoInDb == null)
            {
                return HttpNotFound();
            }

            todoInDb.Description = todo.Description;
            todoInDb.DueDate = todo.DueDate;

            _context.SaveChanges();

            return RedirectToAction("Index", "Todos");
        }
    }
}