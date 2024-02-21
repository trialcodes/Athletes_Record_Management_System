-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Feb 21, 2024 at 03:47 AM
-- Server version: 5.5.16
-- PHP Version: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `db_ars`
--

-- --------------------------------------------------------

--
-- Table structure for table `athletes`
--

CREATE TABLE IF NOT EXISTS `athletes` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `date` text,
  `idnumber` text,
  `fullname` text,
  `sex` text,
  `birthdate` text,
  `age` int(2) DEFAULT NULL,
  `height` text,
  `weight` text,
  `course` text,
  `yearlevel` text,
  `sport` text,
  `position` text,
  `contactnumber` text,
  `stats` text,
  `filepath` text,
  `filepath2` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `awardees`
--

CREATE TABLE IF NOT EXISTS `awardees` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `date` text,
  `idnumber` text,
  `fullname` text,
  `course` text,
  `yearlevel` text,
  `sport` text,
  `position` text,
  `contactnumber` text,
  `athletepic` text,
  `athleteawards` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `useraccount`
--

CREATE TABLE IF NOT EXISTS `useraccount` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `fullname` text,
  `address` text,
  `contactnumber` text,
  `sex` text,
  `email` text,
  `role` text,
  `status` text,
  `username` text,
  `password` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `useraccount`
--

INSERT INTO `useraccount` (`id`, `fullname`, `address`, `contactnumber`, `sex`, `email`, `role`, `status`, `username`, `password`) VALUES
(1, 'John Paul Pellogo', 'Araneta City, Manila', '09912345678', 'MALE', 'sample@gmail.com', 'ADMIN', 'APPROVED', 'admin123', 'admin');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
