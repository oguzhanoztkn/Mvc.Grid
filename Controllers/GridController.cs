﻿using Mvc.Grid.Models;
using Mvc.Grid.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Grid.Controllers
{
    public class GridController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Grid
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listele()
        {
            var model = db.Personeller.ToList();
            return View(model);
        }
        public ActionResult Ekle()
        {
            //dropdown için
            List<SelectListItem> ulkeler =
                (from i in db.Ulkeler.ToList()
                 select new SelectListItem
                 {
                     Text = i.Ad,
                     Value = i.Id.ToString()
                 }).ToList();
            ViewBag.Ulkeler = ulkeler;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Personel model)
        {
            var ulke = db.Ulkeler.Where(m => m.Id == model.Ulke.Id).FirstOrDefault();
            model.Ulke = ulke;
            db.Personeller.Add(model);
            db.SaveChanges();

            return RedirectToAction("Listele");
        }
        public ActionResult Duzenle(int id)
        {
            var personel = db.Personeller.Where(m => m.Id == id).FirstOrDefault();

            //dropdown için
            List<SelectListItem> ulkeler =
                (from i in db.Ulkeler.ToList()
                 select new SelectListItem
                 {
                     Text = i.Ad,
                     Value = i.Id.ToString()
                 }).ToList();
            ViewBag.Ulkeler = ulkeler;

            return View(personel);
        }
        [HttpPost]
        public ActionResult Duzenle(Personel model)
        {
            var personel = db.Personeller.Where(m => m.Id == model.Id).FirstOrDefault();
            personel.Ad = model.Ad;
            personel.Soyad = model.Soyad;
            personel.Yas = model.Yas;

            var ulke = db.Ulkeler.Where(m => m.Id == model.Ulke.Id).FirstOrDefault();
            personel.Ulke = ulke;

            db.SaveChanges();

            return RedirectToAction("Listele");
        }

        public ActionResult Sil(int? id)
        {
            if (id!=null)
            {
                var personel = db.Personeller.Where(m => m.Id == id).FirstOrDefault();
                if (personel!=null)
                {
                    db.Personeller.Remove(personel);
                    int deger=db.SaveChanges(); //etkilenen satırları görmek için
                    if (deger>0)
                    {
                        //veritabanı etkilendi
                    }
                    else
                    {
                        //veritabanı etkilenmedi
                    }
                }
            }
            return View();
        }
    }
}