using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
namespace DoAn.Controllers
{
    public class NguoidungController : Controller
    {
        
        dbQLMonanDataContext db = new dbQLMonanDataContext();
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            return View();
        }       
        
        [HttpPost]
        public ActionResult Dangky(FormCollection collection,KHACHHANG kh)
        {
            var hoten = collection.Get("HotenKH");
            var tendn = collection.Get("TenDN");
            var matkhau = collection.Get("Matkhau");
            var matkhaunhaplai = collection.Get("Matkhaunhaplai");
            var diachi  = collection.Get("Diachi");
            var email = collection.Get("Email");
            var dienthoai = collection.Get("Dienthoai");
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection.Get("Ngaysinh"));
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            }


            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Địa chỉ không được bỏ trống";
            }

            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "Phải nhập điện thoai";
            }
            else
            {
                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.Diachi = diachi;
                kh.Dienthoai = dienthoai;
                kh.Ngaysinh =DateTime.Parse(ngaysinh);
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Dangky();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            string tendn = collection.Get("userName");
            string matkhau = collection.Get("password");

            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
            if (kh != null)
            {
                
                Session["Taikhoan"] = kh;
                return RedirectToAction("Giohang", "Giohang");
            }
            else ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            return View();
        }
    }
}