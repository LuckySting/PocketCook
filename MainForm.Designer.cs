namespace PocketCook
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.RefrigeratorButton = new System.Windows.Forms.Button();
            this.CookBookButton = new System.Windows.Forms.Button();
            this.ProductsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RefrigeratorButton
            // 
            this.RefrigeratorButton.Location = new System.Drawing.Point(12, 12);
            this.RefrigeratorButton.Name = "RefrigeratorButton";
            this.RefrigeratorButton.Size = new System.Drawing.Size(279, 61);
            this.RefrigeratorButton.TabIndex = 0;
            this.RefrigeratorButton.Text = "Refrigerator";
            this.RefrigeratorButton.UseVisualStyleBackColor = true;
            this.RefrigeratorButton.Click += new System.EventHandler(this.RefrigeratorButton_Click);
            // 
            // CookBookButton
            // 
            this.CookBookButton.Location = new System.Drawing.Point(12, 95);
            this.CookBookButton.Name = "CookBookButton";
            this.CookBookButton.Size = new System.Drawing.Size(279, 61);
            this.CookBookButton.TabIndex = 1;
            this.CookBookButton.Text = "CookBook";
            this.CookBookButton.UseVisualStyleBackColor = true;
            this.CookBookButton.Click += new System.EventHandler(this.CookBookButton_Click);
            // 
            // ProductsButton
            // 
            this.ProductsButton.Location = new System.Drawing.Point(12, 178);
            this.ProductsButton.Name = "ProductsButton";
            this.ProductsButton.Size = new System.Drawing.Size(279, 61);
            this.ProductsButton.TabIndex = 3;
            this.ProductsButton.Text = "Products";
            this.ProductsButton.UseVisualStyleBackColor = true;
            this.ProductsButton.Click += new System.EventHandler(this.ProductsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 253);
            this.Controls.Add(this.ProductsButton);
            this.Controls.Add(this.CookBookButton);
            this.Controls.Add(this.RefrigeratorButton);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.Text = "PocketCook";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RefrigeratorButton;
        private System.Windows.Forms.Button CookBookButton;
        private System.Windows.Forms.Button ProductsButton;
    }
}

