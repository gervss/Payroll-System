using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

namespace Project_Ramir
{
    public partial class Report : MetroForm
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBRamir2016DataSet1.tbl_salary' table. You can move, or remove it, as needed.
            this.tbl_salaryTableAdapter.Fill(this.dBRamir2016DataSet1.tbl_salary);

        }

        private void printReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print f2 = new Print();
            f2.ShowDialog();


        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            Session.print_emp = metroGrid1.Rows[e.RowIndex].Cells[1].Value + "";
            Session.print_name = metroGrid1.Rows[e.RowIndex].Cells[2].Value + "";
            Session.print_contact = metroGrid1.Rows[e.RowIndex].Cells[3].Value + "";
            Session.print_date = metroGrid1.Rows[e.RowIndex].Cells[4].Value + "";
            Session.print_info = metroGrid1.Rows[e.RowIndex].Cells[5].Value + "";
            Session.print_hours = metroGrid1.Rows[e.RowIndex].Cells[6].Value + "";
            Session.print_sss = metroGrid1.Rows[e.RowIndex].Cells[7].Value + "";
            Session.print_phil = metroGrid1.Rows[e.RowIndex].Cells[8].Value + "";
            Session.print_ibig = metroGrid1.Rows[e.RowIndex].Cells[9].Value + "";
            Session.print_total = metroGrid1.Rows[e.RowIndex].Cells[10].Value + "";

        }
    }
}
