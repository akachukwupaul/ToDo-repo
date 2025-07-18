//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;
//using Todo.Models;
//using System;

//namespace Todo.Controllers
//{
//    public class HomeController1 : Controller
//    {
//        private ToDoContext Context;
//        public HomeController1(ToDoContext cxt) => Context = cxt;

//        public IActionResult Index(string id)
//        {
//            // Store filter info and data for dropdowns in the ViewBag for use in the view
//            var filters = new Filters(id);
//            ViewBag.Filters = filters;
//            ViewBag.Categories = Context.Categories.ToList();
//            ViewBag.Statuses = Context.Statuses.ToList();
//            ViewBag.DueFilters = Filters.DueFilterValues;

//            IQueryable<ToDo> query = Context.ToDos
//                .Include(t => t.Category)
//                .Include(t => t.Status);

//            if (filters.HasCategory)
//            {
//                query = query.Where(t => t.CategoryId == filters.CategoryId);
//            }
//            if (filters.HasStatus)
//            {
//                query = query.Where(t=>t.StatusId == filters.StatusId);
//            }

//            // Apply due date filter if selected
//            if (filters.HasDue)
//            {
//                var today = DateTime.Today;
//                if (filters.IsPast)
//                {
//                    query = query.Where(t => t.DueDate < today);
//                }
//               else if (filters.IsFuture)
//               {
//                    query = query.Where(t => t.DueDate > today);
//               }
//                else if (filters.IsToday)
//                {
//                    query = query.Where(t => t.DueDate == today);
//                }
//            }
//            var tasks = query.OrderBy(t => t.DueDate).ToList();
//            return View(tasks);


//        }
//        // Display form to add a new ToDo task
//        [HttpGet]
//        public IActionResult Add()
//        {
//            ViewBag.Categories = Context.Categories.ToList();
//            ViewBag.statuses = Context.Statuses.ToList();
//            var task = new ToDo { StatusId = "open" };

//            return View(task);  
//        }
//        // Process form submission for adding a new ToDo task
//        [HttpPost]
//        public IActionResult Add(ToDo Task)
//        {
//            if(ModelState.IsValid)
//            {
//                // Save the new task to the database
//                Context.ToDos.Add(Task);
//                Context.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                // Re-display form with validation messages and dropdown data
//                ViewBag.Categories = Context.Categories.ToList();
//                ViewBag.statuses = Context.Statuses.ToList();
//                return View(Task);
//            }
//        }
//        // Handle filter form submission by building a filter ID and redirecting to Index
//        [HttpPost]
//        public IActionResult filter(string[] filter)
//        {
//            string id = string.Join("-", filter);
//            return RedirectToAction("Index", new { ID = id });
//        }
//        // Mark a ToDo task as completed (closed)
//        [HttpPost]
//        public IActionResult MarkComplete([FromRoute] string id, ToDo selected)
//        {
//            selected = Context.ToDos.Find(selected.Id)!;
//            if(selected != null)
//            {
//                // Set task status to "closed" and save changes
//                selected.StatusId = "closed";
//                Context.SaveChanges();
//            }
//            return RedirectToAction("Index", new {ID = id});
//        }
//        // Delete all tasks marked as "closed"
//        [HttpPost]
//        public IActionResult DeleteComplete(string id) 
//        {
//            var toDelete = Context.ToDos.Where(t => t.StatusId =="closed").ToList();
//            // Remove each of them from the context
//            foreach (var task in toDelete) 
//            {
//                Context.ToDos.Remove(task);
//            }
//            // Remove each of them from the context
//            Context.SaveChanges();
//            return RedirectToAction("Index", new { id});
//       }

//    }
//}
