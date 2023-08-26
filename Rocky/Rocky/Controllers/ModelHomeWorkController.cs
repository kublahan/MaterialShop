using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    public class ModelHomeWorkController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ModelHomeWorkController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable <ModelHomeWork> objList = _db.ModelHomeWork; 
            return View(objList);
        }


        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ModelHomeWork obj)
        {
            _db.ModelHomeWork.Add(obj);
            _db.SaveChanges();
            return View();
        }
    }
}
