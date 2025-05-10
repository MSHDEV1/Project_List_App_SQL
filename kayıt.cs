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
    public partial class kayıt : Form
    {
        public kayıt()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CHPA8O3;Initial Catalog=projelist;Integrated Security=True;TrustServerCertificate=True");
        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            giris giris = new giris();  
            giris.Show();

            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand ekle = new SqlCommand("INSERT INTO account(kullanıcıadı,sifre) VALUES (@kul,@sif)",sql);
            ekle.Parameters.AddWithValue("@kul",bunifuTextBox1.Text);
            ekle.Parameters.AddWithValue("@sif",bunifuTextBox2.Text);
            ekle.ExecuteNonQuery();
           
            
            MessageBox.Show("Kayıt Oldunuz","İnfo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            giris giris = new giris();
            giris.Show();
            this.Hide();

            sql.Close();
        }
    }
}
