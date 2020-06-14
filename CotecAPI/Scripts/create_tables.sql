-- SQL Database
create database cotecDB;

-- Database Tables
use cotecDB;

-- These databases cannot be edited by the users

create table Continents (
	Code varchar(2) primary key,
	Name varchar(15) not null
);

create table Countries (
	Code varchar(3) NOT NULL primary key, 
	Name varchar(50) NOT NULL,
	ContinentCode varchar(2) NOT NULL foreign key references Continents(Code),
	FlagUrl varchar(45) NOT NULL, -- Url fromat: https://www.countryflags.io/AB/flat/64.png
);


-- Regions Table

create table Regions (
	Name varchar(50) NOT NULL,
	CountryCode varchar(3) NOT NULL foreign key references Countries(Code),
	primary key(Name,CountryCode)
);

-- Users Tables

create table Admins (
	Username varchar(20) NOT NULL,
	Email varchar(30) NOT NULL,
	Password varchar(20) NOT NULL,
	Name varchar(20) NOT NULL,
	LastName varchar(20),
	CountryCode varchar(3) NOT NULL foreign key references Countries(Code),
	primary key(Username, Email)
);

create table PatientStatus(
	Id int identity(1,1) primary key,
	Name varchar(20) NOT NULL
);


-- TODO: Implement HospitalEmployees Table

-- Measurements Tables

create table SanityMeasurements (
	Id int identity(1,1) primary key,
	Name varchar(255) NOT NULL,
	Description varchar(255)
);

create table CountryMeasurements (
	
	CountryCode varchar(3) foreign key references Countries(Code),
	MeasurementId int foreign key references SanityMeasurements(Id),
	StartDate date,
	EndDate date,
	Status varchar(15),
	primary key(CountryCode, MeasurementId),
	check(Status in ('ACTIVE','INACTIVE'))
);

-- Hospital Tables

create table Hospital(
	
	Id int identity(1,1) primary key,
	Name varchar(255) NOT NULL,
	ManagerName varchar(60) NOT NULL,
	Capacity int NOT NULL,
	ICU_Capacity int NOT NULL,
	Phone varchar(15), -- Twilio recomendation https://support.twilio.com/hc/en-us/articles/223183008-Formatting-International-Phone-Numbers,
	Region varchar(50) NOT NULL,
	Country varchar(3) NOT NULL,
	foreign key (Region, Country) references Regions(Name, CountryCode)
);

create table PharmaceuticalCompanies(
	Id int identity(1,1) primary key,
	Name varchar(60) NOT NULL
);

create table Medications (
	Id int identity(1,1) primary key,
	Name varchar(60) NOT NULL,
	PharmaceuticalCo int foreign key references PharmaceuticalCompanies(Id)
);

create table Pathologies (
	Name varchar(255) NOT NULL primary key,
	Symptoms varchar(255),
	Description varchar(255),
	Treatment varchar(255)
);

create table Patients (
	Dni varchar(30) primary key,
	Name varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	Birthdate date NOT NULL,
	StatusId int foreign key references PatientStatus(Id),
	Hospitalized bit NOT NULL default 0,
	ICU bit NOT NULL default 0,
	Region varchar(50) NOT NULL,
	Country varchar(3) NOT NULL,
	foreign key (Region, Country) references Regions(Name, CountryCode)
);

-- Quedé haciendo las tablas de relacion entre Pacientes y medicamento y patologías
