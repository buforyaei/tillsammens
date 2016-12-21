
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/13/2016 00:56:09
-- Generated from EDMX file: C:\Users\Tytus\Documents\aSEMESTR 7\PI\tillsammens\PeojectTillsammens\TillsammensWeb\Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TillsammensDataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(20)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [LastVisit] datetime  NOT NULL,
    [X] float  NOT NULL,
    [Y] float  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [FriendsList] nvarchar(max)  NOT NULL,
    [PhotoUri] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InvitationSet'
CREATE TABLE [dbo].[InvitationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SenderId] int  NOT NULL,
    [RecieverId] int  NOT NULL,
    [IsAccepted] bit  NOT NULL
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