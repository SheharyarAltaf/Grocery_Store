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
namespace grocery_store
{  
    public partial class Form1 : Form
    {

        loginInputUserControl LoginInput = new loginInputUserControl();
        UserControl1 sss = new UserControl1();

        public Form1()
        {
            InitializeComponent();
            panel1.Controls.Clear();
            panel1.Controls.Add(LoginInput);
            LoginInput.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel2.Controls.Add(sss);
            sss.Dock = DockStyle.Fill;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
