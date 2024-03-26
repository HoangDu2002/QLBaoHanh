using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class BH
    {
        ObjectId id;
        string masp;
        string tensp;
        string nsx;
        string giaban;

        public BH()
        {

        }
        public BH(string ma,string ten,string nxs,string giaban)
        {
            this.MaSP = ma;
            this.TenSP = ten;
            this.NSX = nxs;
            this.GiaBan = giaban;
        }

        public ObjectId _id
        {
            get { return id; }
            set { id = value; }
        }

        public string MaSP
        {
            get { return masp; }
            set { masp = value; }
        }

        public string TenSP
        {
            get { return tensp; }
            set { tensp = value; }
        }

        public string NSX
        {
            get { return nsx; }
            set { nsx = value; }
        }

        public string GiaBan
        {
            get { return giaban; }
            set { giaban = value; }
        }
    }
}
