using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Turkiye.Models.Data;

namespace Turkiye.Controllers
{
    public class TurkıyeController : Controller
    {
        turkiyeEntities db = new turkiyeEntities();
        // GET: Turkıye
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sehirler(string q)
        {
            if (string.IsNullOrEmpty(q)) // boş veya null ise...
                return View(db.tbl_il.ToList());
            else
                return View(db.tbl_il.Where(x => x.il_ad.Contains(q)).ToList());




        }
        public ActionResult İlceler(int sehir)
        {
            var lıste=db.tbl_ilce.Where(x=>x.il_id==sehir).ToList(); //illerin ilçelerine ulaşmak için 
            return View(lıste);
        }
        public ActionResult Semtler(int ılce)
        {
            var lıste = db.tbl_semt.Where(x => x.ilce_id == ılce).ToList(); //illerin ilçelerine ulaşmak için 
            return View(lıste);
        }
    }
}