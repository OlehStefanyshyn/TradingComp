using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingCompMVC.Models;
using System.Data.Entity;

namespace TradingCompMVC.Controllers
{
    public class StockItemC : Controller
    {
        public ActionResult Index()
        {
            using (DBM db = new DBM())
            {
                return View(db.SI.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (DBM db = new DBM())
            {
                return View(db.SI.Where(x => x.item_id == id).FirstOrDefault());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SI si)
        {
            try
            {
                using (DBM db = new DBM())
                {
                    db.SI.Add(si);
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
                return View(db.SI.Where(x => x.O_M_id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Order_Manager o_m)
        {
            try
            {
                using (DBM db = new DBM())
                {
                    db.Entry(o_m).State = EntityState.Modified;
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
                return View(db.SI.Where(x => x.O_M_id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, SI o_m)
        {
            try
            {
                using (DBM db = new DBM())
                {
                    return View(db.SI.Where(x => x.O_M_id == id).FirstOrDefault());
                    db.SI.SaveChanges();
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