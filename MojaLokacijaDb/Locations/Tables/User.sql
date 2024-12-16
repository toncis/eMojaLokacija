CREATE TABLE [Locations].[User]
(
	[ID]					INT				NOT NULL,
	[Active]				BIT				NOT NULL CONSTRAINT [DF_Locations_User_Active] DEFAULT ((1)),
	[DateCreated]			DATETIME		NOT NULL CONSTRAINT [DF_Locations_User_DateCreated] DEFAULT (GETDATE()),
	[Name]			        VARCHAR(255)	NOT NULL,
	[Email]					VARCHAR(255)	NOT NULL,
	CONSTRAINT [PK_Locations_User] PRIMARY KEY CLUSTERED ([ID] ASC),
)
