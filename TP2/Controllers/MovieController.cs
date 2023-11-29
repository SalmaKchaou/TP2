using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP2.Models;

namespace TP2.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
             List<Movie> movies = _db.movies.ToList();
            return View(movies);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            _db.movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _db.movies.Find(id);
            if (movie == null)
            {
                return Content("NOT FOUND ");
            }
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(movie).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var movie = _db.movies.Find(id);
            if (movie == null)
            {
                return Content("NOT FOUND ");
            }
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(movie).State = EntityState.Deleted;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }
}
