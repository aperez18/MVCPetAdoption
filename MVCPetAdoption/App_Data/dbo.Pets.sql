CREATE TABLE [dbo].[Pets] (
    [PetId]              INT            IDENTITY (1, 1) NOT NULL,
    [SpeciesId]          INT            NOT NULL,
    [Name]               NVARCHAR (MAX) NULL,
    [Breed]              NVARCHAR (MAX) NULL,
    [Age]                INT            NOT NULL,
    [Description]        NVARCHAR (MAX) NULL,
    [Diet]               NVARCHAR (MAX) NULL,
    [PetPictureUrl]      NVARCHAR (MAX) NULL,
    [UserId]             INT            NOT NULL,
    CONSTRAINT [PK_dbo.Pets] PRIMARY KEY CLUSTERED ([PetId] ASC),
    CONSTRAINT [FK_dbo.Pets_dbo.Species_SpeciesId] FOREIGN KEY ([SpeciesId]) REFERENCES [dbo].[Species] ([SpeciesId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Pets_dbo.ServiceUsers_User_ServiceUserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[ServiceUsers] ([ServiceUserId])
);


GO
CREATE NONCLUSTERED INDEX [IX_SpeciesId]
    ON [dbo].[Pets]([SpeciesId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[Pets]([UserId] ASC);

