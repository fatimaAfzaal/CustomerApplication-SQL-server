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

namespace lab7_VP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            String str= @"Data Source=DESKTOP-URV7AE9\SQLEXPRESS01;Initial Catalog=softtech;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader r;

            cmd.CommandText = "SELECT * FROM customers";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();
            r = cmd.ExecuteReader();

            while (r.Read())
            {
                ListViewItem item = new ListViewItem(r[0].ToString());
                item.SubItems.Add(r[1].ToString());
                item.SubItems.Add(r[2].ToString());
                item.SubItems.Add(r[3].ToString());

                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
