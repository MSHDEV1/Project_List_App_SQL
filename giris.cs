using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSH_List_Project
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CHPA8O3;Initial Catalog=projelist;Integrated Security=True;TrustServerCertificate=True");
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand giris = new SqlCommand("SELECT * FROM account WHERE kullanıcıadı=@ac AND sifre=@sf",sql);
            giris.Parameters.AddWithValue("@ac",bunifuTextBox1.Text);
            giris.Parameters.AddWithValue("@sf",bunifuTextBox2.Text);
            SqlDataReader komut = giris.ExecuteReader();
            if (komut.Read())
            {
                MessageBox.Show("Giriş Yaptınız", "İnfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                anayer ana = new anayer();
                ana.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                sql.Close();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            kayıt kayıt = new kayıt();

            kayıt.Show();
            this.Hide();
        }
    }
}
