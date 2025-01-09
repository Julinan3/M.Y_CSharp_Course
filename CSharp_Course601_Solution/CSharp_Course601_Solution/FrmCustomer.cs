using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Course601_Solution
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        string connectionString = "Server = localhost;port=5432;Database=CustomberDb;userId=postgres;Password=1234";
        void GetAllCustomers()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Customers";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }
        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            GetAllCustomers();
        }

        private void btnCustomerUpdate_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;
            int id = int.Parse(txtCustomerId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "UPDATE Customers SET CustomerName = @CustomerName, CustomerSurname = @CustomerSurname, CustomerCity = @CustomerCity WHERE CustomerId = @CustomerId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerName", customerName);
            command.Parameters.AddWithValue("@CustomerSurname", customerSurname);
            command.Parameters.AddWithValue("@CustomerCity", customerCity);
            command.Parameters.AddWithValue("@CustomerId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Güncelleme işlemi başarılı");
            connection.Close();
            GetAllCustomers();
        }

        private void btnCustomerDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCustomerId.Text);
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", id);
            command.ExecuteNonQuery();
            MessageBox.Show("Silme işlemi başarılı");
            connection.Close();
            GetAllCustomers();
        }

        private void btnCustomerCreate_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            string customerSurname = txtCustomerSurname.Text;
            string customerCity = txtCustomerCity.Text;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Customers (CustomerName, CustomerSurname, CustomerCity) VALUES (@CustomerName, @CustomerSurname, @CustomerCity)";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerName", customerName);
            command.Parameters.AddWithValue("@CustomerSurname", customerSurname);
            command.Parameters.AddWithValue("@CustomerCity", customerCity);
            command.ExecuteNonQuery();
            MessageBox.Show("Ekleme işlemi başarılı");
            connection.Close();
            GetAllCustomers();

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {

        }
    }
}
