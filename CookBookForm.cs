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
    public partial class CookBookForm : Form
    {
        public CookBookForm()
        {
            InitializeComponent();
            fill();
        }

        private void fill()
        {
            var data = Recipe.getSuitableRecipes(ref Program.db);
            this.dataGridView1.Rows.Clear();
            foreach (var row in data)
            {
                this.dataGridView1.Rows.Add(row.all);
            }
        }

        private void AddNewProductButton_Click(object sender, EventArgs e)
        {
            var form = new RecipeAddForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                var necessary_products = form.necessaryProducts;
                foreach(var np in necessary_products)
                {
                    if(np[0] != null)
                    {
                        var productName = (String)np[0];
                        var quantity = Double.Parse((String)np[1]);
                        Program.db.addNecessaryProduct(form.recipe.recipeName, productName, quantity);
                        form.recipe.recipeDescription = productName + " " + quantity + "g\n" + form.recipe.recipeDescription;
                    }
                }
            }
            this.fill();
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            var row = e.Row;
            var recipeName = (String)row.Cells[0].Value;
            Recipe.deleteRecipe(recipeName);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var recipeName = (String)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                var recipeDescription = (String)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                var ingridients = "";
                var necessaryProducts = Program.db.getNecessaryProducts(recipeName);
                foreach (var product in necessaryProducts)
                {
                    ingridients = product["productName"] + " " + product["quantity"] + "g\n" + ingridients;
                }
                MessageBox.Show(ingridients + "--------------------\n" + recipeDescription);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var recipeNames = new List<String>();
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[5].Value != null && (bool)this.dataGridView1.Rows[i].Cells[5].Value)
                {
                    this.dataGridView1.Rows[i].Cells[5].Value = false;
                    recipeNames.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                }
            }
            var products = Program.db.getMissingProducts(recipeNames.ToArray());
            var cart = new List<string>();
            double totalPrice = 0;
            foreach (var product in products)
            {
                cart.Add(product["productName"] + " " + product["needed"] + "g");
                totalPrice += Double.Parse(product["price"].ToString());
            }
            cart.Add("\n");
            cart.Add("Total price: " + totalPrice);
            var cartForm = new CartForm(cart.ToArray()); ;
            cartForm.ShowDialog();
        }
    }
}
