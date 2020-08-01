USE COTEC_DB;
GO

-- Insert Patient Status
INSERT INTO PatientStatus (Name)
VALUES ('ACTIVE'),
	   ('INFECTED'),
	   ('RECOVERED'),
	   ('DEAD');

SELECT * FROM PatientStatus;

-- Insert CR Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('San Jose','CRI'),
	   ('Alajuela','CRI'),
	   ('Heredia','CRI'),
	   ('Cartago','CRI'),
	   ('Puntarenas','CRI'),
	   ('Guanacaste','CRI'),
	   ('Limon','CRI');

-- Insert USA Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Alabama','USA'),
	   ('Alaska','USA'),
	   ('Arkansas','USA'),
	   ('Colorado','USA'),
	   ('Connecticut','USA'),
	   ('Delaware','USA'),
	   ('Georgia','USA'),
	   ('Hawaii','USA'),
	   ('Idaho','USA'),
	   ('Illinois','USA'),
	   ('Iowa','USA'),
	   ('Indiana','USA'),
	   ('Kansas','USA'),
	   ('Kentucky','USA'),
	   ('Louisiana','USA'),
	   ('Maine','USA'),
	   ('Maryland','USA'),
	   ('Michigan','USA'),
	   ('Minnesota','USA'),
	   ('Mississippi','USA'),
	   ('Missouri','USA'),
	   ('Montana','USA'),
	   ('Nebraska','USA'),
	   ('Nevada','USA'),
	   ('New Mexico','USA'),
	   ('North Carolina','USA'),
	   ('North Dakota','USA'),
	   ('Oklahoma','USA'),
	   ('Oregon','USA'),
	   ('Tennesse','USA'),
	   ('Utah','USA'),
	   ('Virginia','USA');

-- Insert MEX Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Sonora','MEX'),
	   ('Chihuahua','MEX'),
	   ('Oaxaca','MEX'),
	   ('Yucatán','MEX'),
	   ('Puebla','MEX'),
	   ('Querétaro','MEX'),
	   ('Estado de Mexico','MEX');

-- Insert ESP Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Albacete','ESP'),
	   ('Asturias','ESP'),
	   ('Barcelona','ESP'),
	   ('Madrid','ESP'),
	   ('Cádiz','ESP'),
	   ('Gerona','ESP'),
	   ('Canarias','ESP'),
	   ('La Coruña','ESP'),
	   ('León','ESP'),
	   ('Valencia','ESP'),
	   ('Sevilla','ESP'),
	   ('Segovia','ESP'),
	   ('Valladolid','ESP'),
	   ('Zaragoza','ESP');

-- Insert FRA Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('París','FRA'),
	   ('Bourges','FRA'),
	   ('Orleans','FRA'),
	   ('Ruan','FRA'),
	   ('Tolosa','FRA'),
	   ('Lyon','FRA'),
	   ('Saintes','FRA'),
	   ('Burdeos','FRA'),
	   ('Dijon','FRA'),
	   ('Rennes','FRA');

-- Insert GBR Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Liverpool','GBR'),
	   ('Chelsea','GBR'),
	   ('Manchester','GBR'),
	   ('London','GBR'),
	   ('Cambridge','GBR'),
	   ('Glasgow','GBR'),
	   ('Leicester','GBR');

-- Insert PRT Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Porto','PRT'),
	   ('Villa Real','PRT'),
	   ('Lisboa','PRT'),
	   ('Faro','PRT'),
	   ('Coimbra','PRT'),
	   ('Aveiro','PRT'),
	   ('Portalegre','PRT');

-- Insert ITA Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Lombardia','ITA'),
	   ('Veneto','ITA'),
	   ('Sicilia','ITA'),
	   ('Piemonte','ITA'),
	   ('Lazio','ITA'),
	   ('Sardegna','ITA'),
	   ('Basilicata','ITA');

-- Insert CHN Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Beijing','CHN'),
	   ('Taiwan','CHN'),
	   ('Honk Kong','CHN'),
	   ('Shanghai','CHN');

-- Insert RUS Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Saint Petersburg','RUS'),
	   ('Saransk','RUS'),
	   ('kazan','RUS'),
	   ('Sochi','RUS'),
	   ('Volgograd','RUS'),
	   ('Moscow','RUS'),
	   ('Samara','RUS');

-- Insert ARG Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Buenos  Aires','ARG'),
	   ('Chaco','ARG'),
	   ('La Pampa','ARG'),
	   ('Santa Cruz','ARG'),
	   ('Misiones','ARG'),
	   ('Chubut','ARG'),
	   ('Mendoza','ARG');

-- Insert BRA Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Paraná','BRA'),
	   ('Minas Gerais','BRA'),
	   ('Bahía','BRA'),
	   ('Pernambuco','BRA'),
	   ('Sao Paulo','BRA'),
	   ('Janeiro','BRA'),
	   ('Espirito Santo','BRA');

-- Insert CHL Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Santiago','CHL'),
	   ('La Serena','CHL'),
	   ('Puerto Montt','CHL'),
	   ('Antagofasta','CHL'),
	   ('St Concepción','CHL');

-- Insert COL Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Antoquia','COL'),
	   ('Bogotá','COL'),
	   ('Boyacá','COL'),
	   ('Cartagena','COL'),
	   ('Tolima','COL'),
	   ('Medellín','COL'),
	   ('Barranquilla','COL');

-- Insert JPN Regions
INSERT INTO Regions (Name,CountryCode)
VALUES ('Kyoto','JPN'),
	   ('Tokyo','JPN'),
	   ('Kagawa','JPN'),
	   ('Okinawa','JPN'),
	   ('Nagasaki','JPN'),
	   ('Nagano','JPN'),
	   ('Nara','JPN');

--SELECT * FROM Countries ORDER BY  Code;
--SELECT * FROM Regions WHERE CountryCode='USA';