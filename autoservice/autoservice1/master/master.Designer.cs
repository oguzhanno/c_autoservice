namespace autoservice1
{
    partial class master
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
            this.EndWorkButton = new System.Windows.Forms.Button();
            this.GoToWorkButton = new System.Windows.Forms.Button();
            this.OrderButton = new System.Windows.Forms.Button();
            this.VehicleButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ShowOrderButton = new System.Windows.Forms.Button();
            this.ChangeOrderButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.EndWorkButton);
            this.panel1.Controls.Add(this.GoToWorkButton);
            this.panel1.Controls.Add(this.OrderButton);
            this.panel1.Controls.Add(this.VehicleButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 450);
            this.panel1.TabIndex = 6;
            // 
            // EndWorkButton
            // 
            this.EndWorkButton.Location = new System.Drawing.Point(12, 321);
            this.EndWorkButton.Name = "EndWorkButton";
            this.EndWorkButton.Size = new System.Drawing.Size(131, 81);
            this.EndWorkButton.TabIndex = 4;
            this.EndWorkButton.Text = "Закончить работы";
            this.EndWorkButton.UseVisualStyleBackColor = true;
            this.EndWorkButton.Click += new System.EventHandler(this.EndWorkButton_Click);
            // 
            // GoToWorkButton
            // 
            this.GoToWorkButton.Location = new System.Drawing.Point(12, 221);
            this.GoToWorkButton.Name = "GoToWorkButton";
            this.GoToWorkButton.Size = new System.Drawing.Size(131, 81);
            this.GoToWorkButton.TabIndex = 3;
            this.GoToWorkButton.Text = "Приступить к работе";
            this.GoToWorkButton.UseVisualStyleBackColor = true;
            this.GoToWorkButton.Click += new System.EventHandler(this.GoToWorkButton_Click);
            // 
            // OrderButton
            // 
            this.OrderButton.Location = new System.Drawing.Point(12, 24);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(131, 81);
            this.OrderButton.TabIndex = 1;
            this.OrderButton.Text = "Заказ-наряды";
            this.OrderButton.UseVisualStyleBackColor = true;
            this.OrderButton.Click += new System.EventHandler(this.OrderButton_Click);
            // 
            // VehicleButton
            // 
            this.VehicleButton.Location = new System.Drawing.Point(12, 124);
            this.VehicleButton.Name = "VehicleButton";
            this.VehicleButton.Size = new System.Drawing.Size(131, 81);
            this.VehicleButton.TabIndex = 2;
            this.VehicleButton.Text = "Автомобиль";
            this.VehicleButton.UseVisualStyleBackColor = true;
            this.VehicleButton.Click += new System.EventHandler(this.VehicleButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(160, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(637, 381);
            this.dataGridView1.TabIndex = 5;
            // 
            // ShowOrderButton
            // 
            this.ShowOrderButton.Location = new System.Drawing.Point(160, 390);
            this.ShowOrderButton.Name = "ShowOrderButton";
            this.ShowOrderButton.Size = new System.Drawing.Size(312, 60);
            this.ShowOrderButton.TabIndex = 8;
            this.ShowOrderButton.Text = "Просмотреть заказ-наряд";
            this.ShowOrderButton.UseVisualStyleBackColor = true;
            this.ShowOrderButton.Click += new System.EventHandler(this.ShowOrderButton_Click);
            // 
            // ChangeOrderButton
            // 
            this.ChangeOrderButton.Location = new System.Drawing.Point(478, 390);
            this.ChangeOrderButton.Name = "ChangeOrderButton";
            this.ChangeOrderButton.Size = new System.Drawing.Size(310, 60);
            this.ChangeOrderButton.TabIndex = 9;
            this.ChangeOrderButton.Text = "Изменить заказ-наряд";
            this.ChangeOrderButton.UseVisualStyleBackColor = true;
            this.ChangeOrderButton.Click += new System.EventHandler(this.ChangeOrderButton_Click);
            // 
            // master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChangeOrderButton);
            this.Controls.Add(this.ShowOrderButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "master";
            this.Text = "master";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button OrderButton;
        private System.Windows.Forms.Button VehicleButton;
        private System.Windows.Forms.Button GoToWorkButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ShowOrderButton;
        private System.Windows.Forms.Button ChangeOrderButton;
        private System.Windows.Forms.Button EndWorkButton;
    }
}