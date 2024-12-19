// Naufal Syahruradli (102062400103)
// Aldi Rachmatdianto (102062400069)
// Veny Etika Dzakiyyah (102062400117)
// Ida Bagus Giri Krisnabhawa (102062400117)
// Bagus Ardin Prayoga (102062400064)

using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Misc;
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

// red = ConsoleColor.Red;
// green = ConsoleColor.Green;
// yellow = ConsoleColor.Yellow;
// blue = ConsoleColor.Blue;
// magenta = ConsoleColor.Magenta;
// cyan = ConsoleColor.Cyan;
// white = ConsoleColor.White;
// black = ConsoleColor.Black;
// darkBlue = ConsoleColor.DarkBlue;
// darkGreen = ConsoleColor.DarkGreen;
// darkCyan = ConsoleColor.DarkCyan;
// darkRed = ConsoleColor.DarkRed;
// darkMagenta = ConsoleColor.DarkMagenta;
// darkYellow = ConsoleColor.DarkYellow;
// gray = ConsoleColor.Gray;
// darkGray = ConsoleColor.DarkGray;

try
{
    connection.Open();

    while (menu != 6)
    {
        Console.Clear();
        HeadLogo();
        string? mail = Login(connectionString);
        // Console.WriteLine(mail);
        if (mail != "0")
        {
            while (menu != 6)
            {
                Console.Clear();
                HeadLogo();
                InfoUser(connection, mail);
                Menu(menu);
                Console.Write("Pilih Menu : ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        RiwayatTransaksi(connection, mail);
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
        else if (mail == "0")
        {
            Console.WriteLine("Login Gagal");
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            continue;
        }
        // InfoUser(connection);
        // Menu(menu);
        // Console.Write("Pilih Menu : ");
        // menu = Convert.ToInt32(Console.ReadLine());
        // switch (menu)
        // {
        //     case 1:
        //         RiwayatTransaksi(connection);
        //         break;
        //     case 2:
        //         MenuTambah(connection);
        //         break;
        //     case 3:
        //         HapusTransaksi(connection);
        //         break;
        //     case 4:
        //         CariTransaksi(connection);
        //         break;
        //     case 5:
        //         break;
        //     case 6:
        //     default:
        //         break;
        // }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    connection.Close();
}

static void HeadLogo()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@$"
Hi!, wellcome to Mangan Bata!
(Manajemen Keuangan Berbasis Database)

⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢯⠙⠩⠀⡇⠊⠽⢖⠆⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠱⣠⠀⢁⣄⠔⠁⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣷⣶⣾⣾⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⡔⠙⠈⢱⡟⣧⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⡠⠊⠀⠀⣀⡀⠀⠘⠕⢄⠀⠀⠀⠀⠀
⠀⠀⠀⢀⠞⠀⠀⢀⣠⣿⣧⣀⠀⠀⢄⠱⡀⠀⠀⠀
⠀⠀⡰⠃⠀⠀⢠⣿⠿⣿⡟⢿⣷⡄⠀⠑⢜⢆⠀⠀
⠀⢰⠁⠀⠀⠀⠸⣿⣦⣿⡇⠀⠛⠋⠀⠨⡐⢍⢆⠀
⠀⡇⠀⠀⠀⠀⠀⠙⠻⣿⣿⣿⣦⡀⠀⢀⠨⡒⠙⡄
⢠⠁⡀⠀⠀⠀⣤⡀⠀⣿⡇⢈⣿⡷⠀⠠⢕⠢⠁⡇
⠸⠀⡕⠀⠀⠀⢻⣿⣶⣿⣷⣾⡿⠁⠀⠨⣐⠨⢀⠃
⠀⠣⣩⠘⠀⠀⠀⠈⠙⣿⡏⠁⠀⢀⠠⢁⡂⢉⠎⠀
⠀⠀⠈⠓⠬⢀⣀⠀⠀⠈⠀⠀⠀⢐⣬⠴⠒⠁⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀
");
}

static void ProfileLogo()
{
    Console.WriteLine(@"
======= Your Profile =======

    .------\ /------.
    |       -       |
    |               |
    |               |
    |               |
 _______________________
 ===========.===========
   / ~~~~~     ~~~~~ \
  /|     |     |     |\
  W   ---  / \  ---   W
  \.      |o o|      ./
   |                 |
   \    #########    /
    \  ## ----- ##  /
     \##         ##/
      \_____v_____/    
");
}

static void Menu(int menu)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@$"
1. Riwayat Transaksi
2. Tambah Transaksi
3. Hapus Transaksi
4. Cari Transaksi
5. Profile
6. Keluar
");

}

static void InfoUser(MySqlConnection connection, string mail)
{
    string query = $"SELECT * FROM user WHERE email_user = '{mail}'";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    MySqlDataReader reader = cmd.ExecuteReader();
    Console.ForegroundColor = ConsoleColor.White;
    reader.Read();

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(@$"   {reader["name_user"]}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("   Rp. ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(@$"{reader["saldo_user"]}");

    reader.Close();
}

static void RiwayatTransaksi(MySqlConnection connection, string mail)
{
    Console.Clear();
    string query = $"SELECT * FROM transaksi WHERE email_user = '{mail}'";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    MySqlDataReader reader = cmd.ExecuteReader();
    Console.WriteLine(@"
=== Riwayat Transaksi  ===");
    while (reader.Read())
    {
        if (reader["jenis_transaksi"].ToString() == "+ (pemasukkan)")
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        Console.Write(@$"
{reader["jenis_transaksi"]}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@$" Rp. {reader["saldo_transaksi"]}
{reader["tanggal_transaksi"]}");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@$"
    {reader["keterangan_transaksi"]}");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@$"
ID: {reader["id_transaksi"]}
==========================");
    }
    Console.ForegroundColor = ConsoleColor.White;
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
3. Kembali

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
        case 3:
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
    string? jumlah = Console.ReadLine();
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
=== Tambah Pengeluaran ===
");
    Console.Write("Jumlah : ");
    string? jumlah = Console.ReadLine();
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

static string Login(string connectionString)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@"=== Login User ===
    ");
    MySqlConnection connection = new MySqlConnection(connectionString);
    connection.Open();
    Console.Write("Email : ");
    string? email = Console.ReadLine();
    Console.Write("Password : ");
    string? password = Console.ReadLine();
    string query = $"SELECT * FROM user WHERE email_user = '{email}' AND password_user = '{password}'";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    MySqlDataReader reader = cmd.ExecuteReader();
    if (reader.Read())
    {
        string mail = "" + reader["email_user"];
        return mail;
    }
    return "0";
    // else
    // {
    //     Console.WriteLine("Login Gagal");
    //     Console.WriteLine("Press any key to continue ...");
    //     Console.ReadKey();
    // }
}