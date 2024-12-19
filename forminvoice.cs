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
    public partial class forminvoice : Form
    {
        public forminvoice()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                String input = txtSearch.Text.Trim();
                if (input.Length == 0)
                {
                    return;
                }

                String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlCommand cmd;
                if (Regex.IsMatch(input, "^[0-9]+$"))
                {
                    //query agist productd
                    int id;
                    bool result = int.TryParse(input, out id);
                    if (result)
                    {
                        // query agaisnt pid and bacrcode
                        String query = "SELECT * From products1 WHERE p_id=@id OR p_barcode=@code ";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("id", input));
                        cmd.Parameters.Add(new SqlParameter("code", input));
                    }
                    else
                    {
                        // query against only barcode
                        String query = "SELECT * From products1 WHERE p_barcode=@code ";
                        cmd = new SqlCommand(query, con);
                      
                        cmd.Parameters.Add(new SqlParameter("code", input));
                    }
                    
                }
                else
                {
                    String query = "SELECT * From products1 WHERE p_barcode=@code OR p_name LIKE @pname  ";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("pname", "%" + txtSearch.Text + "%"));
                    cmd.Parameters.Add(new SqlParameter("code", input));
                    //query against barcode
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("no product found");
                    txtName.Clear();
                    txtPrice.Clear();
                    txtStock.Clear();
                    txtQty.Clear();
                    lblId.Text = "";
                    txtQty.Text = "1";
                    
                }
                else if (dt.Rows.Count == 1)
                {
                    lblId.Text = dt.Rows[0]["p_id"].ToString();
                    txtName.Text = dt.Rows[0]["p_name"].ToString();
                    txtPrice.Text = dt.Rows[0]["p_sale_price"].ToString();
                    txtStock.Text = dt.Rows[0]["p_stock"].ToString();

                    txtQty.Focus();
                }
                else
                {
                    productSelectionForm form = new productSelectionForm(dt);
                 DialogResult dr=   form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                      //  MessageBox.Show("selected");
                        txtName.Text = dt.Rows[form.selectedRowIndex]["p_name"].ToString();
                        txtPrice.Text = dt.Rows[form.selectedRowIndex]["p_sale_price"].ToString();
                        txtStock.Text = dt.Rows[form.selectedRowIndex]["p_stock"].ToString();
                        lblId.Text = dt.Rows[form.selectedRowIndex]["p_id"].ToString();

                    }
                }
            }
        }

        private void forminvoice_Load(object sender, EventArgs e)
        {
         txtUserName.Text =  employee.userName;
            txtDateTime.Text = DateTime.Now.ToString("dd MMMM, yyyy HH:mm:ss tt");
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtQty.Text.Length == 0)
                {
                    return;
                }
                int qty = Convert.ToInt32(txtQty.Text);
                int stock = Convert.ToInt32(txtStock.Text);
                if (qty > stock)
                {
                    MessageBox.Show("Insufficient stock");
                }
                else
                {
                    int pid = Convert.ToInt32(lblId.Text);
                    String name = txtName.Text;
                    int price = Convert.ToInt32(txtPrice.Text);
                   
                    int amount = price * qty;
                    dgvBill.Rows.Add(pid, name, price,qty, amount);
                    Bill();
                    txtSearch.Clear();
                    txtQty.Text = "1";
                    txtName.Clear();
                    txtPrice.Clear();
                    txtStock.Clear();
                    lblId.Text = "";
                    txtSearch.Focus();

                }
            }
        }



        private void Bill()
        {
            int totalBill = 0;
            for(int i=0; i < dgvBill.Rows.Count; i++)
            {
                totalBill = totalBill + Convert.ToInt32(dgvBill.Rows[i].Cells["p_amount"].Value);
            }
            txtBill.Text = totalBill.ToString();
        }

        private void dgvBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int qty=Convert.ToInt32(dgvBill.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            int price = Convert.ToInt32(dgvBill.Rows[e.RowIndex].Cells["sale_price"].Value);
            int amount = qty * price;
            dgvBill.Rows[e.RowIndex].Cells["p_amount"].Value = amount;
            Bill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userId = employee.userId;
            DateTime invoicedate = DateTime.Now;
            int bill = Convert.ToInt32(txtBill.Text);
            changeCalculationForm form = new changeCalculationForm(bill);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }


            String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            String query = "INSERT INTO sale_invoice (invoice_date, user_id, total_bill) OUTPUT INSERTED.invoice_id VALUES(@date, @uid, @bill) ";
          SqlCommand  cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("date", invoicedate));
            cmd.Parameters.Add(new SqlParameter("uid", userId));
            cmd.Parameters.Add(new SqlParameter("bill", bill));
            int invoiceId = (int)cmd.ExecuteNonQuery();
            if (invoiceId > 0)
            {
               // MessageBox.Show("invoice is saved with id " + invoiceId);
                for (int i = 0; i < dgvBill.Rows.Count; i++)
                {
                    int pid = Convert.ToInt32(dgvBill.Rows[i].Cells["p_id"].Value);
                    int price = Convert.ToInt32(dgvBill.Rows[i].Cells["sale_price"].Value);
                    int qty = Convert.ToInt32(dgvBill.Rows[i].Cells["p_qty"].Value);
                    String query2 = "INSERT INTO sale_invoice_item (invoice_id, p_id,price,qty) VALUES(@id,@pid,@price,@qty)";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.Add(new SqlParameter("id", invoiceId));
                    cmd2.Parameters.Add(new SqlParameter("pid", pid));
                    cmd2.Parameters.Add(new SqlParameter("price", price));
                    cmd2.Parameters.Add(new SqlParameter("qty", qty));

                    cmd2.ExecuteNonQuery();
                    String query3 = "UPDATE products1 SET p_stock=p_stock-@qty WHERE p_id=@pid";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd3.Parameters.Add(new SqlParameter("qty", qty));
                    cmd3.Parameters.Add(new SqlParameter("pid", pid));
                    cmd3.ExecuteNonQuery();
                   

                }
                // MessageBox.Show("data saved successfully");
                ReportInvoiceForm f = new ReportInvoiceForm(invoiceId);
                f.ShowDialog(); 
                ReportInvoiceForm invoiocereport = new ReportInvoiceForm(invoiceId);
               invoiocereport.ShowDialog();
            }
            else
            {
                MessageBox.Show("unable to save");
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
