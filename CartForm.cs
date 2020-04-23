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
    public partial class CartForm : Form
    {
        public CartForm(String[] text)
        {
            InitializeComponent();
            this.textBox1.Lines = text;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(this.textBox1.Text);
        }
    }
}
