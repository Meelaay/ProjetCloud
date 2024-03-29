﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetCloud.Models;

namespace ProjetCloud.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBEntities _db = new MoviesDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Movies.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind (Exclude="Id")] Movie movieToCreate)
        {
            if (!ModelState.IsValid) return View();
            _db.Movies.Add(movieToCreate);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var movieToEdit = (from m in _db.Movies
                               where m.Id == id
                               select m).First();

            return View(movieToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movieToEdit)
        {
            var originalMovie = (from m in _db.Movies
                                 where m.Id == movieToEdit.Id
                                 select m).First();
            if (!ModelState.IsValid)
                return View(originalMovie);



            _db.Entry(originalMovie).CurrentValues.SetValues(movieToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var movieToDelete = (from m in _db.Movies
                where m.Id == id
                select m).First();

            return View(movieToDelete);
        }

        [HttpPost]
        public ActionResult Delete(Movie movieToDelete)
        {
            if (!_db.Movies.Local.Contains(movieToDelete))
                _db.Movies.Attach(movieToDelete);
            
            _db.Movies.Remove(movieToDelete);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
