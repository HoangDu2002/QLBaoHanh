using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class NV
    {
        ObjectId id;
        string manv;
        string tennv;
        string ngsinh;
        string sdt;
        string dchi;
        string chucvu;

        public NV()
        {

        }
        public NV(string ma,string ten,string ns,string sdt,string schi,string cv)
        {
            this.MaNV = ma;
            this.TenNV = ten;
            this.NGSinh = ns;
            this.SDT = sdt;
            this.DChi = schi;
            this.ChucVu = cv;
        }
        public ObjectId _id
        {
            get { return id; }
            set { id = value; }
        }
        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }
        public string TenNV
        {
            get { return tennv; }
            set { tennv = value; }
        }
        public string NGSinh
        {
            get { return ngsinh; }
            set { ngsinh = value; }
        }
        public string SDT
        {
            get { return sdt; }
            set { sdt = value; }
        }
        public string DChi
        {
            get { return dchi; }
            set { dchi = value; }
        }
        public string ChucVu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }
    }
}
