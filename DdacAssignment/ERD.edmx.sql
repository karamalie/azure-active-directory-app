
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/31/2016 12:44:12
-- Generated from EDMX file: F:\VSprojects\DdacAssignment\DdacAssignment\ERD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ddac-db];
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

-- Creating table 'Schedules'
CREATE TABLE [dbo].[Schedules] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [departure_time] datetime  NOT NULL,
    [arrival_time] datetime  NOT NULL,
    [destination] nvarchar(max)  NOT NULL,
    [ShipId] int  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [company_name] nvarchar(max)  NOT NULL,
    [contact_number] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Shipments'
CREATE TABLE [dbo].[Shipments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(max)  NOT NULL,
    [insured_value] int  NOT NULL,
    [weight] int  NOT NULL,
    [destination] nvarchar(max)  NOT NULL,
    [status] int  NOT NULL,
    [CustomerId] int  NOT NULL,
    [YardId] int  NOT NULL,
    [ShipId] int  NOT NULL
);
GO

-- Creating table 'Ships'
CREATE TABLE [dbo].[Ships] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [max_load] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [FleetId] int  NOT NULL
);
GO

-- Creating table 'Yards'
CREATE TABLE [dbo].[Yards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [yard_name] nvarchar(max)  NOT NULL,
    [port] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Fleets'
CREATE TABLE [dbo].[Fleets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fleet_name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Schedules'
ALTER TABLE [dbo].[Schedules]
ADD CONSTRAINT [PK_Schedules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Shipments'
ALTER TABLE [dbo].[Shipments]
ADD CONSTRAINT [PK_Shipments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ships'
ALTER TABLE [dbo].[Ships]
ADD CONSTRAINT [PK_Ships]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Yards'
ALTER TABLE [dbo].[Yards]
ADD CONSTRAINT [PK_Yards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fleets'
ALTER TABLE [dbo].[Fleets]
ADD CONSTRAINT [PK_Fleets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Shipments'
ALTER TABLE [dbo].[Shipments]
ADD CONSTRAINT [FK_ShipmentCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShipmentCustomer'
CREATE INDEX [IX_FK_ShipmentCustomer]
ON [dbo].[Shipments]
    ([CustomerId]);
GO

-- Creating foreign key on [YardId] in table 'Shipments'
ALTER TABLE [dbo].[Shipments]
ADD CONSTRAINT [FK_ShipmentYard]
    FOREIGN KEY ([YardId])
    REFERENCES [dbo].[Yards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShipmentYard'
CREATE INDEX [IX_FK_ShipmentYard]
ON [dbo].[Shipments]
    ([YardId]);
GO

-- Creating foreign key on [ShipId] in table 'Shipments'
ALTER TABLE [dbo].[Shipments]
ADD CONSTRAINT [FK_ShipmentShip]
    FOREIGN KEY ([ShipId])
    REFERENCES [dbo].[Ships]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShipmentShip'
CREATE INDEX [IX_FK_ShipmentShip]
ON [dbo].[Shipments]
    ([ShipId]);
GO

-- Creating foreign key on [ShipId] in table 'Schedules'
ALTER TABLE [dbo].[Schedules]
ADD CONSTRAINT [FK_ShipSchedule]
    FOREIGN KEY ([ShipId])
    REFERENCES [dbo].[Ships]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShipSchedule'
CREATE INDEX [IX_FK_ShipSchedule]
ON [dbo].[Schedules]
    ([ShipId]);
GO

-- Creating foreign key on [FleetId] in table 'Ships'
ALTER TABLE [dbo].[Ships]
ADD CONSTRAINT [FK_FleetShip]
    FOREIGN KEY ([FleetId])
    REFERENCES [dbo].[Fleets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FleetShip'
CREATE INDEX [IX_FK_FleetShip]
ON [dbo].[Ships]
    ([FleetId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------