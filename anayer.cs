using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSH_List_Project
{
    public partial class anayer : Form
    {
        public anayer()
        {
            InitializeComponent();
        }
    
        
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CHPA8O3;Initial Catalog=projelist;Integrated Security=True;TrustServerCertificate=True");
        private void anayer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projelistDataSet.proje' table. You can move, or remove it, as needed.
            this.projeTableAdapter.Fill(this.projelistDataSet.proje);
          

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            ekle yeni = new ekle();
            anayer yer = new anayer();
            yeni.Show();
            yer.Controls.Remove(yer);
        }

        string herhangi;
        string text;

        private void bunifuDataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Bilgi blg = new Bilgi();
            blg.bilgiid = lblid.Text;
            blg.bilgibaslık = lblbaslık.Text;
            blg.bilgiacık = text;
            blg.bilgitarih = lbltarih.Text;
            blg.Show();


        }
        

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.projeTableAdapter.Fill(this.projelistDataSet.proje);
            bunifuDatePicker1.Text = DateTime.Now.ToString();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuDatePicker1.Text = DateTime.Now.ToString();
            sql.Open();
            SqlCommand sil = new SqlCommand("DELETE FROM proje WHERE ID=@ıd", sql);//@ıd si olanı sil

            sil.Parameters.AddWithValue("@ıd", herhangi);//lblid den @ıdye veri gidiyor
            sil.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Proje Silindi", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.projeTableAdapter.Fill(this.projelistDataSet.proje);
            sql.Open();
            SqlCommand toplam = new SqlCommand("SELECT Count(*) FROM proje",sql);
            SqlDataReader toplamlar = toplam.ExecuteReader();
            while (toplamlar.Read())
            {
                label3.Text = toplamlar[0].ToString();

            }
            sql.Close();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilendeger = bunifuDataGridView1.SelectedCells[0].RowIndex;

            herhangi = bunifuDataGridView1.Rows[secilendeger].Cells[0].Value.ToString();
            lblid.Text = herhangi;
            lblbaslık.Text = bunifuDataGridView1.Rows[secilendeger].Cells[1].Value.ToString();
            text = bunifuDataGridView1.Rows[secilendeger].Cells[2].Value.ToString();
            lbltarih.Text = bunifuDataGridView1.Rows[secilendeger].Cells[3].Value.ToString();
            
           
        }

        private void bunifuToggleSwitch1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            if (bunifuToggleSwitch1.Checked == true)
            {
                BackColor = Color.DimGray;
                bunifuPictureBox1.ImageLocation = "gece.png";
                bunifuPictureBox1.Load();
                button1.ForeColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                lblid.ForeColor = Color.White;
                lblbaslık.ForeColor = Color.White;
                lbltarih.ForeColor = Color.White;
                bunifuDatePicker1.ForeColor = Color.White;
            }
            else if (bunifuToggleSwitch1.Checked == false)
            {
                BackColor = Color.White;
                bunifuPictureBox1.ImageLocation = "gündüz.png";
                button1.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label3.ForeColor= Color.Black;
                label5.ForeColor = Color.Black;
                lblid.ForeColor = Color.Black;
                lblbaslık.ForeColor = Color.Black;
                lbltarih.ForeColor = Color.Black;
                bunifuDatePicker1.ForeColor = Color.Black;
                bunifuPictureBox1.Load();
            }
        }

        
    }
}
