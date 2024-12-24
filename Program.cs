// Kelas: IS-07-01
// Kelompok: 06 
// Anggota:
// 1. Naufal Syahruradli (102062400103)
// 2. Aldi Rachmatdianto (102062400069)
// 3. Veny Etika Dzakiyyah (102062400117)
// 4. Ida Bagus Giri Krisnabhawa (102062400117)
// 5. Bagus Ardin Prayoga (102062400064)

using MySql.Data.MySqlClient;

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
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(@"
1. Login
2. Register
3. Exit
        
Pilih Menu : ");
        string? auth = Console.ReadLine();
        if (auth == "1")
        {
            string? mail = Login(connectionString);
            // Console.WriteLine(mail);
            if (mail != "0")
            {
                while (menu != 8)
                {
                    Console.Clear();
                    HeadLogo();
                    InfoUser(connection, mail);
                    Menu();
                    Console.Write("Pilih Menu : ");
                    menu = Convert.ToInt32(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            RiwayatTransaksi(connection, mail);
                            break;
                        case 2:
                            MenuTambah(connection, mail);
                            break;
                        case 3:
                            HapusTransaksi(connection, mail);
                            break;
                        case 4:
                            CariTransaksi(connection, mail);
                            break;
                        case 5:
                            Profile(connection, connectionString, mail);
                            break;
                        case 6:
                            Catatan(connection, mail);
                            break;
                        case 7:
                            TargetMenabung(connection, mail);
                            break;
                        case 8:
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
        }
        else if (auth == "2")
        {
            Register(connectionString);
        }
        else if (auth == "3")
        {
            break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
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
    Console.ForegroundColor = ConsoleColor.Yellow;
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



static void Menu()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@$"
1. Riwayat Transaksi
2. Tambah Transaksi
3. Hapus Transaksi
4. Cari Transaksi
5. Profile
6. Catatan
7. Target Menabung
8. Keluar
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
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(@$"   {reader["email_user"]}");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("   Rp. ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(@$"{reader["saldo_user"]}");

    if (Convert.ToInt32(reader["target_user"]) > 0)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(@"
Target Menabung :");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(@$" Rp. {reader["target_user"]}
");
        if (Convert.ToInt32(reader["saldo_user"]) < Convert.ToInt32(reader["target_user"]))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("(Target Kamu Belum Tercapai kurang dari Rp. " + (Convert.ToInt32(reader["target_user"]) - Convert.ToInt32(reader["saldo_user"])) + ")");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(Target Kamu Sudah Tercapai)");
        }
    }

    reader.Close();
}



static void RiwayatTransaksi(MySqlConnection connection, string mail)
{
    Console.Clear();
    Console.WriteLine(@"
=== Riwayat Transaksi ===

1. Semua Transaksi
2. Pemasukkan
3. Pengeluaran
4. Kembali
");
    Console.Write("Pilih Menu : ");
    int menu = Convert.ToInt32(Console.ReadLine());
    switch (menu)
    {
        case 1:
            TampilRiwayat(connection, mail);
            break;
        case 2:
            TampilRiwayatPemasukkan(connection, mail);
            break;
        case 3:
            TampilRiwayatPengeluaran(connection, mail);
            break;
        case 4:
        default:
            break;
    }
}



static void TampilRiwayatPemasukkan(MySqlConnection connection, string mail)
{
    string query = $"SELECT * FROM transaksi WHERE email_user = '{mail}' AND jenis_transaksi = '+ (pemasukkan)'";
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



static void TampilRiwayatPengeluaran(MySqlConnection connection, string mail)
{
    string query = $"SELECT * FROM transaksi WHERE email_user = '{mail}' AND jenis_transaksi = '- (pengeluaran)'";
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



static void TampilRiwayat(MySqlConnection connection, string mail)
{
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



static void MenuTambah(MySqlConnection connection, string mail)
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
            TambahPemasukkan(connection, mail);
            break;
        case 2:
            TambahPengeluaran(connection, mail);
            break;
        case 3:
        default:
            break;
    }
}



static void TambahPemasukkan(MySqlConnection connection, string mail)
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
    string query = $"INSERT INTO transaksi (jenis_transaksi, saldo_transaksi, keterangan_transaksi, tanggal_transaksi, email_user) VALUES ('+ (pemasukkan)', '{jumlah}', '{keterangan}', '{now}', '{mail}')";
    string queryUpdateUser = $"UPDATE user SET saldo_user = saldo_user + {jumlah} WHERE email_user = '{mail}'";
    MySqlCommand updateUser = new MySqlCommand(queryUpdateUser, connection);
    updateUser.ExecuteNonQuery();
    MySqlCommand cmd = new MySqlCommand(query, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine(@"Data Berhasil Di Tambah
    
Press any key to continue ...");
    Console.ReadKey();
}



static void TambahPengeluaran(MySqlConnection connection, string mail)
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

    string getSaldo = $"SELECT saldo_user FROM user WHERE email_user = '{mail}'";
    MySqlCommand cmdSaldo = new MySqlCommand(getSaldo, connection);
    MySqlDataReader reader = cmdSaldo.ExecuteReader();
    reader.Read();
    int saldo = Convert.ToInt32(reader["saldo_user"]);
    reader.Close();
    if (Convert.ToInt32(jumlah) > saldo)
    {
        Console.WriteLine("Saldo Tidak Mencukupi");
        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey();
        return;
    }

    string query = $"INSERT INTO transaksi (jenis_transaksi, saldo_transaksi, keterangan_transaksi, tanggal_transaksi, email_user) VALUES ('- (pengeluaran)', '{jumlah}', '{keterangan}', '{now}', '{mail}')";
    string queryUpdateUser = $"UPDATE user SET saldo_user = saldo_user - {jumlah} WHERE email_user = '{mail}'";
    MySqlCommand updateUser = new MySqlCommand(queryUpdateUser, connection);
    updateUser.ExecuteNonQuery();
    MySqlCommand cmd = new MySqlCommand(query, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine(@"Data Berhasil Di Tambah
    
Press any key to continue ...");
    Console.ReadKey();
}



static void HapusTransaksi(MySqlConnection connection, string mail)
{
    Console.Clear();
    Console.WriteLine(@"Hapus Transaksi
");
    Console.Write("ID : ");
    int id = Convert.ToInt32(Console.ReadLine());
    string query = $"DELETE FROM transaksi WHERE id_transaksi = {id} AND email_user = '{mail}'";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine("Data Berhasil Di Hapus");
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}



static void CariTransaksi(MySqlConnection connection, string mail)
{
    Console.Clear();
    Console.WriteLine(@"Cari Transaksi
");
    Console.Write("cari : ");
    string? cari = Console.ReadLine();
    string query = $"SELECT * FROM transaksi WHERE keterangan_transaksi LIKE '%{cari}%' AND email_user = '{mail}'";
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



static void Profile(MySqlConnection connection, string connectionString, string mail)
{
    Console.Clear();
    ProfileLogo();
    InfoUser(connection, mail);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(@"
1. Edit Profile
2. Hapus Akun
3. Kembali

Pilih Menu : ");
    int menu = Convert.ToInt32(Console.ReadLine());
    switch (menu)
    {
        case 1:
            EditProfile(connection, connectionString, mail);
            break;
        case 2:
            HapusAkun(connection, connectionString, mail);
            break;
        case 3:
        default:
            break;
    }

}



static void EditProfile(MySqlConnection connection, string connectionString, string mail)
{
    Console.WriteLine(@"===== Edit Profile =====
");
    Console.Write("New Name : ");
    string? name = Console.ReadLine();
    Console.Write("New Email : ");
    string? newEmail = Console.ReadLine();

    string email = Login(connectionString);
    if (email == mail)
    {
        string query = $"UPDATE user SET name_user = '{name}', email_user = '{newEmail}' WHERE email_user = '{mail}'";
        string queryTransaksi = $"UPDATE transaksi SET email_user = '{newEmail}' WHERE email_user = '{mail}'";
        MySqlCommand cmdTransaksi = new MySqlCommand(queryTransaksi, connection);
        cmdTransaksi.ExecuteNonQuery();
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
        Console.WriteLine(@"
Data Berhasil Di Edit Silahkan Muat Ulang Aplikasi
");
        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey();
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("Password Salah");
        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey();
    }
}



static void HapusAkun(MySqlConnection connection, string connectionString, string mail)
{
    Console.Write(@"Hapus Akun

Anda Yakin Ingin Menghapus Akun Ini ? (y/n)");
    string? jawab = Console.ReadLine();
    if (jawab == "y")
    {
        string oldMail = Login(connectionString);
        if (oldMail == mail)
        {
            string query = $"DELETE FROM user WHERE email_user = '{mail}'";
            string queryTransaksi = $"DELETE FROM transaksi WHERE email_user = '{mail}'";
            MySqlCommand cmdTransaksi = new MySqlCommand(queryTransaksi, connection);
            cmdTransaksi.ExecuteNonQuery();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Akun Berhasil Di Hapus :)");
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Password Salah");
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }
    }
    else
    {
        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey();
    }
}



static void Catatan(MySqlConnection connection, string mail)
{
    Console.Clear();
    Console.Write(@"
==== Catatan ====

1. Lihat Catatan
2. Tambah Catatan
3. Hapus Catatan
4. Kembali

Pilih Menu : ");
    int menuCatatan = Convert.ToInt32(Console.ReadLine());
    switch (menuCatatan)
    {
        case 1:
            LihatCatatan(connection, mail);
            break;
        case 2:
            TambahCatatan(connection, mail);
            break;
        case 3:
            HapusCatatan(connection);
            break;
        case 4:
        default:
            break;
    }
}



static void LihatCatatan(MySqlConnection connection, string mail)
{
    Console.Clear();
    Console.WriteLine(@"
=== Catatan ===
");
    string query = $"SELECT * FROM catatan WHERE email_user = '{mail}'";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    MySqlDataReader reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@$"
{reader["judul_catatan"]}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@$"
{reader["deskripsi_catatan"]}

{reader["tanggal_catatan"]}
ID : {reader["id_catatan"]}
==========================
");
    }
    reader.Close();
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}



static void TambahCatatan(MySqlConnection connection, string mail)
{
    Console.Clear();
    Console.WriteLine(@"
=== Tambah Catatan ===
");
    string date = DateTime.Now.ToString("yyyy-MM-dd");
    Console.Write("Judul : ");
    string? judul = Console.ReadLine();
    Console.Write("Deskripsi : ");
    string? deskripsi = Console.ReadLine();
    string query = $"INSERT INTO catatan (judul_catatan, deskripsi_catatan, tanggal_catatan, email_user) VALUES ('{judul}', '{deskripsi}', '{date}', '{mail}')";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine("Data Berhasil Di Tambahkan");
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}



static void HapusCatatan(MySqlConnection connection)
{
    Console.Clear();
    Console.WriteLine(@"
=== Hapus Catatan ===
");
    // LihatCatatan(connection, mail);
    Console.Write("ID Catatan : ");
    string? id = Console.ReadLine();
    string query = $"DELETE FROM catatan WHERE id_catatan = '{id}'";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine("Data Berhasil Di Hapus");
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}



static void TargetMenabung(MySqlConnection connection, string mail)
{
    Console.Clear();
    string getTarget = $"SELECT target_user FROM user WHERE email_user = '{mail}'";
    MySqlCommand cmdTarget = new MySqlCommand(getTarget, connection);
    MySqlDataReader readerTarget = cmdTarget.ExecuteReader();
    readerTarget.Read();
    Console.WriteLine(@$"
Target Menabung Kamu : Rp. {readerTarget["target_user"]}

=== Target Menabung ===
");
    Console.Write("Ubah Target : ");
    string? target = Console.ReadLine();
    readerTarget.Close();
    string query = $"UPDATE user SET target_user = '{target}' WHERE email_user = '{mail}'";
    MySqlCommand cmd = new MySqlCommand(query, connection);
    cmd.ExecuteNonQuery();
    Console.WriteLine("Target Berhasil Di Ubah");
    Console.WriteLine("Press any key to continue ...");
    Console.ReadKey();
}



static string Login(string connectionString)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(@"

=== Login User ===
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
    reader.Close();
    return "0";
    // else
    // {
    //     Console.WriteLine("Login Gagal");
    //     Console.WriteLine("Press any key to continue ...");
    //     Console.ReadKey();
    // }
}



static void Register(string connectionString)
{
    Console.WriteLine(@"
    
=== Register User ===
    ");
    MySqlConnection connection = new MySqlConnection(connectionString);
    connection.Open();
    Console.Write("Name : ");
    string? name = Console.ReadLine();
    Console.Write("Email : ");
    string? email = Console.ReadLine();
    Console.Write("Password : ");
    string? password = Console.ReadLine();
    Console.Write("Ulang Password : ");
    string? ulangPassword = Console.ReadLine();
    if (password != ulangPassword)
    {
        Console.WriteLine("Password Tidak Sama");
        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey();
    }
    else
    {
        string query = $"INSERT INTO user (name_user, email_user, password_user, saldo_user, target_user) VALUES ('{name}', '{email}', '{password}', '0', '0')";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Data Berhasil Di Tambah");
        Console.WriteLine("Press any key to continue ...");
        Console.ReadKey();
    }
}