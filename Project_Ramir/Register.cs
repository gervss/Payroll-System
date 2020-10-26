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
using System.Runtime.InteropServices;

namespace Project_Ramir
{
    public partial class Register : MetroForm
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DBRamir2016.mdf;Integrated Security=True");

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public Register()
        {
            InitializeComponent();

            SendMessage(txt_fname.Handle, EM_SETCUEBANNER, 0, "First Name");
            SendMessage(txt_lname.Handle, EM_SETCUEBANNER, 0, "Last Name");
            SendMessage(txt_mname.Handle, EM_SETCUEBANNER, 0, "Middle Name");

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            string CountRecord = "Select count(*) from tbl_employee";
            SqlCommand Countcmd = new SqlCommand(CountRecord, con);

            int EmpGen = Convert.ToInt32(Countcmd.ExecuteScalar().ToString());
            string GenerateEmp = "";

            if (EmpGen < 9)
            { GenerateEmp = "Emp-" + "0000" + (EmpGen + 1);}
            else if (EmpGen < 100)
            { GenerateEmp = "Emp-" + "000" + (EmpGen + 1); }
            else if (EmpGen < 1000)
            { GenerateEmp = "Emp-" + "00" + (EmpGen + 1); }
            else if (EmpGen < 10000)
            { GenerateEmp = "Emp-" + "0" + (EmpGen + 1); }
            else if (EmpGen < 100000)
            { GenerateEmp = "Emp-" + "" + (EmpGen + 1); }

            cmd = new SqlCommand("Insert Into tbl_employee (EmployeeID, FullName, Birthdate, Address, Email, Contact, MartialStatus, Department, Position, Date, f_name, l_name, m_name, status , cutoff, hours) values (@EmployeeID, @FullName, @Birthdate, @Address, @Email, @Contact, @MartialStatus, @Department, @Position, @Date, @f_name, @l_name, @m_name,  @status , @cutoff, @hours) ", con);
            cmd.Parameters.AddWithValue("@EmployeeID", GenerateEmp);
            cmd.Parameters.AddWithValue("@FullName",  txt_lname.Text + " " + txt_fname.Text + " " + txt_mname.Text); 
            cmd.Parameters.AddWithValue("@Birthdate", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Address", txt_address.Text);
            cmd.Parameters.AddWithValue("@Email", txt_email.Text);
            cmd.Parameters.AddWithValue("@Contact", txt_contact.Text);
            cmd.Parameters.AddWithValue("@MartialStatus", txt_status.Text);
            cmd.Parameters.AddWithValue("@Department", txt_department.Text);
            cmd.Parameters.AddWithValue("@Position", txt_position.Text);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@f_name", txt_fname.Text);
            cmd.Parameters.AddWithValue("@l_name", txt_lname.Text);
            cmd.Parameters.AddWithValue("@m_name", txt_mname.Text);
            cmd.Parameters.AddWithValue("@status", "Active");
            cmd.Parameters.AddWithValue("@cutoff", "0");
            cmd.Parameters.AddWithValue("@hours", "0");

            cmd.ExecuteNonQuery();

            MetroMessageBox.Show(this, "", "Register Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_mname.Text = "";
            dateTimePicker1.Text = "";
            txt_email.Text = "";
            txt_contact.Text = "";
            txt_address.Text = "";
            txt_status.Text = "";
            txt_department.Text = "";
            txt_position.Text = "";

        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("Update tbl_employee SET EmployeeID = @EmployeeID, FullName = @FullName, Birthdate = @Birthdate, Address = @Address, Email = @Email, Contact = @Contact, MartialStatus = @MartialStatus, Department = @Department, Position = @Position, Date = @Date, f_name = @f_name, l_name = @l_name, m_name = @m_name Where EmployeeID = '" + lbl_Holder.Text + "'", con);
            cmd.Parameters.AddWithValue("@EmployeeID", lbl_Holder.Text);
            cmd.Parameters.AddWithValue("@FullName", txt_lname.Text + " " + txt_fname.Text + " " + txt_mname.Text);
            cmd.Parameters.AddWithValue("@Birthdate", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Address", txt_address.Text);
            cmd.Parameters.AddWithValue("@Email", txt_email.Text);
            cmd.Parameters.AddWithValue("@Contact", txt_contact.Text);
            cmd.Parameters.AddWithValue("@MartialStatus", txt_status.Text);
            cmd.Parameters.AddWithValue("@Department", txt_department.Text);
            cmd.Parameters.AddWithValue("@Position", txt_position.Text);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString());
            cmd.Parameters.AddWithValue("@f_name", txt_fname.Text);
            cmd.Parameters.AddWithValue("@l_name", txt_lname.Text);
            cmd.Parameters.AddWithValue("@m_name", txt_mname.Text);
            


            cmd.ExecuteNonQuery();

            MetroMessageBox.Show(this, "", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_mname.Text = "";
            dateTimePicker1.Text = "";
            txt_email.Text = "";
            txt_contact.Text = "";
            txt_address.Text = "";
            txt_status.Text = "";
            txt_department.Text = "";
            txt_position.Text = "";

            this.Close();

            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Delete From tbl_employee Where EmployeeID = '" + lbl_Holder.Text + "'", con);
            cmd.ExecuteNonQuery();

            MetroMessageBox.Show(this, "", "Delete Successfully", MessageBoxButtons.OK, MessageBoxIcon.Error);

            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_mname.Text = "";
            dateTimePicker1.Text = "";
            txt_email.Text = "";
            txt_contact.Text = "";
            txt_address.Text = "";
            txt_status.Text = "";
            txt_department.Text = "";
            txt_position.Text = "";

            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;

            this.Close();
        }
        


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Register_Load(object sender, EventArgs e)
        {


            lbl_Holder.Text = Session.holderID;
            lbl_set.Text = Session.holderSet;

            txt_hours.Text = Session.hours;
            lbl_cutoff.Text = Session.cutoff;


            if (DateTime.Now.ToString("dd") == "15")
            {
                btn_save2.Enabled = true;
            }
            else if (DateTime.Now.ToString("dd") == "30")
            {
                btn_save2.Enabled = true;
            }
            else
            {
                btn_save2.Enabled = false;
            }

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (lbl_set.Text == "Register") 
            {
                btn_save.Enabled = true;
                btn_save.Visible = true;
                btn_save2.Visible = false;
                btn_clear.Visible = true;
                btn_clear2.Visible = false;

                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                gb_deduction.Enabled = false;
                groupBox5.Enabled = false;

            }

            else if (lbl_set.Text == "Add Salary")
            {

                txt_hours.Focus();

                btn_save2.Visible = true;
                
                btn_save.Visible = false;
                btn_clear.Visible = false;
                btn_clear2.Visible = true;
                groupBox1.Enabled = false ;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                gb_deduction.Enabled = true;
                groupBox5.Enabled = true;
                

                try
                {
                    string select = "Select * from tbl_employee Where EmployeeID = '" + lbl_Holder.Text + "'";
                    cmd = new SqlCommand(select, con);
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    txt_fname.Text = dt.Rows[0]["f_name"].ToString();
                    txt_lname.Text = dt.Rows[0]["l_name"].ToString();
                    txt_mname.Text = dt.Rows[0]["m_name"].ToString();
                    dateTimePicker1.Text = dt.Rows[0]["Birthdate"].ToString();
                    txt_email.Text = dt.Rows[0]["Email"].ToString();
                    txt_contact.Text = dt.Rows[0]["Contact"].ToString();
                    txt_address.Text = dt.Rows[0]["Address"].ToString();
                    txt_status.SelectedItem = dt.Rows[0]["MartialStatus"].ToString();
                    txt_department.SelectedItem = dt.Rows[0]["Department"].ToString();
                    txt_position.SelectedItem = dt.Rows[0]["Position"].ToString();
                }
                catch
                {
                }

            }

            else if (lbl_set.Text == "Edit Details")
            {
                btn_save.Enabled = false;
                btn_update.Enabled = true;
                btn_delete.Enabled = true;

                btn_save.Enabled = false;
                btn_save.Visible = true;
                btn_save2.Visible = false;
                btn_clear.Visible = true;
                btn_clear2.Visible = false;

                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                gb_deduction.Enabled = false;
                groupBox5.Enabled = false;

                try
                {
                    string select = "Select * from tbl_employee Where EmployeeID = '" + lbl_Holder.Text + "'";
                    cmd = new SqlCommand(select, con);
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    txt_fname.Text = dt.Rows[0]["f_name"].ToString();
                    txt_lname.Text = dt.Rows[0]["l_name"].ToString();
                    txt_mname.Text = dt.Rows[0]["m_name"].ToString();
                    dateTimePicker1.Text = dt.Rows[0]["Birthdate"].ToString();
                    txt_email.Text = dt.Rows[0]["Email"].ToString();
                    txt_contact.Text = dt.Rows[0]["Contact"].ToString();
                    txt_address.Text = dt.Rows[0]["Address"].ToString();
                    txt_status.SelectedItem = dt.Rows[0]["MartialStatus"].ToString();
                    txt_department.SelectedItem = dt.Rows[0]["Department"].ToString();
                    txt_position.SelectedItem = dt.Rows[0]["Position"].ToString();
                }
                catch
                {
                }
            }
        }

        private void metroTextButton1_Click(object sender, EventArgs e)
        {
            int TotalSalary = 0, TotalDeductions = 0, FinalSalary = 0, Test = 0;

            if (metroRadioButton1.Checked == true)
            {
                TotalSalary = int.Parse(txt_hours.Text) * 100;
            }

            if (metroRadioButton2.Checked == true)
            {
                TotalSalary = int.Parse(txt_hours.Text) * 80;
            }


            if (check_over.Checked == true)
            {
                if (txt_over.Text != "")
                {

                    Test = int.Parse(txt_over.Text) * 100;

                }
                else
                {
                    MetroMessageBox.Show(this, "* Insert Total Hours Overtime", "Requied Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            




            if (txt_status.Text == "Single")
            {

                if (check_sss.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 950;
                }

                if (check_phil.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 900;
                }

                if (check_ibig.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 800;
                }
            }

            if (txt_status.Text == "Married")
            {
                if (check_sss.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 100;
                }

                if (check_phil.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 200;
                }

                if (check_ibig.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 300;
                }
            }

            if (txt_status.Text == "Separated")
            {
                if (check_sss.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 420;
                }

                if (check_phil.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 350;
                }

                if (check_ibig.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 270;
                }
            }

            if (txt_status.Text == "Divorced")
            {
                if (check_sss.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 600;
                }

                if (check_phil.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 500;
                }

                if (check_ibig.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 400;
                }
            }

            if (txt_status.Text == "Widowed")
            {
                if (check_sss.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 850;
                }

                if (check_phil.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 800;
                }

                if (check_ibig.Checked == true)
                {
                    TotalDeductions = TotalDeductions + 700;
                }
            }


            if (txt_hours.Text != "")
            {
                if (metroRadioButton1.Checked == true)
                {
                    FinalSalary = TotalSalary + Test - TotalDeductions;

                    lbl_test.Text = "₱ " + FinalSalary.ToString();
                    txt_total.Text =FinalSalary.ToString();
                }
                else if (metroRadioButton2.Checked == true)
                {
                    FinalSalary = TotalSalary + Test - TotalDeductions;

                    lbl_test.Text = "₱ " + FinalSalary.ToString();
                    txt_total.Text =FinalSalary.ToString();
                }
                else
                {
                    MetroMessageBox.Show(this, "* Please Select Salary Info", "Requied Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "* Insert Total Hours Worked", "Requied Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save2_Click(object sender, EventArgs e)
        {
                Session.StatuActive(lbl_Holder.Text, "0", "0"); 

                cmd = new SqlCommand("Insert Into tbl_salary (EmployeeID, FullName, Contact, salary_info, salary_hours, salary_over, salary_deduction, salary_deduction1, salary_deduction2, salary_total, Date) values (@EmployeeID, @FullName, @Contact, @salary_info, @salary_hours, '" + txt_over.Text + "', @salary_deduction, @salary_deduction1, @salary_deduction2, @salary_total, @Date) ", con);
                cmd.Parameters.AddWithValue("@EmployeeID", lbl_Holder.Text);
                cmd.Parameters.AddWithValue("@FullName", txt_lname.Text + " " + txt_fname.Text + " " + txt_mname.Text);
                cmd.Parameters.AddWithValue("@Contact", txt_contact.Text);

                cmd.Parameters.AddWithValue("@salary_hours", txt_hours.Text);
                cmd.Parameters.AddWithValue("@salary_total", txt_total.Text);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString());

                if (metroRadioButton1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@salary_info", "Regular 100 Per hour");
                }
                if (metroRadioButton2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@salary_info", "Part-time 80 Per hour");
                }

       
                    cmd.Parameters.AddWithValue("@salary_deduction", lbl_1.Text);

                    cmd.Parameters.AddWithValue("@salary_deduction1", lbl_2.Text);

                    cmd.Parameters.AddWithValue("@salary_deduction2", lbl_3.Text);
    

          


                cmd.ExecuteNonQuery();

                MetroMessageBox.Show(this, "", "Register Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_fname.Text = "";
                txt_lname.Text = "";
                txt_mname.Text = "";
                dateTimePicker1.Text = "";
                txt_email.Text = "";
                txt_contact.Text = "";
                txt_address.Text = "";
                txt_status.Text = "";
                txt_over.Text = "";
                txt_total.Text = "";
                metroRadioButton1.Checked = false;
                metroRadioButton2.Checked = false;
                txt_hours.Text = "";
                lbl_cutoff.Text = "";
                this.Close();

            //}
            //catch (Exception Err ){ MetroMessageBox.Show(this, "" , "" , MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            btn_delete.Enabled = false;

            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_mname.Text = "";
            dateTimePicker1.Text = "";
            txt_email.Text = "";
            txt_contact.Text = "";
            txt_address.Text = "";
            txt_status.Text = "";
            txt_over.Text = "";
            txt_hours.Text = "";
            txt_total.Text = "";
            txt_department.Text = "";
            txt_position.Text = "";
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
        }

        private void btn_clear2_Click(object sender, EventArgs e)
        {
            txt_total.Text = "";
            txt_over.Text = "";
            txt_hours.Text = "";
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (check_over.Checked == true)
            {
                txt_over.Enabled = true;
                txt_over.Text = "0";
            }
            else
            {
                txt_over.Enabled = false;
                txt_over.Text = "0";
            }

        }

        private void metroTextButton2_Click(object sender, EventArgs e)
        {
     
        }

        private void check_sss_CheckedChanged(object sender, EventArgs e)
        {
            if (check_sss.Checked == true)
            {
                if (check_sss.Text == "SSS (950)")
                {
                    lbl_1.Text = "950";
                }
                if (check_sss.Text == "SSS (100)")
                {
                    lbl_1.Text = "100";
                }
                if (check_sss.Text == "SSS (420)")
                {
                    lbl_1.Text = "420";
                }
                if (check_sss.Text == "SSS (600)")
                {
                    lbl_1.Text = "600";
                }
                if (check_sss.Text == "SSS (850)")
                {
                    lbl_1.Text = "850";
                }
            }
            else
            {
                if (check_sss.Text == "SSS (950)")
                {
                    lbl_1.Text = "0";
                }
                if (check_sss.Text == "SSS (100)")
                {
                    lbl_1.Text = "0";
                }
                if (check_sss.Text == "SSS (420)")
                {
                    lbl_1.Text = "0";
                }
                if (check_sss.Text == "SSS (600)")
                {
                    lbl_1.Text = "0";
                }
                if (check_sss.Text == "SSS (850)")
                {
                    lbl_1.Text = "0";
                }
            }
        }

        private void check_phil_CheckedChanged(object sender, EventArgs e)
        {

            if (check_phil.Checked == true)
            {
                if (check_phil.Text == "Phil Health (900)")
                {
                    lbl_2.Text = "900";
                }
                if (check_phil.Text == "Phil Health (200)")
                {
                    lbl_2.Text = "200";
                }
                if (check_phil.Text == "Phil Health (350)")
                {
                    lbl_2.Text = "350";
                }
                if (check_phil.Text == "Phil Health (500)")
                {
                    lbl_2.Text = "500";
                }
                if (check_phil.Text == "Phil Health (800)")
                {
                    lbl_2.Text = "800";
                }
            }
            else
            {
                if (check_phil.Text == "Phil Health (900)")
                {
                    lbl_2.Text = "0";
                }
                if (check_phil.Text == "Phil Health (200)")
                {
                    lbl_2.Text = "0";
                }
                if (check_phil.Text == "Phil Health (350)")
                {
                    lbl_2.Text = "0";
                }
                if (check_phil.Text == "Phil Health (500)")
                {
                    lbl_2.Text = "0";
                }
                if (check_phil.Text == "Phil Health (800)")
                {
                    lbl_2.Text = "0";
                }
            }
        }

        private void check_ibig_CheckedChanged(object sender, EventArgs e)
        {
            if (check_ibig.Checked == true)
            {
                if (check_ibig.Text == "Pag-Ibig (800)")
                {
                    lbl_3.Text = "800";
                }
                if (check_ibig.Text == "Pag-Ibig (300)")
                {
                    lbl_3.Text = "300";
                }
                if (check_ibig.Text == "Pag-Ibig (270)")
                {
                    lbl_3.Text = "270";
                }
                if (check_ibig.Text == "Pag-Ibig (400)")
                {
                    lbl_3.Text = "400";
                }
                if (check_ibig.Text == "Pag-Ibig (700)")
                {
                    lbl_3.Text = "700";
                }
            }
            else
            {
                if (check_ibig.Text == "Pag-Ibig (800)")
                {
                    lbl_3.Text = "0";
                }
                if (check_ibig.Text == "Pag-Ibig (300)")
                {
                    lbl_3.Text = "0";
                }
                if (check_ibig.Text == "Pag-Ibig (270)")
                {
                    lbl_3.Text = "0";
                }
                if (check_ibig.Text == "Pag-Ibig (400)")
                {
                    lbl_3.Text = "0";
                }
                if (check_ibig.Text == "Pag-Ibig (700)")
                {
                    lbl_3.Text = "0";
                }
            }
        }

        private void txt_hours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar <= 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_over_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar <= 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txt_total_Click(object sender, EventArgs e)
        {

        }

        private void txt_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_status.Text == "Single")
            {
                check_sss.Text = "SSS (950)";
                check_phil.Text = "Phil Health (900)";
                check_ibig.Text = "Pag-Ibig (800)";
            }

            if (txt_status.Text == "Married")
            {
                check_sss.Text = "SSS (100)";
                check_phil.Text = "Phil Health (200)";
                check_ibig.Text = "Pag-Ibig (300)";
            }

            if (txt_status.Text == "Separated")
            {
                check_sss.Text = "SSS (420)";
                check_phil.Text = "Phil Health (350)";
                check_ibig.Text = "Pag-Ibig (270)";
            }

            if (txt_status.Text == "Divorced")
            {
                check_sss.Text = "SSS (600)";
                check_phil.Text = "Phil Health (500)";
                check_ibig.Text = "Pag-Ibig (400)";
            }

            if (txt_status.Text == "Widowed")
            {
                check_sss.Text = "SSS (850)";
                check_phil.Text = "Phil Health (800)";
                check_ibig.Text = "Pag-Ibig (700)";
            }
        }
    }
}
