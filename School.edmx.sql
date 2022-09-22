
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/21/2022 14:49:24
-- Generated from EDMX file: G:\SeLa\DR. Dmitriy M\Linq\EntityFramework\Les3\WpfDesignerAss\School.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WPF_School];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentTeacher_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentTeacher] DROP CONSTRAINT [FK_StudentTeacher_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentTeacher_Teacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentTeacher] DROP CONSTRAINT [FK_StudentTeacher_Teacher];
GO
IF OBJECT_ID(N'[dbo].[FK_Student_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_Student] DROP CONSTRAINT [FK_Student_inherits_Person];
GO
IF OBJECT_ID(N'[dbo].[FK_Teacher_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People_Teacher] DROP CONSTRAINT [FK_Teacher_inherits_Person];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[People_Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People_Student];
GO
IF OBJECT_ID(N'[dbo].[People_Teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People_Teacher];
GO
IF OBJECT_ID(N'[dbo].[StudentTeacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentTeacher];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'People_Student'
CREATE TABLE [dbo].[People_Student] (
    [Grade] float  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'People_Teacher'
CREATE TABLE [dbo].[People_Teacher] (
    [CourseTeach] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'StudentTeacher'
CREATE TABLE [dbo].[StudentTeacher] (
    [Students_Id] int  NOT NULL,
    [Teachers_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_Student'
ALTER TABLE [dbo].[People_Student]
ADD CONSTRAINT [PK_People_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_Teacher'
ALTER TABLE [dbo].[People_Teacher]
ADD CONSTRAINT [PK_People_Teacher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Students_Id], [Teachers_Id] in table 'StudentTeacher'
ALTER TABLE [dbo].[StudentTeacher]
ADD CONSTRAINT [PK_StudentTeacher]
    PRIMARY KEY CLUSTERED ([Students_Id], [Teachers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Students_Id] in table 'StudentTeacher'
ALTER TABLE [dbo].[StudentTeacher]
ADD CONSTRAINT [FK_StudentTeacher_Student]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[People_Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Teachers_Id] in table 'StudentTeacher'
ALTER TABLE [dbo].[StudentTeacher]
ADD CONSTRAINT [FK_StudentTeacher_Teacher]
    FOREIGN KEY ([Teachers_Id])
    REFERENCES [dbo].[People_Teacher]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentTeacher_Teacher'
CREATE INDEX [IX_FK_StudentTeacher_Teacher]
ON [dbo].[StudentTeacher]
    ([Teachers_Id]);
GO

-- Creating foreign key on [Id] in table 'People_Student'
ALTER TABLE [dbo].[People_Student]
ADD CONSTRAINT [FK_Student_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'People_Teacher'
ALTER TABLE [dbo].[People_Teacher]
ADD CONSTRAINT [FK_Teacher_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------