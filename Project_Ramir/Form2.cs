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

namespace Project_Ramir
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            int adultheadtotal = int.Parse(textBox1.Text) + int.Parse(textBox2.Text);
            textBox3.Text = adultheadtotal.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime dtFrom = DateTime.Parse("1:00 AM");
            DateTime dtTo = DateTime.Parse("5:30 AM");
            int timeDiff = dtTo.Subtract(dtFrom).Hours;

            textBox1.Text = timeDiff.ToString();

        //    int timeDiff = dtFrom.Value.Subtract(dtTo.Value).Hours;

            //DateTime time1 = new DateTime();
            //DateTime time2 = new DateTime();

            //// 1st time dropdown selection 
            //time1 = DateTime.Parse("8:00AM");
            //time2 = DateTime.Parse("10:00AM");

            //TimeSpan tsTotal = time1 + time2;

            //string t1 = Convert.ToString(tsTotal); // 03:30:00
            //textBox1.Text = t1;

            //DateTime time1 = new DateTime();
            //DateTime time2 = new DateTime();

            //// 1st time dropdown selection
            //time1 = DateTime.Parse("8:00AM");
            //time2 = DateTime.Parse("10:00AM");
            //TimeSpan ts = time2.Subtract(time1); // 02:00:00

            //// 2nd time dropdown selection
            //time1 = DateTime.Parse("8:00AM");
            //time2 = DateTime.Parse("9:30AM");
            //TimeSpan ts1 = time2.Subtract(time1); // 01:30:00

            //TimeSpan tsTotal = ts + ts1;

            //string t1 = Convert.ToString(tsTotal); // 03:30:00
            //textBox1.Text = t1;

            //decimal res = 0;

            //TimeSpan t1 = TimeSpan.Parse(textBox1.Text);
            //TimeSpan t2 = TimeSpan.Parse(textBox2.Text);
            //TimeSpan t3 = t1 - t2;
            //t3 = Math.Abs


            //Session.loadopen();

            //string CountRecord = "Select count(*) from tbl_test";
            //SqlCommand Countcmd = new SqlCommand(CountRecord,Session.con);

            //int EmpGen = Convert.ToInt32(Countcmd.ExecuteScalar().ToString());
            //string GenerateEmp = "";

            //if (EmpGen < 15)
            //{ GenerateEmp = "Employee-" + "" + (EmpGen + 1); }

            //Countcmd = new SqlCommand("INSERT INTO tbl_test VALUES ('" + GenerateEmp +"')", Session.con);
            //Countcmd.ExecuteNonQuery();


            //decimal duration;
           // decimal time = 0;

            //DateTime startTime = Convert.ToDateTime("1:00 AM");
            //DateTime endtime = Convert.ToDateTime("3:00 AM");
            //TimeSpan duration = endtime.Subtract(startTime);
            //TimeSpan time = TimeSpan.Zero;

            //time += duration;
            //textBox1.Text = time.ToString();
          
            

            //double second1, second2;

            //string login_date1, login_date2;

            //login_date1 = Databu

            //login_date2 = login_date1;

            ////double Time = 0;
            ////Time = + ConvertHoursToMinutes(Convert.ToDouble(login_date2));

            //double stime;
            //stime = TimeSpan.Parse(login_date2).TotalSeconds;

            //seconds1 = seconds2 + stime;

            //seconds2 = seconds1;

            //Label lblTimeDiff = (Label)e.Row.FindControl("lblTotalTimeDiff");
            ////   Label lblTimeDiff1 = (Label)e.Row.FindControl("lblTotalTimeDiff1");

            //TimeSpan t = TimeSpan.FromSeconds(seconds2);
            ////string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
            //string answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
            //lblTimeDiff.Text = answer;
       

            //TimeSpan t1 = TimeSpan.Parse(textBox1.Text);
            //TimeSpan t2 = TimeSpan.Parse(textBox2.Text);
            //TimeSpan t3 = t1.Add(t2);
            //textBox3.Text = t3.ToString();

            ////open timework
            //DateTime t1 = Convert.ToDateTime(textBox1.Text);
            //DateTime t2 = Convert.ToDateTime("9:30 AM");
            //DateTime t3 = Convert.ToDateTime("10:00 AM");
            //DateTime t4 = Convert.ToDateTime("10:30 AM");
            //DateTime t5 = Convert.ToDateTime("11:00 AM");
            //DateTime t6 = Convert.ToDateTime("11:30 AM");
            //DateTime t7 = Convert.ToDateTime("12:00 PM");
            //DateTime t8 = Convert.ToDateTime("1:00 PM");
            //DateTime t9 = Convert.ToDateTime("1:30 PM");
            //DateTime t10 = Convert.ToDateTime("2:00 PM");
            //DateTime t11 = Convert.ToDateTime("2:30 PM");
            //DateTime t12 = Convert.ToDateTime("3:00 PM");
            //DateTime t13 = Convert.ToDateTime("3:30 PM");
            ////out timework
            ////overtime
            //DateTime t14 = Convert.ToDateTime("4:00 PM");
            //DateTime t15 = Convert.ToDateTime("4:30 PM");
            //DateTime t16 = Convert.ToDateTime("5:00 PM");
            //DateTime t17 = Convert.ToDateTime("5:30 PM");
            //DateTime t18 = Convert.ToDateTime("6:00 PM");
            //DateTime t19 = Convert.ToDateTime("6:30 PM");  
            //DateTime t20 = Convert.ToDateTime("7:00 PM");  
            ////close time building



            //if (t1.TimeOfDay.Ticks <= t2.TimeOfDay.Ticks)
            //{
            //    MessageBox.Show("not late");
            //}

            //else if (t1.TimeOfDay.Ticks >= t2.TimeOfDay.Ticks && t1.TimeOfDay.Ticks <= t13.TimeOfDay.Ticks)
            //{

            //    if (t1.TimeOfDay.Ticks <= t2.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 1 Deduction 30mins ");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t3.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 2 Deduction 30mins");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t4.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 3 Deduction 30mins");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t5.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 4 Deduction 30mins");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t6.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 5 Deduction 30mins");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t7.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 6 Deduction 30mins");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t8.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 7 Deduction 30mins");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t9.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 8 Deduction 30mins");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t10.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 9 Deduction 30mins");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t11.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 10 Deduction 30mins");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t12.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("Late 11 Deduction 30mins");
            //    }
            //}
            //else
            //{
            //    if (t1.TimeOfDay.Ticks <= t14.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("OT 4");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t15.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("OT 5");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t16.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("OT 6");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t17.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("OT 7");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t18.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("OT 8");
            //    }
            //    else if (t1.TimeOfDay.Ticks <= t19.TimeOfDay.Ticks)
            //    {
            //        MessageBox.Show("OT 9");
            //    }
            //}       
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBRamir2016DataSet.tbl_test' table. You can move, or remove it, as needed.
            this.tbl_testTableAdapter.Fill(this.dBRamir2016DataSet.tbl_test);

        }

    
    }
}
