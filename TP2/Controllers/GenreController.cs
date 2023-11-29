using Microsoft.AspNetCore.Mvc;
using TP2.Models;

namespace TP2.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }

    }
}
