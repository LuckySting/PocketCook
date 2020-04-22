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
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
            fill();
        }

        private void fill()
        {
            var data = Product.getProducts();
            foreach (var row in data)
            {
                this.dataGridView1.Rows.Add(row.all);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                var productName = (String)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                var price = Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                var calories = Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                Product.editProduct(productName, price, calories);
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            var productName = (String)row.Cells[0].Value;
            try
            {
                Product.deleteProduct(productName);
            } catch
            {
                MessageBox.Show("You can't delete product, which is necessary in at least one recipe");
                e.Cancel = true;
            }
        }

        private void AddNewProductButton_Click(object sender, EventArgs e)
        {
            var form = new ProductAddForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                var productName = form.productName;
                var price = form.price;
                var calories = form.calories;
                this.dataGridView1.Rows.Add((new Product(productName, price, calories)).all);
            }
        }
    }
}
