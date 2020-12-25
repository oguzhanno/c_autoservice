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
    public partial class master : Form
    {

        NpgsqlConnection npgSqlConnection;
        string id;
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }

        public master(string s)
        {
            InitializeComponent();
            id = s;
        }


        private void OrderButton_Click(object sender, EventArgs e)
        {

            ConnectBD();
            string query = "SELECT order_outfit.id AS ID , order_outfit.datereceipt AS Дата , vehicle.brand AS Модель, vehicle.model AS Марка , person.surname AS Фамилия " +
                            "FROM order_outfit INNER JOIN vehicle ON order_outfit.id_vehicle = vehicle.id " +
                            "INNER JOIN client ON vehicle.id_client = client.id " +
                            "INNER JOIN person ON client.id_person = person.id;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView1.DataSource = table;
        }

        private void VehicleButton_Click(object sender, EventArgs e)
        {
            ConnectBD();
            string query = "SELECT vehicle.id AS ID, vehicle.brand AS Марка, vehicle.model AS Модель, vehicle.year AS Год, vehicle.vin AS VIN, vehicle.state_number AS \"Гос.Номер\" FROM vehicle;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView1.DataSource = table;
        }

        private void GoToWorkButton_Click(object sender, EventArgs e)
        {
            var f = new GoWork(id);
            f.Show();
        }

        private void EndWorkButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE box SET stat=NULL WHERE stat=(SELECT id FROM location WHERE id_employee = '" + id + "');" +
                                "DELETE FROM location WHERE id_employee = '" + id + "';";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Вами ранее не начинались работы!");
            }
        }

        private void ShowOrderButton_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentCell.Value.ToString();
            var f = new ViewOrder(s);
            f.Show();
        }

        private void ChangeOrderButton_Click(object sender, EventArgs e)
        {
            string s = dataGridView1.CurrentCell.Value.ToString();
            var f = new ChangeOrder(s);
            f.Show();
        }
    }
}