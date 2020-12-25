using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace autoservice1
{
    public partial class AddDetail : Form
    {

        NpgsqlConnection npgSqlConnection;
        public AddDetail()
        {
            InitializeComponent();
        }

        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }
        
        public string type 
        { 
           get 
            {
                return textBox1.Text;
            } 
        }
        public string catalogue
        {
            get
            {
                return textBox2.Text;
            }
        }
        public string manufacturer
        {
            get
            {
                return textBox3.Text;
            }
        }
        public string coast
        {
            get
            {
                return textBox4.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectBD();
            try
            {
                string query = "INSERT INTO detail(catalogue,manufacturer,type,coast) VALUES('" + catalogue + "','" + manufacturer + "','" + type + "','" + coast + "');";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
