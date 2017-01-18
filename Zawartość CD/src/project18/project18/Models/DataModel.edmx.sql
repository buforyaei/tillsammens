
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/29/2016 14:15:19
-- Generated from EDMX file: C:\Users\Tytus\Desktop\project18\project18\Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [project18dataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[InvitationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvitationSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(25)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [LastVisit] nvarchar(max)  NOT NULL,
    [OpenDate] nvarchar(max)  NOT NULL,
    [CloseDate] nvarchar(max)  NOT NULL,
    [Desc] nvarchar(120)  NOT NULL,
    [PhotoUri] nvarchar(max)  NOT NULL,
    [X] float  NOT NULL,
    [Y] float  NOT NULL
);
GO

-- Creating table 'InvitationSet'
CREATE TABLE [dbo].[InvitationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SenderId] int  NOT NULL,
    [RecieverId] int  NOT NULL,
    [Status] nvarchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InvitationSet'
ALTER TABLE [dbo].[InvitationSet]
ADD CONSTRAINT [PK_InvitationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------