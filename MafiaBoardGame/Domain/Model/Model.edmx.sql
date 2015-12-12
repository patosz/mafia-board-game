
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/12/2015 11:59:55
-- Generated from EDMX file: C:\Users\Giordano\Source\Repos\mafia-board-game\MafiaBoardGame\Domain\Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ProjectMafia];
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

-- Creating table 'JoueurSet'
CREATE TABLE [dbo].[JoueurSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Pseudo] nvarchar(max)  NOT NULL,
    [Mdp] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PartieSet'
CREATE TABLE [dbo].[PartieSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateHeureCreation] datetime  NOT NULL,
    [Sens] nvarchar(max)  NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [JoueurId] int  NOT NULL,
    [JoueurCourantPartie_Id] int  NOT NULL
);
GO

-- Creating table 'JoueurPartieSet'
CREATE TABLE [dbo].[JoueurPartieSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrdreJoueurs] int  NOT NULL,
    [JoueurId] int  NOT NULL,
    [Partie_Id] int  NOT NULL
);
GO

-- Creating table 'DeSet'
CREATE TABLE [dbo].[DeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valeur] int  NOT NULL
);
GO

-- Creating table 'CarteSet'
CREATE TABLE [dbo].[CarteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodeEffet] int  NOT NULL,
    [Cout] int  NOT NULL,
    [Partie_Id] int  NOT NULL
);
GO

-- Creating table 'mainDe'
CREATE TABLE [dbo].[mainDe] (
    [De_Id] int  NOT NULL,
    [JoueurPartie_Id] int  NOT NULL
);
GO

-- Creating table 'mainCarte'
CREATE TABLE [dbo].[mainCarte] (
    [Carte_Id] int  NOT NULL,
    [JoueurPartie_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'JoueurSet'
ALTER TABLE [dbo].[JoueurSet]
ADD CONSTRAINT [PK_JoueurSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PartieSet'
ALTER TABLE [dbo].[PartieSet]
ADD CONSTRAINT [PK_PartieSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JoueurPartieSet'
ALTER TABLE [dbo].[JoueurPartieSet]
ADD CONSTRAINT [PK_JoueurPartieSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeSet'
ALTER TABLE [dbo].[DeSet]
ADD CONSTRAINT [PK_DeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CarteSet'
ALTER TABLE [dbo].[CarteSet]
ADD CONSTRAINT [PK_CarteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [De_Id], [JoueurPartie_Id] in table 'mainDe'
ALTER TABLE [dbo].[mainDe]
ADD CONSTRAINT [PK_mainDe]
    PRIMARY KEY CLUSTERED ([De_Id], [JoueurPartie_Id] ASC);
GO

-- Creating primary key on [Carte_Id], [JoueurPartie_Id] in table 'mainCarte'
ALTER TABLE [dbo].[mainCarte]
ADD CONSTRAINT [PK_mainCarte]
    PRIMARY KEY CLUSTERED ([Carte_Id], [JoueurPartie_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [JoueurId] in table 'PartieSet'
ALTER TABLE [dbo].[PartieSet]
ADD CONSTRAINT [FK_vainqueur]
    FOREIGN KEY ([JoueurId])
    REFERENCES [dbo].[JoueurSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_vainqueur'
CREATE INDEX [IX_FK_vainqueur]
ON [dbo].[PartieSet]
    ([JoueurId]);
GO

-- Creating foreign key on [JoueurId] in table 'JoueurPartieSet'
ALTER TABLE [dbo].[JoueurPartieSet]
ADD CONSTRAINT [FK_JoueurJoueurPartie]
    FOREIGN KEY ([JoueurId])
    REFERENCES [dbo].[JoueurSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JoueurJoueurPartie'
CREATE INDEX [IX_FK_JoueurJoueurPartie]
ON [dbo].[JoueurPartieSet]
    ([JoueurId]);
GO

-- Creating foreign key on [JoueurCourantPartie_Id] in table 'PartieSet'
ALTER TABLE [dbo].[PartieSet]
ADD CONSTRAINT [FK_joueurCourant]
    FOREIGN KEY ([JoueurCourantPartie_Id])
    REFERENCES [dbo].[JoueurPartieSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_joueurCourant'
CREATE INDEX [IX_FK_joueurCourant]
ON [dbo].[PartieSet]
    ([JoueurCourantPartie_Id]);
GO

-- Creating foreign key on [Partie_Id] in table 'JoueurPartieSet'
ALTER TABLE [dbo].[JoueurPartieSet]
ADD CONSTRAINT [FK_JoueurPartiePartie]
    FOREIGN KEY ([Partie_Id])
    REFERENCES [dbo].[PartieSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JoueurPartiePartie'
CREATE INDEX [IX_FK_JoueurPartiePartie]
ON [dbo].[JoueurPartieSet]
    ([Partie_Id]);
GO

-- Creating foreign key on [De_Id] in table 'mainDe'
ALTER TABLE [dbo].[mainDe]
ADD CONSTRAINT [FK_mainDe_De]
    FOREIGN KEY ([De_Id])
    REFERENCES [dbo].[DeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JoueurPartie_Id] in table 'mainDe'
ALTER TABLE [dbo].[mainDe]
ADD CONSTRAINT [FK_mainDe_JoueurPartie]
    FOREIGN KEY ([JoueurPartie_Id])
    REFERENCES [dbo].[JoueurPartieSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_mainDe_JoueurPartie'
CREATE INDEX [IX_FK_mainDe_JoueurPartie]
ON [dbo].[mainDe]
    ([JoueurPartie_Id]);
GO

-- Creating foreign key on [Carte_Id] in table 'mainCarte'
ALTER TABLE [dbo].[mainCarte]
ADD CONSTRAINT [FK_mainCarte_Carte]
    FOREIGN KEY ([Carte_Id])
    REFERENCES [dbo].[CarteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JoueurPartie_Id] in table 'mainCarte'
ALTER TABLE [dbo].[mainCarte]
ADD CONSTRAINT [FK_mainCarte_JoueurPartie]
    FOREIGN KEY ([JoueurPartie_Id])
    REFERENCES [dbo].[JoueurPartieSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_mainCarte_JoueurPartie'
CREATE INDEX [IX_FK_mainCarte_JoueurPartie]
ON [dbo].[mainCarte]
    ([JoueurPartie_Id]);
GO

-- Creating foreign key on [Partie_Id] in table 'CarteSet'
ALTER TABLE [dbo].[CarteSet]
ADD CONSTRAINT [FK_pioche]
    FOREIGN KEY ([Partie_Id])
    REFERENCES [dbo].[PartieSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pioche'
CREATE INDEX [IX_FK_pioche]
ON [dbo].[CarteSet]
    ([Partie_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------