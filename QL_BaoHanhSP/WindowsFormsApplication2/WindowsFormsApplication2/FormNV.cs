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
    public partial class FormNV : Form
    {
        public FormNV()
        {
            InitializeComponent();
            txtTK.Text = "Nhập Giá Trị Cần Tìm Kiếm";
        }
        void loadData()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<NV>("NV");
            var query = collection.AsQueryable<NV>().ToList();
            dataGridView1.DataSource = query;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");
            var collection = database.GetCollection<NV>("NV");
            var query = collection.AsQueryable<NV>().ToList();
            dataGridView1.DataSource = query;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtMa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtNS.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtCV.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
        private void reset()
        {
            txtID.Text = "";
            txtMa.Text = "";
            txtTen.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<NV>("NV");
            try
            {
                NV nv = new NV();
                nv.MaNV = txtMa.Text;
                nv.TenNV = txtTen.Text;
                nv.NGSinh = txtNS.Text;
                nv.SDT = txtSDT.Text;
                nv.DChi = txtDiaChi.Text;
                nv.ChucVu = txtCV.Text;
                collection.InsertOne(nv);
                MessageBox.Show("Nhân Viên được thêm thành công");

                loadData();
                reset();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<NV>("NV");

            try
            {

                collection.DeleteOne(rs => rs._id == ObjectId.Parse(txtID.Text));
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

            var collection = database.GetCollection<NV>("NV");

            try
            {
                NV nv = new NV(txtMa.Text, txtNS.Text, txtTen.Text, txtSDT.Text, txtDiaChi.Text, txtCV.Text);
                var update = Builders<NV>.Update.Set("MaNV", txtMa.Text).Set("TenNV", txtTen.Text).Set("NGSinh", txtNS.Text).Set("SDT", txtSDT.Text).Set("DChi", txtDiaChi.Text).Set("ChucVu", txtCV.Text);
                collection.UpdateOne(rs => rs._id == ObjectId.Parse(txtID.Text), update);
                MessageBox.Show("Nhân viên được Sửa thành công");
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

            var collection = database.GetCollection<NV>("NV");

            try
            {

                string keyword = txtTK.Text.Trim();

                var filter = Builders<NV>.Filter.Or(
                    Builders<NV>.Filter.Eq("MaNV", keyword),
                    Builders<NV>.Filter.Eq("TenNV", keyword),
                    Builders<NV>.Filter.Eq("NGSinh", keyword),
                    Builders<NV>.Filter.Eq("SDT", keyword),
                    Builders<NV>.Filter.Eq("DChi", keyword),
                    Builders<NV>.Filter.Eq("ChucVu", keyword)
                );
                var NhanViens = collection.Find(filter).ToList();
                if (NhanViens.Count() != 0)
                {
                    dataGridView1.DataSource = NhanViens;
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

        private void FormNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Quản Lý Quán Cafe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
