﻿using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
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
        public IActionResult Create(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();//Реальная передача в базу данных
            return RedirectToAction("Index");
        }
    }
}
