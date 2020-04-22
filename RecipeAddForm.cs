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
    public partial class RecipeAddForm : Form
    {
        private List<String> products;
        public Recipe recipe;
        public List<object[]> necessaryProducts;
        public RecipeAddForm()
        {
            InitializeComponent();
            products = Program.db.getProductNames();
            foreach (var item in products)
            {
                this.productName.Items.Add(item);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.RecipeNameInput.Text.Length == 0)
            {
                MessageBox.Show("Recipe name should be writed");
                return;
            }
            if (this.productName.Items.Count == 0)
            {
                MessageBox.Show("Recipe should contains at least one product");
                return;
            }
            try
            {
                this.recipe = new Recipe(Program.db.addRecipe(RecipeNameInput.Text, RecipeDescriptionInput.Text));
            }
            catch
            {
                MessageBox.Show("Recipe name should be unique");
                return;
            }
            DialogResult = DialogResult.OK;
            necessaryProducts = new List<object[]>();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++ )
            {
                var temp = new object[] {
                    this.dataGridView1.Rows[i].Cells[0].Value,
                    this.dataGridView1.Rows[i].Cells[1].Value
                };
                this.necessaryProducts.Add(temp);
            }
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == ',')
            {
                if (!Double.TryParse(((TextBox)sender).Text + ((e.KeyChar == '\b') ? '0' : e.KeyChar), out _))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
