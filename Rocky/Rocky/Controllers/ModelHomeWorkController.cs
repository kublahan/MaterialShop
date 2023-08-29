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
            IEnumerable<ModelHomeWork> objList = _db.ModelHomeWork;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {

            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]//Токен безопасности
        public IActionResult Create(ModelHomeWork obj)
        {
            if (ModelState.IsValid)
            {
                _db.ModelHomeWork.Add(obj);
                _db.SaveChanges();//Реальная передача в базу данных
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ModelHomeWork.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ModelHomeWork obj)
        {
            if (ModelState.IsValid)
            {
                _db.ModelHomeWork.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ModelHomeWork.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ModelHomeWork.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ModelHomeWork.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
