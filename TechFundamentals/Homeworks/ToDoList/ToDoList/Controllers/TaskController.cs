
namespace ToDoList.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ToDoList.Models;
    using ToDoList.Data;

    public class TaskController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using(var db = new ToDoDbContext())
            {
                var allTasks = db.Tasks.ToList();
                return View(allTasks);
            }
        }

        [HttpGet]
        public IActionResult Create(string title, string comments)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(comments))
            {
                return RedirectToAction("Index");
            }
            Task task = new Task
            {
                Title = title,
                Comments = comments
            };

            using(var db = new ToDoDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
