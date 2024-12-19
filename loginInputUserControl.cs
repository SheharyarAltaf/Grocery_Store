using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace grocery_store
{
    public partial class loginInputUserControl : UserControl
    {
        public loginInputUserControl()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            String username = txtUsername.Text;
            String password = txtPassword.Text;

            String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            String query = "SELECT *From user_info    Where username=@u AND password=@p";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("u", username));
            cmd.Parameters.Add(new SqlParameter("p", password));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                employee.userId = Convert.ToInt32(dt.Rows[0]["user_id"].ToString());
                employee.userName = dt.Rows[0]["username"].ToString();
                employee.roleId = Convert.ToInt32(dt.Rows[0]["role_id"].ToString());
                this.Hide();
                DashboardForm1 form = new DashboardForm1();
                form.Show();

            }
            else
            {
                MessageBox.Show("invalid login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
