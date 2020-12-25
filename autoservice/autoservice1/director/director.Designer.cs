namespace autoservice1
{
    partial class director
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ChangeEmployee = new System.Windows.Forms.Button();
            this.DeleteEmployee = new System.Windows.Forms.Button();
            this.AddEmployee = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.DeleteClient = new System.Windows.Forms.Button();
            this.ChangeClient = new System.Windows.Forms.Button();
            this.AddClient = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.DeleteVehicle = new System.Windows.Forms.Button();
            this.ChangeVehicle = new System.Windows.Forms.Button();
            this.AddVehicle = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.DeleteOrder = new System.Windows.Forms.Button();
            this.ChangeOrder = new System.Windows.Forms.Button();
            this.AddOrder = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.Table1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.metroTabPage6 = new MetroFramework.Controls.MetroTabPage();
            this.ChoseSQLFile = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.NewSQLFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RecoveryBD = new System.Windows.Forms.Button();
            this.BackupBD = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.metroTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.metroTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table1)).BeginInit();
            this.metroTabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Controls.Add(this.metroTabPage5);
            this.metroTabControl1.Controls.Add(this.metroTabPage6);
            this.metroTabControl1.Location = new System.Drawing.Point(12, 12);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(940, 510);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.label1);
            this.metroTabPage1.Controls.Add(this.textBox1);
            this.metroTabPage1.Controls.Add(this.button1);
            this.metroTabPage1.Controls.Add(this.ChangeEmployee);
            this.metroTabPage1.Controls.Add(this.DeleteEmployee);
            this.metroTabPage1.Controls.Add(this.AddEmployee);
            this.metroTabPage1.Controls.Add(this.dataGridView1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(932, 468);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Сотрудники";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            this.metroTabPage1.Click += new System.EventHandler(this.metroTabPage1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Фамилия:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangeEmployee
            // 
            this.ChangeEmployee.Location = new System.Drawing.Point(457, 418);
            this.ChangeEmployee.Name = "ChangeEmployee";
            this.ChangeEmployee.Size = new System.Drawing.Size(230, 50);
            this.ChangeEmployee.TabIndex = 6;
            this.ChangeEmployee.Text = "Изменить";
            this.ChangeEmployee.UseVisualStyleBackColor = true;
            this.ChangeEmployee.Click += new System.EventHandler(this.ChangeEmployee_Click);
            // 
            // DeleteEmployee
            // 
            this.DeleteEmployee.Location = new System.Drawing.Point(693, 418);
            this.DeleteEmployee.Name = "DeleteEmployee";
            this.DeleteEmployee.Size = new System.Drawing.Size(230, 50);
            this.DeleteEmployee.TabIndex = 5;
            this.DeleteEmployee.Text = "Удалить";
            this.DeleteEmployee.UseVisualStyleBackColor = true;
            this.DeleteEmployee.Click += new System.EventHandler(this.DeleteEmployee_Click);
            // 
            // AddEmployee
            // 
            this.AddEmployee.Location = new System.Drawing.Point(221, 418);
            this.AddEmployee.Name = "AddEmployee";
            this.AddEmployee.Size = new System.Drawing.Size(230, 50);
            this.AddEmployee.TabIndex = 3;
            this.AddEmployee.Text = "Добавить";
            this.AddEmployee.UseVisualStyleBackColor = true;
            this.AddEmployee.Click += new System.EventHandler(this.AddEmployee_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(920, 377);
            this.dataGridView1.TabIndex = 2;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.DeleteClient);
            this.metroTabPage2.Controls.Add(this.ChangeClient);
            this.metroTabPage2.Controls.Add(this.AddClient);
            this.metroTabPage2.Controls.Add(this.dataGridView2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(932, 468);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Клиенты";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            this.metroTabPage2.Click += new System.EventHandler(this.metroTabPage2_Click);
            // 
            // DeleteClient
            // 
            this.DeleteClient.Location = new System.Drawing.Point(693, 418);
            this.DeleteClient.Name = "DeleteClient";
            this.DeleteClient.Size = new System.Drawing.Size(230, 50);
            this.DeleteClient.TabIndex = 6;
            this.DeleteClient.Text = "Удалить";
            this.DeleteClient.UseVisualStyleBackColor = true;
            this.DeleteClient.Click += new System.EventHandler(this.DeleteClient_Click);
            // 
            // ChangeClient
            // 
            this.ChangeClient.Location = new System.Drawing.Point(457, 418);
            this.ChangeClient.Name = "ChangeClient";
            this.ChangeClient.Size = new System.Drawing.Size(230, 50);
            this.ChangeClient.TabIndex = 5;
            this.ChangeClient.Text = "Изменить";
            this.ChangeClient.UseVisualStyleBackColor = true;
            this.ChangeClient.Click += new System.EventHandler(this.ChangeClient_Click);
            // 
            // AddClient
            // 
            this.AddClient.Location = new System.Drawing.Point(221, 418);
            this.AddClient.Name = "AddClient";
            this.AddClient.Size = new System.Drawing.Size(230, 50);
            this.AddClient.TabIndex = 4;
            this.AddClient.Text = "Добавить";
            this.AddClient.UseVisualStyleBackColor = true;
            this.AddClient.Click += new System.EventHandler(this.AddClient_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 35);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(920, 377);
            this.dataGridView2.TabIndex = 2;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.DeleteVehicle);
            this.metroTabPage3.Controls.Add(this.ChangeVehicle);
            this.metroTabPage3.Controls.Add(this.AddVehicle);
            this.metroTabPage3.Controls.Add(this.dataGridView3);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(932, 468);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Автомобили";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            this.metroTabPage3.Click += new System.EventHandler(this.metroTabPage3_Click);
            // 
            // DeleteVehicle
            // 
            this.DeleteVehicle.Location = new System.Drawing.Point(693, 418);
            this.DeleteVehicle.Name = "DeleteVehicle";
            this.DeleteVehicle.Size = new System.Drawing.Size(230, 50);
            this.DeleteVehicle.TabIndex = 8;
            this.DeleteVehicle.Text = "Удалить";
            this.DeleteVehicle.UseVisualStyleBackColor = true;
            this.DeleteVehicle.Click += new System.EventHandler(this.DeleteVehicle_Click);
            // 
            // ChangeVehicle
            // 
            this.ChangeVehicle.Location = new System.Drawing.Point(457, 418);
            this.ChangeVehicle.Name = "ChangeVehicle";
            this.ChangeVehicle.Size = new System.Drawing.Size(230, 50);
            this.ChangeVehicle.TabIndex = 7;
            this.ChangeVehicle.Text = "Изменить";
            this.ChangeVehicle.UseVisualStyleBackColor = true;
            this.ChangeVehicle.Click += new System.EventHandler(this.ChangeVehicle_Click);
            // 
            // AddVehicle
            // 
            this.AddVehicle.Location = new System.Drawing.Point(221, 418);
            this.AddVehicle.Name = "AddVehicle";
            this.AddVehicle.Size = new System.Drawing.Size(230, 50);
            this.AddVehicle.TabIndex = 6;
            this.AddVehicle.Text = "Добавить";
            this.AddVehicle.UseVisualStyleBackColor = true;
            this.AddVehicle.Click += new System.EventHandler(this.AddVehicle_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(3, 35);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(920, 377);
            this.dataGridView3.TabIndex = 2;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.DeleteOrder);
            this.metroTabPage4.Controls.Add(this.ChangeOrder);
            this.metroTabPage4.Controls.Add(this.AddOrder);
            this.metroTabPage4.Controls.Add(this.dataGridView4);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(932, 468);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Заказ наряды";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            this.metroTabPage4.Click += new System.EventHandler(this.metroTabPage4_Click);
            // 
            // DeleteOrder
            // 
            this.DeleteOrder.Location = new System.Drawing.Point(693, 418);
            this.DeleteOrder.Name = "DeleteOrder";
            this.DeleteOrder.Size = new System.Drawing.Size(230, 50);
            this.DeleteOrder.TabIndex = 8;
            this.DeleteOrder.Text = "Удалить";
            this.DeleteOrder.UseVisualStyleBackColor = true;
            this.DeleteOrder.Click += new System.EventHandler(this.DeleteOrder_Click);
            // 
            // ChangeOrder
            // 
            this.ChangeOrder.Location = new System.Drawing.Point(457, 418);
            this.ChangeOrder.Name = "ChangeOrder";
            this.ChangeOrder.Size = new System.Drawing.Size(230, 50);
            this.ChangeOrder.TabIndex = 7;
            this.ChangeOrder.Text = "Изменить";
            this.ChangeOrder.UseVisualStyleBackColor = true;
            this.ChangeOrder.Click += new System.EventHandler(this.ChangeOrder_Click);
            // 
            // AddOrder
            // 
            this.AddOrder.Location = new System.Drawing.Point(221, 418);
            this.AddOrder.Name = "AddOrder";
            this.AddOrder.Size = new System.Drawing.Size(230, 50);
            this.AddOrder.TabIndex = 6;
            this.AddOrder.Text = "Добавить";
            this.AddOrder.UseVisualStyleBackColor = true;
            this.AddOrder.Click += new System.EventHandler(this.AddOrder_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(3, 35);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(920, 377);
            this.dataGridView4.TabIndex = 2;
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.Controls.Add(this.Table1);
            this.metroTabPage5.Controls.Add(this.button2);
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.HorizontalScrollbarSize = 10;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(932, 468);
            this.metroTabPage5.TabIndex = 4;
            this.metroTabPage5.Text = "Откаты";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.VerticalScrollbarSize = 10;
            this.metroTabPage5.Click += new System.EventHandler(this.metroTabPage5_Click);
            // 
            // Table1
            // 
            this.Table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table1.Location = new System.Drawing.Point(9, 32);
            this.Table1.Name = "Table1";
            this.Table1.Size = new System.Drawing.Size(920, 377);
            this.Table1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(699, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 50);
            this.button2.TabIndex = 7;
            this.button2.Text = "Откатить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // metroTabPage6
            // 
            this.metroTabPage6.Controls.Add(this.ChoseSQLFile);
            this.metroTabPage6.Controls.Add(this.textBox2);
            this.metroTabPage6.Controls.Add(this.NewSQLFile);
            this.metroTabPage6.Controls.Add(this.label3);
            this.metroTabPage6.Controls.Add(this.label2);
            this.metroTabPage6.Controls.Add(this.RecoveryBD);
            this.metroTabPage6.Controls.Add(this.BackupBD);
            this.metroTabPage6.HorizontalScrollbarBarColor = true;
            this.metroTabPage6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.HorizontalScrollbarSize = 10;
            this.metroTabPage6.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage6.Name = "metroTabPage6";
            this.metroTabPage6.Size = new System.Drawing.Size(932, 468);
            this.metroTabPage6.TabIndex = 5;
            this.metroTabPage6.Text = "Резервные копии";
            this.metroTabPage6.VerticalScrollbarBarColor = true;
            this.metroTabPage6.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.VerticalScrollbarSize = 10;
            // 
            // ChoseSQLFile
            // 
            this.ChoseSQLFile.Location = new System.Drawing.Point(7, 242);
            this.ChoseSQLFile.Name = "ChoseSQLFile";
            this.ChoseSQLFile.Size = new System.Drawing.Size(245, 30);
            this.ChoseSQLFile.TabIndex = 8;
            this.ChoseSQLFile.Text = "Восстановить базу данных";
            this.ChoseSQLFile.UseVisualStyleBackColor = true;
            this.ChoseSQLFile.Click += new System.EventHandler(this.ChoseSQLFile_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(245, 20);
            this.textBox2.TabIndex = 7;
            // 
            // NewSQLFile
            // 
            this.NewSQLFile.Location = new System.Drawing.Point(7, 74);
            this.NewSQLFile.Name = "NewSQLFile";
            this.NewSQLFile.Size = new System.Drawing.Size(248, 30);
            this.NewSQLFile.TabIndex = 6;
            this.NewSQLFile.Text = "Создание SQL-файла";
            this.NewSQLFile.UseVisualStyleBackColor = true;
            this.NewSQLFile.Click += new System.EventHandler(this.NewSQLFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Восстановлене резервной копии:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Создание резервной копии:";
            // 
            // RecoveryBD
            // 
            this.RecoveryBD.Location = new System.Drawing.Point(10, 278);
            this.RecoveryBD.Name = "RecoveryBD";
            this.RecoveryBD.Size = new System.Drawing.Size(245, 30);
            this.RecoveryBD.TabIndex = 3;
            this.RecoveryBD.Text = "Восстановить базу данных";
            this.RecoveryBD.UseVisualStyleBackColor = true;
            this.RecoveryBD.Click += new System.EventHandler(this.RecoveryBD_Click);
            // 
            // BackupBD
            // 
            this.BackupBD.Location = new System.Drawing.Point(7, 136);
            this.BackupBD.Name = "BackupBD";
            this.BackupBD.Size = new System.Drawing.Size(248, 30);
            this.BackupBD.TabIndex = 2;
            this.BackupBD.Text = "Создание резервной копии";
            this.BackupBD.UseVisualStyleBackColor = true;
            this.BackupBD.Click += new System.EventHandler(this.BackupBD_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // director
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 528);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "director";
            this.Text = "director";
            this.Load += new System.EventHandler(this.director_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.metroTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.metroTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.metroTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Table1)).EndInit();
            this.metroTabPage6.ResumeLayout(false);
            this.metroTabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private System.Windows.Forms.Button DeleteEmployee;
        private System.Windows.Forms.Button AddEmployee;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button DeleteClient;
        private System.Windows.Forms.Button ChangeClient;
        private System.Windows.Forms.Button AddClient;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button DeleteVehicle;
        private System.Windows.Forms.Button ChangeVehicle;
        private System.Windows.Forms.Button AddVehicle;
        private System.Windows.Forms.Button DeleteOrder;
        private System.Windows.Forms.Button ChangeOrder;
        private System.Windows.Forms.Button AddOrder;
        private System.Windows.Forms.Button ChangeEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView Table1;
        private MetroFramework.Controls.MetroTabPage metroTabPage6;
        private System.Windows.Forms.Button BackupBD;
        private System.Windows.Forms.Button RecoveryBD;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button NewSQLFile;
        private System.Windows.Forms.Button ChoseSQLFile;
    }
}