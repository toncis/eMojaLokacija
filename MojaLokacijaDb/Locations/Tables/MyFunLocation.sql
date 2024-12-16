CREATE TABLE [Locations].[MyFunLocation]
(
	[ID]				INT				NOT NULL IDENTITY(1, 1),
	[Active]			BIT				NOT NULL CONSTRAINT [DF_Locations_MyFunLocation_Active] DEFAULT ((1)),
	[DateCreated]		DATETIME		NOT NULL CONSTRAINT [DF_Locations_MyFunLocation_DateCreated] DEFAULT (GETDATE()),
	[MyLocationID]	    INT				NOT NULL,
	[FunLocationID]		INT	            NOT NULL,
	CONSTRAINT [PK_Locations_MyFunLocation] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Locations_MyFunLocation_MyLocationID] FOREIGN KEY ([MyLocationID]) REFERENCES [Locations].[MyLocation] ([ID]),
	CONSTRAINT [FK_Locations_MyFunLocation_MyFunLocationID] FOREIGN KEY ([FunLocationID]) REFERENCES [Locations].[FunLocation] ([ID]),
);
GO

CREATE NONCLUSTERED INDEX [IX_Locations_MyFunLocation_MyLocationID]
	ON [Locations].[MyFunLocation]([MyLocationID] ASC);
GO