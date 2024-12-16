CREATE TABLE [Locations].[LocationType]
(
	[ID]					INT				NOT NULL,
	[Active]				BIT				NOT NULL CONSTRAINT [DF_Locations_LocationType_Active] DEFAULT ((1)),
	[DateCreated]			DATETIME		NOT NULL CONSTRAINT [DF_Locations_LocationType_DateCreated] DEFAULT (GETDATE()),
	[Description]			VARCHAR(255)	NOT NULL,
	[Code]					VARCHAR(20)		NOT NULL,
	CONSTRAINT [PK_Locations_LocationType_Type] PRIMARY KEY CLUSTERED ([ID] ASC)
)

