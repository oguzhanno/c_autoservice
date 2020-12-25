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
    public partial class ViewOrder : Form
    {
        string id;
        NpgsqlConnection npgSqlConnection;
        public ViewOrder(string s)
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


        private void ViewOrder_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string query = "SELECT order_outfit.datereceipt, vehicle.brand, vehicle.model, vehicle.year, vehicle.vin, vehicle.state_number," +
                               "person.surname, person.name, person.patronymic, person.gender, person.datebirth , person.telephone " +
                               "FROM order_outfit INNER JOIN vehicle ON order_outfit.id_vehicle = vehicle.id " +
                               "INNER JOIN client ON vehicle.id_client = client.id " +
                               "INNER JOIN person ON client.id_person = person.id WHERE order_outfit.id='" + id + "';";

                NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
                NpgsqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    textBox12.Text = reader[0].ToString();
                    textBox1.Text = reader[1].ToString();
                    textBox2.Text = reader[2].ToString();
                    textBox3.Text = reader[3].ToString();
                    textBox4.Text = reader[4].ToString();
                    textBox5.Text = reader[5].ToString();
                    textBox6.Text = reader[6].ToString();
                    textBox7.Text = reader[7].ToString();
                    textBox8.Text = reader[8].ToString();
                    textBox9.Text = reader[9].ToString();
                    textBox10.Text = reader[10].ToString();
                    textBox11.Text = reader[11].ToString();
                }
                reader.Close();

                string query3 = "SELECT list_of_services.name_of_work AS \"Название работ\" FROM list_of_services WHERE list_of_services.id_order_outfit='" + id + "';";
                NpgsqlCommand comand3 = new NpgsqlCommand(query3, npgSqlConnection);
                DataTable table2 = new DataTable();
                table2.Load(comand3.ExecuteReader());
                dataGridView1.DataSource = table2;


                string query2 = "SELECT detail.type AS Название, detail.catalogue AS \"Каталожный номер\", detail.manufacturer AS Производитель  FROM parts_sheet INNER JOIN detail ON parts_sheet.id_detail = detail.id WHERE parts_sheet.id_order_outfit = '" + id + "';";
                NpgsqlCommand comand2 = new NpgsqlCommand(query2, npgSqlConnection);
                DataTable table = new DataTable();
                table.Load(comand2.ExecuteReader());
                dataGridView2.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Не выбран ID");
                this.Close();
            }
        }

   
    }
}
