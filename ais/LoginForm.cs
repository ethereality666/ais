using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace ais
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void authButton_click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            Connector connector = new Connector();

            string LoginQuery = "SELECT * from `users` WHERE `username`=@user OR `password`=@password";

            MySqlCommand sqlCommand1 = new MySqlCommand(LoginQuery, connector.GetConnection());
            sqlCommand1.Parameters.Add("@user", MySqlDbType.VarChar).Value = LoginTextBox.Text;
            sqlCommand1.Parameters.Add("@password", MySqlDbType.VarChar).Value = PasswordTextBox.Text;
            
            MainForm mainForm = new MainForm();
            try
            {
                connector.OpenConnection();
                dataAdapter.SelectCommand = sqlCommand1;
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Успешно");
                    mainForm.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("Проверьте правильность данных");
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка");
            }
            finally
            {
                connector.CloseConnection();
            }
        }
    }
}
