using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7_VP
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String CompanyID = textBox2.Text;

            System.Data.SqlClient.SqlConnection sqlConnection1 =
             new System.Data.SqlClient.SqlConnection(@"Data Source=DESKTOP-URV7AE9\SQLEXPRESS01;Initial Catalog=softtech;Integrated Security=True");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete customers WHERE CompanyID='"+CompanyID+"'";
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            int i = cmd.ExecuteNonQuery();

            if (i == 1)
            {
                MessageBox.Show("Data deleted");
            }
            else
            {
                MessageBox.Show("Sorry no deletion");
            }
            sqlConnection1.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
