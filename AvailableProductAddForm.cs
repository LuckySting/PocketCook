using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketCook
{
    public partial class AvailableProductAddForm : Form
    {
        public String productName;
        public double quantity;

        public AvailableProductAddForm()
        {
            InitializeComponent();
            this.ProductNameSelector.Items.AddRange(Program.db.getProductNames().ToArray<object>());
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var productName = this.ProductNameSelector.Text;
            var quantity = (double)this.QuantityInput.Value;
            if (productName.Length == 0)
            {
                MessageBox.Show("Product name should be writed");
                return;
            }
            try
            {
                Program.db.addAvailableProcuct(productName, quantity);
            }
            catch
            {
                MessageBox.Show("Product with this name is unknown");
                return;
            }
            this.quantity = quantity;
            this.productName = productName;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
