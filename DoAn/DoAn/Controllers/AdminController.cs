using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
namespace DoAn.Controllers
{
    public class AdminController : Controller
    {
        dbQLMonanDataContext db = new dbQLMonanDataContext();
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Monan(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.CTMONANs.ToList().OrderBy(n => n.Mamon).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        [HttpGet]
        public ActionResult ThemmoiMonan()
        {
            ViewBag.Maloai = new SelectList(db.LOAIMONs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemmoiMonan(CTMONAN monan, HttpPostedFileBase fileUpload)
        {
            ViewBag.Maloai = new SelectList(db.LOAIMONs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai");
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images2"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    monan.Anh = fileName;
                    db.CTMONANs.InsertOnSubmit(monan);
                    db.SubmitChanges();
                }
                return RedirectToAction("Monan");
            }
        }
        public ActionResult Chitietmonan(int id)
        {
            CTMONAN monan = db.CTMONANs.SingleOrDefault(n => n.Mamon == id);
            ViewBag.Mamon = monan.Mamon;
            if (monan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(monan);
        }
        [HttpGet]
        public ActionResult Xoamonan(int id)
        {
            CTMONAN monan = db.CTMONANs.SingleOrDefault(n => n.Mamon == id);
            ViewBag.Mamon = monan.Mamon;
            if (monan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(monan);
        }

        [HttpPost, ActionName("Xoamonan")]
        public ActionResult Xacnhanxoa(int id)
        {
            CTMONAN monan = db.CTMONANs.SingleOrDefault(n => n.Mamon == id);
            ViewBag.Mamon = monan.Mamon;
            if (monan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.CTMONANs.DeleteOnSubmit(monan);
            db.SubmitChanges();
            return RedirectToAction("Monan");
        }
        public ActionResult Suamonan(int id)
        {
            CTMONAN monan = db.CTMONANs.SingleOrDefault(n => n.Mamon == id);
            ViewBag.Mamon = monan.Mamon;
            if (monan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Mamon = new SelectList(db.LOAIMONs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai", monan.Mamon);
            return View(monan);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Suamonan(CTMONAN monan, HttpPostedFileBase fileUpload)
        {
            ViewBag.Maloai = new SelectList(db.LOAIMONs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai");
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images2"), fileName);
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    monan.Anh = fileName;
                    UpdateModel(monan);
                    db.SubmitChanges();
                }
                return RedirectToAction("Monan");
            }
        }
    }
}