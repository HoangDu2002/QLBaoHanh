using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class FormHD : Form
    {
        public FormHD()
        {
            InitializeComponent();
            loadCBNV();
            loadCBKH();
            loadCBSP();
            loadCBTGBH();
            cbKH.SelectedValue = "";
            cbNV.SelectedValue = "";
            cbSP.SelectedValue = "";
            cbTGBH.Text = "";
        }
        void loadData()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            //IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("KH");
            var collection = database.GetCollection<HD>("HD");
            var query = collection.AsQueryable<HD>().ToList();
            dataGridView1.DataSource = query;
        }
        /*private void reset()
        {
            txtID.Text = "";
            txtMa.Text = "";
            txtTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }*/
        private void loadCBNV()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<NV>("NV");
            List<NV> query = collection.AsQueryable<NV>().ToList();
            cbNV.DataSource = query;
            cbNV.ValueMember = "MaNV";
            cbNV.DisplayMember = "TenNV";
        }
        private void loadCBKH()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<KH>("KH");
            List<KH> query = collection.AsQueryable<KH>().ToList();
            cbKH.DataSource = query;
            cbKH.ValueMember = "MaKH";
            cbKH.DisplayMember = "TenKH";
        }
        private void loadCBSP()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<BH>("bh");
            var query = collection.AsQueryable<BH>().ToList();
            cbSP.DataSource = query;
            cbSP.ValueMember = "MaSP";
            cbSP.DisplayMember = "TenSP";
        }
        private void loadCBTGBH()
        {
            // Giả sử bạn lấy danh sách số nguyên từ một mảng
            string[] dataArray = new string[] { "1 tháng", "2 tháng", "3 tháng", "4 tháng", "5 tháng","6 tháng","7 tháng","8 tháng","9 tháng","10 tháng","11 tháng","12 tháng"};

            // Chuyển mảng thành danh sách List<int>
            List<string> dataList = dataArray.ToList();
            cbTGBH.DataSource = dataList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<HD>("HD");
            try
            {
                HD hd = new HD();
                hd.MaHD = txtMa.Text;
                hd.MaKH = cbKH.SelectedValue.ToString();
                hd.MaNV = cbNV.SelectedValue.ToString();
                hd.MaSP = cbSP.SelectedValue.ToString();
                hd.NgMua = txtNgay.Text;
                hd.TimeBH = cbTGBH.SelectedItem.ToString();
                hd.TongTien = txtTT.Text;
                collection.InsertOne(hd);
                MessageBox.Show("Hóa đơn được thêm thành công");

                loadData();
                reset();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void reset()
        {
            txtID.Text = "";
            txtMa.Text = "";
            cbKH.SelectedValue = "";
            cbNV.SelectedValue = "";
            cbSP.SelectedValue = "";
            txtNgay.Text = "";
            cbTGBH.Text = "";
            txtTT.Text = "";
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtMa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbKH.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbNV.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbSP.SelectedValue = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtNgay.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbTGBH.SelectedItem= dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtTT.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<HD>("HD");

            try
            {

                collection.DeleteOne(rs => rs._id == ObjectId.Parse(txtID.Text));
                MessageBox.Show("Hóa đơn được Xóa thành công");
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

            var collection = database.GetCollection<HD>("HD");

            try
            {
                var update = Builders<HD>.Update.Set("MaHD", txtMa.Text).Set("MaKH", cbKH.SelectedValue).Set("MaNV", cbNV.SelectedValue).Set("MaSP", cbSP.SelectedValue).Set("NgMua", txtNgay.Text).Set("TimeBH", cbTGBH.SelectedItem).Set("TongTien", txtTT.Text);
                collection.UpdateOne(rs => rs._id == ObjectId.Parse(txtID.Text), update);
                MessageBox.Show("Hóa đơn được Sửa thành công");
                loadData();
                reset();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<HD>("HD");

            try
            {

                string keyword = txtTK.Text.Trim();

                var filter = Builders<HD>.Filter.Or(
                    Builders<HD>.Filter.Eq("MaHD", keyword),
                    Builders<HD>.Filter.Eq("MaKH", keyword),
                    Builders<HD>.Filter.Eq("MaNV", keyword),
                    Builders<HD>.Filter.Eq("MaSP", keyword),
                    Builders<HD>.Filter.Eq("NgMua", keyword),
                    Builders<HD>.Filter.Eq("TimeBH", keyword),
                    Builders<HD>.Filter.Eq("TongTien", keyword)
                );
                var HoaDons = collection.Find(filter).ToList();
                if (HoaDons.Count() != 0)
                {
                    dataGridView1.DataSource = HoaDons;
                    txtTK.Text = "";
                }
                else
                {
                    MessageBox.Show("Thông tim tìm kiếm không tồn tại");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FormHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Quản Lý Quán Cafe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
