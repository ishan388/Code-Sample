USE [StudentAdmission]
GO

CREATE TABLE [dbo].[Course_Status] (
    [csId]   INT           IDENTITY (1, 1) NOT NULL,
    [csName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([csId] ASC)
);

INSERT INTO [dbo].[Course_Status] ([csName]) VALUES ('Active');
INSERT INTO [dbo].[Course_Status] ([csName]) VALUES ('Suspended');
INSERT INTO [dbo].[Course_Status] ([csName]) VALUES ('Removed');

CREATE TABLE [dbo].[Courses] (
    [coId]       INT           IDENTITY (1, 1) NOT NULL,
    [coName]     NVARCHAR (50) NOT NULL,
    [coNoOfSems] SMALLINT      NOT NULL,
    [coStatus]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([coId] ASC),
    CONSTRAINT [FK_Courses_ToTable] FOREIGN KEY ([coStatus]) REFERENCES [dbo].[Course_Status] ([csId])
);

INSERT INTO [dbo].[Courses] ([coName], [coNoOfSems], [coStatus]) VALUES ('MBA', 4, 1);
INSERT INTO [dbo].[Courses] ([coName], [coNoOfSems], [coStatus]) VALUES ('MSc Management', 3, 2);
INSERT INTO [dbo].[Courses] ([coName], [coNoOfSems], [coStatus]) VALUES ('MCA', 6, 3);
INSERT INTO [dbo].[Courses] ([coName], [coNoOfSems], [coStatus]) VALUES ('MPharm', 4, 1);

CREATE TABLE [dbo].[Student_Status] (
    [ssId]   INT           IDENTITY (1, 1) NOT NULL,
    [ssName] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([ssId] ASC)
);

INSERT INTO [dbo].[Student_Status] ([ssName]) VALUES ('Active');
INSERT INTO [dbo].[Student_Status] ([ssName]) VALUES ('Suspended');
INSERT INTO [dbo].[Student_Status] ([ssName]) VALUES ('Removed');

CREATE TABLE [dbo].[Students] (
    [stuId]              INT           IDENTITY (1, 1) NOT NULL,
    [stuName]            NVARCHAR (50) NOT NULL,
    [stuAge]             SMALLINT      NOT NULL,
    [stuGender]          CHAR (1)      DEFAULT ('m') NOT NULL,
    [stuDOB]             DATETIME      NOT NULL,
    [stuStatus]          INT           NOT NULL,
    [stuCourseId]        INT           NOT NULL,
    [stuSuspendTillDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([stuId] ASC),
    CONSTRAINT [FK_Students_Courses] FOREIGN KEY ([stuCourseId]) REFERENCES [dbo].[Courses] ([coId]),
    CONSTRAINT [FK_Students_Student_Status] FOREIGN KEY ([stuStatus]) REFERENCES [dbo].[Student_Status] ([ssId])
);

