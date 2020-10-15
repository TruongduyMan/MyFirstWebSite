using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyFirstWebSite.Data;
using MyFirstWebSite.Helpers;
using MyFirstWebSite.View_Models;

namespace MyFirstWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HangHoaController : Controller
    {
        private readonly ILogger _logger;
        private readonly MyDbContext _context;
        public HangHoaController(MyDbContext context, ILogger<HangHoaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.HangHoas.Include(hh => hh.Loai).ToListAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.DanhSachLoai = new LoaiDropDownVM(_context.Loais, "MaLoai", "TenLoai", "MaLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa hh, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var urlHinh = FileHelper.UploadFileToFolder(Hinh, "HangHoa");
                    hh.Hinh = urlHinh;
                    _context.Add(hh);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Loi: {ex.Message}");

                    ViewBag.ThongBaoLoi = "Có lỗi";
                    ViewBag.DanhSachLoai = new LoaiDropDownVM(_context.Loais, "MaLoai", "TenLoai", "MaLoai");
                    return View();
                }
            }
            ViewBag.DanhSachLoai = new LoaiDropDownVM(_context.Loais, "MaLoai", "TenLoai", "MaLoai");
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var hh = _context.HangHoas.FirstOrDefault(h => h.MaHangHoa == id);

            ViewBag.DanhSachLoai = new LoaiDropDownVM(_context.Loais, "MaLoai", "TenLoai", "MaLoai", hh.MaLoai);
            return View(hh);
        }
    }
}
