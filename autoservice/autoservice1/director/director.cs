using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace autoservice1
{
    public partial class director : Form
    {
        NpgsqlConnection npgSqlConnection;
        public string SelectedPath { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public director()
        {
            InitializeComponent();
        }
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }
        public void Show_Employee()
        {
            ConnectBD();
            string query = "SELECT person.id AS ID, surname AS Фамилия, name AS Имя, patronymic AS Отчество, telephone AS Телефон, datebirth AS \"Дата рождения\", addres AS Адрес FROM  person, employee WHERE person.id = employee.id_person;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView1.DataSource = table;
        }
        public void Show_Client()
        {
            ConnectBD();
            string query = "SELECT person.id AS ID, surname AS Фамилия, name AS Имя, patronymic AS Отчество, telephone AS Телефон, datebirth AS \"Дата рождения\" FROM  person, client WHERE person.id = client.id_person;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView2.DataSource = table;
        }
        public void Show_Vehicle()
        {
            ConnectBD();
            string query = "SELECT id AS ID, brand AS Марка, model AS Модель, year AS Год, vin AS VIN, state_number AS \"Гос.Номер\" FROM vehicle;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView3.DataSource = table;
        }
        public void Show_Order()
        {
            ConnectBD();
            string query = "SELECT order_outfit.id AS ID, order_outfit.datereceipt AS \"Дата заключения\", vehicle.brand AS Марка, vehicle.model AS Модель, person.surname AS \"Фамилия заказчика\" " +
                            "FROM order_outfit INNER JOIN vehicle ON order_outfit.id_vehicle = vehicle.id " +
                            "INNER JOIN client ON vehicle.id_client = client.id " +
                            "INNER JOIN person ON client.id_person = person.id;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView4.DataSource = table;
        }
        public void Get_backup()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = @"C:\bd\dump.bat";
            proc.StartInfo.WorkingDirectory = @"C:\bd";
            proc.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ConnectBD();
            string query = "SELECT order_outfit.id AS ID, order_outfit.datereceipt AS \"Дата заключения\", vehicle.brand AS Марка, vehicle.model AS Модель, person.surname AS \"Фамилия заказчика\" " +
                            "FROM order_outfit INNER JOIN vehicle ON order_outfit.id_vehicle = vehicle.id " +
                            "INNER JOIN client ON vehicle.id_client = client.id " +
                            "INNER JOIN person ON client.id_person = person.id;";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            dataGridView2.DataSource = table;
        }
        private void director_Load(object sender, EventArgs e)
        {
            Show_Employee();
            Show_Client();
            Show_Vehicle();
            Show_Order();
            Show_Otkat();
        }
        private void metroTabPage1_Click(object sender, EventArgs e)
        {
            Show_Employee();
        }
        private void AddEmployee_Click(object sender, EventArgs e)
        {
            var f = new AddEmployee();
            f.Show();
        }
        private void ChangeEmployee_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentCell.Value.ToString();
            var f = new ChangeEmployee(id);
            f.Show();
        }
        private void DeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string id = dataGridView1.CurrentCell.Value.ToString();
                string query = "DELETE FROM employee WHERE id_person='" + id + "';"+
                               "DELETE FROM person WHERE person.id = '" + id + "' ;";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
                Show_Employee();
            }
            catch
            {
               MessageBox.Show("Не выбран ID");
            }
        }
        private void AddClient_Click(object sender, EventArgs e)
        {
            var f = new AddClient();
            f.Show();
        }
        private void ChangeClient_Click(object sender, EventArgs e)
        {
            string id = dataGridView2.CurrentCell.Value.ToString();
            var f = new ChangeClient(id);
            f.Show();
        }
        private void DeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string id = dataGridView2.CurrentCell.Value.ToString();
            string query = "UPDATE vehicle SET id_client = NULL WHERE vehicle.id_client = (SELECT client.id FROM client,person WHERE client.id_person=person.id AND person.id = '"+id+"');" +
                            "UPDATE order_outfit SET id_client = NULL WHERE order_outfit.id_client = (SELECT client.id FROM client,person WHERE client.id_person=person.id AND person.id = '" + id + "');" +
                            "DELETE FROM client WHERE id_person='" + id + "';"+
                           "DELETE FROM person WHERE id='" + id + "';";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
                Show_Client();
            }
            catch
            {
                MessageBox.Show("Не выбран ID");
            }
        }
        private void metroTabPage2_Click(object sender, EventArgs e)
        {
            Show_Client();
        }
        private void AddVehicle_Click(object sender, EventArgs e)
        {
            var f = new AddVehicle();
            f.Show();
        }
        private void ChangeVehicle_Click(object sender, EventArgs e)
        {
            string id = dataGridView3.CurrentCell.Value.ToString();
            var f = new ChangeVehicle(id);
            f.Show();
        }
        private void DeleteVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string id = dataGridView3.CurrentCell.Value.ToString();
                string query = "UPDATE order_outfit SET id_vehicle=NULL WHERE id_vehicle='"+id+"';"+
                                "DELETE FROM vehicle WHERE id='" + id + "';";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
                Show_Vehicle();
            }
            catch
            {
               MessageBox.Show("Не выбран ID");
            }
        }
        private void metroTabPage3_Click(object sender, EventArgs e)
        {
            Show_Vehicle();
        }
        private void AddOrder_Click(object sender, EventArgs e)
        {
            var f = new Addorder();
            f.Show();
        }
        private void ChangeOrder_Click(object sender, EventArgs e)
        {
                string id = dataGridView4.CurrentCell.Value.ToString();
                var f = new ChangeOrder(id);
                f.Show();   
        }
        private void DeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectBD();
                string id = dataGridView4.CurrentCell.Value.ToString();
                string query = "DELETE FROM parts_sheet WHERE id_order_outfit='" + id + "';" +
                                "DELETE FROM list_of_services WHERE id_order_outfit='" + id + "';" +
                                "DELETE FROM order_outfit WHERE id='" + id + "';";
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(query, npgSqlConnection);
                int count = npgSqlCommand.ExecuteNonQuery();
                Show_Order();
            }
            catch
            {
                MessageBox.Show("Не выбран ID");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {   
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    if (dataGridView1[1, i].FormattedValue.ToString().
                        Contains(textBox1.Text.Trim()))
                    {
                        dataGridView1.CurrentCell = dataGridView1[0, i];               
                        return;
                    }
        }
        public void Show_Otkat()
        {
            ConnectBD();
            string query = "SELECT DISTINCT date From history ORDER BY date";
            NpgsqlCommand comand = new NpgsqlCommand(query, npgSqlConnection);
            DataTable table = new DataTable();
            table.Load(comand.ExecuteReader());
            Table1.DataSource = table;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string sql = "";
            DateTime data;
            string acc = Table1.CurrentCell.Value.ToString();
            if (acc == "") return;
            data = Convert.ToDateTime(acc);
            sql = "SELECT table_h,date From history";
            Table1.DataSource = null;
            Table1.Rows.Clear();
            Table1.Columns.Clear();
            Table1.Columns.Add("Таблица", "Таблица");
            Table1.Columns.Add("Дата", "Дата");
            NpgsqlCommand cmd = new NpgsqlCommand(sql, npgSqlConnection);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            int temp = 0;
            while (reader.Read())
            {
                if (Convert.ToDateTime(reader[1].ToString()) > data)
                {
                    Table1.Rows.Add("");
                    for (int i = 0; i < 2; i++)
                    {
                        Table1[i, temp].Value = reader[i].ToString();
                    }
                    temp++;
                }
            }
            reader.Close();
            int index = 0;
            List<string> r = new List<string>();
            List<string> coll = new List<string>();
            string nsql = "";
            for (int i = Table1.Rows.Count - 2; i >= 0; i--)
            {
                if (Table1[0, i].Value.ToString() == "box" || Table1[0, i].Value.ToString() == "employee" || Table1[0, i].Value.ToString() == "list_of_services" || Table1[0, i].Value.ToString() == "parts_sheet") index = 5;
                if (Table1[0, i].Value.ToString() == "client") index = 4;
                if (Table1[0, i].Value.ToString() == "detail" || Table1[0, i].Value.ToString() == "location" || Table1[0, i].Value.ToString() == "stock") index = 7;
                if (Table1[0, i].Value.ToString() == "order_outfit") index = 8;
                if (Table1[0, i].Value.ToString() == "person") index = 10;
                if (Table1[0, i].Value.ToString() == "vehicle") index = 9;

                sql = "SELECT * FROM " + "h" + Table1[0, i].Value + " WHERE  id_=(SELECT MAX(id_) FROM " + "h" + Table1[0, i].Value + ")";
                NpgsqlCommand cmd2 = new NpgsqlCommand(sql, npgSqlConnection);
                NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    for (int j = 0; j < index; j++)
                    {
                        r.Add(reader2[j].ToString());
                        coll.Add(reader2.GetName(j));
                    }
                }
                reader2.Close();

                if (r[index - 1] == "1")
                {
                    nsql = "DELETE FROM " + Table1[0, i].Value + @" WHERE """ + coll[1] + @""" = " + r[1];
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM " + "h" + Table1[0, i].Value + " WHERE  id_=(SELECT MAX(id_) FROM " + "h" + Table1[0, i].Value + ")";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM " + "h" + Table1[0, i].Value + " WHERE  id_=(SELECT MAX(id_) FROM " + "h" + Table1[0, i].Value + ")";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM history WHERE  id=(SELECT MAX(id) FROM history)";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM history WHERE  id=(SELECT MAX(id) FROM history)";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                }

                if (r[index - 1] == "2")
                {
                    sql = "UPDATE " + Table1[0, i].Value + " SET ";
                    for (int x = 1; x < coll.Count - 1; x++)
                    {

                        if (r[x] != "") sql += " " + coll[x] + " = '" + r[x] + "'";
                        else sql += " " + coll[x] + " = NULL";
                        if (x < coll.Count - 2) sql += ",";
                    }
                    sql += " WHERE " + coll[1] + " = " + r[1];

                    cmd = new NpgsqlCommand(sql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM h" + Table1[0, i].Value + " WHERE  id_=(SELECT MAX(id_) FROM h" + Table1[0, i].Value + ")";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM h" + Table1[0, i].Value + " WHERE  id_=(SELECT MAX(id_) FROM h" + Table1[0, i].Value + ")";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM history WHERE  id=(SELECT MAX(id) FROM history)";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM history WHERE  id=(SELECT MAX(id) FROM history)";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                }
                if (r[index - 1] == "3")
                {
                    sql = "INSERT INTO " + Table1[0, i].Value + " (";
                    for (int x = 1; x < coll.Count - 1; x++)
                    {
                        sql += " " + coll[x] + " ";
                        if (x < coll.Count - 2) sql += ", ";
                        else sql += ") ";
                    }
                    sql += "VALUES (";
                    for (int x = 1; x < coll.Count - 1; x++)
                    {
                        if (r[x] != "") sql += "'" + r[x] + "'";
                        else sql += "NULL";

                        if (x < coll.Count - 2) sql += ", ";
                        else sql += ")";
                    }
                    cmd = new NpgsqlCommand(sql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM h" + Table1[0, i].Value + " WHERE  id_=(SELECT MAX(id_) FROM h" + Table1[0, i].Value + ")";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM h" + Table1[0, i].Value + " WHERE  id_=(SELECT MAX(id_) FROM h" + Table1[0, i].Value + ")";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM history WHERE  id=(SELECT MAX(id) FROM history)";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                    nsql = "DELETE FROM history WHERE  id=(SELECT MAX(id) FROM history)";
                    cmd = new NpgsqlCommand(nsql, npgSqlConnection);
                    cmd.ExecuteNonQuery();
                }
                r.Clear();
                coll.Clear();
            }
            Table1.Rows.Clear();  // удаление всех строк
            int count = Table1.Columns.Count;
            for (int m = 0; m < count; m++)     // цикл удаления всех столбцов
            {
                Table1.Columns.RemoveAt(0);
            }
        }

        private void metroTabPage5_Click(object sender, EventArgs e)
        {
            Show_Otkat();
        }
        private void metroTabPage4_Click(object sender, EventArgs e)
        {
            Show_Order();
        }

        private void NewSQLFile_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SelectedPath = dialog.SelectedPath;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            FileName = DateTime.Now.ToString().Replace(":", ".").Replace(" ", "_") + ".sql";
            FilePath = SelectedPath;
            textBox2.Text = FilePath;
            FileStream fstream = new FileStream(FilePath + "\\" + FileName, FileMode.OpenOrCreate);
            fstream.Close();
        }

        private void BackupBD_Click(object sender, EventArgs e)
        {
            string commands = $@"SET PGPASSWORD={ChangeConnectBD.Password}
                                 cd {FilePath}
                                 c:\\""Program Files""\\PostgreSQL\\12\bin\\pg_dump.exe -c -h localhost -U postgres -F p -f {FileName} {ChangeConnectBD.Database}";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                }
            };  
            process.Start();

            using (StreamWriter pWriter = process.StandardInput)
            {
                if (pWriter.BaseStream.CanWrite)
                {
                    foreach (var line in commands.Split('\n'))
                        pWriter.WriteLine(line);
                }
            }
        }
        private void ChoseSQLFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + ".sql"; ;
                FilePath = Path.GetDirectoryName(openFileDialog1.FileName);
            }
        }
        private void RecoveryBD_Click(object sender, EventArgs e)
        {
            string commands = $@"SET PGPASSWORD={ChangeConnectBD.Password}
                                cd {FilePath} 
                                c:\\""Program Files""\\PostgreSQL\\12\bin\\psql.exe -U postgres autoservice < {FileName}";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                }
            };
            process.Start();

            using (StreamWriter pWriter = process.StandardInput)
            {
                if (pWriter.BaseStream.CanWrite)
                {
                    foreach (var line in commands.Split('\n'))
                        pWriter.WriteLine(line);
                }
            }
        }

    }
}
