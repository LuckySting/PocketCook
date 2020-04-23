namespace PocketCook
{
    partial class ProductAddForm
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
            this.ProductNameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CaloriesInput = new System.Windows.Forms.NumericUpDown();
            this.PriceInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.CaloriesInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceInput)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductNameInput
            // 
            this.ProductNameInput.Location = new System.Drawing.Point(147, 12);
            this.ProductNameInput.Name = "ProductNameInput";
            this.ProductNameInput.Size = new System.Drawing.Size(301, 22);
            this.ProductNameInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Product name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Price (for 100g)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Calories (for 100g)";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(313, 187);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(135, 36);
            this.OkButton.TabIndex = 7;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(172, 187);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(135, 36);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CaloriesInput
            // 
            this.CaloriesInput.DecimalPlaces = 2;
            this.CaloriesInput.Location = new System.Drawing.Point(147, 147);
            this.CaloriesInput.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.CaloriesInput.Name = "CaloriesInput";
            this.CaloriesInput.Size = new System.Drawing.Size(301, 22);
            this.CaloriesInput.TabIndex = 9;
            // 
            // PriceInput
            // 
            this.PriceInput.DecimalPlaces = 2;
            this.PriceInput.Location = new System.Drawing.Point(147, 81);
            this.PriceInput.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.PriceInput.Name = "PriceInput";
            this.PriceInput.Size = new System.Drawing.Size(301, 22);
            this.PriceInput.TabIndex = 10;
            // 
            // ProductAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 235);
            this.ControlBox = false;
            this.Controls.Add(this.PriceInput);
            this.Controls.Add(this.CaloriesInput);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductNameInput);
            this.MaximumSize = new System.Drawing.Size(478, 282);
            this.MinimumSize = new System.Drawing.Size(478, 282);
            this.Name = "ProductAddForm";
            this.Text = "Add product";
            ((System.ComponentModel.ISupportInitialize)(this.CaloriesInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProductNameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.NumericUpDown CaloriesInput;
        private System.Windows.Forms.NumericUpDown PriceInput;
    }
}