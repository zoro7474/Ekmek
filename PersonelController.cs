using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;

namespace MvcRestaurant.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersnelEkle(TBLPERSONEL p)
        {
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var person = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);
            return View("PersoneliGetir", prs);
        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs = db.TBLPERSONEL.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}