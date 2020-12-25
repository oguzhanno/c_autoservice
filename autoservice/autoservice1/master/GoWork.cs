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
    public partial class GoWork : Form
    {
        string id;
        NpgsqlConnection npgSqlConnection;
     

        public GoWork(string s)
        {
            InitializeComponent();
            id = s;
        }
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }

        private void GoWork_Load(object sender, EventArgs e)
        {
            ConnectBD();
            string query = "SELECT vehicle.id AS ID, vehicle.brand AS Марка, vehicle.model AS Модель, vehicle.year AS Год, vehicle.vin AS VIN, vehicle.state_number AS \"Гос.Номер\" " +
                            "FROM vehicle, order_outfit WHERE order_outfit.id_vehicle = vehicle.id AND order_outfit.dateexpiration is NULL;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView1.DataSource = table;
            
            string query2 = "SELECT title FROM box WHERE stat is NULL;";
            NpgsqlCommand comand2 = new NpgsqlCommand(query2, npgSqlConnection);
            NpgsqlDataReader reader2 = comand2.ExecuteReader();

            while (reader2.Read())
            {
                comboBox1.Items.Add(reader2[0].ToString());
            }
            reader2.Close();
        }


        public string time
        {
            get
            {
                return textBox1.Text;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string s = dataGridView1.CurrentCell.Value.ToString();
                string title = comboBox1.SelectedItem.ToString();

                string query = "INSERT INTO location(id_employee,id_vehicle,work_time) VALUES ('" + id + "','" + s + "','" + time + "');" +
                               "UPDATE box SET stat = (SELECT id FROM location WHERE id_employee = '" + id + "') WHERE title = '" + title + "';";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не выбран автомобиль или не указано время");
            }
        }
    }
}