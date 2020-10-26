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
using MetroFramework.Forms;
using System.Data.SqlClient;
using System.Configuration;
using MetroFramework;

namespace Project_Ramir
{
    public partial class Attendance : MetroForm
    {
        SqlDataAdapter da;
        SqlCommand cmd;

        public Attendance()
        {
            InitializeComponent();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBRamir2016DataSet.tbl_attend' table. You can move, or remove it, as needed.
            this.tbl_attendTableAdapter.Fill(this.dBRamir2016DataSet.tbl_attend);
            // TODO: This line of code loads data into the 'dS_Ramir.tbl_employee' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dBRamir2016DataSet.tbl_employee' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dBRamir2016DataSet.tbl_attend' table. You can move, or remove it, as needed.
            this.tbl_attendTableAdapter.Fill(this.dBRamir2016DataSet.tbl_attend);
            // TODO: This line of code loads data into the 'dBRamir2016DataSet.tbl_attend' table. You can move, or remove it, as needed.
            loaddata();

            Session.loadopen();

           // label1.Text = DateTime.Now.ToShortTimeString();
        }
        private void loaddata()
        {
            this.tbl_attendTableAdapter.Fill(this.dBRamir2016DataSet.tbl_attend);            
           
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(metroTextBox1.Text.Length.ToString());
            if (num1 <= 9)
            {
                string checkuser = "Select count(*) from tbl_employee Where EmployeeID = '" + metroTextBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(checkuser, Session.con);
                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

  
                if (temp == 1)
                {
                    string select = "Select * from tbl_employee Where EmployeeID = '" + metroTextBox1.Text + "'";
                    cmd = new SqlCommand(select, Session.con);
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    lbl_holderID.Text = dt.Rows[0]["EmployeeID"].ToString();
                    lbl_fullname.Text = dt.Rows[0]["FullName"].ToString();
                    lbl_status.Text = dt.Rows[0]["status"].ToString();
                    lbl_cutoff.Text = dt.Rows[0]["cutoff"].ToString();
                    lbl_hours.Text = dt.Rows[0]["hours"].ToString();

                    if (DateTime.Now.ToString("dd") == "15")
                    {
                        MetroMessageBox.Show(this, "Oh Right! Salary Day", "Hi! " + lbl_fullname.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DateTime.Now.ToString("dd") == "30")
                    {
                        MetroMessageBox.Show(this, "Oh Right! Salary Day", "Hi! " + lbl_fullname.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (lbl_status.Text == "Active")
                    {
                        Session.StatuDeactive(metroTextBox1.Text);
                        // //open timework
                        DateTime t1 = Convert.ToDateTime(DateTime.Now);
                        DateTime t2 = Convert.ToDateTime("9:30 AM");
                        DateTime t13 = Convert.ToDateTime("3:30 PM");

                        if (t1.TimeOfDay.Ticks <= t2.TimeOfDay.Ticks)
                        {
                            Session.InsertTime(metroTextBox1.Text, lbl_fullname.Text, "", DateTime.Now.ToShortTimeString(), "", DateTime.Now.ToShortDateString(), "");

                            MetroMessageBox.Show(this, "Good Morning!", "Hi! " + lbl_fullname.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            metroTextBox1.Text = "";
                            loaddata();
                        }
                        else
                        {
                            Session.InsertTime(metroTextBox1.Text, lbl_fullname.Text, "", DateTime.Now.ToShortTimeString(), "", DateTime.Now.ToShortDateString(), "LATE");
                            MetroMessageBox.Show(this, "Your Are Late!", "Hi! " + lbl_fullname.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            metroTextBox1.Text = "";
                            loaddata();
                        }
                    }
                    if (lbl_status.Text == "Deactive")
                    {
                       

                        string select2 = "Select * from tbl_attend Where EmployeeID = '" + metroTextBox1.Text + "'";
                        cmd = new SqlCommand(select2, Session.con);
                        DataTable dt2 = new DataTable();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(dt2);

                        lbl_holderID.Text = dt2.Rows[0]["EmployeeID"].ToString();
                        lbl_attendIN.Text = dt2.Rows[0]["attend_IN"].ToString();

                        DateTime dtFrom = DateTime.Parse(lbl_attendIN.Text);
                        DateTime dtTo = DateTime.Parse(DateTime.Now.ToShortTimeString());
                        int timeDiff = dtTo.Subtract(dtFrom).Hours;


                        int finaltotal = int.Parse(lbl_hours.Text) + int.Parse(timeDiff.ToString());


                        Session.Emp_Update(lbl_holderID.Text, lbl_timetotal.Text, DateTime.Now.ToShortTimeString());

                        Session.StatuActive(metroTextBox1.Text, lbl_cutoff.Text, finaltotal.ToString());

        
                        loaddata();
                        metroTextBox1.Text = "";
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "*PLease try again later.", "No Such Record Exist!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void metroTextBox1_ButtonClick(object sender, EventArgs e)
        {

        }
    }
}
