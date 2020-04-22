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
    public partial class ProductAddForm : Form
    {

        public String _productName = "";
        public double _price = 0;
        public double _calories = 0;
        public String productName
        {
            get
            {
                return this._productName;
            }
            set
            {
                this._productName = value;
            }
        }
        public double price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }
        }
        public double calories
        {
            get
            {
                return this._calories;
            }
            set
            {
                this._calories = value;
            }
        }

        public ProductAddForm()
        {
            InitializeComponent();
            this.ProductNameInput.DataBindings.Add("Text", this, "productName");
            this.PriceInput.DataBindings.Add("Value", this, "price");
            this.CaloriesInput.DataBindings.Add("Value", this, "calories");
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if(this.productName.Length == 0)
            {
                MessageBox.Show("Product name should be writed");
                return;
            }
            try
            {
                Program.db.addProduct(productName, price, calories);
            } catch
            {
                MessageBox.Show("Product name should be unique");
                return;
            }
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
