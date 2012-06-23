
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/23/2012 13:29:53
-- Generated from EDMX file: D:\Dropbox\vs-projects\PHeart\src\Domain\Models\PHeart.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PHeart];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FstClassSndClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SndClasses] DROP CONSTRAINT [FK_FstClassSndClass];
GO
IF OBJECT_ID(N'[dbo].[FK_FstClassNews]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Newses] DROP CONSTRAINT [FK_FstClassNews];
GO
IF OBJECT_ID(N'[dbo].[FK_SndClassNews]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Newses] DROP CONSTRAINT [FK_SndClassNews];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_RoleUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FstClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FstClasses];
GO
IF OBJECT_ID(N'[dbo].[SndClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SndClasses];
GO
IF OBJECT_ID(N'[dbo].[Newses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Newses];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FstClasses'
CREATE TABLE [dbo].[FstClasses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'SndClasses'
CREATE TABLE [dbo].[SndClasses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FstClassId] int  NOT NULL
);
GO

-- Creating table 'Newses'
CREATE TABLE [dbo].[Newses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [Published] datetime  NOT NULL,
    [Views] int  NOT NULL,
    [ImageUrl] nvarchar(max)  NULL,
    [Body] nvarchar(max)  NOT NULL,
    [FstClassId] int  NOT NULL,
    [SndClassId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'FstClasses'
ALTER TABLE [dbo].[FstClasses]
ADD CONSTRAINT [PK_FstClasses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SndClasses'
ALTER TABLE [dbo].[SndClasses]
ADD CONSTRAINT [PK_SndClasses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Newses'
ALTER TABLE [dbo].[Newses]
ADD CONSTRAINT [PK_Newses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FstClassId] in table 'SndClasses'
ALTER TABLE [dbo].[SndClasses]
ADD CONSTRAINT [FK_FstClassSndClass]
    FOREIGN KEY ([FstClassId])
    REFERENCES [dbo].[FstClasses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FstClassSndClass'
CREATE INDEX [IX_FK_FstClassSndClass]
ON [dbo].[SndClasses]
    ([FstClassId]);
GO

-- Creating foreign key on [FstClassId] in table 'Newses'
ALTER TABLE [dbo].[Newses]
ADD CONSTRAINT [FK_FstClassNews]
    FOREIGN KEY ([FstClassId])
    REFERENCES [dbo].[FstClasses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FstClassNews'
CREATE INDEX [IX_FK_FstClassNews]
ON [dbo].[Newses]
    ([FstClassId]);
GO

-- Creating foreign key on [SndClassId] in table 'Newses'
ALTER TABLE [dbo].[Newses]
ADD CONSTRAINT [FK_SndClassNews]
    FOREIGN KEY ([SndClassId])
    REFERENCES [dbo].[SndClasses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SndClassNews'
CREATE INDEX [IX_FK_SndClassNews]
ON [dbo].[Newses]
    ([SndClassId]);
GO

-- Creating foreign key on [RoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_RoleUser]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUser'
CREATE INDEX [IX_FK_RoleUser]
ON [dbo].[Users]
    ([RoleId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------