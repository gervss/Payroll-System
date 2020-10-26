using MetroFramework.Forms;
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
using System.Configuration;
using MetroFramework;

namespace Project_Ramir
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void metroTextButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DBRamir2016.mdf;Integrated Security=True");
            string LoginStr = " Select Count(*) from tbl_user where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'";

            SqlCommand LoginCMD = new SqlCommand(LoginStr, con);

            con.Open();

            int ctr = Convert.ToInt32(LoginCMD.ExecuteScalar().ToString());

            if (ctr == 1)
            {
                this.Hide();

                MetroMessageBox.Show(this, "", "Successfully Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Main f2 = new Main();
                f2.Show();
            }

            else
            {
                MetroMessageBox.Show(this, "* Invalid Username/Password", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
            }
        }

        private void metroTextButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
