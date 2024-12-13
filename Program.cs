using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

string host, db, user, pass;

host = "localhost";
user = "root";
pass = "";
db = "csharp_keuangan";

string connectionString = $"Server={host};Database={db};User Id={user};Password={pass};";
int menu = 0;

MySqlConnection connection = new MySqlConnection(connectionString);

try
{
    connection.Open();

    while (menu != 6)
    {
        Console.Clear();
        InfoUser(connection);
        Menu(menu);
        Console.Write("Pilih Menu : ");
        menu = Convert.ToInt32(Console.ReadLine());
        switch (menu)
        {
            case 1:
                RiwayatTransaksi(connection);
                break;
            case 2:
                MenuTambah(connection);
                break;
            case 3:
                HapusTransaksi(connection);
                break;
            case 4:
                CariTransaksi(connection);
                break;
            case 5:
                break;
            case 6:
            default:
                break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static void Menu(int menu)
{
    Console.WriteLine(@"
1. Riwayat Transaksi
2. Tambah Transaksi
3. Hapus Transaksi
4. Cari Transaksi
5. Edit User
6. Keluar
");

}

static void InfoUser(MySqlConnection connection)
{
    string query = "SELECT * FROM user";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    MySqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(@$"
Hi! {reader["name_user"]}, wellcome to Mangan Bata!
(Manajemen Keuangan Berbasis Database)

    {reader["name_user"]}
    Rp. {reader["saldo_user"]}");
    }
    reader.Close();
}

static void RiwayatTransaksi(MySqlConnection connection)
{
    Console.Clear();
    string query = "SELECT * FROM transaksi";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    MySqlDataReader reader = cmd.ExecuteReader();
    Console.WriteLine(@"
=== Riwayat Transaksi  ===");
    while (reader.Read())
    {
        Console.WriteLine(@$"
{reader["jenis_transaksi"]} Rp. {reader["saldo_transaksi"]}
{reader["tanggal_transaksi"]}

{reader["keterangan_transaksi"]}

ID : {reader["id_transaksi"]}
==========================");
    }
    reader.Close();
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}

static void MenuTambah(MySqlConnection connection)
{
    Console.Clear();
    Console.Write(@"
1. Tambah Pemasukkan
2. Tambah Pengeluaran

Pilih Menu : ");
    int menu = Convert.ToInt32(Console.ReadLine());
    switch (menu)
    {
        case 1:
            TambahPemasukkan(connection);
            break;
        case 2:
            TambahPengeluaran(connection);
            break;
        default:
            break;
    }
}

static void TambahPemasukkan(MySqlConnection connection)
{
    Console.Clear();
    DateTime now = DateTime.Now;
    Console.Clear();
    Console.WriteLine(@"
=== Tambah Pemasukkan ===
");
    Console.Write("Jumlah : ");
    int jumlah = Convert.ToInt32(Console.ReadLine());
    Console.Write("Keterangan : ");
    string? keterangan = Console.ReadLine();
    string query = $"INSERT INTO transaksi (jenis_transaksi, saldo_transaksi, keterangan_transaksi, tanggal_transaksi, email_user) VALUES ('+ (pemasukkan)', '{jumlah}', '{keterangan}', '{now}', 'adli@gmail.com')";
    string queryUpdateUser = $"UPDATE user SET saldo_user = saldo_user + {jumlah} WHERE email_user = 'adli@gmail.com'";
    MySqlCommand updateUser = new MySqlCommand(queryUpdateUser, connection);
    updateUser.ExecuteNonQuery();
    MySqlCommand cmd = new MySqlCommand(query, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine(@"Data Berhasil Di Tambah
    
Press any key to continue ...");
    Console.ReadKey();
}

static void TambahPengeluaran(MySqlConnection connection)
{
    Console.Clear();
    DateTime now = DateTime.Now;
    Console.Clear();
    Console.WriteLine(@"
=== Tambah Pemasukkan ===
");
    Console.Write("Jumlah : ");
    int jumlah = Convert.ToInt32(Console.ReadLine());
    Console.Write("Keterangan : ");
    string? keterangan = Console.ReadLine();
    string query = $"INSERT INTO transaksi (jenis_transaksi, saldo_transaksi, keterangan_transaksi, tanggal_transaksi, email_user) VALUES ('- (pengeluaran)', '{jumlah}', '{keterangan}', '{now}', 'adli@gmail.com')";
    string queryUpdateUser = $"UPDATE user SET saldo_user = saldo_user - {jumlah} WHERE email_user = 'adli@gmail.com'";
    MySqlCommand updateUser = new MySqlCommand(queryUpdateUser, connection);
    updateUser.ExecuteNonQuery();
    MySqlCommand cmd = new MySqlCommand(query, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine(@"Data Berhasil Di Tambah
    
Press any key to continue ...");
    Console.ReadKey();
}

static void HapusTransaksi(MySqlConnection connection)
{
    Console.Clear();
    Console.WriteLine(@"Hapus Transaksi
");
    Console.Write("ID : ");
    int id = Convert.ToInt32(Console.ReadLine());
    string query = $"DELETE FROM transaksi WHERE id_transaksi = {id}";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine("Data Berhasil Di Hapus");
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}

static void CariTransaksi(MySqlConnection connection)
{
    Console.Clear();
    Console.WriteLine(@"Cari Transaksi
");
    Console.Write("cari : ");
    string? cari = Console.ReadLine();
    string query = $"SELECT * FROM transaksi WHERE keterangan_transaksi LIKE '%{cari}%'";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    MySqlDataReader reader = cmd.ExecuteReader();
    Console.WriteLine(@$"
=== Hasil Pencarian {cari}  ===");
    while (reader.Read())
    {
        Console.WriteLine(@$"
{reader["jenis_transaksi"]} Rp. {reader["saldo_transaksi"]}
{reader["tanggal_transaksi"]}

{reader["keterangan_transaksi"]}

ID : {reader["id_transaksi"]}
==========================");
    }
    reader.Close();
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}