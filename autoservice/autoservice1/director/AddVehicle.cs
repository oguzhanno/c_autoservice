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
    public partial class AddVehicle : Form
    {

        NpgsqlConnection npgSqlConnection;
        public AddVehicle()
        {
            InitializeComponent();
        }

        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
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
                try
                {
                    return comboBox1.SelectedItem.ToString();
                }
                catch
                {
                    return "0";
                }
            }
        } 


        private void AddVehicle_Load(object sender, EventArgs e)
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string[] cl = client.Split(new char[] { ' ' });
                string query = "INSERT INTO Vehicle(brand, model, year, vin, state_number) VALUES('" + mark + "', '" + model + "', '" + year + "', '" + vin + "', '" + state + "');" +
                               "UPDATE vehicle SET id_client = (SELECT client.id FROM person,client WHERE person.surname = '" + cl[0] + "' AND person.name = '" + cl[1] + "' AND client.id_person = person.id) WHERE vin = '" + vin + "';";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Заполне все поля");
            }
        }
    }
    
}
