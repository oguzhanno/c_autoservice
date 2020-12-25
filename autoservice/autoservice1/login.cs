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
    public partial class login : Form
    {

        NpgsqlConnection npgSqlConnection;
        public login()
        {
            InitializeComponent();
        }

        public string t1
        {
            get
            {
                return login_field.Text;
            }
        }
        public string t2
        {
            get
            {
                return password_field.Text;
            }
        }
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }

        public void cl()
        {
            login.ActiveForm.Hide();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            login_field.Text = "";
            password_field.Text = "";
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            ConnectBD();
            string id = " ";
            string specialty = " ";
            string query = "SELECT employee.id, employee.specialty FROM employee,person,users WHERE person.surname='" + t1 + "' and person.id=employee.id_person and users.password = '" + t2 + "'";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            NpgsqlDataReader reader = comand.ExecuteReader();
            while (reader.Read()) {
                id = reader[0].ToString();
                specialty = reader[1].ToString();
            }

            switch (specialty)
            {
                case "Диагност-приемщик":
                    priem f1 = new priem();
                    f1.Show();
                    //this.Hide();
                    break;

                case "Директор":
                    director f2 = new director();
                    f2.Show();
                    //this.Hide();
                    break;

                case "Зав.склад":
                    sclad f3 = new sclad();
                    f3.Show();
                    //this.Hide();
                    break;

                case " ":
                    MessageBox.Show("Неверно указан логин/пароль.");
                    break;

                default:
                    master f4 = new master(id);
                    f4.Show();
                    //this.Hide();
                    break;
            }
        }

        private void ChangeConnectBD_Click(object sender, EventArgs e)
        {
            ChangeConnectBD f1 = new ChangeConnectBD();
            f1.Show();
        }
    }
     
}
