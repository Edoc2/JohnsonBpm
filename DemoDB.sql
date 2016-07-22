--1.创建数据库
CREATE DATABASE DemoDB
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DemoDB', FILENAME = N'D:\DataBase\DemoDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DemoDB_log', FILENAME = N'D:\DataBase\DemoDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO


--2.添加表

CREATE TABLE [dbo].[sy_menu](
	[row_id] [UNIQUEIDENTIFIER] PRIMARY KEY NONCLUSTERED  NOT NULL ,
	[name] [nvarchar](50) NOT NULL,
	[link] [nvarchar](50) NOT NULL,
	[is_parent] [bit] NOT NULL,
	[parent_id] [uniqueidentifier] NULL
)



