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
            SqlDataAdapter da = new SqlDataAdapter("Select * from KISILER", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into KISILER(AD,SOYAD,TELEFON,MAIL) values (@P1,@P2,@P3,@P4)", baglanti);
            cmd.Parameters.AddWithValue("@P1", txt_ad.Text);
            cmd.Parameters.AddWithValue("@P2", txt_soyad.Text);
            cmd.Parameters.AddWithValue("@P3", masked_tel.Text);
            cmd.Parameters.AddWithValue("@P4", txt_mail.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kişi başarıyla eklendi");
            listele();
            temizle();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        void temizle()
        {
            txt_ad.Text = "";
            txt_id.Text = "";
            masked_tel.Text = "";
            txt_mail.Text = "";
            txt_soyad.Text = "";
            txt_ad.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txt_id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            masked_tel.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txt_mail.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("delete from KISILER where ID=" + txt_id.Text, baglanti); // bu da farklı bir kullanım
            cmd.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Silme işlemi başarılı");
            listele();
            temizle();
        }

        // Ömer faruk karakurt//
        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("update KISILER set AD=@P1,SOYAD=@P2,TELEFON=@P3,MAIL=@P4 where ID=@P5", baglanti);
            cmd.Parameters.AddWithValue("@P1", txt_ad.Text);
            cmd.Parameters.AddWithValue("@P2", txt_soyad.Text);
            cmd.Parameters.AddWithValue("@P3", masked_tel.Text);
            cmd.Parameters.AddWithValue("@P4", txt_mail.Text);
            cmd.Parameters.AddWithValue("@P5", txt_id.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Güncelleme işlemi Başarılı");
            listele();
            temizle();

        }
    }
}
