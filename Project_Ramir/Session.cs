using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace Project_Ramir
{
    class Session
    {

        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        public static DataTable dt;
        public static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DBRamir2016.mdf;Integrated Security=True");
        public static string holderID, holderSet, cutoff, hours;
        public static string print_name, print_contact, print_info, print_hours, print_sss, print_phil, print_ibig, print_total, print_emp, print_date;
        public static void loadopen()
        {
            if (Session.con.State == ConnectionState.Closed)
            {
                Session.con.Open();
            }

        }
        public static void StatuActive(string data1, string test, string final_hours)
        {
            loadopen();
            cmd = new SqlCommand("UPDATE tbl_employee SET Status = 'Active', cutoff = @1, hours = @2  WHERE EmployeeID = '" + data1 + "'", con);

            if (test == "0")
            {
                cmd.Parameters.AddWithValue("@1", "1");
            }
            if (test == "1")
            {
                cmd.Parameters.AddWithValue("@1", "2");
            }
            if (test == "2")
            {
                cmd.Parameters.AddWithValue("@1", "3");
            }
            if (test == "3")
            {
                cmd.Parameters.AddWithValue("@1", "4");
            }
            if (test == "4")
            {
                cmd.Parameters.AddWithValue("@1", "5");
            }
            if (test == "5")
            {
                cmd.Parameters.AddWithValue("@1", "6");
            }
            if (test == "6")
            {
                cmd.Parameters.AddWithValue("@1", "7");
            }
            if (test == "7")
            {
                cmd.Parameters.AddWithValue("@1", "8");
            }
            if (test == "8")
            {
                cmd.Parameters.AddWithValue("@1", "9");
            }
            if (test == "9")
            {
                cmd.Parameters.AddWithValue("@1", "10");
            }
            if (test == "10")
            {
                cmd.Parameters.AddWithValue("@1", "11");
            }
            if (test == "11")
            {
                cmd.Parameters.AddWithValue("@1", "12");
            }
            if (test == "12")
            {
                cmd.Parameters.AddWithValue("@1", "13");
            }
            if (test == "13")
            {
                cmd.Parameters.AddWithValue("@1", "14");
            }
            if (test == "14")
            {
                cmd.Parameters.AddWithValue("@1", "15");
            }
            if (test == "15")
            {
                cmd.Parameters.AddWithValue("@1", "0");
            }

            cmd.Parameters.AddWithValue("@2", final_hours);

            cmd.ExecuteNonQuery();

        }

        public static void StatuDeactive(string data1)
        {
            loadopen();
            cmd = new SqlCommand("UPDATE tbl_employee SET Status = 'Deactive' WHERE EmployeeID = '" + data1 + "'", con);
            cmd.ExecuteNonQuery();
        }

        public static void InsertTime(string emloyeeID, string Fullname, string hours, string timeIN, string timeOUT, string date, string remarks)
        {
            loadopen();
            cmd = new SqlCommand("INSERT INTO tbl_attend VALUES ('" + emloyeeID + "','" + Fullname + "','" + hours + "','" + timeIN + "','" + timeOUT + "','" + date + "','" + remarks + "')", con);
            cmd.ExecuteNonQuery();
        }

        public static void load_attend(string holderID, string holder1, string holder2)
        {
            loadopen();
            string select = "Select * from tbl_attend Where EmployeeID = '" + holderID + "'";
            cmd = new SqlCommand(select, Session.con);
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            holder1 = dt.Rows[0]["EmployeeID"].ToString();
            holder2 = dt.Rows[0]["attend_IN"].ToString();
        }
        public static void Emp_Update(string holder_id , string hold_hours, string hold_out)
        {
            loadopen();
            cmd = new SqlCommand("UPDATE tbl_attend SET Hours = @1, attend_OUT = @2 WHERE EmployeeID = '" + holder_id + "'", con);
            cmd.Parameters.AddWithValue("@1", hold_hours);
            cmd.Parameters.AddWithValue("@2", hold_out);
            cmd.ExecuteNonQuery();  
        }
    }
}
