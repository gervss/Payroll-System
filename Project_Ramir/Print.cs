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
    public partial class Print : MetroForm 
    {
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {
           lbl_emp.Text =  Session.print_emp;
           lbl_name.Text = Session.print_name;
           lbl_contact.Text = Session.print_contact;
           lbl_date.Text = Session.print_date;
           lbl_info.Text = Session.print_info;
           lbl_hours.Text = Session.print_hours;
           lbl_sss.Text = Session.print_sss;
           lbl_phil.Text = Session.print_phil; 
           lbl_ibig.Text = Session.print_ibig;
           lbl_total.Text = Session.print_total;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
            printForm1.Print();
        }
    }
}
