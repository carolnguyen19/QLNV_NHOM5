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
            SetViewBagLoai();
            SetViewBagPhong();
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
            SetViewBagLoai();
            SetViewBagPhong();
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
            //SetViewBagNgaySinh();
            var model = new NhanVien();
            model.NgaySinh = nhanVien.NgaySinh;
            SetViewBagLoai(nhanVien.LoaiNV);
            SetViewBagPhong(nhanVien.MaPhong);

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
            //SetViewBagNgaySinh();
            SetViewBagLoai();
            SetViewBagPhong();
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(long? id)
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
        public ActionResult DeleteConfirmed(long? id)
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

        //Dùng để filter ds nhân viên theo phòng
        public void SetViewBag(string selectedMaPhong = null)
        {
            ViewBag.ddl = new SelectList(db.Phongs.ToList(), "MaPhong", "TenPhong", 
                                                selectedMaPhong);

        }

        public void SetViewBagLoai(int? selectedLoai = 0)
        {
            var categories = new List<SelectListItem>
            {
                new SelectListItem {Text = "Công nhật", Value = "0"},
                new SelectListItem {Text = "Biên chế", Value = "1"}
            };
            ViewBag.LoaiNV = new SelectList(categories, "Value", "Text",
                                                selectedLoai);
        }

        public void SetViewBagPhong(string selectedPhong = null)
        {
            ViewBag.MaPhong = new SelectList(db.Phongs.ToList(), "MaPhong", "TenPhong",
                                                selectedPhong);
        }

        public void SetViewBagNgaySinh(DateTime? selectedNgaySinh = null)
        {
            ViewBag.DefaultNgaySinh = "19/09/1966";
        }

    }
}
