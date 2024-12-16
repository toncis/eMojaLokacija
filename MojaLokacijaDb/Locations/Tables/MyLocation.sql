CREATE TABLE [Locations].[MyLocation]
(
	[ID]				INT				NOT NULL IDENTITY(1, 1),
	[Active]			BIT				NOT NULL CONSTRAINT [DF_Locations_MyLocation_Active] DEFAULT ((1)),
	[DateCreated]		DATETIME		NOT NULL CONSTRAINT [DF_Locations_MyLocation_DateCreated] DEFAULT (GETDATE()),
	[UserID]		    INT				NOT NULL,
	[GeoPoint]			GEOMETRY		NOT NULL,
	[Description]		VARCHAR(255)	NOT NULL,
	CONSTRAINT [PK_Locations_MyLocation] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Locations_MyLocation_User] FOREIGN KEY ([UserID]) REFERENCES [Locations].[User] ([ID])
);
GO

CREATE NONCLUSTERED INDEX [IX_Locations_MyLocation_UserID]
	ON [Locations].[MyLocation]([UserID] ASC);
GO