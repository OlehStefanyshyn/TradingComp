using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingCompMVC.Models;
using System.Data.Entity;

namespace TradingCompMVC.Controllers
{
    public class StockManagerC : Controller
    {
        public ActionResult Index()
        {
            using (DBM db = new DBM())
            {
                return View(db.StockManager.Tolist());
            }
        }

 
        public ActionResult Details(int id)
        {
            using(DBM db = new DBM())
            {
                return View(db.StockManager.Where(x => x.SM_id == id).FirstOrDefault());
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StockManager stockmanager)
        {
            try
            {
                using (DBM db = new DBM())
                {
                    db.stockManager.Add(stockmanager);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (DBM db = new DBM())
            {
                return View(db.StockManager.Where(x => x.SM_id == id).FirstOrDefault());
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, StockManager stockmanager)
        {
            try
            {
                using(DBM db = new DBM())
                {
                    db.Entry(stockmanager).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (DBM db = new DBM())
            {
                return View(db.StockManager.Where(x => x.StockManager_id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, StockManager stockmanager)
        {
            try
            {
                using (DBM db = new DBM())
                {
                    return View(db.StockManager.Where(x => x.SM_id == id).FirstOrDefault());
                    db.StockManager.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}