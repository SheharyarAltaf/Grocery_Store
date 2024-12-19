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
    public partial class categoryform : Form
    {
        public categoryform()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String catName = txtCatName.Text;
            int catStatus;
            if (rdoavailable.Checked)
            {
                catStatus = 1;
            }
            else
            {
                catStatus = 0;
            }

            String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            String query = "INSERT INTO category(cat_name,cat_status)VALUES(@catname,@catstatus)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("catname",catName));
            cmd.Parameters.Add(new SqlParameter("catstatus",catStatus));
            int n= cmd.ExecuteNonQuery();
            
            if (n > 0)
            {
                MessageBox.Show("data saved succesfully");
                formreset();
                loadcategory();
            }
            else
            {
                MessageBox.Show("unable to insert data");
            }






        }

        private void formreset()
        {
            txtCatId.Clear();
            txtCatName.Clear();
            rdoavailable.Checked = true;
        }

        private void categoryform_Load(object sender, EventArgs e)
        {
            loadcategory();
        }
        private void loadcategory()
        {
            String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            String query = "SELECT * From category";
            SqlCommand cmd = new SqlCommand(query, con);
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            dgvCategory.DataSource = dt;
            dgvCategory.Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int catId = Convert.ToInt32(txtCatId.Text);
            String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            String query = "SELECT * From category WHERE cat_id=@catid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("catid", catId));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCategory.DataSource = dt;
            dgvCategory.Refresh();
            
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No data foud");
            }
            else
            {
                String cat_Name = dt.Rows[0]["cat_name"].ToString();
                int cat_Status = Convert.ToInt32(dt.Rows[0]["cat_status"].ToString());
                txtCatName.Text = cat_Name;
                if (cat_Status == 1)
                {
                    rdoavailable.Checked = true;
                }
                else
                {
                    rdoUnavailable.Checked = true;
                }
            }
        }

        private void txtCatId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int catId = Convert.ToInt32(txtCatId.Text);
                String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                String query = "SELECT * From category WHERE cat_id=@catid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("catid", catId));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCategory.DataSource = dt;
                dgvCategory.Refresh();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data foud");
                }
                else
                {
                    String cat_Name = dt.Rows[0]["cat_name"].ToString();
                    int cat_Status = Convert.ToInt32(dt.Rows[0]["cat_status"].ToString());
                    txtCatName.Text = cat_Name;
                    if (cat_Status == 1)
                    {
                        rdoavailable.Checked = true;
                    }
                    else
                    {
                        rdoUnavailable.Checked = true;
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
