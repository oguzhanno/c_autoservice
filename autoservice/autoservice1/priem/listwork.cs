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

    public partial class listwork : Form
    {
        int i = 0;
        int i2 = 0;
        int i3 = 0;
        int i4 = 0;
        int i5 = 0;
        int i6 = 0;
        int i7 = 0;
        int i8 = 0;
        string id;

        List<string> works = new List<string>();
        public listwork(string s)
        {
            InitializeComponent();
            id = s;
        }

        NpgsqlConnection npgSqlConnection;

        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                button1.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167)))));
                works.Add("Диагностика/ремонт подвески");
                i += 1;
            }
            else
            {
                button1.BackColor = Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
                i -= 1;
                works.Remove("Диагностика/ремонт подвески");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (i2 == 0)
            {
                button2.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167)))));
                i2 += 1;
                works.Add("Ремонт ходой части");
            }
            else
            {
                button2.BackColor = Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
                i2 -= 1;
                works.Remove("Ремонт ходой части");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (i3 == 0)
            {
                button3.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167)))));
                i3 += 1;
                works.Add("Ремонт ДВС");
            }
            else
            {
                button3.BackColor = Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
                i3 -= 1;
                works.Remove("Ремонт ДВС");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (i4 == 0)
            {
                button4.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167)))));
                i4 += 1;
                works.Add("Прохождение ТО");
            }
            else
            {
                button4.BackColor = Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
                i4 -= 1;
                works.Remove("Прохождение ТО");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i5 == 0)
            {
                button5.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167)))));
                i5 += 1;
                works.Add("Электрика");
            }
            else
            {
                button5.BackColor = Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
                i5 -= 1;
                works.Remove("Электрика");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (i6 == 0)
            {
                button6.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167)))));
                i6 += 1;
                works.Add("Кузовной ремонт");
            }
            else
            {
                button6.BackColor = Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
                i6 -= 1;
                works.Remove("Кузовной ремонт");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (i7 == 0)
            {
                button7.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167)))));
                i7 += 1;
                works.Add("Покраска");
            }
            else
            {
                button7.BackColor = Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
                i7 -= 1;
                works.Remove("Покраска");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (i8 == 0)
            {
                button8.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167)))));
                i8 += 1;
                works.Add("Ремонт кондиционеров");
            }
            else
            {
                button8.BackColor = Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
                i8 -= 1;
                works.Remove("Ремонт кондиционеров");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ConnectBD();

            string query2 = " DELETE FROM list_of_services WHERE id_order_outfit = '" + id + "';";
            NpgsqlCommand npgSqlCommand2 = new NpgsqlCommand(query2, npgSqlConnection);
            int count2 = npgSqlCommand2.ExecuteNonQuery();

            foreach (var item in works)
            {
                string query = "INSERT INTO list_of_services (name_of_work,id_order_outfit) VALUES('" + item + "', '" + id + "');";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
            }
            this.Close();
        }

        private void listwork_Load(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string query3 = "SELECT list_of_services.name_of_work FROM list_of_services WHERE list_of_services.id_order_outfit='" + id + "';";
                NpgsqlCommand comand3 = new NpgsqlCommand(query3, npgSqlConnection);
                NpgsqlDataReader reader3 = comand3.ExecuteReader();
                int j = 0;

                List<string> works2 = new List<string>();
                while (reader3.Read())
                {
                    works2.Add(reader3[j].ToString());
                }
                reader3.Close();

                foreach (var result in works2)
                {
                    if (result == "Диагностика/ремонт подвески") { i++; button1.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167))))); works.Add("Диагностика/ремонт подвески"); }
                    if (result == "Ремонт ходовой части") { i2++; button2.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167))))); works.Add("Ремонт ходовой части"); }
                    if (result == "Ремонт ДВС") { i3++; button3.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167))))); works.Add("Ремонт ДВС"); }
                    if (result == "Прохождение ТО") { i4++; button4.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167))))); works.Add("Прохождение ТО"); }
                    if (result == "Электрика") { i5++; button5.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167))))); works.Add("Электрика"); }
                    if (result == "Кузовной ремонт") { i6++; button6.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167))))); works.Add("Кузовной ремонт"); }
                    if (result == "Покраска") { i7++; button7.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167))))); works.Add("Покраска"); }
                    if (result == "Ремонт кондиционеров") { i8++; button8.BackColor = Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(255)))), ((int)(((byte)(167))))); works.Add("Ремонт кондиционеров"); }
                    j += 1;
                }
            }
            catch
            {
                MessageBox.Show("Заказ наряд не заключен!");
                this.Close();

            }
            finally
            {
                
            }
        }
    }
}
