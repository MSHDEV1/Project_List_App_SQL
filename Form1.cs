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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int zaman = 0;
        string version;
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CHPA8O3;Initial Catalog=projelist;Integrated Security=True;TrustServerCertificate=True");
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            bunifuCircleProgress1.Value += 1;
            
        
                zaman += 1;
                if (zaman == 10)
                {
                    label4.Text = "Yükleniyor.";
                }
                if (zaman == 20)
                {
                    label4.Text = "Yükleniyor..";
                }
                if (zaman == 30)
                {
                    label4.Text = "Yükleniyor...";
                }
                if (zaman >= 31)
                {
                    zaman = 0;
                }
            
                
            if (bunifuCircleProgress1.Value == 100)
            {
                
                giris giris = new giris();
                giris.Show();
                this.Hide();
                timer1.Stop();

            }
        }
   
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projelistDataSet2.vers' table. You can move, or remove it, as needed.
            this.versTableAdapter.Fill(this.projelistDataSet2.vers);
            
            int secilendeger = bunifuDataGridView1.SelectedCells[0].RowIndex;

            version = bunifuDataGridView1.Rows[secilendeger].Cells[0].Value.ToString();
            if (version.ToString() != label5.Text)
            {
                MessageBox.Show("Version Uyumsuz Veya Eski Olabilir","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
