using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class HD
    {

        public HD()
        {

        }
        public HD(string ma,string makh,string manv,string masp,string ngmua,string tgbh,string tt)
        {
            this.MaHD = ma;
            this.MaKH = makh;
            this.MaNV = manv;
            this.MaSP = masp;
            this.NgMua = ngmua;
            this.TimeBH = tgbh;
            this.TongTien = tt;
        }
        ObjectId id;

        public ObjectId _id
        {
            get { return id; }
            set { id = value; }
        }
        string mahd;

        public string MaHD
        {
            get { return mahd; }
            set { mahd = value; }
        }
        string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        string maNV;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        string maSP;

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        string ngMua;

        public string NgMua
        {
            get { return ngMua; }
            set { ngMua = value; }
        }
        string timeBH;

        public string TimeBH
        {
            get { return timeBH; }
            set { timeBH = value; }
        }
        string tongTien;

        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
    }
}
