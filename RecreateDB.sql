USE AddressBookDB;

/* Пересоздание базы данных */
DROP TABLE Addresses
DROP TABLE TypeBuilding

CREATE TABLE TypeBuilding (
    BuildingId	INT					 IDENTITY (1, 1) NOT NULL,
    TypeBuild	NVARCHAR (50)		 NOT NULL,
    CONSTRAINT	primary_build_id	 PRIMARY KEY (BuildingId)
);

CREATE TABLE Addresses (
    AddressId	 INT				 IDENTITY (1, 1) NOT NULL,
    Country		 NVARCHAR (50)		 NOT NULL,
    City		 NVARCHAR (50)		 NOT NULL,
    Street		 NVARCHAR (50)		 NULL,
    HouseNumber	 INT				 NULL,
    Date		 DATETIME			 DEFAULT (getdate()) NOT NULL,
	TypeBuildId	 INT				 NULL,
	CONSTRAINT	 foreign_address	 FOREIGN KEY (TypeBuild) REFERENCES TypeBuilding(BuildingId),
    CONSTRAINT	 primary_address_id	 PRIMARY KEY (AddressID)
);