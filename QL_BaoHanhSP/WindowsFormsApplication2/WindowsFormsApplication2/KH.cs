using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class KH
    {
        ObjectId id;
        public KH()
        {

        }
        public KH(string ma,string ten,string sdt,string dc)
        {
            this.MaKH = ma;
            this.TenKH = ten;
            this.SDT = sdt;
            this.DChi = dc;
        }
        public ObjectId _id
        {
            get { return id; }
            set { id = value; }
        }
        string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        string tenKH;

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }
        string sdt;

        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
        string dChi;

        public string DChi
        {
            get { return dChi; }
            set { dChi = value; }
        }

    }
}
