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
    public partial class sclad : Form
    {
        NpgsqlConnection npgSqlConnection;
        public sclad()
        {
            InitializeComponent();
        }
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }

        public void Show_Sclad()
        {
            ConnectBD();
            string query = "SELECT id AS ID ,type AS Название, catalogue AS \"Каталожный номер\", manufacturer AS Производитель, coast AS Цена FROM detail;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView1.DataSource = table;
        }

        private void AddDetailButton_Click(object sender, EventArgs e)
        {
            var f = new AddDetail();
            f.Show();
        }

        private void DeleteDetail_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string s = dataGridView1.CurrentCell.Value.ToString();

                string query = "DELETE FROM detail WHERE id='" + s + "';";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Не выбран ID детали");
            }
            Show();
        }
        private void sclad_Load(object sender, EventArgs e)
        {
            Show_Sclad();
        }
    }
}
