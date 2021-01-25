-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jan 25, 2021 at 06:16 AM
-- Server version: 5.7.24
-- PHP Version: 7.2.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `apotek_vbnet`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `id_admin` int(3) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(255) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `tingkat` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`id_admin`, `username`, `password`, `nama`, `tingkat`) VALUES
(1, 'admin', '21232f297a57a5a743894a0e4a801fc3', 'Risky Setiawa', 'admin'),
(2, 'user', 'ee11cbb19052e40b07aac0ca060c23ee', 'Risky User\r\n', 'user'),
(3, 'admin', '21232f297a57a5a743894a0e4a801fc3', 'Risky Setiawa', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `master_detail_pemesanan`
--

CREATE TABLE `master_detail_pemesanan` (
  `id` int(11) NOT NULL,
  `kode_pesan` varchar(255) NOT NULL,
  `kode_obat` varchar(255) NOT NULL,
  `jumlah` varchar(255) NOT NULL,
  `total` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `master_detail_pemesanan`
--

INSERT INTO `master_detail_pemesanan` (`id`, `kode_pesan`, `kode_obat`, `jumlah`, `total`) VALUES
(1, '4317005', 'a0001', '434', '2170000'),
(2, '8883406', 'a0001', '34', '170000');

-- --------------------------------------------------------

--
-- Table structure for table `obat`
--

CREATE TABLE `obat` (
  `kode_obat` char(5) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `bentuk` varchar(100) NOT NULL,
  `konsumen` varchar(100) NOT NULL,
  `manfaat` varchar(200) NOT NULL,
  `harga` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `obat`
--

INSERT INTO `obat` (`kode_obat`, `nama`, `bentuk`, `konsumen`, `manfaat`, `harga`) VALUES
('A0001', 'Acarbose', 'Tablet, Kapsul', 'Dewasa', 'Mengontrol kadar gula dalam darah', 5000),
('A0002', 'Albumin', 'Obat infus', 'Dewasa', 'Menangani defisiensi albumin', 10000),
('A0003', 'Amfetamin', 'Tablet, kapsul, dan puyer', 'Dewasa dan anak-anak', 'Menangani ADHD, mengobati narkolepsi, menurunkan berat badan', 12500),
('A0004', 'Atenolol', 'Tablet', 'Dewasa', 'Mengobati angina, gangguan detak jantung, dan hipertensi. Menjaga kesehatan jantung Menjaga kesehatan jantu setelah serangan jantung', 25000),
('B0001', 'Bacitracin', 'Suntik', 'Dewasa dan anak-anak', 'Mencegah infeksi bakteri pada luka ringan di kulit', 15000),
('B0002', 'Baclofen', 'Tablet', 'Dewasa dan anak-anak', 'Meredakan kejang otot', 32000),
('C0001', 'Captopril', 'Tablet', 'Dewasa', 'Menangani hipertensi, mencegah komplikasi setelah serangan jantung', 52000),
('D0001', 'Diazepam', 'Tablet, Obat cair, Suntikan', 'Dewasa dan anak-anak', 'Mengatasi insomnia, serangan kecemasan, melemaskan otot kejang', 12000);

-- --------------------------------------------------------

--
-- Table structure for table `pemesanan`
--

CREATE TABLE `pemesanan` (
  `kode_pesan` varchar(7) NOT NULL,
  `tanggal` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL DEFAULT 'Belum'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pemesanan`
--

INSERT INTO `pemesanan` (`kode_pesan`, `tanggal`, `status`) VALUES
('1508027', '1/24/2021', 'Lunas'),
('2052083', '1/24/2021', 'Lunas'),
('2506962', '1/24/2021', ''),
('2938504', '1/24/2021', 'Lunas'),
('2GH3B48', '2017-06-09', 'L'),
('3778301', '1/24/2021', ''),
('4317005', '1/24/2021', 'Lunas'),
('4722112', '1/24/2021', 'Lunas'),
('4842965', '1/24/2021', 'Lunas'),
('5013969', '1/24/2021', 'Lunas'),
('5227599', '1/24/2021', ''),
('5340796', '1/24/2021', 'Belum'),
('5840283', '1/24/2021', 'Lunas'),
('6162451', '1/24/2021', 'Belum'),
('7419592', '1/24/2021', 'Belum'),
('7606140', '1/24/2021', 'Lunas'),
('7879337', '1/24/2021', 'Lunas'),
('8883406', '1/25/2021', 'Lunas'),
('8X60SSU', '2017-06-09', 'L'),
('9083725', '1/24/2021', 'Belum'),
('9294270', '1/24/2021', 'Lunas'),
('9949241', '1/24/2021', 'Lunas'),
('HACW9GN', '2017-06-10', 'B'),
('Q6X46CZ', '2017-06-10', 'L'),
('S244QXZ', '2017-06-10', 'B'),
('SWWY31J', '2017-06-10', 'B');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id_admin`);

--
-- Indexes for table `master_detail_pemesanan`
--
ALTER TABLE `master_detail_pemesanan`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `obat`
--
ALTER TABLE `obat`
  ADD PRIMARY KEY (`kode_obat`);

--
-- Indexes for table `pemesanan`
--
ALTER TABLE `pemesanan`
  ADD PRIMARY KEY (`kode_pesan`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `id_admin` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `master_detail_pemesanan`
--
ALTER TABLE `master_detail_pemesanan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
