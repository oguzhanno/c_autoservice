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
    public partial class ChangeClient : Form
    {
        string id;
        NpgsqlConnection npgSqlConnection;
        public ChangeClient(string s)
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

        private void ChangeClient_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.Add("Мужской");
                comboBox1.Items.Add("Женский");
                ConnectBD();
                string query = "SELECT surname , name , patronymic, gender, datebirth, telephone FROM person " +
                               "INNER JOIN client ON client.id_person = person.id AND client.id = '" + id + "';";

                NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
                NpgsqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader[0].ToString();
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();
                    comboBox1.Text = reader[3].ToString();
                    textBox5.Text = reader[4].ToString();
                    textBox6.Text = reader[5].ToString();
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Не выбран ID");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectBD();
            string query = "UPDATE person SET surname ='" + surname + "', name='" + name + "', patronymic='" + patronymic + "', gender='" + gender + "', datebirth='" + datebirth + "', telephone='" + telephone + "' WHERE id=(SELECT id_person FROM client WHERE id='" + id + "');";
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
            int count = npgSqlCommand.ExecuteNonQuery();
            this.Close();
        }

        public string surname
        {
            get
            {
                return textBox1.Text;
            }
        }
        public string name
        {
            get
            {
                return textBox2.Text;
            }
        }
        public string patronymic
        {
            get
            {
                return textBox3.Text;
            }
        }
        public string gender
        {
            get
            {
                return comboBox1.SelectedItem.ToString();
            }
        }
        public string datebirth
        {
            get
            {
                return textBox5.Text;
            }
        }
        public string telephone
        {
            get
            {
                return textBox6.Text;
            }
        }
    }
}
