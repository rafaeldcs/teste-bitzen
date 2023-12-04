/*
 Navicat Premium Data Transfer

 Source Server         : SQL Local
 Source Server Type    : SQL Server
 Source Server Version : 12002269
 Source Host           : LAPTOP-6F9ISQ9R\SQLEXPRESS:1433
 Source Catalog        : Teste
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 12002269
 File Encoding         : 65001

 Date: 04/12/2023 01:02:43
*/


-- ----------------------------
-- Table structure for Login
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Login]') AND type IN ('U'))
	DROP TABLE [dbo].[Login]
GO

CREATE TABLE [dbo].[Login] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Usuario] nvarchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [Senha] nvarchar(255) COLLATE Latin1_General_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Login] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Login
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Login] ON
GO

INSERT INTO [dbo].[Login] ([Id], [Usuario], [Senha]) VALUES (N'1', N'teste', N'teste')
GO

SET IDENTITY_INSERT [dbo].[Login] OFF
GO


-- ----------------------------
-- Auto increment value for Login
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Login]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Login
-- ----------------------------
ALTER TABLE [dbo].[Login] ADD CONSTRAINT [PK__Login__3214EC07FB8D1F0F] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

