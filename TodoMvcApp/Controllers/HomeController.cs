using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TodoMvcApp.Data;
using TodoMvcApp.Models;

namespace TodoMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TodoList()
        {
            var todos = await _dataContext.Todos.ToListAsync();
            return View(todos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Todo todo)
        {
            if (!ModelState.IsValid)
                return View(todo);
            await _dataContext.Todos.AddAsync(todo);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("TodoList", "Home");
        }
        [HttpGet]
        public IActionResult Create() => View();

        [HttpGet]
        public async Task<IActionResult> Done(int id, bool isdone)
        {
            var todo = await _dataContext.Todos
                .FirstOrDefaultAsync(t => t.Id == id);
            if (todo is not null)
            {
                todo.IsDone = !isdone;
                _dataContext.Todos.Update(todo);
                await _dataContext.SaveChangesAsync();
            }
            return RedirectToAction("TodoList", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _dataContext.Todos
                .FirstOrDefaultAsync(t => t.Id == id);
            if (todo is not null)
            {
                _dataContext.Todos.Remove(todo);
                await _dataContext.SaveChangesAsync();
            }
            return RedirectToAction("TodoList", "Home");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = _dataContext.Todos
                .FirstOrDefault(t => t.Id == id);
            if (todo is not null)
            {
                return View(todo);
            }
            return RedirectToAction("TodoList", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Todo todo)
        {
            if (!ModelState.IsValid)
                return View(todo);

            var todoDb = await _dataContext.Todos
                .FirstOrDefaultAsync(t => t.Id == todo.Id);
            if(todo is null)
            {
                return RedirectToAction("TodoList", "Home");
            }
            todoDb.IsDone = todo.IsDone;
            todoDb.Title = todo.Title;

            await _dataContext.SaveChangesAsync();
            return RedirectToAction("TodoList", "Home");
        }
    }
}
