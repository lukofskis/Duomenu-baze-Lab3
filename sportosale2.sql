-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 22, 2023 at 12:29 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sportosale2`
--

-- --------------------------------------------------------

--
-- Table structure for table `atsiskaitymo_budai`
--

CREATE TABLE `atsiskaitymo_budai` (
  `id_ATSISKAITYMO_BUDAS` int(11) NOT NULL,
  `name` char(17) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `atsiskaitymo_budai`
--

INSERT INTO `atsiskaitymo_budai` (`id_ATSISKAITYMO_BUDAS`, `name`) VALUES
(1, 'grynieji'),
(2, 'kreditine_kortele'),
(3, 'dovanu_kuponas');

-- --------------------------------------------------------

--
-- Table structure for table `darbuotojai`
--

CREATE TABLE `darbuotojai` (
  `vardas` varchar(255) NOT NULL,
  `pavarde` varchar(255) NOT NULL,
  `asmens_kodas` varchar(255) NOT NULL,
  `etatas` decimal(10,0) NOT NULL,
  `fk_SPORTOSALEid_SPORTOSALE` int(11) NOT NULL,
  `fk_PAREIGAid_PAREIGA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `darbuotojai`
--

INSERT INTO `darbuotojai` (`vardas`, `pavarde`, `asmens_kodas`, `etatas`, `fk_SPORTOSALEid_SPORTOSALE`, `fk_PAREIGAid_PAREIGA`) VALUES
('Klaudija', 'Narke', '170936876311', 1, 14, 1),
('Jurijus', 'Uzbonas', '170946721566', 1, 7, 2),
('Lijana', 'Lijiene', '245600253820', 1, 2, 1),
('Aurimas', 'Alginskas', '264423121399', 1, 15, 1),
('Mindaugas', 'Daugela', '264432966654', 1, 8, 2),
('Marius', 'Marietis', '300411102613', 1, 5, 1),
('Paulius', 'Bunkus', '324338852382', 1, 12, 1),
('Lijada', 'Pilanivaite', '324348697637', 1, 5, 2),
('Saulius', 'Saulevicius', '329203007891', 1, 7, 1),
('Pijus', 'Pijutis', '350291155135', 1, 4, 1),
('Darija', 'Sviesaite', '386333202676', 1, 9, 1),
('Aukse ', 'Auksaite', '436923676568', 1, 3, 1),
('Marius', 'Saulevicius', '471492172904', 1, 8, 1),
('Gabrielius', 'Laimutis', '505068237650', 1, 10, 1),
('Aurelija', 'Simaite', '505078082905', 1, 3, 2),
('Edgaras', 'Merikietis', '559251856268', 1, 13, 1),
('Milana', 'Tiktokaite', '559261701523', 1, 6, 2),
('Jonas', 'BIliunas', '57987987987', 2, 23, 2),
('Sigita', 'Sigitiene', '589897136521', 2, 19, 1),
('Lauris', 'Reinikis', '589906981776', 1, 12, 3),
('Povilas', 'Dapsas', '604148913253', 1, 13, 3),
('Audrius', 'Audraitis', '634170925870', 1, 1, 1),
('Normantas', 'Dobilevicius', '734000283337', 1, 2, 2),
('Dimitrijus', 'Mironcikas', '734010128592', 2, 14, 3),
('Karolis', 'Karolingas', '749983226786', 2, 11, 1),
('Karina', 'Uznecovaite', '749993072041', 2, 4, 2),
('Saulius', 'Simonaitis', '795988695170', 2, 18, 1),
('Paulius', 'Bunkus', '853953398092', 1, 17, 1),
('asd', 'asd', '853963243347', 1, 10, 2),
('Sigita', 'Domikaite', '885412502861', 1, 16, 1),
('Evaldas', 'Guogis', '885422348116', 1, 9, 2),
('Algis', 'Algevicius', '967471279808', 1, 6, 1);

-- --------------------------------------------------------

--
-- Table structure for table `gamintojai`
--

CREATE TABLE `gamintojai` (
  `pavadinimas` varchar(255) NOT NULL,
  `id_GAMINTOJAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `gamintojai`
--

INSERT INTO `gamintojai` (`pavadinimas`, `id_GAMINTOJAS`) VALUES
('Abac', 1),
('ADTnS', 2),
('AEG', 3),
('Aerius', 4),
('AGP', 5),
('Bosch', 6),
('Distar', 7),
('Famag', 8),
('FARO', 9),
('Gesipa', 10),
('HiKOKI', 11),
('Kapro', 12),
('LAVOR', 13),
('Neato', 14),
('Pfaff', 15),
('Rems', 16),
('Rapid', 17),
('SDMO', 18),
('STIHL', 19),
('Uvex', 20),
('Wera', 21),
('3M', 22);

-- --------------------------------------------------------

--
-- Table structure for table `itraukimai_i`
--

CREATE TABLE `itraukimai_i` (
  `fk_PARDAVIMO_ISRASASpardavimo_kodas` varchar(255) NOT NULL,
  `fk_PREKEid` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itraukimai_i`
--

INSERT INTO `itraukimai_i` (`fk_PARDAVIMO_ISRASASpardavimo_kodas`, `fk_PREKEid`) VALUES
('321321', '123'),
('321324', '125'),
('321347', '167'),
('321360', '169'),
('321373', '147'),
('321386', '149'),
('321399', '169'),
('321412', '167'),
('321425', '169'),
('321438', '171');

-- --------------------------------------------------------

--
-- Table structure for table `lytys`
--

CREATE TABLE `lytys` (
  `id_LYTIS` int(11) NOT NULL,
  `name` char(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `lytys`
--

INSERT INTO `lytys` (`id_LYTIS`, `name`) VALUES
(1, 'moteris'),
(2, 'vyras'),
(3, 'kita');

-- --------------------------------------------------------

--
-- Table structure for table `miestai`
--

CREATE TABLE `miestai` (
  `pavadinimas` varchar(255) NOT NULL,
  `id_MIESTAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `miestai`
--

INSERT INTO `miestai` (`pavadinimas`, `id_MIESTAS`) VALUES
('Mazeikiai', 1),
('Siauliai', 2),
('Panevezys', 3),
('Vilnius', 4),
('Trakai', 5),
('Akmene', 6),
('Klaipeda', 7),
('Kaunas', 8),
('Raseiniai', 9),
('Kazlu Ruda', 10),
('Utena', 12),
('Ignalina', 13),
('Palanga', 14),
('Taurage', 15),
('Kybartai', 16),
('Jonava', 17);

-- --------------------------------------------------------

--
-- Table structure for table `mokejimai`
--

CREATE TABLE `mokejimai` (
  `data` date NOT NULL,
  `suma` decimal(10,0) NOT NULL,
  `id_MOKEJIMAS` int(11) NOT NULL,
  `fk_SASKAITAid_SASKAITA` int(11) NOT NULL,
  `fk_PIRKEJASasmens_kodas` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `mokejimai`
--

INSERT INTO `mokejimai` (`data`, `suma`, `id_MOKEJIMAS`, `fk_SASKAITAid_SASKAITA`, `fk_PIRKEJASasmens_kodas`) VALUES
('2023-02-12', 100, 1, 1, '795988700793'),
('2023-02-12', 100, 2, 2, '589897142144'),
('2023-02-12', 100, 3, 3, '604139073621'),
('2023-02-12', 100, 4, 4, '734000288960');

-- --------------------------------------------------------

--
-- Table structure for table `papildomi_mokesciai`
--

CREATE TABLE `papildomi_mokesciai` (
  `pavadinimas` varchar(255) NOT NULL,
  `kaina` decimal(10,0) NOT NULL,
  `id_PAPILDOMAS_MOKESTIS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `papildomi_mokesciai`
--

INSERT INTO `papildomi_mokesciai` (`pavadinimas`, `kaina`, `id_PAPILDOMAS_MOKESTIS`) VALUES
('LT235', 2, 1),
('LT265', 2, 2),
('LT356', 2, 3),
('LT667', 4, 4),
('LT879', 3, 5),
('LT899', 3, 6),
('LT999', 9, 7);

-- --------------------------------------------------------

--
-- Table structure for table `pardavimo_israsai`
--

CREATE TABLE `pardavimo_israsai` (
  `pardavimo_kodas` varchar(255) NOT NULL,
  `data` date NOT NULL,
  `suma` decimal(10,0) NOT NULL,
  `pritaikyta_nuolaida` decimal(10,0) DEFAULT NULL,
  `grazinimo_data` date DEFAULT NULL,
  `apmokejimo_budas` int(11) NOT NULL,
  `fk_PIRKEJASasmens_kodas` varchar(255) NOT NULL,
  `fk_DARBUOTOJASasmens_kodas` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pardavimo_israsai`
--

INSERT INTO `pardavimo_israsai` (`pardavimo_kodas`, `data`, `suma`, `pritaikyta_nuolaida`, `grazinimo_data`, `apmokejimo_budas`, `fk_PIRKEJASasmens_kodas`, `fk_DARBUOTOJASasmens_kodas`) VALUES
('321321', '2023-02-12', 55, 0, NULL, 1, '795988700793', '300411102613'),
('321334', '2023-02-12', 65, 0, NULL, 2, '589897142144', '967471279808'),
('321347', '2023-02-12', 55, 0, NULL, 3, '604139073621', '329203007891'),
('321360', '2023-02-12', 55, 0, NULL, 1, '734000288960', '471492172904'),
('321373', '2023-02-12', 55, 0, NULL, 2, '505078088528', '386333202676'),
('321386', '2023-02-12', 55, 0, NULL, 3, '749993077664', '300411102613'),
('321399', '2023-02-12', 5, 0, NULL, 1, '324348703260', '967471279808'),
('321412', '2023-02-12', 5, 0, NULL, 2, '559261707146', '329203007891'),
('321425', '2023-02-12', 55, 0, NULL, 3, '170946727189', '471492172904'),
('321438', '2023-02-12', 5, 0, NULL, 1, '264432972277', '386333202676');

-- --------------------------------------------------------

--
-- Table structure for table `pareigos`
--

CREATE TABLE `pareigos` (
  `pavadinimas` varchar(255) NOT NULL,
  `valandinis` decimal(10,0) NOT NULL,
  `id_PAREIGA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pareigos`
--

INSERT INTO `pareigos` (`pavadinimas`, `valandinis`, `id_PAREIGA`) VALUES
('administratorius', 8, 1),
('pardavejas', 6, 2),
('valytojas', 4, 3);

-- --------------------------------------------------------

--
-- Table structure for table `pirkejai`
--

CREATE TABLE `pirkejai` (
  `vardas` varchar(255) NOT NULL,
  `pavarde` varchar(255) NOT NULL,
  `asmens_kodas` varchar(255) NOT NULL,
  `telefono_numeris` varchar(255) NOT NULL,
  `elektroninis_pastas` varchar(255) NOT NULL,
  `adresas` varchar(255) NOT NULL,
  `amzius` int(11) NOT NULL,
  `lytis` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pirkejai`
--

INSERT INTO `pirkejai` (`vardas`, `pavarde`, `asmens_kodas`, `telefono_numeris`, `elektroninis_pastas`, `adresas`, `amzius`, `lytis`) VALUES
('Aurimas', 'Vaicius', '170946727189', '860950269', 'qwer@gmail.com', 'Ventos g. 18', 34, 2),
('Robertas', 'Kiudys', '264432972277', '860950270', 'tyry@gmail.com', 'Zemaitijos g. 98', 36, 2),
('Mantryda', 'Dovydaite', '324348703260', '860950267', 'sdas22@gmail.com', 'J. Tumo-Vaižganto g. 15', 30, 1),
('Sima', 'Simute', '505078088528', '860950265', 'trytr@gmail.com', 'Montuotoju g. 55', 26, 1),
('Airidas', 'Airiduavicius', '559261707146', '860950268', 'asdaf@gmail.com', 'Gamyklos g. 66', 32, 2),
('Arija', 'Kavaliauskaite', '589897142144', '860950262', 'asdasd@gmail.com', 'Skuodo g. 88', 20, 1),
('Kipras', 'Zube', '589906987399', '860950274', '21321@gmail.com', 'Sodu skg. 47', 44, 2),
('Migle', 'Norke', '604139073621', '860950263', 'grtr@gmail.com', 'Montuotoju g. 132', 22, 1),
('Tautydas', 'Gravicius', '604148918876', '860950275', 'asjdasdda.fsa@gmail.com', 'Pavasario g. 91', 46, 2),
('Aiste', 'Bozuvaite', '734000288960', '860950264', 'eweq@gmail.com', 'Naujoji g. 277', 24, 1),
('Erikas', 'Berikas', '734010134215', '860950276', 'pooo@gmail.com', 'Zemaitijos g. 77', 48, 2),
('Dovydas', 'Kiusys', '734010229636', '860950277', 'ueueu@gmail.com', 'Kvistės g. 84', 50, 2),
('Mantelis', 'Samuolis', '734010325057', '860950278', 'jeriweor@gmail.com', 'Vadaksties g. 91', 52, 2),
('Titas', 'Dobilevicius', '734010420478', '860950279', 'ejrhqq@gmail.com', 'Zemupio g. 1', 54, 2),
('Arenijus', 'Milius', '734010515899', '860950280', 'qiwrjqoe@gmail.com', 'Juodpelkio g. 119', 56, 2),
('Milana', 'Grubskaite', '749993077664', '860950266', 'werwer@gmail.com', 'Gamyklos g. 9', 28, 1),
('Evelina', 'Dumskyte', '795988700793', '860950261', 'asd@gmail.com', 'Skuodo g. 69', 18, 1),
('Edgaras', 'Narkus', '795998546048', '860950273', 'opoi@gmail.com', 'S. Daukanto g. 28', 42, 2),
('Povilas', 'Dapsys', '853963248970', '860950272', 'utitui@gmail.com', 'Naftininku g. 108', 40, 2),
('Eligijus', 'KIudys', '885422353739', '860950271', 'tyrtw@gmail.com', 'Ventos g. 1', 38, 2);

-- --------------------------------------------------------

--
-- Table structure for table `prekes`
--

CREATE TABLE `prekes` (
  `id` varchar(255) NOT NULL,
  `kaina` decimal(10,0) NOT NULL,
  `pavadinimas` varchar(255) NOT NULL,
  `tipas` varchar(255) NOT NULL,
  `pagaminimo_data` date NOT NULL,
  `svoris` decimal(10,0) DEFAULT NULL,
  `galiojimo_data` date DEFAULT NULL,
  `sezonas` int(11) DEFAULT NULL,
  `lytis` int(11) DEFAULT NULL,
  `fk_GAMINTOJASid_GAMINTOJAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `prekes`
--

INSERT INTO `prekes` (`id`, `kaina`, `pavadinimas`, `tipas`, `pagaminimo_data`, `svoris`, `galiojimo_data`, `sezonas`, `lytis`, `fk_GAMINTOJASid_GAMINTOJAS`) VALUES
('123', 66, 'JAXON', 'meskere', '2022-06-16', 3, NULL, 1, NULL, 1),
('125', 64, 'New Gunter', 'meskere', '2023-01-07', 9, NULL, 1, NULL, 2),
('127', 51, 'New Gunter', 'meskere', '2022-11-30', 6, NULL, 3, NULL, 3),
('129', 86, 'New Gunter', 'meskere', '2020-12-23', 8, NULL, 2, NULL, 4),
('131', 34, 'JAXON', 'meskere', '2022-07-26', 3, NULL, 4, NULL, 5),
('133', 49, 'Carp Attack', 'meskere', '2021-10-23', 1, NULL, NULL, NULL, 6),
('135', 98, 'Carp Attack', 'meskere', '2021-02-05', 9, NULL, NULL, NULL, 7),
('137', 80, 'New Gunter', 'meskere', '2021-06-06', 6, NULL, NULL, NULL, 8),
('139', 44, 'Delphin Exyl', 'rite', '2021-02-12', NULL, NULL, NULL, NULL, 9),
('141', 28, '10BB Carp Runner', 'rite', '0022-09-01', NULL, NULL, NULL, NULL, 10),
('143', 1, 'Modeco carp', 'rite', '2020-12-18', NULL, NULL, NULL, NULL, 11),
('145', 80, 'Dynamic 4000', 'rite', '2021-04-13', NULL, NULL, NULL, NULL, 12),
('147', 78, 'Delphin Exyl', 'rite', '2021-02-15', NULL, NULL, NULL, NULL, 13),
('149', 79, 'Delphin Exyl', 'rite', '2022-11-25', NULL, NULL, NULL, NULL, 14),
('151', 98, 'Aller Performa', 'pasaras', '2020-12-20', 5, '2023-05-17', NULL, NULL, 15),
('153', 62, 'Aller Silver', 'pasaras', '2022-09-13', 4, '2023-04-17', NULL, NULL, 16),
('155', 97, 'Aller Silver Flloat', 'pasaras', '2022-07-13', 4, '2023-07-26', NULL, NULL, 17),
('157', 42, 'Aller Futura', 'pasaras', '2022-06-08', 5, '2023-05-07', NULL, NULL, 18),
('159', 100, 'Chunk LW camo', 'apranga', '2021-05-13', NULL, NULL, 3, 1, 19),
('161', 2, 'Norfin Mirage', 'apranga', '2022-11-11', NULL, NULL, 3, 2, 20),
('163', 23, 'DAM CamoVision', 'apranga', '2022-09-02', NULL, NULL, 4, 2, 21),
('165', 99, 'Norfin Alpha', 'apranga', '2022-07-23', NULL, NULL, 4, 2, 22),
('167', 26, 'Prologic bank', 'apranga', '2022-12-19', NULL, NULL, 1, 1, 1),
('169', 10, 'AquaCam', 'povandenine kamera', '2021-06-27', NULL, NULL, NULL, NULL, 2),
('171', 13, 'CamAqua', 'povandenine kamera', '2022-06-25', NULL, NULL, NULL, NULL, 3),
('173', 50, 'WaterTour', 'povandenine kamera', '2022-07-13', NULL, NULL, NULL, NULL, 4),
('175', 80, 'Tournament', 'kabliukas', '2022-12-27', NULL, NULL, NULL, NULL, 5),
('177', 39, 'Trout', 'kabliukas', '2020-12-29', NULL, NULL, NULL, NULL, 6),
('179', 33, 'Katana', 'kabliukas', '2022-10-02', NULL, NULL, NULL, NULL, 7),
('181', 92, 'Slidin Head', 'svarelis', '2022-12-25', 0, NULL, NULL, NULL, 8),
('183', 26, 'Bullet', 'svarelis', '2021-12-18', 0, NULL, NULL, NULL, 9),
('185', 99, 'Bullet', 'svarelis', '2022-12-29', 0, NULL, NULL, NULL, 10);

-- --------------------------------------------------------

--
-- Table structure for table `priskyrimai`
--

CREATE TABLE `priskyrimai` (
  `fk_PARDAVIMO_ISRASASpardavimo_kodas` varchar(255) NOT NULL,
  `fk_PAPILDOMAS_MOKESTISid_PAPILDOMAS_MOKESTIS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `priskyrimai`
--

INSERT INTO `priskyrimai` (`fk_PARDAVIMO_ISRASASpardavimo_kodas`, `fk_PAPILDOMAS_MOKESTISid_PAPILDOMAS_MOKESTIS`) VALUES
('321321', 1),
('321324', 2),
('321327', 3);

-- --------------------------------------------------------

--
-- Table structure for table `sandeliai`
--

CREATE TABLE `sandeliai` (
  `miestas` varchar(255) NOT NULL,
  `adresas` varchar(255) NOT NULL,
  `patalpu_dydis` decimal(10,0) NOT NULL,
  `darbuotoju_skaicius` int(11) NOT NULL,
  `krovininiu_automobiliu_skaicius` int(11) NOT NULL,
  `id_SANDELYS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sandeliai`
--

INSERT INTO `sandeliai` (`miestas`, `adresas`, `patalpu_dydis`, `darbuotoju_skaicius`, `krovininiu_automobiliu_skaicius`, `id_SANDELYS`) VALUES
('Palanga', 'Skuodo g. 12C', 145, 2, 2, 1),
('Vilnius', 'Skuodo g. 12F', 452, 2, 5, 2),
('Vilnius', 'Montuotoju g. 10', 245, 2, 6, 3),
('Vilnius', 'Naujoji g. 2', 126, 3, 2, 4),
('Kaunas', 'Montuotoju g. 6A', 321, 2, 2, 5),
('Kaunas', 'Gamyklos g. 46', 352, 1, 3, 6),
('Kaunas', 'J. Tumo-Vaižganto g. 4', 345, 3, 1, 7),
('Kaunas', 'Gamyklos g. 15', 265, 2, 2, 8),
('Mazeikiai', 'Ventos g. 19', 156, 1, 3, 9),
('Mazeikiai', 'Zemaitijos g. 20', 234, 2, 0, 10),
('Siauliai', 'Ventos g. 21', 256, 3, 0, 11),
('Siauliai', 'Naftininku g. 10', 235, 2, 5, 12),
('Siauliai', 'S. Daukanto g. 2', 266, 3, 3, 13),
('Siauliai', 'Sodu skg. 4', 345, 1, 2, 14),
('Taurage', 'Pavasario g. 9', 565, 2, 1, 15),
('Taurage', 'Zemaitijos g. 7', 565, 3, 2, 16),
('Taurage', 'Kvistės g. 8', 232, 1, 1, 17),
('Klaipeda', 'Vadaksties g. 9', 232, 3, 2, 18),
('Klaipeda', 'Zemupio g. 55', 523, 2, 2, 19),
('Klaipeda', 'Juodpelkio g. 10', 232, 3, 2, 20);

-- --------------------------------------------------------

--
-- Table structure for table `saskaitos`
--

CREATE TABLE `saskaitos` (
  `nr` varchar(255) NOT NULL,
  `data` date NOT NULL,
  `suma` decimal(10,0) NOT NULL,
  `id_SASKAITA` int(11) NOT NULL,
  `fk_PARDAVIMO_ISRASASpardavimo_kodas` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `saskaitos`
--

INSERT INTO `saskaitos` (`nr`, `data`, `suma`, `id_SASKAITA`, `fk_PARDAVIMO_ISRASASpardavimo_kodas`) VALUES
('232321', '2023-02-12', 100, 1, '321321'),
('4564', '2023-02-12', 100, 2, '321324'),
('456456', '2023-02-12', 100, 3, '321327'),
('4567', '2023-02-12', 100, 4, '321360');

-- --------------------------------------------------------

--
-- Table structure for table `sezonai`
--

CREATE TABLE `sezonai` (
  `id_SEZONAS` int(11) NOT NULL,
  `name` char(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sezonai`
--

INSERT INTO `sezonai` (`id_SEZONAS`, `name`) VALUES
(1, 'ziema'),
(2, 'pavasaris'),
(3, 'vasara'),
(4, 'ruduo');

-- --------------------------------------------------------

--
-- Table structure for table `sportosales`
--

CREATE TABLE `sportosales` (
  `pavadinimas` varchar(255) NOT NULL,
  `adresas` varchar(255) NOT NULL,
  `patalpu_dydis` decimal(10,0) NOT NULL,
  `id_SPORTOSALE` int(11) NOT NULL,
  `fk_MIESTASid_MIESTAS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `sportosales`
--

INSERT INTO `sportosales` (`pavadinimas`, `adresas`, `patalpu_dydis`, `id_SPORTOSALE`, `fk_MIESTASid_MIESTAS`) VALUES
('Zvejoklis', 'Veiverių g. 153-237', 100, 1, 1),
('Pas Gyti', 'Savanoriu pr. 119-3', 120, 2, 1),
('Almarijas', 'Mesinių g. 5', 123, 3, 2),
('Azukle', 'Laives al. 45', 120, 4, 2),
('Zvejys LT', 'Europos pr. 122', 110, 5, 2),
('FlyToTie', 'Elektrenų g. 16', 100, 6, 3),
('Siprakas', 'A. Vivulskio g. 41-7', 90, 7, 5),
('Vilmanda', 'Savanoriu pr. 176', 90, 8, 5),
('Karmelita', 'Raguvos g. 4', 90, 9, 8),
('Zvejoklis', 'Ateities pl. 40', 110, 10, 9),
('Pas Gyti', 'Gedimino g. 30', 110, 11, 9),
('Almarijas', 'Europos pr. 122', 120, 12, 9),
('Azukle', 'T. Masiulio g. 18', 210, 13, 10),
('Zvejys LT', 'Guobų g. 33', 120, 14, 10),
('FlyToTie', 'Raudondvario pl. 101', 120, 15, 12),
('Siprakas', 'Jonavos g. 182', 130, 16, 12),
('Vilmanda', 'Kaunakiemio g. 5', 150, 17, 13),
('Karmelita', 'P. Kalpoko g. 1', 140, 18, 14),
('Zvejoklis', 'K. Petrausko g. 13', 120, 19, 15),
('Zvejys LT', 'V. Putvinskio g. 32', 120, 23, 16);

-- --------------------------------------------------------

--
-- Table structure for table `teikimai`
--

CREATE TABLE `teikimai` (
  `fk_SPORTOSALEid_SPORTOSALE` int(11) NOT NULL,
  `fk_SANDELYSid_SANDELYS` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `teikimai`
--

INSERT INTO `teikimai` (`fk_SPORTOSALEid_SPORTOSALE`, `fk_SANDELYSid_SANDELYS`) VALUES
(2, 1),
(2, 2),
(2, 3),
(4, 3),
(4, 9),
(5, 3),
(8, 6);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `atsiskaitymo_budai`
--
ALTER TABLE `atsiskaitymo_budai`
  ADD PRIMARY KEY (`id_ATSISKAITYMO_BUDAS`);

--
-- Indexes for table `darbuotojai`
--
ALTER TABLE `darbuotojai`
  ADD PRIMARY KEY (`asmens_kodas`),
  ADD KEY `dirba` (`fk_SPORTOSALEid_SPORTOSALE`),
  ADD KEY `eina` (`fk_PAREIGAid_PAREIGA`);

--
-- Indexes for table `gamintojai`
--
ALTER TABLE `gamintojai`
  ADD PRIMARY KEY (`id_GAMINTOJAS`);

--
-- Indexes for table `itraukimai_i`
--
ALTER TABLE `itraukimai_i`
  ADD PRIMARY KEY (`fk_PARDAVIMO_ISRASASpardavimo_kodas`,`fk_PREKEid`);

--
-- Indexes for table `lytys`
--
ALTER TABLE `lytys`
  ADD PRIMARY KEY (`id_LYTIS`);

--
-- Indexes for table `miestai`
--
ALTER TABLE `miestai`
  ADD PRIMARY KEY (`id_MIESTAS`);

--
-- Indexes for table `mokejimai`
--
ALTER TABLE `mokejimai`
  ADD PRIMARY KEY (`id_MOKEJIMAS`),
  ADD KEY `apmoka` (`fk_SASKAITAid_SASKAITA`),
  ADD KEY `sumoka` (`fk_PIRKEJASasmens_kodas`);

--
-- Indexes for table `papildomi_mokesciai`
--
ALTER TABLE `papildomi_mokesciai`
  ADD PRIMARY KEY (`id_PAPILDOMAS_MOKESTIS`);

--
-- Indexes for table `pardavimo_israsai`
--
ALTER TABLE `pardavimo_israsai`
  ADD PRIMARY KEY (`pardavimo_kodas`),
  ADD KEY `apmokejimo_budas` (`apmokejimo_budas`),
  ADD KEY `sudaro` (`fk_PIRKEJASasmens_kodas`),
  ADD KEY `patvirtina` (`fk_DARBUOTOJASasmens_kodas`);

--
-- Indexes for table `pareigos`
--
ALTER TABLE `pareigos`
  ADD PRIMARY KEY (`id_PAREIGA`);

--
-- Indexes for table `pirkejai`
--
ALTER TABLE `pirkejai`
  ADD PRIMARY KEY (`asmens_kodas`),
  ADD KEY `lytis` (`lytis`);

--
-- Indexes for table `prekes`
--
ALTER TABLE `prekes`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sezonas` (`sezonas`),
  ADD KEY `lytis` (`lytis`),
  ADD KEY `gamina` (`fk_GAMINTOJASid_GAMINTOJAS`);

--
-- Indexes for table `priskyrimai`
--
ALTER TABLE `priskyrimai`
  ADD PRIMARY KEY (`fk_PARDAVIMO_ISRASASpardavimo_kodas`,`fk_PAPILDOMAS_MOKESTISid_PAPILDOMAS_MOKESTIS`);

--
-- Indexes for table `sandeliai`
--
ALTER TABLE `sandeliai`
  ADD PRIMARY KEY (`id_SANDELYS`);

--
-- Indexes for table `saskaitos`
--
ALTER TABLE `saskaitos`
  ADD PRIMARY KEY (`id_SASKAITA`),
  ADD KEY `israsyta` (`fk_PARDAVIMO_ISRASASpardavimo_kodas`);

--
-- Indexes for table `sezonai`
--
ALTER TABLE `sezonai`
  ADD PRIMARY KEY (`id_SEZONAS`);

--
-- Indexes for table `sportosales`
--
ALTER TABLE `sportosales`
  ADD PRIMARY KEY (`id_SPORTOSALE`),
  ADD KEY `turi` (`fk_MIESTASid_MIESTAS`);

--
-- Indexes for table `teikimai`
--
ALTER TABLE `teikimai`
  ADD PRIMARY KEY (`fk_SPORTOSALEid_SPORTOSALE`,`fk_SANDELYSid_SANDELYS`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `miestai`
--
ALTER TABLE `miestai`
  MODIFY `id_MIESTAS` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `pareigos`
--
ALTER TABLE `pareigos`
  MODIFY `id_PAREIGA` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `sportosales`
--
ALTER TABLE `sportosales`
  MODIFY `id_SPORTOSALE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `darbuotojai`
--
ALTER TABLE `darbuotojai`
  ADD CONSTRAINT `dirba` FOREIGN KEY (`fk_SPORTOSALEid_SPORTOSALE`) REFERENCES `sportosales` (`id_SPORTOSALE`),
  ADD CONSTRAINT `eina` FOREIGN KEY (`fk_PAREIGAid_PAREIGA`) REFERENCES `pareigos` (`id_PAREIGA`);

--
-- Constraints for table `mokejimai`
--
ALTER TABLE `mokejimai`
  ADD CONSTRAINT `apmoka` FOREIGN KEY (`fk_SASKAITAid_SASKAITA`) REFERENCES `saskaitos` (`id_SASKAITA`),
  ADD CONSTRAINT `sumoka` FOREIGN KEY (`fk_PIRKEJASasmens_kodas`) REFERENCES `pirkejai` (`asmens_kodas`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
