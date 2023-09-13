using System.Data;
using System.Data.SqlClient;

namespace CityWithStreet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string databaseName = "Database1.mdf";
            //string connectionString = $"Data Source=" +
            //$"(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\programs\\0A studio мои проги\\CityWithStreet\\CityWithStreet\\Database1.mdf\";" +
            //$"Integrated Security=True";

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

            string connectionString = $"Data Source=" +
                $"(LocalDB)\\MSSQLLocalDB;AttachDbFilename={databasePath};" +
                $"Integrated Security=True";

            #region Подключение к базе
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT L.name AS LocalityName, H.houseNumber AS HouseName, H.totalApartments 
                    FROM Main AS M
                    INNER JOIN Localities AS L ON M.localityId = L.Id
                    INNER JOIN HouseData AS H ON M.houseId = H.Id";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dGV_main.DataSource = table;
                }
            }
            #endregion


        }
    }
}