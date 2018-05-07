/*
create database RabbitClub
go;
use RabbitClub;
go
*/
/*
drop TABLE [dbo].[Club]
drop TABLE [dbo].[MembersPhone]

drop TABLE [dbo].[Members]
*/
IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Members' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE  TABLE [dbo].[Members] (
			[MemberID] [INT] identity CONSTRAINT pk__Members_MemberID PRIMARY KEY,
			[MemberLastName] [NVARCHAR] (200),
			[MemberFirstName] [NVARCHAR] (200),
			[MemberNumber] [NVARCHAR] (10),

			[RegionID] [INT] CONSTRAINT fk_Members_RegionID REFERENCES Region(ID),
			[DistrictID] [INT] CONSTRAINT fk_Members_DistrictID REFERENCES District(ID),
			[CityID] [INT] CONSTRAINT fk_Members_CityID REFERENCES City(ID),
			
			[Address] [NVARCHAR] (200),
			[House] [NVARCHAR] (10),
			[Flat] [NVARCHAR] (10),
			[PostBox] [NVARCHAR] (200)
		)
	END
GO

IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Club' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE  TABLE [dbo].[Club] (
			[ClubID] [INT] identity CONSTRAINT pk__Club_ClubId  PRIMARY KEY,
			[ClubName] [NVARCHAR] (200),
			[ClubNumber] [NVARCHAR] (10),
			[ClubHeadID] [INT] CONSTRAINT fk_Club_ClubHeadID REFERENCES Members(MemberID),
			[City] [NVARCHAR] (200),
			[Address] [NVARCHAR] (200),
			[PostBox] [NVARCHAR] (200)
		)
	END
GO



IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PhoneTypes' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE  TABLE [dbo].[PhoneTypes] (
			[ID] [INT] CONSTRAINT pk_PhoneTypes_ID PRIMARY KEY,
			[PhoneType] [NVARCHAR] (50) NOT NULL

			CONSTRAINT uk_PhoneTypes_PhoneType UNIQUE (PhoneType),
		)
	END
GO


IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MembersPhone' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[MembersPhone] (
			[ID] [INT] identity CONSTRAINT pk_MembersPhone_ID PRIMARY KEY,
			[MemberID] [INT] CONSTRAINT fk_MembersPhone_MemberID REFERENCES Members(MemberID),
			
			[PhoneTypeID] [INT] CONSTRAINT fk_MembersPhone_PhoneTypeID REFERENCES PhoneTypes(ID),
			[PhoneNumber] [NVARCHAR] (200)

			CONSTRAINT uk_MembersPhone_MemberID UNIQUE (MemberID, PhoneNumber),
		)
	END
GO


IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[Users] (
			[Id] [INT] identity  CONSTRAINT pk__Users_ID PRIMARY KEY,
			[UserName] [NVARCHAR] (200),
			[UserEmail] [NVARCHAR] (200),
			[UserPassword] [NVARCHAR] (200),
			[UserTypeId] int,
			[isActive] [BIT] 
			
		)
	END
GO


IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Region' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE  TABLE [dbo].[Regions] (
			[ID] [INT] CONSTRAINT pk__Regions_ID PRIMARY KEY,
			[RegionName] [NVARCHAR] (200)
			
		)
	END
GO



IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'District' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[Districts] (
			[ID] [INT] CONSTRAINT pk__District_ID PRIMARY KEY,
			[DistrictName] [NVARCHAR] (200)
			
		)
	END
GO

IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'City' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[City] (
			[ID] [INT] CONSTRAINT pk__City_ID PRIMARY KEY,
			[CityName] [NVARCHAR] (200)
			
		)
	END
GO


IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'City' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[City] (
			[ID] [INT] CONSTRAINT pk__City_ID PRIMARY KEY,
			[CityName] [NVARCHAR] (200)
			
		)
	END
GO

IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Street' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[Street] (
			[ID] [INT] CONSTRAINT pk__Street_ID PRIMARY KEY,
			[StreetName] [NVARCHAR] (200)
		)
	END
GO

IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'AddressData' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[AddressData] (
			[ID] [INT] IDENTITY CONSTRAINT pk__AddressData_ID PRIMARY KEY,
			[RegionId] INT Not NULL CONSTRAINT fc_Region_RegionId FOREIGN KEY REFERENCES Region(Id),
			[DistrictId] INT Not NULL CONSTRAINT fc_District_DistrictId FOREIGN KEY REFERENCES District(Id),
			[CityId] INT Not NULL CONSTRAINT fc_City_CityId FOREIGN KEY REFERENCES City(Id),
			[StreetId] INT Not NULL CONSTRAINT fc_Street_StreetId FOREIGN KEY REFERENCES Street(Id),

			CONSTRAINT  uk_Region_District_Street UNIQUE (RegionId, DistrictId, CityId, StreetId)

		)
	END
GO


IF  EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RegionsDistrincts' AND TABLE_TYPE = 'VIEW' AND TABLE_SCHEMA = 'dbo')
BEGIN
	drop view RegionsDistrincts 
END
go

create   view RegionsDistrincts 
as
select distinct ad.RegionId, ad.DistrictId, d.DistrictName
	from AddressData ad
		inner join Region r on ad.RegionId = r.Id
		inner join District d on ad.DistrictId = d.Id
go

IF  EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RegionsDistrinctsCities' AND TABLE_TYPE = 'VIEW' AND TABLE_SCHEMA = 'dbo')
BEGIN
	drop view RegionsDistrinctsCities
END
go

create   view RegionsDistrinctsCities 
as
select distinct ad.RegionId, ad.DistrictId, d.DistrictName, ad.CityId, c.CityName
	from AddressData ad
		inner join Region r on ad.RegionId = r.Id
		inner join District d on ad.DistrictId = d.Id
		inner join City c on ad.CityId = c.ID
go


IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RabbitBreed' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[RabbitBreed] (
			[ID] [INT] IDENTITY CONSTRAINT pk__RabbitBreed_ID PRIMARY KEY,
			[BreedName] [NVARCHAR] (200)
		)
	END
GO

IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RabbitColor' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[RabbitColor] (
			[ID] [INT] IDENTITY CONSTRAINT pk__RabbitColor_ID PRIMARY KEY,
			[ColorName] [NVARCHAR] (200)
		)
	END
GO

IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Breeds' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[Breeds] (
			[ID] [INT] IDENTITY CONSTRAINT pk__Breeds_ID PRIMARY KEY,
			[RabbitBreedId] INT Not NULL CONSTRAINT fc_RabbitBreed_RabbitBreedId FOREIGN KEY REFERENCES RabbitBreed(Id),
			[RabbitColorId] INT Not NULL CONSTRAINT fc_RabbitColor_RabbitColorId FOREIGN KEY REFERENCES RabbitColor(Id)
		)
	END
GO

IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Breeds' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[Breeds] (
			[ID] [INT] IDENTITY CONSTRAINT pk__Breeds_ID PRIMARY KEY,
			[RabbitBreedId] INT Not NULL CONSTRAINT fc_RabbitBreed_RabbitBreedId FOREIGN KEY REFERENCES RabbitBreed(Id),
			[RabbitColorId] INT Not NULL CONSTRAINT fc_RabbitBreed_RabbitColorId FOREIGN KEY REFERENCES RabbitColor(Id)
		)
	END
GO

IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MemberBreeds' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[MemberBreeds] (
			[ID] [INT] IDENTITY CONSTRAINT pk__MemberBreeds_ID PRIMARY KEY,
			[MembersId] INT Not NULL CONSTRAINT fc_MemberBreeds_MembersId FOREIGN KEY REFERENCES Members(MemberID),
			[BreedsId] INT Not NULL CONSTRAINT fc_MemberBreeds_BreedsId FOREIGN KEY REFERENCES Breeds(Id),
			[RowCreated] DATETIME NOT NULL CONSTRAINT DF_MemberBreeds_RowCreated DEFAULT GETDATE()
		)
	END
GO


IF  EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'v_Members' AND TABLE_TYPE = 'VIEW' AND TABLE_SCHEMA = 'dbo')
BEGIN
	drop view v_Members 
END
go

create   view v_Members 
as
select m.MemberID, m.MemberFirstName, m.MemberLastName, m.MemberNumber
	,m.RegionID, r.RegionName, m.DistrictID, d.DistrictName,
	m.CityID, c.CityName, m.Address, m.House, m.Flat, m.PostBox
	from members m
		inner join Region r on m.RegionId = r.Id
		inner join District d on m.DistrictId = d.Id
		inner join City c on m.CityID = c.ID
go

IF  EXISTS ( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'v_RabbitBreedColorList' AND TABLE_TYPE = 'VIEW' AND TABLE_SCHEMA = 'dbo')
BEGIN
	drop view v_RabbitBreedColorList 
END
go

create   view v_RabbitBreedColorList 
as
select b.id as BreedId, b.BreedName
	,c.ID as ColorId, c.ColorName
	,br.id as BreedsId
	,case when br.id is null then 0 else 1 end as IsSelected
	from [dbo].[RabbitBreed] b
		inner join [dbo].[RabbitColor] c on 1=1
	left join [dbo].[Breeds] br  on c.ID = br.RabbitColorId and b.id = br.RabbitBreedId
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'UpdateRabbitColorrelation')
BEGIN
	DROP PROCEDURE UpdateRabbitColorrelation
END
GO

CREATE PROCEDURE UpdateRabbitColorrelation
@BreedId int
,@ColorId int
,@Value bit
AS
BEGIN
	IF @Value = 0
		DELETE FROM Breeds 
			WHERE RabbitBreedId = @BreedId AND RabbitColorId = @ColorId
	ELSE
	BEGIN
		UPDATE Breeds
		SET  RabbitBreedId = @BreedId, RabbitColorId = @ColorId
		WHERE RabbitBreedId = @BreedId AND RabbitColorId = @ColorId

		IF @@ROWCOUNT = 0
		INSERT INTO Breeds (RabbitBreedId, RabbitColorId) VALUES(@BreedId, @ColorId)
	END
END
GO


IF NOT EXISTS ( SELECT NULL FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'News' AND TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo')
	BEGIN
		CREATE TABLE [dbo].[News] (
			[Id] [INT] identity  CONSTRAINT pk__News_ID PRIMARY KEY,
			[Subject] [NVARCHAR] (200) NOT NULL,
			[Body] [NVARCHAR] (max) NOT NULL,
			[Image] [VARBINARY] (MAX),
			[UserId] int, --- needs to add references
			[isActive] [BIT] NOT NULL,
			[CreatedDate] [datetime] NOT NULL DEFAULT GETDATE()
			
		)
	END
GO
