using Microsoft.AspNetCore.Mvc;
using MvcEf.Models;

namespace MvcEf.Controllers
{
    public class DersController : Controller
    {
        public IActionResult Index()
        {
            using(OkulContext context = new OkulContext())
            {
                List<Ders> derslers = context.Ders.Where(x => x.SilindiMi == false).ToList();

                return View(derslers);
            }          
        }
        public IActionResult Detay(int id)
        {
            using (OkulContext context = new OkulContext())
            {
                Ders ders = context.Ders.First(x => x.Id == id && x.SilindiMi == false);

                return View(ders);
            }
            
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Ders ders)
        {
            using(OkulContext context = new OkulContext())
            {
                context.Ders.Add(ders);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            using(OkulContext context = new OkulContext())
            {
                var ders= context.Ders.First(x => x.Id == id);

                return View(ders);
            }
            
        }
        [HttpPost]
        public IActionResult Guncelle(Ders ders)
        {
            using(OkulContext context = new OkulContext())
            {
                context.Ders.Update(ders);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
        public IActionResult Sil(int id)
        {
            using(OkulContext context = new OkulContext())
            {
                var ders = context.Ders.First(x => x.Id == id);
                ders.SilindiMi = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }
   
}
