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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CookBookButton_Click(object sender, EventArgs e)
        {
            var cookBook = new CookBookForm();
            cookBook.ShowDialog();
        }

        private void RefrigeratorButton_Click(object sender, EventArgs e)
        {
            var refrigeratorForm = new RefrigeratorForm();
            refrigeratorForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            var productsForm = new ProductsForm();
            productsForm.ShowDialog();
        }
    }
}
