namespace autoservice1
{
    partial class sclad
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
            this.AddDetailButton = new System.Windows.Forms.Button();
            this.DeleteDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(762, 355);
            this.dataGridView1.TabIndex = 0;
            // 
            // AddDetailButton
            // 
            this.AddDetailButton.Location = new System.Drawing.Point(17, 389);
            this.AddDetailButton.Name = "AddDetailButton";
            this.AddDetailButton.Size = new System.Drawing.Size(250, 40);
            this.AddDetailButton.TabIndex = 1;
            this.AddDetailButton.Text = "Добавить деталь";
            this.AddDetailButton.UseVisualStyleBackColor = true;
            this.AddDetailButton.Click += new System.EventHandler(this.AddDetailButton_Click);
            // 
            // DeleteDetail
            // 
            this.DeleteDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.DeleteDetail.Location = new System.Drawing.Point(273, 389);
            this.DeleteDetail.Name = "DeleteDetail";
            this.DeleteDetail.Size = new System.Drawing.Size(250, 40);
            this.DeleteDetail.TabIndex = 2;
            this.DeleteDetail.Text = "Удалить деталь";
            this.DeleteDetail.UseVisualStyleBackColor = true;
            this.DeleteDetail.Click += new System.EventHandler(this.DeleteDetail_Click);
            // 
            // sclad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 441);
            this.Controls.Add(this.DeleteDetail);
            this.Controls.Add(this.AddDetailButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "sclad";
            this.Text = "sclad";
            this.Load += new System.EventHandler(this.sclad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddDetailButton;
        private System.Windows.Forms.Button DeleteDetail;
    }
}