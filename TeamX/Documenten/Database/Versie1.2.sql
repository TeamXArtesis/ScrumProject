-- MySQL dump 10.13  Distrib 5.5.9, for Win32 (x86)
--
-- Host: localhost    Database: timetable
-- ------------------------------------------------------
-- Server version	5.5.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `timetable`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `timetable` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `timetable`;

--
-- Table structure for table `docent_olods`
--

DROP TABLE IF EXISTS `docent_olods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `docent_olods` (
  `docent_id` int(11) NOT NULL,
  `olod_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`docent_id`),
  KEY `for_docolod_docent_id` (`docent_id`),
  KEY `for_docolod_olod_id` (`olod_id`),
  CONSTRAINT `for_docolod_docent_id` FOREIGN KEY (`docent_id`) REFERENCES `docenten` (`docent_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `for_docolod_olod_id` FOREIGN KEY (`olod_id`) REFERENCES `olods` (`olod_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `docent_olods`
--

LOCK TABLES `docent_olods` WRITE;
/*!40000 ALTER TABLE `docent_olods` DISABLE KEYS */;
/*!40000 ALTER TABLE `docent_olods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `docenten`
--

DROP TABLE IF EXISTS `docenten`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `docenten` (
  `docent_id` int(11) NOT NULL AUTO_INCREMENT,
  `naam` varchar(45) DEFAULT NULL,
  `voornaam` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`docent_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `docenten`
--

LOCK TABLES `docenten` WRITE;
/*!40000 ALTER TABLE `docenten` DISABLE KEYS */;
/*!40000 ALTER TABLE `docenten` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `klas_olods`
--

DROP TABLE IF EXISTS `klas_olods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `klas_olods` (
  `klas_id` int(11) NOT NULL,
  `olod_id` int(11) NOT NULL,
  PRIMARY KEY (`klas_id`,`olod_id`),
  KEY `for_klas_id` (`klas_id`),
  KEY `for_olod_id` (`olod_id`),
  CONSTRAINT `for_klas_id` FOREIGN KEY (`klas_id`) REFERENCES `klassen` (`klas_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `for_olod_id` FOREIGN KEY (`olod_id`) REFERENCES `olods` (`olod_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klas_olods`
--

LOCK TABLES `klas_olods` WRITE;
/*!40000 ALTER TABLE `klas_olods` DISABLE KEYS */;
/*!40000 ALTER TABLE `klas_olods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `klassen`
--

DROP TABLE IF EXISTS `klassen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `klassen` (
  `klas_id` int(11) NOT NULL AUTO_INCREMENT,
  `afkorting` varchar(5) DEFAULT NULL,
  `naam` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`klas_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `klassen`
--

LOCK TABLES `klassen` WRITE;
/*!40000 ALTER TABLE `klassen` DISABLE KEYS */;
/*!40000 ALTER TABLE `klassen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lessen`
--

DROP TABLE IF EXISTS `lessen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lessen` (
  `les_id` int(11) NOT NULL AUTO_INCREMENT,
  `tijd` time NOT NULL,
  `olod_id` int(11) NOT NULL,
  `duur_in_minuten` int(11) DEFAULT NULL,
  `lokaal` varchar(10) DEFAULT NULL,
  `dag` int(2) NOT NULL,
  `week` int(10) DEFAULT '-1',
  PRIMARY KEY (`olod_id`,`dag`,`tijd`),
  UNIQUE KEY `les_id_UNIQUE` (`les_id`),
  KEY `olod_id` (`olod_id`),
  CONSTRAINT `olod_id` FOREIGN KEY (`olod_id`) REFERENCES `olods` (`olod_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lessen`
--

LOCK TABLES `lessen` WRITE;
/*!40000 ALTER TABLE `lessen` DISABLE KEYS */;
/*!40000 ALTER TABLE `lessen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `olods`
--

DROP TABLE IF EXISTS `olods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `olods` (
  `olod_id` int(11) NOT NULL AUTO_INCREMENT,
  `naam` varchar(45) DEFAULT NULL,
  `studiepunten` int(11) DEFAULT NULL,
  `omschrijving` text,
  PRIMARY KEY (`olod_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `olods`
--

LOCK TABLES `olods` WRITE;
/*!40000 ALTER TABLE `olods` DISABLE KEYS */;
/*!40000 ALTER TABLE `olods` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-11-19 17:34:01
