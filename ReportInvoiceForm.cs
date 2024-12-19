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
    public partial class ReportInvoiceForm : Form
    {
        int InvoiceId;
        public ReportInvoiceForm( int InvoiceId)
        {   
            InitializeComponent();
            this.InvoiceId = InvoiceId;
        }

        private void ReportInvoiceForm_Load(object sender, EventArgs e)
        {
             String connStr = "Data Source=DESKTOP-677VPCL\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();
            
            String query = "SELECT *FROM sale_invoice WHERE invoice_id=" + InvoiceId;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            InvoiceDataSet ds = new InvoiceDataSet();
            da.Fill(ds.Invoice_Table);
            invoiocereport r = new invoiocereport();
            r.SetDataSource(ds);
            r.Refresh();
            crystalReportViewer1.ReportSource = r;

        }
    }
}
