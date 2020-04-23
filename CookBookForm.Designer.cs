namespace PocketCook
{
    partial class CookBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.recipeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addToCartCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AddNewProductButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recipeName,
            this.recipeDescription,
            this.calories,
            this.price,
            this.available,
            this.addToCartCheckBox});
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1080, 370);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            // 
            // recipeName
            // 
            this.recipeName.DataPropertyName = "recipeName";
            this.recipeName.HeaderText = "Recipe name";
            this.recipeName.MinimumWidth = 6;
            this.recipeName.Name = "recipeName";
            this.recipeName.ReadOnly = true;
            this.recipeName.Width = 125;
            // 
            // recipeDescription
            // 
            this.recipeDescription.DataPropertyName = "recipeDescription";
            this.recipeDescription.HeaderText = "Recipe description";
            this.recipeDescription.MinimumWidth = 6;
            this.recipeDescription.Name = "recipeDescription";
            this.recipeDescription.ReadOnly = true;
            this.recipeDescription.Width = 125;
            // 
            // calories
            // 
            this.calories.DataPropertyName = "calories";
            this.calories.HeaderText = "Calories";
            this.calories.MinimumWidth = 6;
            this.calories.Name = "calories";
            this.calories.ReadOnly = true;
            this.calories.Width = 125;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 125;
            // 
            // available
            // 
            this.available.DataPropertyName = "available";
            this.available.HeaderText = "In stock";
            this.available.MinimumWidth = 6;
            this.available.Name = "available";
            this.available.ReadOnly = true;
            this.available.ToolTipText = "Ingridients in refrigerator";
            this.available.Width = 125;
            // 
            // addToCartCheckBox
            // 
            this.addToCartCheckBox.HeaderText = "Add missings to cart";
            this.addToCartCheckBox.MinimumWidth = 6;
            this.addToCartCheckBox.Name = "addToCartCheckBox";
            this.addToCartCheckBox.Width = 125;
            // 
            // AddNewProductButton
            // 
            this.AddNewProductButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewProductButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddNewProductButton.Location = new System.Drawing.Point(1042, 12);
            this.AddNewProductButton.Name = "AddNewProductButton";
            this.AddNewProductButton.Size = new System.Drawing.Size(50, 50);
            this.AddNewProductButton.TabIndex = 2;
            this.AddNewProductButton.Text = "+";
            this.AddNewProductButton.UseVisualStyleBackColor = true;
            this.AddNewProductButton.Click += new System.EventHandler(this.AddNewProductButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Image = global::PocketCook.Properties.Resources.baseline_shopping_cart_black_24dp1;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CookBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddNewProductButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CookBookForm";
            this.Text = "CookBook";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddNewProductButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipeDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn calories;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn available;
        private System.Windows.Forms.DataGridViewCheckBoxColumn addToCartCheckBox;
        private System.Windows.Forms.Button button1;
    }
}