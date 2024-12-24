-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 24 Des 2024 pada 07.10
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `csharp_keuangan`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `catatan`
--

CREATE TABLE `catatan` (
  `id_catatan` int(11) NOT NULL,
  `judul_catatan` varchar(500) NOT NULL,
  `deskripsi_catatan` text NOT NULL,
  `tanggal_catatan` varchar(500) NOT NULL,
  `email_user` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `catatan`
--

INSERT INTO `catatan` (`id_catatan`, `judul_catatan`, `deskripsi_catatan`, `tanggal_catatan`, `email_user`) VALUES
(1, 'wkwk', 'wkwk', '2024-12-23', 'lixxy@gmail.com');

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi`
--

CREATE TABLE `transaksi` (
  `id_transaksi` int(11) NOT NULL,
  `jenis_transaksi` varchar(500) NOT NULL,
  `saldo_transaksi` varchar(500) NOT NULL,
  `keterangan_transaksi` text NOT NULL,
  `tanggal_transaksi` varchar(500) NOT NULL,
  `email_user` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `transaksi`
--

INSERT INTO `transaksi` (`id_transaksi`, `jenis_transaksi`, `saldo_transaksi`, `keterangan_transaksi`, `tanggal_transaksi`, `email_user`) VALUES
(14, '+ (pemasukkan)', '500000', 'uang saku bulanan', '18/12/2024 04:04:35', 'lixxy@gmail.com'),
(15, '- (pengeluaran)', '250500', 'pengeluaran untuk makan', '18/12/2024 04:05:05', 'lixxy@gmail.com'),
(17, '+ (pemasukkan)', '1000000', 'Transfer', '19/12/2024 11:53:20', 'lixxy@gmail.com'),
(21, '- (pengeluaran)', '17000', 'beli geprek', '20/12/2024 11:20:02', 'lixxy@gmail.com'),
(22, '+ (pemasukkan)', '800000', 'rezeki freelance', '24/12/2024 12:21:30', 'lixxy@gmail.com'),
(23, '+ (pemasukkan)', '4000000', 'rezeky', '24/12/2024 13:08:49', 'lixxy@gmail.com');

-- --------------------------------------------------------

--
-- Struktur dari tabel `user`
--

CREATE TABLE `user` (
  `id_user` int(11) NOT NULL,
  `name_user` varchar(500) NOT NULL,
  `email_user` varchar(500) NOT NULL,
  `password_user` varchar(500) NOT NULL,
  `saldo_user` varchar(500) NOT NULL,
  `target_user` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `user`
--

INSERT INTO `user` (`id_user`, `name_user`, `email_user`, `password_user`, `saldo_user`, `target_user`) VALUES
(1, 'Lixxy Code', 'lixxy@gmail.com', 'adli123', '6012500', '0'),
(3, 'Aldi R', 'alditaher@gmail.com', 'aldiganteng123gt', '0', '0');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `catatan`
--
ALTER TABLE `catatan`
  ADD PRIMARY KEY (`id_catatan`);

--
-- Indeks untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`id_transaksi`);

--
-- Indeks untuk tabel `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id_user`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `catatan`
--
ALTER TABLE `catatan`
  MODIFY `id_catatan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  MODIFY `id_transaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT untuk tabel `user`
--
ALTER TABLE `user`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
