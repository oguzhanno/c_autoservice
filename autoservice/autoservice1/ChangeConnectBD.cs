using Npgsql;
using System;
using System.Windows.Forms;

namespace autoservice1
{
    public partial class ChangeConnectBD : Form
    {
        public static string Server = "localhost";
        public static string Port = "5432";
        public static string User = "postgres";
        public static string Password = "root";
        public static string Database = "autoservice";
        NpgsqlConnection npgSqlConnection;
        public void ConnectBD()
        {
            String connectionString = $"Server={autoservice1.ChangeConnectBD.Server};Port={autoservice1.ChangeConnectBD.Port};User Id={autoservice1.ChangeConnectBD.User};Password={autoservice1.ChangeConnectBD.Password};Database={autoservice1.ChangeConnectBD.Database};";
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }
        public ChangeConnectBD()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Server = ServerField.Text;
            Port = PortField.Text;
            User = IDField.Text;
            Password = PasswordFIeld.Text;
            Database = DatabaseField.Text;
            try
            {
                ConnectBD();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться, проверьте данные подключения.");
            }
        }
    }
}
