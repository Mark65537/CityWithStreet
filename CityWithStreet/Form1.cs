using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CityWithStreet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string connectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable table;

        private void Form1_Load(object sender, EventArgs e)
        {
            //string connectionString = $"Data Source=" +
            //$"(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programs\\0A studio ��� �����\\CityWithStreet\\CityWithStreet\\Database1.mdf\";" +
            //$"Integrated Security=True";

            string databaseName = "Database1.mdf";
            string currentDirectory = Directory.GetCurrentDirectory();
            string databasePath = Path.Combine(currentDirectory, databaseName);

            #region ����� ����
            if (!File.Exists(databasePath)) // ���� ���� �� ������ � ������� ����������
            {
                // ��������� ����� ���� � ������������ ����������
                string parentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(currentDirectory).FullName).FullName).FullName;
                databasePath = Path.Combine(parentDirectory, databaseName);

                if (!File.Exists(databasePath)) // ���� ���� ��� ��� �� ������
                {
                    MessageBox.Show("Database file not found.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            connectionString = $"Data Source=" +
                $"(LocalDB)\\MSSQLLocalDB;AttachDbFilename={databasePath};" +
                $"Integrated Security=True";

            #region ����������� � ����
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT L.name AS LocalityName, H.houseNumber AS HouseName, H.totalApartments 
                    FROM Main AS M
                    INNER JOIN Localities AS L ON M.localityId = L.Id
                    INNER JOIN HouseData AS H ON M.houseId = H.Id";

                dataAdapter = new SqlDataAdapter(query, connection);
                table = new DataTable();
                dataAdapter.Fill(table);

                dGV_main.DataSource = table;
                
            }
            #endregion


        }

        private void b_mdelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGV_main.SelectedRows)
            {
                dGV_main.Rows.Remove(row);
            }
        }

        private void b_msave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // �������� SqlCommandBuilder, ����� ������������� ������������ SQL-������� ��� ���������� ���� ������
                //using (SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter))
                //{
                    //dataAdapter.UpdateCommand = builder.GetUpdateCommand();
                    //dataAdapter.InsertCommand = builder.GetInsertCommand();
                    //dataAdapter.DeleteCommand = builder.GetDeleteCommand();

                    dataAdapter.Update(table);
                //}
            }
        }
    }
}