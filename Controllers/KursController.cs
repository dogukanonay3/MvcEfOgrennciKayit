using Microsoft.AspNetCore.Mvc;
using MvcEf.Models;

namespace MvcEf.Controllers
{
    public class KursController : Controller
    {
        public IActionResult Index()
        {     //---------------------------------------------------BUNU YAPMANIN ANLAMINI HOCAYA SOR--------------------------------------
            using (OkulContext context = new OkulContext())
            {
                List<Kurs> kurslar = context.Kurs.Where(x => x.SilindiMi == false).ToList();

                return View(kurslar);
            }
        }
        public IActionResult Detay(int id)
        {
            using (OkulContext context = new OkulContext())
            {
                Kurs kurs = context.Kurs.First(x => x.Id == id && x.SilindiMi == false);

                return View(kurs);
            }
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Kurs kurs)
        {
            using (OkulContext context = new OkulContext())
            {
                context.Kurs.Add(kurs);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            //db kayıt

        }
        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            using (OkulContext context = new OkulContext())
            {
                var kurs = context.Kurs.First(x => x.Id == id);

                return View(kurs);
            }


        }
        [HttpPost]
        public IActionResult Guncelle(Kurs kurs)
        {
            using (OkulContext context = new OkulContext())
            {
                context.Kurs.Update(kurs);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

        }
        public IActionResult Sil(int id)
        {
            using (OkulContext context = new OkulContext())
            {
                var kurs = context.Kurs.First(x => x.Id == id);
                kurs.SilindiMi = true;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }
    }
}
