﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDatabase.Models;

namespace MVCDatabase.Controllers
{
    public class HomeController : Controller
    {
        DatabaseFirstEFEntities db = new DatabaseFirstEFEntities();
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }

        // GET: Crud/Details/5
        public ActionResult Details(int id)
        {
            var detail = db.students.Where(model => model.id == id ).FirstOrDefault();
            return View(detail);
        }

        // GET: Crud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crud/Create
        [HttpPost]
        public ActionResult Create(student s)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        // GET: Crud/Edit/5
        public ActionResult Edit(int id)
        {
            var row = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }

        // POST: Crud/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Edit"] = "<script>alert('Not Updated')</script>";
                }
            }
            return View();
        }

        // GET: Crud/Delete/5
        public ActionResult Delete(int id)
        {
            var deletedRow = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(deletedRow);
        }

        // POST: Crud/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Edit"] = "<script>alert('Not Updated')</script>";
                }
            }
            return View();
        }
    }
}