using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAn.Models;

namespace DoAn.Models
{
    public class Giohang
    {

        dbQLMonanDataContext data = new dbQLMonanDataContext();
        public int iMamon{set; get;}
        public string sTenmon{set; get;}
        public int sGiaban{set; get;}
        public int iSoluong { set; get; }
        public string sAnh { set; get; }
        public Double dDongia{set; get;}
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }

        }
        public Giohang(int Mamon)
        {
            iMamon = Mamon;
            CTMONAN monan = data.CTMONANs.Single(n => n.Mamon == iMamon);
            sTenmon = monan.Tenmon;
            sAnh = monan.Anh;
            dDongia =double.Parse(monan.Giaban.ToString());
            iSoluong = 1;
        }
    }
}