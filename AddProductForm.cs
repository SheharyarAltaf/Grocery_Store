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
using System.Text.RegularExpressions;

namespace grocery_store
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {

       
            loadproducts();
            String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            String query = "SELECT * From category WHERE cat_status=1 ";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbxCategory.DataSource = dt;
            cbxCategory.DisplayMember = "cat_name";
            cbxCategory.ValueMember = "cat_id";
        }
        private void loadproducts()
        {
            String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            String query = "SELECT * From products1";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvProducts.DataSource = dt;
            dgvProducts.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)

        {
            String barcode = txtBarcode.Text;
            String pName = txtProductName.Text;
            int stock = Convert.ToInt32(txtStock.Text);

            int status;
            if (rdoAvailable.Checked)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }
            int purPrice = Convert.ToInt32(txtPurchasePrice.Text);
            int salePrice = Convert.ToInt32(txtSalePrice.Text);
            int categoryId = Convert.ToInt32(cbxCategory.SelectedValue.ToString());

            String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            String query = "INSERT INTO products1(p_name,p_stock,cat_id,p_status, p_pur_price,p_sale_price,p_barcode )VALUES(@pname,@pstock,@catid,@status,@purchase,@sale,@code )";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("pname", pName));
            cmd.Parameters.Add(new SqlParameter("pstock", stock));
            cmd.Parameters.Add(new SqlParameter("catid", categoryId));
            cmd.Parameters.Add(new SqlParameter("status", status));
            cmd.Parameters.Add(new SqlParameter("purchase", purPrice));
            cmd.Parameters.Add(new SqlParameter("sale", salePrice));
            cmd.Parameters.Add(new SqlParameter("code", barcode));
            int n = cmd.ExecuteNonQuery();

            if (n > 0)
            {
                MessageBox.Show("data saved succesfully");
                loadproducts();
                formreset();

            }
            else
            {
                MessageBox.Show("unable to insert data");
            }




        }



        private void formreset()
        {
            txtBarcode.Clear();
            txtBarcode.Focus();
            txtProductName.Clear();
            rdoAvailable.Checked = true;
            txtPurchasePrice.Clear();
            txtSalePrice.Clear();
            txtStock.Clear();
            cbxCategory.SelectedIndex = 0;
             
           
        }

        private void txtPName_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtPName.Text.Length == 0)
                {
                    loadproducts();
                    return;
                }
                string input = txtPName.Text;
                String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlCommand cmd;

                if (Regex.IsMatch(input, "^[0-9]+$"))
                {
                    //query agaisnst p_id
                    String query = "SELECT * From products1 WHERE p_id=@id";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("id", input));

                }
                else
                {
                    //query agianst nam and barcode
                    String query = "SELECT * From products1 WHERE p_barcode=@code OR p_name LIKE @pname  ";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("pname", "%" + txtPName.Text + "%"));
                     cmd.Parameters.Add(new SqlParameter("code", input));
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProducts.DataSource = dt;
                dgvProducts.Refresh();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            formreset();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0 || txtProductName.TextLength==0)
            {
                MessageBox.Show("please select row first");


            }
            else
            {
                int pid = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["p_id"].Value);
                String pname = txtProductName.Text;
                String barcode = txtBarcode.Text;
                int purPrice = Convert.ToInt32(txtPurchasePrice.Text);
                int salePrice = Convert.ToInt32(txtSalePrice.Text);
                int stock = Convert.ToInt32(txtStock.Text);
                int catId = Convert.ToInt32(cbxCategory.SelectedValue);
                int status;
                if (rdoAvailable.Checked)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
                try
                {
                    SqlConnection con = new SqlConnection(connStr);
                    con.Open();
                    String query = "UPDATE products1 SET p_name=@pname,p_stock=@pstock,cat_id=@catid,p_status=@status, p_pur_price=@purchase,p_sale_price=@sale, p_barcode=@code WHERE p_id=@pid";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("pid", pid));
                    cmd.Parameters.Add(new SqlParameter("pname", pname));
                    cmd.Parameters.Add(new SqlParameter("pstock", stock));
                    cmd.Parameters.Add(new SqlParameter("catid", catId));
                    cmd.Parameters.Add(new SqlParameter("status", status));
                    cmd.Parameters.Add(new SqlParameter("purchase", purPrice));
                    cmd.Parameters.Add(new SqlParameter("sale", salePrice));
                    cmd.Parameters.Add(new SqlParameter("code", barcode));
                    int n = cmd.ExecuteNonQuery();

                    if (n > 0)
                    {
                        MessageBox.Show("data Update succesfully");
                        loadproducts();
                        formreset();

                    }
                    else
                    {
                        MessageBox.Show("unable to Update data");
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
              

            }

        }

        private void dgvProducts_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtBarcode.Text = dgvProducts.Rows[rowIndex].Cells["p_barcode"].Value.ToString();
            txtProductName.Text = dgvProducts.Rows[rowIndex].Cells["p_name"].Value.ToString();
            txtPurchasePrice.Text = dgvProducts.Rows[rowIndex].Cells["p_pur_price"].Value.ToString();
            txtSalePrice.Text = dgvProducts.Rows[rowIndex].Cells["p_sale_price"].Value.ToString();
            txtStock.Text = dgvProducts.Rows[rowIndex].Cells["p_stock"].Value.ToString();
            int status = Convert.ToInt32(dgvProducts.Rows[rowIndex].Cells["p_status"].Value.ToString());
            if (status == 1)
            {
                rdoAvailable.Checked = true;
            }
            else
            {
                rdoUnavailable.Checked = true;
            }
            int catId = Convert.ToInt32(dgvProducts.Rows[rowIndex].Cells["cat_id"].Value.ToString());
            for (int i = 0; i < cbxCategory.Items.Count; i++)
            {
                DataRowView drv = (DataRowView)cbxCategory.Items[i];
                if (Convert.ToInt32(drv["cat_id"].ToString()) == catId)
                {
                    cbxCategory.SelectedIndex = i;
                }
            }



        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                String barcode = txtBarcode.Text.Trim();
                String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                String query = "SELECT * From products1 WHERE p_barcode=@code  ";
           SqlCommand     cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("code", barcode));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >0)
                {
                    txtProductName.Text = dt.Rows[0]["p_name"].ToString();
                    txtPurchasePrice.Text = dt.Rows[0]["p_pur_price"].ToString();
                    txtSalePrice.Text = dt.Rows[0]["p_sale_price"].ToString();
                    txtStock.Text = dt.Rows[0]["p_stock"].ToString();
                    int status = Convert.ToInt32(dt.Rows[0]["p_status"].ToString());
                    if (status == 1)
                    {
                        rdoAvailable.Checked = true;
                    }
                    else
                    {
                        rdoUnavailable.Checked = true;
                    }
                    int catId = Convert.ToInt32(dt.Rows[0]["cat_id"].ToString());
                    for (int i = 0; i < cbxCategory.Items.Count; i++)
                    {
                        DataRowView drv = (DataRowView)cbxCategory.Items[i];
                        if (Convert.ToInt32(drv["cat_id"].ToString()) == catId)
                        {
                            cbxCategory.SelectedIndex = i;
                        }
                    }
                }
            }
        }
    }
}
