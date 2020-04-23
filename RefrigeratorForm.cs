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
    public partial class RefrigeratorForm : Form
    {
        public RefrigeratorForm()
        {
            InitializeComponent();
            fill();
        }

        private void fill()
        {
            var data = Program.db.getAvailableProducts();
            foreach (var product in data)
            {
                this.dataGridView1.Rows.Add(new object[] { product["productName"], product["quantity"] });
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            var productName = (String)row.Cells[0].Value;
            Program.db.deleteAvailableProduct(productName);
        }

        private void AddNewProductButton_Click(object sender, EventArgs e)
        {
            var form = new AvailableProductAddForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                var productName = form.productName;
                var quantity = form.quantity;
                this.dataGridView1.Rows.Add(new object[] { productName, quantity });
            }
        }
    }
}
