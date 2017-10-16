using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLNV_NHOM5;
using PagedList;

namespace QLNV_NHOM5.Controllers
{
    public class NhanViensController : Controller
    {
        private QLNV_NHOM5Context db = new QLNV_NHOM5Context();

        // GET: NhanViens
        [HttpGet]
        public ActionResult Index()
        {
            SetViewBag();
            return View(db.NhanViens.ToList());
        }

        //POST
        [HttpPost]
        public ActionResult Index(string ddl)
        {
            /////////////// Nhớ nhaaaa
            SetViewBag(ddl);
            var nv = from s in db.NhanViens
                     select s;
            if (!String.IsNullOrEmpty(ddl))
            {
                nv = nv.Where(s => s.MaPhong.Contains(ddl));
            }
            return View(nv.ToList());
        }

        // GET: NhanViens/Details/5
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

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
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

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,NgaySinh,LoaiNV,MaPhong,Luong,SoNgayLam,BacLuong,PhuCap,TongLuong")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(string id)
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

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void SetViewBag(string selectedMaPhong = null)
        {
            ViewBag.ddl = new SelectList(db.Phongs.ToList(), "MaPhong", "TenPhong", 
                                                selectedMaPhong);

        }

       

    }
}
