-- --------------------------------------------------------
-- Hôte :                        127.0.0.1
-- Version du serveur:           10.5.8-MariaDB - mariadb.org binary distribution
-- SE du serveur:                Win64
-- HeidiSQL Version:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Listage de la structure de la base pour melodie_db
CREATE DATABASE IF NOT EXISTS `melodie_db` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `melodie_db`;

-- Listage de la structure de la table melodie_db. aspnetroles
CREATE TABLE IF NOT EXISTS `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `ConcurrencyStamp` text DEFAULT NULL,
  `Name` text DEFAULT NULL,
  `NormalizedName` text DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `RoleNameIndex` (`NormalizedName`(1024))
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Listage des données de la table melodie_db.aspnetroles : ~0 rows (environ)
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;

-- Listage de la structure de la table melodie_db. aspnetuserclaims
CREATE TABLE IF NOT EXISTS `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ClaimType` text CHARACTER SET utf8mb4 NOT NULL,
  `ClaimValue` text CHARACTER SET utf8mb4 NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_identityuserclaim_aspnetusers` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Listage des données de la table melodie_db.aspnetuserclaims : ~0 rows (environ)
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;

-- Listage de la structure de la table melodie_db. aspnetuserroles
CREATE TABLE IF NOT EXISTS `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL DEFAULT '',
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`) USING BTREE,
  KEY `IX_AspNetUserRoles_UserId` (`UserId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Listage des données de la table melodie_db.aspnetuserroles : ~0 rows (environ)
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;

-- Listage de la structure de la table melodie_db. aspnetusers
CREATE TABLE IF NOT EXISTS `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL DEFAULT '',
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` text CHARACTER SET utf8mb4 DEFAULT NULL,
  `Email` text CHARACTER SET utf8mb4 DEFAULT NULL,
  `EmailConfirmed` int(11) NOT NULL,
  `LockoutEnabled` int(11) NOT NULL,
  `LockoutEnd` text CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedEmail` text CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedUserName` text CHARACTER SET utf8mb4 DEFAULT NULL,
  `PasswordHash` text CHARACTER SET utf8mb4 DEFAULT NULL,
  `PhoneNumber` text CHARACTER SET utf8mb4 DEFAULT NULL,
  `PhoneNumberConfirmed` int(11) NOT NULL,
  `SecurityStamp` text CHARACTER SET utf8mb4 DEFAULT NULL,
  `TwoFactorEnabled` int(11) NOT NULL,
  `UserName` text CHARACTER SET utf8mb4 DEFAULT NULL,
  `Discriminator` varchar(255) CHARACTER SET utf8mb4 DEFAULT 'AspNetUser',
  PRIMARY KEY (`Id`),
  KEY `EmailIndex` (`NormalizedEmail`(768)),
  KEY `UserNameIndex` (`NormalizedUserName`(768))
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Listage des données de la table melodie_db.aspnetusers : ~4 rows (environ)
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` (`Id`, `AccessFailedCount`, `ConcurrencyStamp`, `Email`, `EmailConfirmed`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `SecurityStamp`, `TwoFactorEnabled`, `UserName`, `Discriminator`) VALUES
	('0a72cc87-39c3-40e5-bd13-b7e640e9c51b', 0, 'becf160e-d960-4693-9241-0da50b155848', 'pierre@feuille.ciseaux', 0, 1, NULL, 'PIERRE@FEUILLE.CISEAUX', 'PIERRE-CISEAUX', 'AQAAAAEAACcQAAAAECvKuWCU9JswrA8WGjJAWTnrJ3DLxN+hyva8Fu3KzL2qmvLBdIEhvvQ9krI4XsF7cA==', NULL, 0, 'CX4JLEJBJUW22VNFPOVMIOJJWBN4X6QO', 0, 'pierre-ciseaux', 'AspNetUser'),
	('0dca04c5-d38f-4443-8a1f-f2843664e93e', 0, '0b0dce27-bcee-41bc-81a9-ef22a94199c8', 'captain.diabete@glyce.mie', 0, 1, NULL, 'CAPTAIN.DIABETE@GLYCE.MIE', 'CAPTAIN DIABÈTE', 'AQAAAAEAACcQAAAAEAeGZPiTvlG6CU9r1ade2Mep/JSNko0biZvpY2USrarN5xBnEzYZC3vL75khENSGMw==', NULL, 0, 'D5JDMORGPVIIWEUZR2RRXZ3KANBMXOGS', 0, 'Captain Diabète', 'AspNetUser'),
	('1fd5c4e0-10c2-4b4c-917a-a6ddc45df8f0', 0, '54f63e37-a7df-4b06-8c6d-1d314090e2af', 'jean-sébastien@caramail.com', 0, 1, NULL, 'JEAN-SÉBASTIEN@CARAMAIL.COM', 'JEAN-SÉBASTIEN', 'AQAAAAEAACcQAAAAEFJT6BcdixYD+asulrUbW/uTk1zEZyYGWb4AG4tMcnsuorbv+UObt1utUm/gUHH+tw==', NULL, 0, 'RH2DX363GW5CKJFXHIFPJRVXYYGSWTWZ', 0, 'Jean-Sébastien', 'AspNetUser'),
	('482ec54e-c443-444a-aa0c-f04378ab4ac1', 0, '34d65c8e-2893-47d5-a8ce-a1110c71c142', 'jeanne.arc@niqueles.anglais', 0, 1, NULL, 'JEANNE.ARC@NIQUELES.ANGLAIS', 'JEANNE D\'ARC', 'AQAAAAEAACcQAAAAELDuhdlxriuArwaMirjMxWCH0Vvb7s8JCVUV29sTokiqffxG6YZ2/cY/0ZJjtf09Qg==', NULL, 0, 'ZQLBWHDXJNZ6GWCJJVS7CMXOTZU5LBB7', 0, 'Jeanne d\'Arc', 'AspNetUser');
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;

-- Listage de la structure de la table melodie_db. colors
CREATE TABLE IF NOT EXISTS `colors` (
  `color_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `hex` char(9) DEFAULT NULL,
  PRIMARY KEY (`color_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Listage des données de la table melodie_db.colors : ~0 rows (environ)
/*!40000 ALTER TABLE `colors` DISABLE KEYS */;
INSERT INTO `colors` (`color_id`, `hex`) VALUES
	(1, '#FFFFFF');
/*!40000 ALTER TABLE `colors` ENABLE KEYS */;

-- Listage de la structure de la table melodie_db. musics
CREATE TABLE IF NOT EXISTS `musics` (
  `music_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `playlist_id` int(11) unsigned NOT NULL,
  `name` char(100) NOT NULL,
  `author` char(255) DEFAULT NULL,
  `duration` char(8) DEFAULT '00:00',
  `creation_date` date DEFAULT current_timestamp(),
  `file_path` varchar(2048) NOT NULL,
  PRIMARY KEY (`music_id`),
  KEY `playlist_id_idx` (`playlist_id`),
  CONSTRAINT `playlist_id` FOREIGN KEY (`playlist_id`) REFERENCES `playlists` (`playlist_id`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;

-- Listage des données de la table melodie_db.musics : ~0 rows (environ)
/*!40000 ALTER TABLE `musics` DISABLE KEYS */;
/*!40000 ALTER TABLE `musics` ENABLE KEYS */;

-- Listage de la structure de la table melodie_db. playlists
CREATE TABLE IF NOT EXISTS `playlists` (
  `playlist_id` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` varchar(255) NOT NULL DEFAULT '',
  `color_id` int(11) unsigned NOT NULL,
  `name` char(100) NOT NULL,
  `description` char(255) DEFAULT NULL,
  PRIMARY KEY (`playlist_id`),
  KEY `user_id_idx` (`user_id`),
  KEY `color_id_idx` (`color_id`),
  CONSTRAINT `color_id` FOREIGN KEY (`color_id`) REFERENCES `colors` (`color_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

-- Listage des données de la table melodie_db.playlists : ~3 rows (environ)
/*!40000 ALTER TABLE `playlists` DISABLE KEYS */;
INSERT INTO `playlists` (`playlist_id`, `user_id`, `color_id`, `name`, `description`) VALUES
	(1, '0dca04c5-d38f-4443-8a1f-f2843664e93e', 1, '80\'s', 'C\'est rétro, c\'est géniaux (?)'),
	(2, '0dca04c5-d38f-4443-8a1f-f2843664e93e', 1, '♫ Les musiques ♪', 'dance \'till you\'re dead'),
	(11, '482ec54e-c443-444a-aa0c-f04378ab4ac1', 1, 'Vive la France', 'Et au bûcher les Anglois');
/*!40000 ALTER TABLE `playlists` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
