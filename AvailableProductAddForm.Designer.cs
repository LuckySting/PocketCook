namespace PocketCook
{
    partial class AvailableProductAddForm
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
            this.ProductNameSelector = new System.Windows.Forms.ComboBox();
            this.QuantityInput = new System.Windows.Forms.NumericUpDown();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductNameSelector
            // 
            this.ProductNameSelector.FormattingEnabled = true;
            this.ProductNameSelector.Location = new System.Drawing.Point(132, 12);
            this.ProductNameSelector.Name = "ProductNameSelector";
            this.ProductNameSelector.Size = new System.Drawing.Size(314, 24);
            this.ProductNameSelector.TabIndex = 0;
            // 
            // QuantityInput
            // 
            this.QuantityInput.DecimalPlaces = 2;
            this.QuantityInput.Location = new System.Drawing.Point(132, 82);
            this.QuantityInput.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.QuantityInput.Name = "QuantityInput";
            this.QuantityInput.Size = new System.Drawing.Size(314, 22);
            this.QuantityInput.TabIndex = 1;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(170, 145);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(135, 36);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(311, 145);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(135, 36);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Product name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Quantity";
            // 
            // AvailableProductAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 193);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.QuantityInput);
            this.Controls.Add(this.ProductNameSelector);
            this.MaximumSize = new System.Drawing.Size(476, 240);
            this.MinimumSize = new System.Drawing.Size(476, 240);
            this.Name = "AvailableProductAddForm";
            this.Text = "Add available product";
            ((System.ComponentModel.ISupportInitialize)(this.QuantityInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProductNameSelector;
        private System.Windows.Forms.NumericUpDown QuantityInput;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}