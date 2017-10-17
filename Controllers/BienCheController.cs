using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNV_NHOM5;

namespace QLNV_NHOM5.Controllers
{
    public class BienCheController : Controller
    {
        private QLNV_NHOM5Context db = new QLNV_NHOM5Context();

        public ActionResult Index()
        {
            return View(db.NhanViens.Where(x => x.LoaiNV == 1).ToList());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }


        // GET: CongNhat/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,NgaySinh,LoaiNV,MaPhong,Luong,SoNgayLam,BacLuong,PhuCap,TongLuong")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                nhanVien.TongLuong = (nhanVien.Luong * nhanVien.BacLuong) + nhanVien.PhuCap;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
