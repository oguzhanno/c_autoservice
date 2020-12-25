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
    public partial class AddEmployee : Form
    {


        NpgsqlConnection npgSqlConnection;
        public AddEmployee()
        {
            InitializeComponent();
        }
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
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
                try
                {
                    return comboBox1.SelectedItem.ToString();
                }
                catch
                {
                    return "не выбран пол!";
                }
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
        public string adress
        {
            get
            {
                return textBox7.Text;
            }
        }
        public string speciality
        {
            get
            {
                return textBox8.Text;
            }
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Мужской");
            comboBox1.Items.Add("Женский");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string query = "INSERT INTO Person(name, surname, patronymic, gender, datebirth, telephone,addres) VALUES('" + name + "', '" + surname + "', '" + patronymic + "', '" + gender + "', '" + datebirth + "', '" + telephone + "','" + adress + "');" +
                               "INSERT INTO Employee(id_person) SELECT person.id FROM Person WHERE surname = '" + surname + "' AND name = '" + name + "';" +
                               "UPDATE Employee SET specialty ='" + speciality + "' WHERE id_person = (SELECT id FROM person WHERE surname = '" + surname + "' AND name = '" + name + "');";
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
