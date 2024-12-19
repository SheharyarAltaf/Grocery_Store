using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grocery_store
{
    public partial class DashboardForm1 : Form
    {
        public DashboardForm1()
        {
            InitializeComponent();
        }

        private void DashboardForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void manageCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            categoryform f = new categoryform();
            f.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm form = new AddProductForm();
            form.ShowDialog();
        }

        private void DashboardForm1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome" + employee.userName);
            lblUserLogin.Text = employee.userName;
        }

        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            forminvoice form = new forminvoice();
            form.ShowDialog();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
