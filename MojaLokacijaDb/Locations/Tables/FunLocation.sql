CREATE TABLE [Locations].[FunLocation]
(
	[ID]				INT				NOT NULL IDENTITY(1, 1),
	[Active]			BIT				NOT NULL CONSTRAINT [DF_Locations_FunLocation_Active] DEFAULT ((1)),
	[DateCreated]		DATETIME		NOT NULL CONSTRAINT [DF_Locations_FunLocation_DateCreated] DEFAULT (GETDATE()),
	[Description]		VARCHAR(255)	NOT NULL,
	[GeoPoint]			GEOMETRY		NOT NULL,
	[TypeID]		    INT				NOT NULL,
	CONSTRAINT [PK_Locations_FunLocation] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Locations_FunLocation_Assignment] FOREIGN KEY ([TypeID]) REFERENCES [Locations].[LocationType] ([ID])
);
GO

CREATE NONCLUSTERED INDEX [IX_TypeID]
	ON [Locations].[FunLocation]([TypeID] ASC);
GO