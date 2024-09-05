using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Rehber_uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=faruk\\sqlexpress;Initial Catalog=Rehber-Uygulaması;Integrated Security=True;");
       
       public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from KISILER",baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        } 
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

    }
}
