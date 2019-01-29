namespace EveTradingFinder.Forms
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.profitPerVolume = new System.Windows.Forms.RadioButton();
            this.profitPerUnit = new System.Windows.Forms.RadioButton();
            this.profitPerIsk = new System.Windows.Forms.RadioButton();
            this.byTotalProfit = new System.Windows.Forms.RadioButton();
            this.searchOrdersButton = new System.Windows.Forms.Button();
            this.regionsButton = new System.Windows.Forms.Button();
            this.itemsButton = new System.Windows.Forms.Button();
            this.allRegionsCheckBox = new System.Windows.Forms.CheckBox();
            this.loadDataButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Moccasin;
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.profitPerVolume);
            this.panel1.Controls.Add(this.profitPerUnit);
            this.panel1.Controls.Add(this.profitPerIsk);
            this.panel1.Controls.Add(this.byTotalProfit);
            this.panel1.Controls.Add(this.searchOrdersButton);
            this.panel1.Controls.Add(this.regionsButton);
            this.panel1.Controls.Add(this.itemsButton);
            this.panel1.Controls.Add(this.allRegionsCheckBox);
            this.panel1.Controls.Add(this.loadDataButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 100);
            this.panel1.TabIndex = 0;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(3, 56);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(122, 41);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "Обновить";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // profitPerVolume
            // 
            this.profitPerVolume.AutoSize = true;
            this.profitPerVolume.Location = new System.Drawing.Point(93, 3);
            this.profitPerVolume.Name = "profitPerVolume";
            this.profitPerVolume.Size = new System.Drawing.Size(99, 17);
            this.profitPerVolume.TabIndex = 8;
            this.profitPerVolume.Text = "profitPerVolume";
            this.profitPerVolume.UseVisualStyleBackColor = true;
            // 
            // profitPerUnit
            // 
            this.profitPerUnit.AutoSize = true;
            this.profitPerUnit.Location = new System.Drawing.Point(93, 26);
            this.profitPerUnit.Name = "profitPerUnit";
            this.profitPerUnit.Size = new System.Drawing.Size(83, 17);
            this.profitPerUnit.TabIndex = 7;
            this.profitPerUnit.Text = "profitPerUnit";
            this.profitPerUnit.UseVisualStyleBackColor = true;
            // 
            // profitPerIsk
            // 
            this.profitPerIsk.AutoSize = true;
            this.profitPerIsk.Location = new System.Drawing.Point(3, 26);
            this.profitPerIsk.Name = "profitPerIsk";
            this.profitPerIsk.Size = new System.Drawing.Size(78, 17);
            this.profitPerIsk.TabIndex = 6;
            this.profitPerIsk.Text = "profitPerIsk";
            this.profitPerIsk.UseVisualStyleBackColor = true;
            // 
            // byTotalProfit
            // 
            this.byTotalProfit.AutoSize = true;
            this.byTotalProfit.Checked = true;
            this.byTotalProfit.Location = new System.Drawing.Point(3, 3);
            this.byTotalProfit.Name = "byTotalProfit";
            this.byTotalProfit.Size = new System.Drawing.Size(84, 17);
            this.byTotalProfit.TabIndex = 5;
            this.byTotalProfit.TabStop = true;
            this.byTotalProfit.Text = "byTotalProfit";
            this.byTotalProfit.UseVisualStyleBackColor = true;
            // 
            // searchOrdersButton
            // 
            this.searchOrdersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchOrdersButton.Location = new System.Drawing.Point(379, 50);
            this.searchOrdersButton.Name = "searchOrdersButton";
            this.searchOrdersButton.Size = new System.Drawing.Size(122, 41);
            this.searchOrdersButton.TabIndex = 4;
            this.searchOrdersButton.Text = "Поиск ордеров";
            this.searchOrdersButton.UseVisualStyleBackColor = true;
            this.searchOrdersButton.Click += new System.EventHandler(this.searchOrdersButton_Click);
            // 
            // regionsButton
            // 
            this.regionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.regionsButton.Location = new System.Drawing.Point(507, 50);
            this.regionsButton.Name = "regionsButton";
            this.regionsButton.Size = new System.Drawing.Size(80, 41);
            this.regionsButton.TabIndex = 3;
            this.regionsButton.Text = "Регионы";
            this.regionsButton.UseVisualStyleBackColor = true;
            this.regionsButton.Click += new System.EventHandler(this.regionsButton_Click);
            // 
            // itemsButton
            // 
            this.itemsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsButton.Location = new System.Drawing.Point(507, 3);
            this.itemsButton.Name = "itemsButton";
            this.itemsButton.Size = new System.Drawing.Size(80, 41);
            this.itemsButton.TabIndex = 2;
            this.itemsButton.Text = "Предметы";
            this.itemsButton.UseVisualStyleBackColor = true;
            this.itemsButton.Click += new System.EventHandler(this.itemsButton_Click);
            // 
            // allRegionsCheckBox
            // 
            this.allRegionsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.allRegionsCheckBox.AutoSize = true;
            this.allRegionsCheckBox.Location = new System.Drawing.Point(252, 4);
            this.allRegionsCheckBox.Name = "allRegionsCheckBox";
            this.allRegionsCheckBox.Size = new System.Drawing.Size(121, 17);
            this.allRegionsCheckBox.TabIndex = 1;
            this.allRegionsCheckBox.Text = "По всем регионам";
            this.allRegionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // loadDataButton
            // 
            this.loadDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadDataButton.Location = new System.Drawing.Point(379, 3);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(122, 41);
            this.loadDataButton.TabIndex = 0;
            this.loadDataButton.Text = "Загрузить данные";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(590, 375);
            this.dataGridView1.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 505);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Main";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button loadDataButton;
        private System.Windows.Forms.CheckBox allRegionsCheckBox;
        private System.Windows.Forms.Button regionsButton;
        private System.Windows.Forms.Button itemsButton;
        private System.Windows.Forms.Button searchOrdersButton;
        private System.Windows.Forms.RadioButton profitPerVolume;
        private System.Windows.Forms.RadioButton profitPerUnit;
        private System.Windows.Forms.RadioButton profitPerIsk;
        private System.Windows.Forms.RadioButton byTotalProfit;
        private System.Windows.Forms.Button refreshButton;
    }
}