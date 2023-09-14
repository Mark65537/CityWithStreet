using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

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

        private void Load_base()
        {
            string databaseName = "Database1.mdf";
            string currentDirectory = Directory.GetCurrentDirectory();
            string databasePath = Path.Combine(currentDirectory, databaseName);

            #region Поиск базы
            if (!File.Exists(databasePath)) // Если файл не найден в текущей директории
            {
                // Попробуем найти файл в родительской директории
                string parentDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(currentDirectory).FullName).FullName).FullName;
                databasePath = Path.Combine(parentDirectory, databaseName);

                if (!File.Exists(databasePath)) // Если файл все еще не найден
                {
                    MessageBox.Show("Database file not found.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion

            connectionString = $"Data Source=" +
                $"(LocalDB)\\MSSQLLocalDB;AttachDbFilename={databasePath};" +
                $"Integrated Security=True";

            string query = @"
                    SELECT M.houseId, L.name AS LocalityName, H.houseNumber AS HouseName, H.totalApartments 
                    FROM Main AS M
                    INNER JOIN Localities AS L ON M.localityId = L.Id
                    INNER JOIN HouseData AS H ON M.houseId = H.Id";

            #region Подключение к базе
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                dataAdapter = new SqlDataAdapter(query, connection);
                table = new DataTable();
                dataAdapter.Fill(table);

                dGV_main.DataSource = table;
                dGV_main.Columns["Id"].Visible = false;
            }
            #endregion
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Load_base();
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
                using (SqlTransaction sqlTran = connection.BeginTransaction())//мы используем транзакции для обеспечения целостности данных. Если во время выполнения запросов произойдет ошибка, все изменения будут откатываться.
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.Transaction = sqlTran;
                        cmd.CommandText = @"
                          DELETE FROM Main;
                          ";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"
                          INSERT INTO Main (localityId, houseId)
                            VALUES (
                                (SELECT Id FROM Localities WHERE name = @localityName), 
                                (SELECT Id FROM HouseData WHERE houseNumber = @houseNumber)
                            )
                            ";

                        foreach (DataGridViewRow row in dGV_main.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@localityName", (string)row.Cells["LocalityName"].Value);
                                cmd.Parameters.AddWithValue("@houseNumber", (string)row.Cells["HouseName"].Value);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    sqlTran.Commit();
                }
            }
            MessageBox.Show("База сохранена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void b_update_Click(object sender, EventArgs e)
        {
            Load_base();
        }

        private void dGV_main_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
                string query = @"
                    SELECT H.houseNumber AS HouseNumber, SP.prefix AS StreetPrefix, H.street, 
                    H.apartmentNumber, H.ownerName, H.totalApartments 

                    FROM HouseData AS H
                    INNER JOIN StreetPrefix AS SP ON H.streetPrefixId = SP.Id
                    WHERE H.Id=(SELECT houseId FROM Main WHERE houseNumber = @houseNumber) 
                    ";

                #region Подключение к базе
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    dataAdapter = new SqlDataAdapter(query, connection);
                    table = new DataTable();
                    dataAdapter.Fill(table);

                    dGV_submain.DataSource = table;

                }
                #endregion
            
            MessageBox.Show("База сохранена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}