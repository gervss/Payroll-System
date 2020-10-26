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
using System.Configuration;
using System.Data.SqlClient;
using MetroFramework;
using System.Runtime.InteropServices;

namespace Project_Ramir
{
    public partial class Admin : MetroForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DBRamir2016.mdf;Integrated Security=True");
        SqlCommand cmd;

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);


        public Admin()
        {
            InitializeComponent();

            SendMessage(txt_fname.Handle, EM_SETCUEBANNER, 0, "First Name");
            SendMessage(txt_lname.Handle, EM_SETCUEBANNER, 0, "Last Name");
            SendMessage(txt_user.Handle, EM_SETCUEBANNER, 0, "Username");
            SendMessage(txt_pass.Handle, EM_SETCUEBANNER, 0, "Password");

            SendMessage(txt_contact.Handle, EM_SETCUEBANNER, 0, "Contact No.");
            SendMessage(txt_email.Handle, EM_SETCUEBANNER, 0, "Email Address");

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_Ramir.tbl_user' table. You can move, or remove it, as needed.
            this.tbl_userTableAdapter.Fill(this.dS_Ramir.tbl_user);

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
             cmd = new SqlCommand("Insert into tbl_user values ('" + txt_fname.Text + " " + txt_lname.Text + "','" + txt_user.Text + "','" + txt_pass.Text + "','" + txt_contact.Text + "','" + txt_email.Text + "','" + txt_lname.Text + "','" + txt_fname.Text + "')", con);
             con.Open();
             cmd.ExecuteNonQuery();
             con.Close();

             txt_fname.Text = "";
             txt_lname.Text = "";
             txt_user.Text = "";
             txt_pass.Text = "";
             txt_contact.Text = "";
             txt_email.Text = "";

             MetroMessageBox.Show(this, "", "Register Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;

            cmd = new SqlCommand("Update tbl_user SET Fullname = '" + txt_fname.Text + " " + txt_lname.Text + "', Username = '" + txt_user.Text + "', Password = '" + txt_pass.Text + "', Contact = '" + txt_contact.Text + "', Email = '" + txt_email.Text + "', l_name = '" + txt_lname.Text + "', f_name = '" + txt_fname.Text + "' Where ID = '" + label1.Text + "'", con); 
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_user.Text = "";
            txt_pass.Text = "";
            txt_contact.Text = "";
            txt_email.Text = "";

            MetroMessageBox.Show(this, "", "Successfully Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;

            cmd = new SqlCommand("Delete From tbl_user Where ID = '" + label1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_user.Text = "";
            txt_pass.Text = "";
            txt_contact.Text = "";
            txt_email.Text = "";

            MetroMessageBox.Show(this, "", "Successfully Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_delete.Enabled = false;
            btn_update.Enabled = false;

            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_user.Text = "";
            txt_pass.Text = "";
            txt_contact.Text = "";
            txt_email.Text = "";
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_save.Enabled = false;
            btn_delete.Enabled = true;
            btn_update.Enabled = true;

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            label1.Text = metroGrid1.Rows[e.RowIndex].Cells[0].Value + "";
            txt_fname.Text = metroGrid1.Rows[e.RowIndex].Cells[7].Value + "";
            txt_lname.Text = metroGrid1.Rows[e.RowIndex].Cells[6].Value + "";
            txt_user.Text = metroGrid1.Rows[e.RowIndex].Cells[2].Value + "";
            txt_pass.Text = metroGrid1.Rows[e.RowIndex].Cells[3].Value + "";
            txt_contact.Text = metroGrid1.Rows[e.RowIndex].Cells[4].Value + "";
            txt_email.Text = metroGrid1.Rows[e.RowIndex].Cells[5].Value + "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tbl_userTableAdapter.Fill(this.dS_Ramir.tbl_user);

        }
    }
}
