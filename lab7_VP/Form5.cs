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
    public partial class Form5 : Form
    {
        bool flag = true;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String CompanyID = textBox2.Text;
            String str = @"Data Source=DESKTOP-URV7AE9\SQLEXPRESS01;Initial Catalog=softtech;Integrated Security=True";
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
                if (r[0].ToString() == CompanyID)
                {
                    flag= false;
                    textBox1.Text = r[1].ToString();
                    textBox3.Text = r[2].ToString();
                    textBox4.Text = r[3].ToString();
                }
            }
            if (flag)
            {
                MessageBox.Show("Data not found");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String CompanyID = textBox2.Text;
            String str = @"Data Source=DESKTOP-URV7AE9\SQLEXPRESS01;Initial Catalog=softtech;Integrated Security=True";
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
                if (r[0].ToString() == CompanyID)
                {
                    String str1 = @"Data Source=DESKTOP-URV7AE9\SQLEXPRESS01;Initial Catalog=softtech;Integrated Security=True";
                    SqlConnection con1 = new SqlConnection(str1);
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "UPDATE customers SET CompanyName='"+textBox1.Text+"',ContactName='"+textBox3.Text+"',Phone='"+textBox4.Text+ "' WHERE CompanyID = '" + CompanyID + "'";
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = con1;
                    con1.Open();
                    int i = cmd1.ExecuteNonQuery();

                    if (i == 1)
                    {
                        MessageBox.Show("Data updated");
                    }
                    else
                    {
                        MessageBox.Show("Sorry no updation");
                    }
                    con1.Close();
                }
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
