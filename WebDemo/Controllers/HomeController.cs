using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using System.Net;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace WebDemo.Controllers
{
    public class HomeController : Controller
    {
        QLBanVaLiEntities db = new QLBanVaLiEntities();
        public ActionResult Index(int? page)
        {
            int pageSize = 12; // Số sản phẩm có trên 1 trang
            int pageNumber = (page ?? 1);
            return View(db.tDanhMucSPs.ToList().ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult ChuDePartial()
        {
            return PartialView(db.tLoaiSPs.ToList());
        }

        public PartialViewResult QuocGia()
        {
            return PartialView(db.tQuocGias.ToList());
        }

        public ViewResult SanPhamTheoQuocGia(int? page, string MaNuoc = "my")
        {
            int pageSize = 12; // Số sản phẩm có trên 1 trang
            int pageNumber = (page ?? 1);
            tQuocGia lsp = db.tQuocGias.SingleOrDefault
                (n => n.MaNuoc == MaNuoc);
            if (lsp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<tDanhMucSP> lstSanPham =
                db.tDanhMucSPs.Where(n => n.MaNuocSX == MaNuoc).OrderBy(n => n.MaLoai).ToList();
            if (lstSanPham.Count == 0)
            {
                ViewBag.SanPam = "Không có sản phẩm nào thuộc loại này !!!";
            }

            return View(db.tDanhMucSPs.Where
                (n => n.MaNuocSX == MaNuoc).OrderBy
                (n => n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
        }

        public ViewResult SanPhamTheoChuDe(int? page, string MaLoai = "vali")
        {
            int pageSize = 12; // Số sản phẩm có trên 1 trang
            int pageNumber = (page ?? 1);
            tLoaiSP lsp = db.tLoaiSPs.SingleOrDefault
                (n => n.MaLoai == MaLoai);
            if (lsp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<tDanhMucSP> lstSanPham =
                db.tDanhMucSPs.Where(n => n.MaLoai == MaLoai).OrderBy(n => n.MaLoai).ToList();
            if (lstSanPham.Count == 0)
            {
                ViewBag.SanPam = "Không có sản phẩm nào thuộc loại này !!!";
            }

            return View(db.tDanhMucSPs.Where
                (n => n.MaLoai == MaLoai).OrderBy
                (n=>n.TenSP).ToList().ToPagedList(pageNumber, pageSize));
        }

        public ViewResult XemChiTiet(string MaSP = "bacakeroirbl")
        {
            tDanhMucSP sanpham = db.tDanhMucSPs.SingleOrDefault
                (n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(sanpham);
        }

        [HttpGet]
        public ActionResult ThemSanPham()
        {
            ViewBag.MaChatLieu = new SelectList(db.tChatLieux.ToList().OrderBy(n => n.ChatLieu), "MaChatLieu", "ChatLieu");
            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs.ToList().OrderBy(n => n.KichThuoc), "MaKichThuoc", "KichThuoc");
            ViewBag.MaHangSX = new SelectList(db.tHangSXes.ToList().OrderBy(n => n.HangSX), "MaHangSX", "HangSX");
            ViewBag.MaNuocSX = new SelectList(db.tQuocGias.ToList().OrderBy(n => n.TenNuoc), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.tLoaiSPs.ToList().OrderBy(n => n.Loai), "MaLoai", "Loai");
            ViewBag.MaDT = new SelectList(db.tLoaiDTs.ToList().OrderBy(n => n.TenLoai), "MaDT", "TenLoai");
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham([Bind(Include = "MaSP,TenSP, MaChatLieu ,NganLapTop , Model ,MauSac , MaKichThuoc , CanNang , DoNoi, MaHangSX , MaNuocSX , MaDacTinh , Website, ThoiGianBaoHanh , GioiThieuSP , Gia , ChietKhau , MaLoai , MaDT , Anh ")] tDanhMucSP sanpham)
        {
            if (ModelState.IsValid)
            {
                db.tDanhMucSPs.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanpham);
        }

        [HttpGet]
        public ActionResult ChinhSua(string MaSP)
        {
            if (MaSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tDanhMucSP sanpham = db.tDanhMucSPs.Find(MaSP);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChatLieu =
                new SelectList(db.tChatLieux.ToList().OrderBy(n => n.ChatLieu), "MaChatLieu", "ChatLieu");
            ViewBag.MaKichThuoc = new SelectList(db.tKichThuocs.ToList().OrderBy(n => n.KichThuoc), "MaKichThuoc",
                "KichThuoc");
            ViewBag.MaHangSX = new SelectList(db.tHangSXes.ToList().OrderBy(n => n.HangSX), "MaHangSX", "HangSX");
            ViewBag.MaNuocSX = new SelectList(db.tQuocGias.ToList().OrderBy(n => n.TenNuoc), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.tLoaiSPs.ToList().OrderBy(n => n.Loai), "MaLoai", "Loai");
            ViewBag.MaDT = new SelectList(db.tLoaiDTs.ToList().OrderBy(n => n.TenLoai), "MaDT", "TenLoai");
            return View();
        }

        [HttpPost]
        public ActionResult ChinhSua([Bind(Include =
                "MaSP,TenSP, MaChatLieu ,NganLapTop , Model ,MauSac , MaKichThuoc , CanNang , DoNoi, MaHangSX , MaNuocSX , MaDacTinh , Website, ThoiGianBaoHanh , GioiThieuSP , Gia , ChietKhau , MaLoai , MaDT , Anh ")]
            tDanhMucSP sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Xoa(string MaSP)
        {
            tDanhMucSP sanpham = db.tDanhMucSPs.SingleOrDefault
                (n=>n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(sanpham);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhan(string MaSP)
        {
            tDanhMucSP sanpham = db.tDanhMucSPs.SingleOrDefault
                (n=>n.MaSP==MaSP);
            var anhsp = from p in db.tAnhSPs
                where p.MaSP == sanpham.MaSP
                select p;
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.tAnhSPs.RemoveRange(anhsp);
            db.tDanhMucSPs.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}