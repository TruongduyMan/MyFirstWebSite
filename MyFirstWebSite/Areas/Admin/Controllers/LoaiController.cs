using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstWebSite.Data;
using MyFirstWebSite.View_Models;
using System.Linq;

namespace MyFirstWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiController : Controller
    {
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Loais.Include(l => l.LoaiCha).ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.DanhSachLoaiCha = new LoaiDropDownVM(_context.Loais, "MaLoai", "TenLoai", "MaLoaiCha");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Loai l)
        {
            if (ModelState.IsValid)
            {
                _context.Add(l);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanhSachLoaiCha = new LoaiDropDownVM(_context.Loais, "MaLoai", "TenLoai", "MaLoaiCha");
            return View();
        }

        //public IActionResult Edit()
        //{
        //    var data = _context.Loais.A
        //    return View();
        //}

    }
}
