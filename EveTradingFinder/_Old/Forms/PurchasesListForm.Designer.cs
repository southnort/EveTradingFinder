namespace EveTradingFinder.Forms
{
    partial class PurchasesListForm
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
            this.inputTextPos = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ingridientsListTextBox = new System.Windows.Forms.RichTextBox();
            this.itemsTextBox = new System.Windows.Forms.RichTextBox();
            this.addIngridientsButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputTextPos
            // 
            this.inputTextPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTextPos.Location = new System.Drawing.Point(46, 61);
            this.inputTextPos.Name = "inputTextPos";
            this.inputTextPos.Size = new System.Drawing.Size(186, 311);
            this.inputTextPos.TabIndex = 0;
            this.inputTextPos.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "input";
            // 
            // ingridientsListTextBox
            // 
            this.ingridientsListTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ingridientsListTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ingridientsListTextBox.Location = new System.Drawing.Point(319, 136);
            this.ingridientsListTextBox.Name = "ingridientsListTextBox";
            this.ingridientsListTextBox.ReadOnly = true;
            this.ingridientsListTextBox.Size = new System.Drawing.Size(423, 236);
            this.ingridientsListTextBox.TabIndex = 2;
            this.ingridientsListTextBox.Text = "список ингридиентов";
            // 
            // itemsTextBox
            // 
            this.itemsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemsTextBox.Location = new System.Drawing.Point(319, 12);
            this.itemsTextBox.Name = "itemsTextBox";
            this.itemsTextBox.Size = new System.Drawing.Size(423, 118);
            this.itemsTextBox.TabIndex = 3;
            this.itemsTextBox.Text = "список предметов";
            // 
            // addIngridientsButton
            // 
            this.addIngridientsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addIngridientsButton.Location = new System.Drawing.Point(238, 216);
            this.addIngridientsButton.Name = "addIngridientsButton";
            this.addIngridientsButton.Size = new System.Drawing.Size(75, 92);
            this.addIngridientsButton.TabIndex = 4;
            this.addIngridientsButton.Text = "=>";
            this.addIngridientsButton.UseVisualStyleBackColor = true;
            this.addIngridientsButton.Click += new System.EventHandler(this.addIngridientsButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(266, 136);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(47, 47);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // PurchasesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 450);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addIngridientsButton);
            this.Controls.Add(this.itemsTextBox);
            this.Controls.Add(this.ingridientsListTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputTextPos);
            this.Name = "PurchasesListForm";
            this.Text = "PurchasesListForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox inputTextPos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ingridientsListTextBox;
        private System.Windows.Forms.RichTextBox itemsTextBox;
        private System.Windows.Forms.Button addIngridientsButton;
        private System.Windows.Forms.Button clearButton;
    }
}