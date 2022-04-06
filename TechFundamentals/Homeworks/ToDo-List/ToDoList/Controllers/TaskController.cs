
namespace ToDoList.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using ToDoList.Models;
    using ToDoList.Data;

    public class TaskController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new ToDoDbContext())
            {
                var allTasks = db.Tasks.ToList();
                return View(allTasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string title, string comments)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(comments))
            {
                return RedirectToAction("Index");
            };

            Task task = new Task()
            {
                Title = title,
                Comments = comments
            };

            using (var db = new ToDoDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            };

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new ToDoDbContext())
            {
                var Olddask = db.Tasks.FirstOrDefault(x => x.Id == id);
                if (Olddask == null)
                {
                    return RedirectToAction("Index");
                }

                return this.View(Olddask);
            }
        }
        [HttpPost]
        public IActionResult Edit(Task editTask)
        {
            using (var db = new ToDoDbContext())
            {
                var Oldtask = db.Tasks.FirstOrDefault(x => x.Id == editTask.Id);
                if (Oldtask == null)
                {
                    return RedirectToAction("Index");
                }

                Oldtask.Title = editTask.Title;
                Oldtask.Comments = editTask.Comments;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {
            using (var db = new ToDoDbContext())
            {
                var currentTask = db.Tasks.FirstOrDefault(x => x.Id == id);
                if (currentTask == null)
                {
                    return RedirectToAction("Index");
                }

                return View(currentTask);

            }
        }

        public IActionResult Delete(int id)
        {

            using (var db = new ToDoDbContext())
            {
                var currentTask = db.Tasks.FirstOrDefault(x => x.Id == id);
                if (currentTask == null)
                {
                    return RedirectToAction("Index");
                }

                db.Tasks.Remove(currentTask);
                db.SaveChanges();


                return RedirectToAction("Index");

            }
        }
    }
}
