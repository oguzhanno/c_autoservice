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
    public partial class priem : Form
    {
        NpgsqlConnection npgSqlConnection;
        public priem()
        {
            InitializeComponent();
        }
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }
        public void Show_Order()
        {
            ConnectBD();
            string query = "SELECT order_outfit.id AS ID, order_outfit.datereceipt AS \"Дата заключения\" , vehicle.brand AS Марка, vehicle.model AS Модель, person.surname AS \"Фамилия клиента\" " +
                            "FROM order_outfit INNER JOIN vehicle ON order_outfit.id_vehicle = vehicle.id " +
                            "INNER JOIN client ON vehicle.id_client = client.id " +
                            "INNER JOIN person ON client.id_person = person.id;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView1.DataSource = table;
        }
        public void Show_Client()
        {
            ConnectBD();
            string query = "SELECT surname AS Фамилия,name AS Имя ,patronymic AS Отчество,telephone AS Телефон,datebirth AS \"Дата рождения\" from person,client WHERE person.id=client.id_person";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView2.DataSource = table;
        }
        public void Show_Vehicle()
        {
            ConnectBD();
            string query = "SELECT vehicle.brand AS Марка, vehicle.model AS Модель, vehicle.year AS Год, vehicle.vin AS VIN, vehicle.state_number AS \"Гос.Номер\" FROM vehicle;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView3.DataSource = table;
        }
        private void priem1_Load(object sender, EventArgs e)
        {
            Show_Order();
            Show_Client();
            Show_Vehicle();
        }
        private void metroTabPage1_Click(object sender, EventArgs e)
        {
            Show_Order();
        }
        private void ChangeOrderButton_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentCell.Value.ToString();
            var f = new ChangeOrder(s);
            f.Show();
        }
        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            var f = new Addorder();
            f.Show();
        }
        private void ShowOrderButton_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentCell.Value.ToString();
            var f = new ViewOrder(s);
            f.Show();
        }
    }
}
