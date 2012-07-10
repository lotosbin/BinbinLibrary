CREATE TABLE [dbo].[Url]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [WebsiteId] INT NOT NULL, 
    [Url] NVARCHAR(200) NOT NULL, 
    CONSTRAINT [FK_Url_ToWebsite] FOREIGN KEY ([WebsiteId]) REFERENCES [Website]([Id]))
