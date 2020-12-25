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
    public partial class Addorder : Form
    {
        public Addorder()
        {
            InitializeComponent();
        }

        NpgsqlConnection npgSqlConnection;
        string s;
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
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

        public string statenum
        {
            get
            {
                return textBox5.Text;
            }
        }

        public string surname
        {
            get
            {
                return textBox6.Text;
            }
        }
        public string name
        {
            get
            {
                return textBox7.Text;
            }
        }
        public string patronymic
        {
            get
            {
                return textBox8.Text;
            }
        }
        public string gender
        {
            get
            {
                return textBox9.Text;
            }
        }
        public string datebirth
        {
            get
            {
                return textBox10.Text;
            }
        }
        public string telephone
        {
            get
            {
                return textBox11.Text;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ConnectBD();
            string query = "SELECT id from order_outfit WHERE order_outfit.id_vehicle = (SELECT id FROM vehicle WHERE vin='"+ vin + "');";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            NpgsqlDataReader reader = comand.ExecuteReader();
            while (reader.Read()) { s = reader[0].ToString(); }
            var f = new listwork(s);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string query = "INSERT INTO Person(name, surname, patronymic, gender, datebirth, telephone) VALUES('" + name + "', '" + surname + "', '" + patronymic + "', '" + gender + "', '" + datebirth + "', '" + telephone + "');" +
                               "INSERT INTO Client(id_person) SELECT person.id FROM Person WHERE surname = '" + surname + "' AND name = '" + name + "';" +
                               "INSERT INTO Vehicle(brand, model, year, vin, state_number) VALUES('" + mark + "', '" + model + "', '" + year + "', '" + vin + "', '" + statenum + "');" +
                               "UPDATE vehicle SET id_client = (SELECT client.id FROM person,client WHERE person.surname = '" + surname + "' AND person.name = '" + name + "' AND client.id_person = person.id) WHERE vin = '" + vin + "';" +
                               "INSERT INTO order_outfit(id_client) (SELECT client.id FROM person,client WHERE person.surname = '" + surname + "' AND person.name = '" + name + "' AND client.id_person = person.id);" +
                               "UPDATE order_outfit SET id_vehicle =(SELECT vehicle.id FROM vehicle WHERE order_outfit.id_client = vehicle.id_client) FROM client,person WHERE  order_outfit.id_client = client.id AND person.surname = '" + surname + "' AND person.name = '" + name + "' AND client.id_person = person.id;";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Значение поля неверно!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new listdetail(s);
            f.Show();
        }
    }
}   
