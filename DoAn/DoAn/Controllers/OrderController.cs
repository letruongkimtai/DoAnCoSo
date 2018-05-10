using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        dbQLMonanDataContext data = new dbQLMonanDataContext();
        private List<CTMONAN> Laymonanmoi(int count)
        {
            return data.CTMONANs.OrderByDescending(a => a.Giaban).Take(count).ToList();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SPTheoloai(int id)
        {
            var monan = from ma in data.CTMONANs where ma.Maloai == id select ma;
            return View(monan);
        }
        public ActionResult Loai()
        {
            var loai = from l in data.LOAIMONs select l;
            return PartialView(loai);
        }
    }
}