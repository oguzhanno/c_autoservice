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
    public partial class listdetail : Form
    {
        string id;
        public listdetail(string s)
        {
            InitializeComponent();
            id = s;
        }

        NpgsqlConnection npgSqlConnection;
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }

        public void Show_list()
        {
            
                ConnectBD();
                string query = "SELECT detail.type AS Название, detail.catalogue AS \"Каталожный номер\", detail.manufacturer AS Производитель FROM parts_sheet INNER JOIN detail ON parts_sheet.id_detail = detail.id WHERE parts_sheet.id_order_outfit = '" + id + "';";
                NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
                DataTable table = new DataTable();
                table.Load(comand.ExecuteReader());
                dataGridView1.DataSource = table;
            
            
        }

        private void listdetail_Load(object sender, EventArgs e)
        {
            try
            {
                Show_list();
            }
            catch
            {
                MessageBox.Show("Заказ наряд не заключен");
                this.Close();
            }
        }
        public string number
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO parts_sheet(id_order_outfit) VALUES('" + id + "');" +
                           "UPDATE parts_sheet SET id_detail = (SELECT id FROM detail WHERE catalogue = '" + number + "') WHERE id_order_outfit = '" + id + "' AND id_detail is NULL;";
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
            int count = npgSqlCommand.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string s = dataGridView1.CurrentCell.Value.ToString();
                string query2 = " DELETE FROM parts_sheet WHERE parts_sheet.id_detail=(SELECT id FROM detail where type='" + s + "') AND parts_sheet.id_order_outfit='" + id + "';";
                NpgsqlCommand npgSqlCommand2 = new NpgsqlCommand(query2, npgSqlConnection);
                int count2 = npgSqlCommand2.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Не выбран каталожный номер!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Show();
        }
    }
}
