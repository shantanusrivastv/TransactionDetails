USE [master]
GO

/****** Object:  Database [TransactionDetails]    Script Date: 08/18/2015 14:54:11 ******/
CREATE DATABASE [TransactionDetails] ON  PRIMARY 
( NAME = N'TransactionDetails', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\TransactionDetails.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TransactionDetails_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\TransactionDetails_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [TransactionDetails] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TransactionDetails].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [TransactionDetails] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [TransactionDetails] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [TransactionDetails] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [TransactionDetails] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [TransactionDetails] SET ARITHABORT OFF 
GO

ALTER DATABASE [TransactionDetails] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [TransactionDetails] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [TransactionDetails] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [TransactionDetails] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [TransactionDetails] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [TransactionDetails] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [TransactionDetails] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [TransactionDetails] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [TransactionDetails] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [TransactionDetails] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [TransactionDetails] SET  DISABLE_BROKER 
GO

ALTER DATABASE [TransactionDetails] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [TransactionDetails] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [TransactionDetails] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [TransactionDetails] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [TransactionDetails] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [TransactionDetails] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [TransactionDetails] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [TransactionDetails] SET  READ_WRITE 
GO

ALTER DATABASE [TransactionDetails] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [TransactionDetails] SET  MULTI_USER 
GO

ALTER DATABASE [TransactionDetails] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [TransactionDetails] SET DB_CHAINING OFF 
GO

