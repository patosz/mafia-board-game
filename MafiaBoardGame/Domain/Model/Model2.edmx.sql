
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/14/2015 11:24:05
-- Generated from EDMX file: C:\Users\pdolega15\Source\Repos\mafia-board-game\MafiaBoardGame\Domain\Model\Model2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelContainer];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PartieCarte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cartes] DROP CONSTRAINT [FK_PartieCarte];
GO
IF OBJECT_ID(N'[dbo].[FK_PartiesJoueesJoueur]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JoueurParties] DROP CONSTRAINT [FK_PartiesJoueesJoueur];
GO
IF OBJECT_ID(N'[dbo].[FK_JoueursParticipantsJoueurPartie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JoueurParties] DROP CONSTRAINT [FK_JoueursParticipantsJoueurPartie];
GO
IF OBJECT_ID(N'[dbo].[FK_JoueurPartieCarte_JoueurPartie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JoueurPartieCarte] DROP CONSTRAINT [FK_JoueurPartieCarte_JoueurPartie];
GO
IF OBJECT_ID(N'[dbo].[FK_JoueurPartieCarte_Carte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JoueurPartieCarte] DROP CONSTRAINT [FK_JoueurPartieCarte_Carte];
GO
IF OBJECT_ID(N'[dbo].[FK_JoueurPartieDe_JoueurPartie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JoueurPartieDe] DROP CONSTRAINT [FK_JoueurPartieDe_JoueurPartie];
GO
IF OBJECT_ID(N'[dbo].[FK_JoueurPartieDe_De]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JoueurPartieDe] DROP CONSTRAINT [FK_JoueurPartieDe_De];
GO
IF OBJECT_ID(N'[dbo].[FK_JoueurPartie1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parties] DROP CONSTRAINT [FK_JoueurPartie1];
GO
IF OBJECT_ID(N'[dbo].[FK_JoueurPartiePartie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parties] DROP CONSTRAINT [FK_JoueurPartiePartie];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Joueurs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Joueurs];
GO
IF OBJECT_ID(N'[dbo].[Parties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parties];
GO
IF OBJECT_ID(N'[dbo].[Cartes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cartes];
GO
IF OBJECT_ID(N'[dbo].[JoueurParties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JoueurParties];
GO
IF OBJECT_ID(N'[dbo].[Des]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Des];
GO
IF OBJECT_ID(N'[dbo].[JoueurPartieCarte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JoueurPartieCarte];
GO
IF OBJECT_ID(N'[dbo].[JoueurPartieDe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JoueurPartieDe];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Joueurs'
CREATE TABLE [dbo].[Joueurs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Pseudo] nvarchar(max)  NOT NULL,
    [Mdp] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Parties'
CREATE TABLE [dbo].[Parties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [DateHeureCreation] datetime  NOT NULL,
    [Sens] bit  NOT NULL,
    [JoueurId] int  NULL,
    [JoueurCourant_Id] int  NULL
);
GO

-- Creating table 'Cartes'
CREATE TABLE [dbo].[Cartes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodeEffet] int  NOT NULL,
    [Cout] int  NOT NULL,
    [PartieId] int  NOT NULL
);
GO

-- Creating table 'JoueurParties'
CREATE TABLE [dbo].[JoueurParties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [JoueurId] int  NOT NULL,
    [OrdreJoueur] int  NOT NULL,
    [PartieId] int  NOT NULL
);
GO

-- Creating table 'Des'
CREATE TABLE [dbo].[Des] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valeur] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'JoueurPartieCarte'
CREATE TABLE [dbo].[JoueurPartieCarte] (
    [JoueurParties_Id] int  NOT NULL,
    [CartesMain_Id] int  NOT NULL
);
GO

-- Creating table 'JoueurPartieDe'
CREATE TABLE [dbo].[JoueurPartieDe] (
    [JoueurParties_Id] int  NOT NULL,
    [DesMain_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Joueurs'
ALTER TABLE [dbo].[Joueurs]
ADD CONSTRAINT [PK_Joueurs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parties'
ALTER TABLE [dbo].[Parties]
ADD CONSTRAINT [PK_Parties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cartes'
ALTER TABLE [dbo].[Cartes]
ADD CONSTRAINT [PK_Cartes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JoueurParties'
ALTER TABLE [dbo].[JoueurParties]
ADD CONSTRAINT [PK_JoueurParties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Des'
ALTER TABLE [dbo].[Des]
ADD CONSTRAINT [PK_Des]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [JoueurParties_Id], [CartesMain_Id] in table 'JoueurPartieCarte'
ALTER TABLE [dbo].[JoueurPartieCarte]
ADD CONSTRAINT [PK_JoueurPartieCarte]
    PRIMARY KEY CLUSTERED ([JoueurParties_Id], [CartesMain_Id] ASC);
GO

-- Creating primary key on [JoueurParties_Id], [DesMain_Id] in table 'JoueurPartieDe'
ALTER TABLE [dbo].[JoueurPartieDe]
ADD CONSTRAINT [PK_JoueurPartieDe]
    PRIMARY KEY CLUSTERED ([JoueurParties_Id], [DesMain_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PartieId] in table 'Cartes'
ALTER TABLE [dbo].[Cartes]
ADD CONSTRAINT [FK_PartieCarte]
    FOREIGN KEY ([PartieId])
    REFERENCES [dbo].[Parties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PartieCarte'
CREATE INDEX [IX_FK_PartieCarte]
ON [dbo].[Cartes]
    ([PartieId]);
GO

-- Creating foreign key on [JoueurId] in table 'JoueurParties'
ALTER TABLE [dbo].[JoueurParties]
ADD CONSTRAINT [FK_PartiesJoueesJoueur]
    FOREIGN KEY ([JoueurId])
    REFERENCES [dbo].[Joueurs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PartiesJoueesJoueur'
CREATE INDEX [IX_FK_PartiesJoueesJoueur]
ON [dbo].[JoueurParties]
    ([JoueurId]);
GO

-- Creating foreign key on [PartieId] in table 'JoueurParties'
ALTER TABLE [dbo].[JoueurParties]
ADD CONSTRAINT [FK_JoueursParticipantsJoueurPartie]
    FOREIGN KEY ([PartieId])
    REFERENCES [dbo].[Parties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JoueursParticipantsJoueurPartie'
CREATE INDEX [IX_FK_JoueursParticipantsJoueurPartie]
ON [dbo].[JoueurParties]
    ([PartieId]);
GO

-- Creating foreign key on [JoueurParties_Id] in table 'JoueurPartieCarte'
ALTER TABLE [dbo].[JoueurPartieCarte]
ADD CONSTRAINT [FK_JoueurPartieCarte_JoueurPartie]
    FOREIGN KEY ([JoueurParties_Id])
    REFERENCES [dbo].[JoueurParties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [CartesMain_Id] in table 'JoueurPartieCarte'
ALTER TABLE [dbo].[JoueurPartieCarte]
ADD CONSTRAINT [FK_JoueurPartieCarte_Carte]
    FOREIGN KEY ([CartesMain_Id])
    REFERENCES [dbo].[Cartes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JoueurPartieCarte_Carte'
CREATE INDEX [IX_FK_JoueurPartieCarte_Carte]
ON [dbo].[JoueurPartieCarte]
    ([CartesMain_Id]);
GO

-- Creating foreign key on [JoueurParties_Id] in table 'JoueurPartieDe'
ALTER TABLE [dbo].[JoueurPartieDe]
ADD CONSTRAINT [FK_JoueurPartieDe_JoueurPartie]
    FOREIGN KEY ([JoueurParties_Id])
    REFERENCES [dbo].[JoueurParties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DesMain_Id] in table 'JoueurPartieDe'
ALTER TABLE [dbo].[JoueurPartieDe]
ADD CONSTRAINT [FK_JoueurPartieDe_De]
    FOREIGN KEY ([DesMain_Id])
    REFERENCES [dbo].[Des]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JoueurPartieDe_De'
CREATE INDEX [IX_FK_JoueurPartieDe_De]
ON [dbo].[JoueurPartieDe]
    ([DesMain_Id]);
GO

-- Creating foreign key on [JoueurId] in table 'Parties'
ALTER TABLE [dbo].[Parties]
ADD CONSTRAINT [FK_JoueurPartie1]
    FOREIGN KEY ([JoueurId])
    REFERENCES [dbo].[Joueurs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JoueurPartie1'
CREATE INDEX [IX_FK_JoueurPartie1]
ON [dbo].[Parties]
    ([JoueurId]);
GO

-- Creating foreign key on [JoueurCourant_Id] in table 'Parties'
ALTER TABLE [dbo].[Parties]
ADD CONSTRAINT [FK_JoueurPartiePartie]
    FOREIGN KEY ([JoueurCourant_Id])
    REFERENCES [dbo].[JoueurParties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JoueurPartiePartie'
CREATE INDEX [IX_FK_JoueurPartiePartie]
ON [dbo].[Parties]
    ([JoueurCourant_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------