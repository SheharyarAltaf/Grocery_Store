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
    public partial class changeCalculationForm : Form
    {
        int totalBill;
        public changeCalculationForm(int totalBill)
        {
            this.totalBill = totalBill;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void changeCalculationForm_Load(object sender, EventArgs e)
        {
            txtBill.Text = totalBill.ToString();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            int cashpaid = Convert.ToInt32(txtCash.Text);
            int change = cashpaid- totalBill;
            txtDueCash.Text = change.ToString();
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&& !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
