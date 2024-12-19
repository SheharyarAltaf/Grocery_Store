using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Ali
namespace grocery_store
{
    public partial class DashboardForm1 : Form
    {
        public DashboardForm1()
        {

            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
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
            // Connection string to the database
            string connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";

            // Query to retrieve products from the database
            string query = "SELECT * FROM products1";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable productTable = new DataTable();
                da.Fill(productTable); // Fetch data into DataTable

                // Show the product selection form
                productSelectionForm selectionForm = new productSelectionForm(productTable);
                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected product details using the selectedRowIndex
                    int selectedIndex = selectionForm.selectedRowIndex;
                    DataRow selectedRow = productTable.Rows[selectedIndex];

                    // Display selected product details
                    string selectedProductDetails = $"Selected Product:\n" +
                                                    $"ID: {selectedRow["p_id"]}\n" +
                                                    $"Name: {selectedRow["p_name"]}\n" +
                                                    $"Stock: {selectedRow["p_stock"]}\n" +
                                                    $"Price: {selectedRow["p_sale_price"]}";
                    MessageBox.Show(selectedProductDetails, "Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
