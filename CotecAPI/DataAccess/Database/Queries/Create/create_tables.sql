/* ------------------------------------
 *	File: create_tables.sql
 *  by: @estalvgs1999
 *
 *  TEC 2020 | CE3101
 * ------------------------------------*/

-- SQL Database
CREATE DATABASE COTEC_DB;
GO

-- Database Tables
USE COTEC_DB;
GO

-- ------------------------------------------------------------------

CREATE TABLE Continent (
  Code varchar(2),
  Name varchar(15),
  PRIMARY KEY (Code)
);

CREATE TABLE Country (
  Code varchar(3),
  Name varchar(50),
  ContinentCode varchar(2) FOREIGN KEY REFERENCES Continent(Code),
  FlagUrl varchar(45),
  PRIMARY KEY (Code)
);

CREATE TABLE Region (
  Name varchar(50),
  CountryCode varchar(3) FOREIGN KEY REFERENCES Country(Code),
  PRIMARY KEY (Name,CountryCode)
);

CREATE TABLE Admin (
  Username varchar(20),
  Password varchar(20),
  Name varchar(20),
  LastName varchar(20),
  CountryCode varchar(3) FOREIGN KEY REFERENCES Country(Code),
  PRIMARY KEY (Username)
);

-- ------------------------------------------------------------------

CREATE TABLE SanitaryMeasure (
  Id int,
  Name varchar(255),
  Description varchar(255),
  PRIMARY KEY (Id)
);

CREATE TABLE ContainmentMeasure (
  Id int,
  Name varchar(255),
  Description varchar(255),
  PRIMARY KEY (Id)
);

CREATE TABLE Event (
  Id int,
  Type varchar(20),
  Date date,
  Country varchar(3) FOREIGN KEY REFERENCES Country(Code),
  PRIMARY KEY (Id)
);

CREATE TABLE CountrySanitaryMeasures (
  CountryCode varchar(3) FOREIGN KEY REFERENCES Country(Code),
  MeasureId int  FOREIGN KEY REFERENCES SanitaryMeasure(Id),
  Startdate date,
  EndDate date,
  Status varchar(15),
  PRIMARY KEY(CountryCode,MeasureId)
);

CREATE TABLE CountryContainmentMeasures (
  CountryCode varchar(3) FOREIGN KEY REFERENCES Country(Code),
  MeasureId int  FOREIGN KEY REFERENCES ContainmentMeasure(Id),
  Startdate date,
  EndDate date,
  Status varchar(15),
  PRIMARY KEY(CountryCode,MeasureId)
);

-- ------------------------------------------------------------------

CREATE TABLE PharmaceuticalCompany (
  Id int,
  Name varchar(60),
  PRIMARY KEY (Id)
);

CREATE TABLE Medication (
  Id int,
  Name varchar(60),
  PharmaceuticCo int FOREIGN KEY REFERENCES PharmaceuticalCompany(Id),
  PRIMARY KEY (Id)
);

CREATE TABLE Pathology (
  Name varchar(50),
  Symptoms varchar(255),
  Description varchar(255),
  Treatment varchar(255),
  PRIMARY KEY (Name)
);

CREATE TABLE PatientStatus (
  Id int,
  Name varchar(20),
  PRIMARY KEY (Id)
);

-- ------------------------------------------------------------------

CREATE TABLE Hospital (
  Id int,
  Name varchar(255),
  ManagerName varchar(60),
  Phone varchar(15),
  Capacity int,
  ICU_Capacity int,
  Region varchar(50),
  Country varchar(3),
  PRIMARY KEY (Id),
  FOREIGN KEY (Region,Country) REFERENCES Region(Name,CountryCode)
);

CREATE TABLE HospitalEmployee (
  Username varchar(20),
  Password varchar(20),
  Name varchar(20),
  LastName varchar(20),
  Hospital_Id int FOREIGN KEY REFERENCES Hospital(Id),
  PRIMARY KEY (Username)
);

CREATE TABLE Patient (
  Dni varchar(30),
  Name varchar(20),
  LastName varchar(20),
  BoD date,
  Status int FOREIGN KEY REFERENCES PatientStatus(Id),
  Hospitalized bit,
  ICU bit,
  Hospital_Id int FOREIGN KEY REFERENCES Hospital(Id),
  Region varchar(50),
  Country varchar(3),
  PRIMARY KEY (Dni),
  FOREIGN KEY (Region,Country) REFERENCES Region(Name,CountryCode)
);

CREATE TABLE ContactedPerson (
  Dni varchar(30),
  Name varchar(20),
  LastName varchar(20),
  DoB date,
  Email varchar(60),
  Region varchar(50),
  Country varchar(3),
  PRIMARY KEY (Dni),
  FOREIGN KEY (Region,Country) REFERENCES Region(Name,CountryCode)
);

CREATE TABLE PersonsContactedByPatient (
  PatientDni varchar(30) FOREIGN KEY REFERENCES Patient(Dni),
  ContactDni varchar(30) FOREIGN KEY REFERENCES ContactedPerson(Dni),
  MeetingDate date,
  PRIMARY KEY (PatientDni,ContactDni)
);

CREATE TABLE PatientPathologies (
  PatientDni varchar(30) FOREIGN KEY REFERENCES Patient(Dni),
  PathologyName varchar(50) FOREIGN KEY REFERENCES Pathology(Name),
  PRIMARY KEY (PatientDni,PathologyName)
);

CREATE TABLE PersonPathologies (
  PersonDni varchar(30) FOREIGN KEY REFERENCES ContactedPerson(Dni),
  PathologyName varchar(50) FOREIGN KEY REFERENCES Pathology(Name),
  PRIMARY KEY (PersonDni,PathologyName)
);

CREATE TABLE PatientMedications (
  PatientDni varchar(30) FOREIGN KEY REFERENCES Patient(Dni),
  MedicationId int FOREIGN KEY REFERENCES Medication(Id),
  Prescription varchar(255),
  PRIMARY KEY (PatientDni,MedicationId)
);




