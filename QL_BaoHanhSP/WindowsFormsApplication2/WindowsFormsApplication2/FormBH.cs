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
    public partial class FormBH : Form
    {
        public FormBH()
        {
            InitializeComponent();
            txtTK.Text = "Nhập Giá Trị Cần Tìm Kiếm";
        }
        void loadData()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<BH>("bh");
            var query = collection.AsQueryable<BH>().ToList();
            dataGridView1.DataSource = query;
        }
        private void reset()
        {
            txtID.Text = "";
            txtMa.Text = "";
            txtTen.Text = "";
            txtNXS.Text = "";
            txtGia.Text = "";
        }

        private void FormBH_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Quản Lý Quán Cafe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtMa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtNXS.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtGia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");
            var collection = database.GetCollection<BH>("bh");
            var query = collection.AsQueryable<BH>().ToList();
            dataGridView1.DataSource = query;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("QLBaoHanh");

            var collection = database.GetCollection<BH>("bh");
            try
            {
                BH bh = new BH();
                bh.MaSP = txtMa.Text;
                bh.TenSP = txtTen.Text;
                bh.NSX = txtNXS.Text;
                bh.GiaBan = txtGia.Text;
                collection.InsertOne(bh);
                MessageBox.Show("Sản phẩm được thêm thành công");

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

            var collection = database.GetCollection<BH>("bh");

            try
            {

                collection.DeleteOne(rs => rs._id == ObjectId.Parse(txtID.Text));
                MessageBox.Show("Sản phẩm được Xóa thành công");
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

            var collection = database.GetCollection<BH>("bh");

            try
            {
                BH bh = new BH(txtMa.Text, txtTen.Text, txtNXS.Text, txtGia.Text);
                var update = Builders<BH>.Update.Set("MaSP", txtMa.Text).Set("TenSP", txtTen.Text).Set("NSX", txtNXS.Text).Set("GiaBan", txtGia.Text);
                collection.UpdateOne(rs => rs._id == ObjectId.Parse(txtID.Text), update);
                MessageBox.Show("Sản phẩm được Sửa thành công");
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

            var collection = database.GetCollection<BH>("bh");

            try
            {

                string keyword = txtTK.Text.Trim();

                var filter = Builders<BH>.Filter.Or(
                    Builders<BH>.Filter.Eq("MaSP", keyword),
                    Builders<BH>.Filter.Eq("TenSP", keyword),
                    Builders<BH>.Filter.Eq("NSX", keyword),
                    Builders<BH>.Filter.Eq("GiaBan", keyword)
                );
                var BHS = collection.Find(filter).ToList();
                if (BHS.Count() != 0)
                {
                    dataGridView1.DataSource = BHS;
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
    }
}
