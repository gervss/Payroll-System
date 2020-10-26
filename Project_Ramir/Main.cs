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
    public partial class Main : MetroForm
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\DBRamir2016.mdf;Integrated Security=True");

        public Main()
        {
            InitializeComponent();
        }

        private void sSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report f2 = new Report();
            f2.ShowDialog();
        }

        private void createEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.holderSet = "Register";

            Register f2 = new Register();
            f2.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 f2 = new Form1();
            f2.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBRamir2016DataSet1.tbl_salary' table. You can move, or remove it, as needed.
            this.tbl_salaryTableAdapter1.Fill(this.dBRamir2016DataSet1.tbl_salary);
            // TODO: This line of code loads data into the 'dS_Ramir.tbl_salary' table. You can move, or remove it, as needed.
            this.tbl_salaryTableAdapter.Fill(this.dS_Ramir.tbl_salary);
            // TODO: This line of code loads data into the 'dS_Ramir.tbl_employee' table. You can move, or remove it, as needed.
            this.tbl_employeeTableAdapter.Fill(this.dS_Ramir.tbl_employee);
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.holderSet = "Add Salary"; 

            Register f2 = new Register();
            f2.ShowDialog();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.holderSet = "Edit Details";

            Credits f2 = new Credits();
            f2.ShowDialog();

        }

        private void editEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.holderSet = "Edit Details";

            Register f2 = new Register();
            f2.ShowDialog();
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dl = MetroMessageBox.Show(this, "Are you sure?, you want to Delete ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
             if (dl == DialogResult.OK)
             {

                 SqlCommand cmd = new SqlCommand("Delete From tbl_employee Where EmployeeID = '" + Session.holderID + "'", con);
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();

                 MetroMessageBox.Show(this, "", " Successfully Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void userControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin f2 = new Admin();
            f2.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tbl_employeeTableAdapter.Fill(this.dS_Ramir.tbl_employee);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbl_salaryTableAdapter1.Fill(this.dBRamir2016DataSet1.tbl_salary);
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance f2 = new Attendance();
            f2.ShowDialog();
        }

        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
               DataGridViewCell cell = null;
               foreach (DataGridViewCell selectedCell in metroGrid1.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                Session.holderID = row.Cells[0].Value.ToString();
                Session.hours = row.Cells[8].Value.ToString();
                Session.cutoff = row.Cells[9].Value.ToString();
            }
        }

    }
}
