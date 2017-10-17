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
    public class CongNhatController : Controller
    {
        private QLNV_NHOM5Context db = new QLNV_NHOM5Context();

        // GET: CongNhat
        public ActionResult Index()
        {
            return View(db.NhanViens.Where(x => x.LoaiNV == 0).ToList());
        }

        // GET: CongNhat/Details/5
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

        // POST: CongNhat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,NgaySinh,LoaiNV,MaPhong,Luong,SoNgayLam,BacLuong,PhuCap,TongLuong")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                nhanVien.TongLuong = nhanVien.Luong * nhanVien.SoNgayLam;
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
