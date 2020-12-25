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
    public partial class ChangeVehicle : Form
    {
        string id;
        NpgsqlConnection npgSqlConnection;
        public ChangeVehicle(string s)
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

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectBD();
            string[] cl = client.Split(new char[] { ' ' });
            string query = "UPDATE Vehicle SET brand='" + mark + "', model='" + model + "', year='" + year + "', vin='" + vin + "', state_number='" + state + "' WHERE id = '" + id + "';;" +
                           "UPDATE Vehicle SET id_client = (SELECT client.id FROM person,client WHERE person.surname = '" + cl[0] + "' AND person.name = '" + cl[1] + "' AND client.id_person = person.id) WHERE vin = '" + vin + "';";
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
            int count = npgSqlCommand.ExecuteNonQuery();
            this.Close();
        }

        private void ChangeVehicle_Load(object sender, EventArgs e)
        {
            ConnectBD();
            string query = "SELECT surname, name ,patronymic FROM person INNER JOIN client ON client.id_person=person.id;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            NpgsqlDataReader reader = comand.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
            }
            reader.Close();

            string query2 = "SELECT vehicle.brand , vehicle.model , vehicle.year, vehicle.vin, vehicle.state_number, person.surname, person.name, person.patronymic FROM vehicle " +
                            "INNER JOIN client ON vehicle.id_client=client.id " +
                            "INNER JOIN person ON person.id=client.id_person WHERE vehicle.id='" + id + "';";

            NpgsqlCommand comand2 = new NpgsqlCommand(query2, npgSqlConnection);
            NpgsqlDataReader reader2 = comand2.ExecuteReader();
            while (reader2.Read())
            {
                textBox1.Text = reader2[0].ToString();
                textBox2.Text = reader2[1].ToString();
                textBox3.Text = reader2[2].ToString();
                textBox4.Text = reader2[3].ToString();
                textBox5.Text = reader2[4].ToString();
                comboBox1.Text = (reader2[5].ToString() + " " + reader2[6].ToString() + " " + reader2[7].ToString());
            }
            reader2.Close();

        }
        public string mark
        {
            get
            {
                return textBox1.Text;
            }
        }
        public string model
        {
            get
            {
                return textBox2.Text;
            }
        }
        public string year
        {
            get
            {
                return textBox3.Text;
            }
        }
        public string vin
        {
            get
            {
                return textBox4.Text;
            }
        }
        public string state
        {
            get
            {
                return textBox5.Text;
            }
        }
        public string client
        {
            get
            {
                return comboBox1.SelectedItem.ToString();
            }
        }


    }
}
