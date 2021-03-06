﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;
using System.Reflection;
using System.Xml.Linq;
using System.Diagnostics;
using System.Linq.Expressions;

namespace MovieProject.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBModel db = new MovieDBModel();

        // GET: Movies
        public ActionResult Index()
        {
            var MoviesFullInfo = new MovieCategoryViewModel();
            MoviesFullInfo.Genres = db.MovieCategories.ToList();
            MoviesFullInfo.Movies = db.Movies.ToList();
            MoviesFullInfo.Pictures = db.MoviePictures.ToList();
            MoviesFullInfo.Directors = db.Directors.ToList();


            var query = from d in MoviesFullInfo.Directors
                        join m in MoviesFullInfo.Movies
                        on d.ID equals m.DirectorID
                        select new
                        {
                            MovieName = m.Title,
                            DirectorName = d.Name,
                            DirectorLastname = d.Surname
                        };


            var ExtQuery = MoviesFullInfo.Directors.GroupJoin(
                MoviesFullInfo.Movies, 
                d => d.ID, 
                m=> m.DirectorID,
                (d,mo) => new
                {
                    Movies = mo,
                    DirectorName = d.Name,
                    DirectorLastname = d.Surname
                });

            int[] numbers = { 5};




            var x = new List<int>();



            return View(MoviesFullInfo);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.DirectorID = new SelectList(db.Directors, "ID", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Duration,RatingIMDB,Trailer,MovieDescription,Budget,Income,DirectorID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DirectorID = new SelectList(db.Directors, "ID", "Name", movie.DirectorID);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "ID", "Name", movie.DirectorID);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Duration,RatingIMDB,Trailer,MovieDescription,Budget,Income,DirectorID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DirectorID = new SelectList(db.Directors, "ID", "Name", movie.DirectorID);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
