
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/11/2016 21:04:01
-- Generated from EDMX file: c:\users\tytus\documents\visual studio 2015\Projects\PeojectTillsammens\TillsammensWeb\Models\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjectTillsammensDataBase];
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
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [MailAddress] nvarchar(max)  NOT NULL,
    [LastVisit] nvarchar(max)  NOT NULL,
    [X] nvarchar(max)  NOT NULL,
    [Y] nvarchar(max)  NOT NULL,
    [Desc] nvarchar(max)  NOT NULL,
    [FriendList] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InvitationSet'
CREATE TABLE [dbo].[InvitationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SenderId] nvarchar(max)  NOT NULL,
    [RecieverId] nvarchar(max)  NOT NULL,
    [IsAccepted] nvarchar(max)  NOT NULL
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