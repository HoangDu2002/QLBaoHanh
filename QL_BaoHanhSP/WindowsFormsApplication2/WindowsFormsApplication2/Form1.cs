using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtTK.Text = "Nhập Giá Trị Cần Tìm Kiếm";
        }
        void loadData()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            //IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("KH");
            var collection = database.GetCollection<KH>("KH");
            var query = collection.AsQueryable<KH>().ToList();
            dataGridView1.DataSource = query;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            //IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("KH");
            var collection=database.GetCollection<KH>("KH");
            var query =collection.AsQueryable<KH>().ToList();
            dataGridView1.DataSource = query;
            /*List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();
            listView1.Items.Clear();
            DataTable da = new DataTable();
            foreach (BsonDocument document in documents)
            {
                DataRow row = da.NewRow();
                string ma = document["Ma"].AsString;
                string ten = document["Ten"].AsString;
                int gia = document["DonGia"].AsInt32;
                row["Id"] = ma;
                row["Name"] = ten;
                row["Gia"] = gia;
                da.Rows.Add(row);
                /*da.Rows.Add("ma");
                da.Rows.Add("ten");
                da.Rows.Add("gia");
                */
                //listView1.Items.Add(ma + "\t" + ten + "\t" + gia);
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtMa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<KH>("KH");
            try
            {
                KH kh = new KH();
                kh.MaKH = txtMa.Text;
                kh.TenKH = txtTen.Text;
                kh.SDT = txtSDT.Text;
                kh.DChi = txtDiaChi.Text;
                collection.InsertOne(kh);
                MessageBox.Show("Khách hàng được thêm thành công");

                loadData();
                reset();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            
        }
        private void reset()
        {
            txtID.Text = "";
            txtMa.Text = "";
            txtTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<KH>("KH");

            try
            {

                collection.DeleteOne( rs =>rs._id == ObjectId.Parse(txtID.Text));
                MessageBox.Show("Khách hàng được Xóa thành công");
                loadData();
                reset();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<KH>("KH");

            try
            {
                KH kh = new KH(txtMa.Text, txtTen.Text, txtSDT.Text, txtDiaChi.Text);
                var update = Builders<KH>.Update.Set("MaKH", txtMa.Text).Set("TenKH", txtTen.Text).Set("SDT", txtSDT.Text).Set("DChi", txtDiaChi.Text);
                collection.UpdateOne(rs => rs._id == ObjectId.Parse(txtID.Text), update);
                MessageBox.Show("Khách hàng được Sửa thành công");
                loadData();
                reset();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Quản Lý Quán Cafe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<KH>("KH");

            try
            {

                string keyword = txtTK.Text.Trim();

                var filter = Builders<KH>.Filter.Or(
                    Builders<KH>.Filter.Eq("MaKH", keyword),
                    Builders<KH>.Filter.Eq("TenKH", keyword),
                    Builders<KH>.Filter.Eq("SDT", keyword),
                    Builders<KH>.Filter.Eq("DChi", keyword)
                );
                var khachHangs = collection.Find(filter).ToList();
                if(khachHangs.Count()!=0)
                {
                    dataGridView1.DataSource = khachHangs;
                    txtTK.Text = "";
                }
                else
                {
                    MessageBox.Show("Thông tim tìm kiếm không tồn tại");
                }
                

               /* var khachHangs1 = collection.Find(filter1).ToList();
                if(khachHangs1!=null)
                {
                    dataGridView1.DataSource = khachHangs1;
                }
                else
                {
                    dataGridView1.DataSource = null;
                }

                var filter2 = Builders<KH>.Filter.Eq("SDT", txtTK.Text);
                var khachHangs2 = collection.Find(filter2).ToList();
                if(khachHangs2!=null)
                {
                    dataGridView1.DataSource = khachHangs2;
                }
                else
                {
                    dataGridView1.DataSource = null;
                }

                var filter3 = Builders<KH>.Filter.Eq("DChi", txtTK.Text);
                var khachHangs3 = collection.Find(filter3).ToList();
                if (khachHangs3 != null)
                {
                    dataGridView1.DataSource = khachHangs3;
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
                /*var filter = Builders<KH>.Filter.Eq("MaKH", txtTK.Text);
                var khachHangs = collection.Find(filter).ToList();
                if(khachHangs==null)
                {
                    dataGridView1.Rows.Clear();
                    var filter1 = Builders<KH>.Filter.Eq("TenKH", txtTK.Text);
                    var khachHangs1 = collection.Find(filter1).ToList();
                    if(khachHangs1==null)
                    {
                        dataGridView1.Rows.Clear();
                        var filter2 = Builders<KH>.Filter.Eq("SDT", txtTK.Text);
                        var khachHangs2 = collection.Find(filter2).ToList();
                        if(khachHangs2==null)
                        {
                            dataGridView1.Rows.Clear();
                            var filter3 = Builders<KH>.Filter.Eq("DChi", txtTK.Text);
                            var khachHangs3 = collection.Find(filter3).ToList();
                            if(khachHangs3!=null)
                            {
                                dataGridView1.DataSource = khachHangs3;
                            }
                            else
                            {
                                MessageBox.Show("Khách hàng được Sửa thành công");
                            }
                            
                        }
                        else
                        {
                            dataGridView1.DataSource = khachHangs2;
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = khachHangs1;
                    }
                }
                else
                {
                    dataGridView1.DataSource = khachHangs;
                }
                // Hiển thị dữ liệu trên DataGridView
                /*foreach (var khachHang in khachHangs)
                {
                    dataGridView1.Rows.Add(khachHang.MaKH, khachHang.TenKH, khachHang.SDT);
                }*/
                reset();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
