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

 Date: 04/12/2023 01:02:14
*/


-- ----------------------------
-- Table structure for Abastecimento
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Abastecimento]') AND type IN ('U'))
	DROP TABLE [dbo].[Abastecimento]
GO

CREATE TABLE [dbo].[Abastecimento] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [VeiculoId] int  NOT NULL,
  [MotoristaId] int  NOT NULL,
  [Data] datetime  NOT NULL,
  [TipoCombustivel] nvarchar(50) COLLATE Latin1_General_CI_AS  NOT NULL,
  [QuantidadeAbastecida] int  NOT NULL,
  [Total] decimal(18,2)  NOT NULL
)
GO

ALTER TABLE [dbo].[Abastecimento] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Motorista
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Motorista]') AND type IN ('U'))
	DROP TABLE [dbo].[Motorista]
GO

CREATE TABLE [dbo].[Motorista] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Nome] nvarchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [CPF] nvarchar(14) COLLATE Latin1_General_CI_AS  NOT NULL,
  [NumeroCNH] nvarchar(20) COLLATE Latin1_General_CI_AS  NOT NULL,
  [CategoriaCNH] nvarchar(5) COLLATE Latin1_General_CI_AS  NOT NULL,
  [DataNascimento] date  NOT NULL,
  [Status] bit  NOT NULL
)
GO

ALTER TABLE [dbo].[Motorista] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Veiculo
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Veiculo]') AND type IN ('U'))
	DROP TABLE [dbo].[Veiculo]
GO

CREATE TABLE [dbo].[Veiculo] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Placa] nvarchar(10) COLLATE Latin1_General_CI_AS  NOT NULL,
  [NomeVeiculo] nvarchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [TipoCombustivel] nvarchar(50) COLLATE Latin1_General_CI_AS  NOT NULL,
  [Fabricante] nvarchar(255) COLLATE Latin1_General_CI_AS  NOT NULL,
  [AnoFabricacao] int  NOT NULL,
  [CapacidadeTanque] int  NOT NULL,
  [Observacoes] nvarchar(max) COLLATE Latin1_General_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Veiculo] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Auto increment value for Abastecimento
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Abastecimento]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table Abastecimento
-- ----------------------------
ALTER TABLE [dbo].[Abastecimento] ADD CONSTRAINT [PK__Abasteci__3214EC07D9E394FD] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Motorista
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Motorista]', RESEED, 8)
GO


-- ----------------------------
-- Primary Key structure for table Motorista
-- ----------------------------
ALTER TABLE [dbo].[Motorista] ADD CONSTRAINT [PK__Motorist__3214EC07788DFEBB] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Veiculo
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Veiculo]', RESEED, 3)
GO


-- ----------------------------
-- Primary Key structure for table Veiculo
-- ----------------------------
ALTER TABLE [dbo].[Veiculo] ADD CONSTRAINT [PK__Veiculo__3214EC07D30E7015] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Abastecimento
-- ----------------------------
ALTER TABLE [dbo].[Abastecimento] ADD CONSTRAINT [FK__Abastecim__Veicu__5165187F] FOREIGN KEY ([VeiculoId]) REFERENCES [dbo].[Veiculo] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[Abastecimento] ADD CONSTRAINT [FK__Abastecim__Motor__52593CB8] FOREIGN KEY ([MotoristaId]) REFERENCES [dbo].[Motorista] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

