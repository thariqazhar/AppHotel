using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AppHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Program PR = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi ke Database\n");
                    Console.WriteLine("Masukkan User ID: ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password: ");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan Database tujuan: ");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik K untuk terhubung ke Database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'K':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data source =LAPTOP-9VURLJFC\\THARIQ_AZHAR; " +
                                    "initial catalog = {0}; " +
                                    "User ID = {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strKoneksi, db, user, pass));
                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Insert data");
                                        Console.WriteLine("2. Update data");
                                        Console.WriteLine("3. Delete");
                                        Console.WriteLine("4. Quit");
                                        Console.WriteLine("\nEnter your choice (1-4): ");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Input Data Pelanggan\n");
                                                    Console.WriteLine("Masukkan Id_Pelanggan:");
                                                    string id_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama Pelanggan :");
                                                    string nama_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No. Telp :");
                                                    string tlp_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No. Kamar :");
                                                    string no_kamar = Console.ReadLine();
                                                    Console.WriteLine("Masukkan jenis kelamin (L/P) :");
                                                    string jenis_kelamin = Console.ReadLine();
                                                    try
                                                    {
                                                        PR.insert(id_pelanggan, nama_pelanggan, tlp_pelanggan, jenis_kelamin, no_kamar, conn);
                                                        conn.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " + "akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Input Data Pelanggan\n");
                                                    Console.WriteLine("Masukkan Id_Pelanggan:");
                                                    string id_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama Pelanggan :");
                                                    string nama_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No. Telp :");
                                                    string tlp_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No. Kamar :");
                                                    string no_kamar = Console.ReadLine();
                                                    Console.WriteLine("Masukkan jenis kelamin (L/P) :");
                                                    string jenis_kelamin = Console.ReadLine();
                                                    try
                                                    {
                                                        PR.insert(id_pelanggan, nama_pelanggan, tlp_pelanggan, jenis_kelamin, no_kamar, conn);
                                                        conn.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " + "akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '3':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Masukkan data yang anda ingin hapus");
                                                    Console.WriteLine("Masukkan Id_Pelanggan:");
                                                    string id_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama Pelanggan :");
                                                    string nama_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No. Telp :");
                                                    string tlp_pelanggan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No. Kamar :");
                                                    string no_kamar = Console.ReadLine();
                                                    Console.WriteLine("Masukkan jenis kelamin (L/P) :");
                                                    string jenis_kelamin = Console.ReadLine();
                                                    try
                                                    {
                                                        PR.delete(id_pelanggan, nama_pelanggan, tlp_pelanggan, jenis_kelamin, no_kamar, conn);
                                                        conn.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " + "akses untuk menghapus data");
                                                    }
                                                }
                                                break;
                                            case '4':
                                                conn.Close();
                                                return;
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\nInvalid option");
                                                }
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nCheck for the value entered.");
                                    }
                                }
                            }
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tidak dapat mengakses database menggunakan user tersebut\n");
                    Console.ResetColor();
                }
            }
        }

        public void delete(string id_pelanggan, string nama_pelanggan, string tlp_pelanggan, string jenis_kelamin, string no_kamar,
            SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Delete * From pelanggan", con);
            string str = "";
            str = "delete*from pelanggan (id_pelanggan,nama_pelanggan,tlp_pelanggan,no_kamar,jenis_kelamin)"
                + "values(@id,@nma,@tlp,@kmr,@jk)";
            SqlCommand dcmd = new SqlCommand(str, con);
            dcmd.CommandType = CommandType.Text;

            dcmd.Parameters.Remove(new SqlParameter("id", id_pelanggan));
            dcmd.Parameters.Remove(new SqlParameter("nma", nama_pelanggan));
            dcmd.Parameters.Remove(new SqlParameter("tlp", tlp_pelanggan));
            dcmd.Parameters.Remove(new SqlParameter("kmr", no_kamar));
            dcmd.Parameters.Remove(new SqlParameter("jk", jenis_kelamin));
            dcmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Dihapus");
        }

        public void insert(string id_pelanggan, string nama_pelanggan, string tlp_pelanggan, string jenis_kelamin, string no_kamar,
            SqlConnection con)
        {
            string str = "";
            str = "insert into pelanggan (id_pelanggan,nama_pelanggan,tlp_pelanggan,no_kamar,jenis_kelamin)"
                + "values(@id,@nma,@tlp,@kmr,@jk)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("id", id_pelanggan));
            cmd.Parameters.Add(new SqlParameter("nma", nama_pelanggan));
            cmd.Parameters.Add(new SqlParameter("tlp", tlp_pelanggan));
            cmd.Parameters.Add(new SqlParameter("kmr", no_kamar));
            cmd.Parameters.Add(new SqlParameter("jk", jenis_kelamin));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }
    }
}

