using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Listele()
        {
            ToDoListEntitiesConnectionStringDB db = new ToDoListEntitiesConnectionStringDB();
            ViewBag.Liste = db.Lists;
            return View();
        }
        [HttpPost]
        public ActionResult Kaydet(List l)
        {
            ToDoListEntitiesConnectionStringDB db = new ToDoListEntitiesConnectionStringDB();
            db.Lists.Add(l);
            db.SaveChanges();
            return RedirectToAction("Listele");
        }
        [HttpPost]
        public ActionResult Duzenle( List D)
        {
            ToDoListEntitiesConnectionStringDB db = new ToDoListEntitiesConnectionStringDB();
            List KL = db.Lists.FirstOrDefault(x => x.id == D.id);
            KL.Title = D.Title;
            KL.Description = D.Description;
            db.SaveChanges();
            return RedirectToAction("Listele");
        }

        public ActionResult Sil(int id)
        {
            ToDoListEntitiesConnectionStringDB db = new ToDoListEntitiesConnectionStringDB();
            List silinecek = db.Lists.FirstOrDefault(x => x.id == id);
            db.Lists.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Listele");
        } 
    }
}