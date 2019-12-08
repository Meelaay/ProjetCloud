using System;
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
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
