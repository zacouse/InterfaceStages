USE [master]
GO

CREATE DATABASE GestionStage

use GestionStage

CREATE TABLE MilieuStage (
	IDMilieuStage INT PRIMARY KEY,
	Titre VARCHAR,
	[Description] VARCHAR,
	NoCivique VARCHAR,
	Rue VARCHAR,
	CodePostal VARCHAR,
	Province VARCHAR,
	Pays VARCHAR,
	NoTelephone VARCHAR,
	Etat BIT,
	DateHeureCreation DATETIME,
	DateHeureModification DATETIME
)
GO


CREATE TABLE Stage (
	IDStage INT,
	IDMilieuStage INT,
	DateHeureCreation DATETIME,
	DateHeureModification DATETIME
)
GO