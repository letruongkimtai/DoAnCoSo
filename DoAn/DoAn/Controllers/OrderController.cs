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
        private List<MONAN> Laymonanmoi(int count)
        {
            return data.MONANs.OrderByDescending(a => a.Giaban).Take(count).ToList();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SPTheoloai(int id)
        {
            var monan = from ma in data.MONANs where ma.Maloai == id select ma;
            return View(monan);
        }
        public ActionResult Loai()
        {
            var loai = from l in data.LOAIs select l;
            return PartialView(loai);
        }
    }
}