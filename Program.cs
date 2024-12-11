using MySql.Data.MySqlClient;

string host, user, password, database;

host = "localhost";
user = "root";
password = "";
database = "tubes_keuangan";

string connectionString = $"server={host};user={user};password={password};database={database};";

MySqlConnection connection = new MySqlConnection(connectionString);

try
{
    connection.Open();
    // Console.WriteLine("Koneksi berhasil!");

    TampilData(connection);
    connection.Close();

}
catch (Exception ex)
{
    Console.WriteLine($"Terdapat error: {ex.Message}");
}

static void TampilData(MySqlConnection connection)
{
    Console.WriteLine("Data Keuangan");
    Console.WriteLine("==============");

    string query = "SELECT * FROM user";
    MySqlCommand command = new MySqlCommand(query, connection);
    MySqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        string nama = reader.GetString("name_user");
        int saldo = reader.GetInt32("saldo_user");

        Console.WriteLine($@"
        Nama: {nama}           Saldo: {saldo}
        ");
    }
}