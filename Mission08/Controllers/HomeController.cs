using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission08.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;
        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult ViewTasks()
        {
            // Retrieve all movies from the database, including the related categories
            var tasks = _repo.Tasks.ToList();

            // Return the movies to the View
            return View(tasks);
        }
        public IActionResult AddTask()
        {
            // Retrieve categories for the dropdown list
            var categories =  _repo.Categories.ToList();
            
            ViewBag.Categories = categories;
            foreach (var category in _repo.Categories)
            {
                Console.WriteLine($"Category ID: {category.CategoryId}, Category Name: {category.Name}");
            }
            // Return the view where the user can fill in task details
            return View(new Mission08.Models.Task());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTask(Mission08.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                // Add the new task to the database
                _repo.AddTask(task);

                // Redirect to the task list or another view (e.g., Index)
                return RedirectToAction("Index");
            }

            // If the model state is invalid, return the same view with validation messages
            ViewBag.Categories = _repo.Categories.ToList();
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repo.DeleteTask(id); //Delete the task
            return RedirectToAction("ViewTasks"); //Redirect back to the task list
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            // Pass the categories for dropdown
            ViewBag.Categories = _repo.Categories.ToList();
            return View("~/Views/Home/Edit.cshtml", task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Mission08.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(task); //Update the task in the database
                return RedirectToAction("ViewTasks"); //Redirect back to the main task list
            }

            // If validation fails, reload categories
            ViewBag.Categories = _repo.Categories.ToList();
            return View(task);
        }

    }
}
