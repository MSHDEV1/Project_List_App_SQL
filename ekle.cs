using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSH_List_Project
{
    public partial class ekle : Form
    {
        public ekle()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CHPA8O3;Initial Catalog=projelist;Integrated Security=True;TrustServerCertificate=True");
         

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string tarih =  bunifuDatePicker1.Text = DateTime.Now.ToString();
            anayer ana = new anayer();
            sql.Open();

            SqlCommand ekle = new SqlCommand("INSERT INTO proje(Başlık,Acıklama,Tarih) VALUES (@bas ,@acık,@tari)", sql);
            ekle.Parameters.AddWithValue("@bas", bunifuTextBox1.Text);
            ekle.Parameters.AddWithValue("@acık", bunifuTextBox2.Text);
            ekle.Parameters.AddWithValue("@tari", tarih);
            ekle.ExecuteNonQuery();


            sql.Close();
            MessageBox.Show("Proje Eklendi", "İnfo", MessageBoxButtons.OK);

            this.Close();
        }
    }
}
