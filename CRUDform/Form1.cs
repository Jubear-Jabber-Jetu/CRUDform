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

namespace CRUDform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JUBEAR\\MSSQLSERVER01;Initial Catalog=CRUDform;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Information values(@id, @name, @age)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Submitted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JUBEAR\\MSSQLSERVER01;Initial Catalog=CRUDform;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Information set id=@id, name=@name, age=@age", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JUBEAR\\MSSQLSERVER01;Initial Catalog=CRUDform;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Information where id=@id",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void Search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=JUBEAR\\MSSQLSERVER01;Initial Catalog=CRUDform;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Information where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
