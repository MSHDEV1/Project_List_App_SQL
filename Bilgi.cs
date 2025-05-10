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
    public partial class Bilgi : Form
    {
        public Bilgi()
        {
            InitializeComponent();
        
             
         }
        
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CHPA8O3;Initial Catalog=projelist;Integrated Security=True;TrustServerCertificate=True");
        anayer ana = new anayer();
        public string bilgiid, bilgibaslık, bilgiacık, bilgitarih;
        string tarih;

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.Filter = "yazılım|*.txt";
            saveFileDialog1.ShowDialog();
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            sw.WriteLine("İD:"+" "+bilgiid);
            sw.WriteLine("Başlık:"+" "+bilgibaslık);
            sw.WriteLine("Açıklama:"+" "+bilgiacık);
            sw.WriteLine("Tarih:"+" "+bilgitarih);
            sw.Close();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "yazılım|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string acık = sr.ReadLine();
                while (acık != null)
                {
                    bunifuTextBox2.Text = acık;
                    acık = sr.ReadLine();
                }
            }
           
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            tarih = bunifuDatePicker1.Text = DateTime.Now.ToString();
            sql.Open();
            SqlCommand guncel = new SqlCommand("UPDATE proje SET Başlık= @bas,Acıklama=@acık,Tarih = @tar WHERE ID=@ıd",sql);
            guncel.Parameters.AddWithValue("@ıd", label1.Text);
            guncel.Parameters.AddWithValue("@bas", bunifuTextBox1.Text);
            guncel.Parameters.AddWithValue("@acık",bunifuTextBox2.Text);
            guncel.Parameters.AddWithValue("@tar", tarih);
            
            guncel.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Güncelleme Başarılı", "İnfo", MessageBoxButtons.OK);
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Enabled = true;
            bunifuTextBox2.Enabled = true;
            bunifuButton1.Visible = true;
            bunifuButton2.Visible= false;
            MessageBox.Show("Güncellemeye Başladınız","İnfo",MessageBoxButtons.OK);
           
           ;
        }

        private void Bilgi_Load(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = bilgibaslık;
            bunifuTextBox2.Text = bilgiacık;
            bunifuDatePicker1.Text = bilgitarih;
            label1.Text = bilgiid;
        }
    }
}
