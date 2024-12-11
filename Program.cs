using System;
using System.Data;
using System.Data.OleDb;

string filePath = @"database/database.xlsx";
string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";

int menu = 0;

try
{
    while (menu != 5)
    {
        ClearScreen();
        Console.WriteLine(@"Wellcome To Mangan Bata C 
(Manajemen Keuangan Berbasis Database dan C#)");
        ReadUser(connectionString);
        Menu(menu, connectionString);
    }
    // ReadData(connectionString);
}
catch (Exception e)
{
    Console.WriteLine($"terjadi kesalahan {e}");
}

// bersihkan layar

static void ClearScreen()
{
    Console.Clear();
}

// tampilkan menu

static void Menu(int menu, string connectionString)
{
    Console.Write(@"
1. Riwayat Transaksi
2. Tambah Transaksi
3. Hapus Transaksi
4. Edit User
5. Keluar

Pilih Menu : ");
    menu = Convert.ToInt32(Console.ReadLine());

    switch (menu)
    {
        case 1:
            ReadTransaksi(connectionString);
            Console.WriteLine("Press any key");
            Console.ReadKey();
            return;
        default:
            Console.WriteLine("Pilihan tidak valid");
            break;
    }

}

// baca data user

static void ReadUser(string connectionString)
{
    string query = "SELECT * FROM [user$]";
#pragma warning disable
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        connection.Open();
        using (OleDbCommand command = new OleDbCommand(query, connection))
        using (OleDbDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(@$"
    {reader["NAME_KEUANGAN"]}
    Rp. {reader["SALDO_KEUANGAN"]}");
            }
        }
    }
#pragma warning restore
}

// baca riwayat transakssi

static void ReadTransaksi(string connectionString)
{
    string query2 = "SELECT * FROM [transaksi$]";
#pragma warning disable CA1416 // Validate platform compatibility

    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        connection.Open();
        using (OleDbCommand command2 = new OleDbCommand(query2, connection))
        using (OleDbDataReader reader2 = command2.ExecuteReader())
        {
            Console.WriteLine(@"
==== RIWAYAT TRANSAKSI ====
                ");
            while (reader2.Read())
            {
                ClearScreen();
                Console.WriteLine(@$"
Jenis : {reader2["JENIS_TRANSAKSI"]}
Total: {reader2["SALDO_TRANSAKSI"]}

{reader2["KETERANGAN_TRANSAKSI"]}

{reader2["TANGGAL_TRANSAKSI"]}");
            }
            Console.WriteLine(@"
===========================
                ");
        }
    }
#pragma warning restore CA1416 // Validate platform compatibility
}

// static void ExecuteNonQuery(string query, string connectionString)
// {
// #pragma warning disable
//     using (OleDbConnection connection = new OleDbConnection(connectionString))
//     {
//         connection.Open();
//         using (OleDbCommand command = new OleDbCommand(query, connection))
//         {
//             command.ExecuteNonQuery();
//         }
//     }
// #pragma warning restore
// }