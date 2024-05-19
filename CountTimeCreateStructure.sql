CREATE TABLE [dbo].[tBaseline] (
    [GDCNum]     INT           NOT NULL,
    [InActive]   BIT           NULL,
    [LastName]   NVARCHAR (50) NULL,
    [FirstName]  NVARCHAR (30) NULL,
    [Dorm]       SMALLINT      NULL,
    [Bed]        SMALLINT      NULL,
    [LastUpdate] DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([GDCNum] ASC)
);
CREATE TABLE [dbo].[tCountMain] (
    [CountEventID]    INT           IDENTITY (1, 1) NOT NULL,
    [CountDate]       DATETIME2 (7) NULL,
    [CountTime]       DATETIME2 (7) NULL,
    [TotalInCount]    INT           NULL,
    [TotalOutCount]   INT           NULL,
    [CountCleared]    DATETIME2 (7) NULL,
    [AUnitTotal]      INT           NULL,
    [RSATTotal]       INT           NULL,
    [TIC]             INT           NULL,
    [UnitCountDorm1]  SMALLINT      NULL,
    [UnitCountDorm2]  SMALLINT      NULL,
    [UnitCountDorm3]  SMALLINT      NULL,
    [UnitCountDorm4]  SMALLINT      NULL,
    [UnitCountDorm5]  SMALLINT      NULL,
    [UnitCountDorm6]  SMALLINT      NULL,
    [UnitCountDorm7]  SMALLINT      NULL,
    [UnitCountDorm8]  SMALLINT      NULL,
    [UnitCountDorm9]  SMALLINT      NULL,
    [UnitCountDorm10] SMALLINT      NULL,
    [UnitCountDorm11] SMALLINT      NULL,
    [UnitCountDorm12] SMALLINT      NULL,
    [UnitCountDorm13] SMALLINT      NULL,
    [UnitCountDorm14] SMALLINT      NULL,
    PRIMARY KEY CLUSTERED ([CountEventID] ASC)
);
CREATE TABLE [dbo].[tMasterOptions] (
    [ID] INT NOT NULL IDENTITY, 
    [OptionName]  VARCHAR (255) NULL,
    [OptionValue] INT           NULL, 
    CONSTRAINT [PK_tMasterOptions] PRIMARY KEY ([ID])
);
CREATE TABLE [dbo].[tOutCountUnion] (
    [CountEventID] INT NULL,
    [OutCountID]   INT NULL,
    [GDCNum]       INT NULL,
    [DormAtCount]  INT NULL
);
CREATE TABLE [dbo].[tHospitalMembers] (
    [ID]           INT IDENTITY (1, 1) NOT NULL,
    [HospitalID]   INT NULL,
    [GDCNum]       INT NULL,
    [CountEventID] INT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
CREATE TABLE [dbo].[tHospitals] (
    [HospitalID]   INT            IDENTITY (1, 1) NOT NULL,
    [hospitalName] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([HospitalID] ASC)
);
CREATE TABLE [dbo].[tLocations] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Location] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
CREATE TABLE [dbo].[tOptionsBE] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [OptionName]  NVARCHAR (255) NULL,
    [OptionValue] INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
CREATE TABLE [dbo].[tOutCountNames] (
    [CountEventID] INT      NOT NULL,
    [OutCountID]   INT      NOT NULL,
    [GDCNum]       INT      NOT NULL,
    [DormAtCount]  SMALLINT NULL,
    PRIMARY KEY CLUSTERED ([CountEventID] ASC, [OutCountID] ASC, [GDCNum] ASC)
);
CREATE TABLE [dbo].[tOutCount] (
    [OutCountID]     INT  IDENTITY (1, 1) NOT NULL,
    [CountEventID]   INT  NULL,
    [OutCountColumn] REAL NULL,
    [LocationID]     INT  NULL,
    PRIMARY KEY CLUSTERED ([OutCountID] ASC)
);
CREATE TABLE [dbo].[tUnits] (
    [UnitID] SMALLINT       NULL,
    [Unit]   NVARCHAR (255) NULL
);
CREATE TABLE [dbo].[tOutCountLocations] (
    [LocationID]           INT           IDENTITY (1, 1) NOT NULL,
    [OutCountLocationName] NVARCHAR (21) NULL,
    [InsideOutside]        NVARCHAR (8)  NULL,
    [UnitsEligible]        SMALLINT      NULL,
    PRIMARY KEY CLUSTERED ([LocationID] ASC)
);