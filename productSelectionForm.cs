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
    public partial class productSelectionForm : Form

    {
        private DataTable dt;
        public int selectedRowIndex { get; set; }
        public productSelectionForm(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productSelectionForm_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = dt;
            dgvProducts.Refresh();
        }

        private void dgvProducts_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void dgvProducts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {

                selectedRowIndex = dgvProducts.CurrentRow.Index;
                // MessageBox.Show(selectedRowIndex.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
