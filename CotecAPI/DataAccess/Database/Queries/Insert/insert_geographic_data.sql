/* ------------------------------------
 *	File: insert_geographic.sql
 *
 *  Description: Script that loads all
 *  the countries and continents from
 *  the database. These can only be
 *  edited by the DBA and not by ordinary
 *  administrators.
 *
 *  by: @estalvgs1999
 *  TEC 2020 | CE3101
 * ------------------------------------*/

-- Select DB
USE COTEC_DB;
GO

-- INSERT Continents
INSERT INTO Continents (Name, Code)
VALUES ('Asia','AF'),
	   ('Africa', 'AS'),
	   ('Europe','EU'),
	   ('North America','NA'),
	   ('South America','SA'),
	   ('Oceania','OC'),
	   ('Antartica','AN');

-- INSERT African Countries
INSERT INTO Countries (Name, Code, ContinentCode, FlagUrl)
VALUES  ('Algeria','DZA','AF','https://www.countryflags.io/DZ/flat/64.png'),
		('Angola','AGO','AF','https://www.countryflags.io/AO/flat/64.png'),
		('Botswana','BWA','AF','https://www.countryflags.io/BW/flat/64.png'),
		('Burundi','BDI','AF','https://www.countryflags.io/BI/flat/64.png'),
		('Cameroon','CMR','AF','https://www.countryflags.io/CM/flat/64.png'),
		('Cape Verde','CPV','AF','https://www.countryflags.io/CV/flat/64.png'),
		('Central African Republic','CAF','AF','https://www.countryflags.io/CF/flat/64.png'),
		('Chad','TCD','AF','https://www.countryflags.io/TD/flat/64.png'),
		('Comoros','COM','AF','https://www.countryflags.io/KM/flat/64.png'),
		('Mayotte','MYT','AF','https://www.countryflags.io/YT/flat/64.png'),
		('Congo','COG','AF','https://www.countryflags.io/CG/flat/64.png'),
		('Congo','COD','AF','https://www.countryflags.io/CD/flat/64.png'),
		('Benin','BEN','AF','https://www.countryflags.io/BJ/flat/64.png'),
		('Equatorial Guinea','GNQ','AF','https://www.countryflags.io/GQ/flat/64.png'),
		('Ethiopia','ETH','AF','https://www.countryflags.io/ET/flat/64.png'),
		('Eritrea','ERI','AF','https://www.countryflags.io/ER/flat/64.png'),
		('Djibouti','DJI','AF','https://www.countryflags.io/DJ/flat/64.png'),
		('Gabon','GAB','AF','https://www.countryflags.io/GA/flat/64.png'),
		('Gambia','GMB','AF','https://www.countryflags.io/GM/flat/64.png'),
		('Ghana','GHA','AF','https://www.countryflags.io/GH/flat/64.png'),
		('Guinea','GIN','AF','https://www.countryflags.io/GN/flat/64.png'),
		('Cote dIvoire','CIV','AF','https://www.countryflags.io/CI/flat/64.png'),
		('Kenya','KEN','AF','https://www.countryflags.io/KE/flat/64.png'),
		('Lesotho','LSO','AF','https://www.countryflags.io/LS/flat/64.png'),
		('Liberia','LBR','AF','https://www.countryflags.io/LR/flat/64.png'),
		('Libyan Arab Jamahiriya','LBY','AF','https://www.countryflags.io/LY/flat/64.png'),
		('Madagascar','MDG','AF','https://www.countryflags.io/MG/flat/64.png'),
		('Malawi','MWI','AF','https://www.countryflags.io/MW/flat/64.png'),
		('Mali','MLI','AF','https://www.countryflags.io/ML/flat/64.png'),
		('Mauritania','MRT','AF','https://www.countryflags.io/MR/flat/64.png'),
		('Mauritius','MUS','AF','https://www.countryflags.io/MU/flat/64.png'),
		('Morocco','MAR','AF','https://www.countryflags.io/MA/flat/64.png'),
		('Mozambique','MOZ','AF','https://www.countryflags.io/MZ/flat/64.png'),
		('Namibia','NAM','AF','https://www.countryflags.io/NA/flat/64.png'),
		('Niger','NER','AF','https://www.countryflags.io/NE/flat/64.png'),
		('Nigeria','NGA','AF','https://www.countryflags.io/NG/flat/64.png'),
		('Guinea-Bissau','GNB','AF','https://www.countryflags.io/GW/flat/64.png'),
		('Reunion','REU','AF','https://www.countryflags.io/RE/flat/64.png'),
		('Rwanda','RWA','AF','https://www.countryflags.io/RW/flat/64.png'),
		('Saint Helena','SHN','AF','https://www.countryflags.io/SH/flat/64.png'),
		('Sao Tome and Principe','STP','AF','https://www.countryflags.io/ST/flat/64.png'),
		('Senegal','SEN','AF','https://www.countryflags.io/SN/flat/64.png'),
		('Seychelles','SYC','AF','https://www.countryflags.io/SC/flat/64.png'),
		('Sierra Leone','SLE','AF','https://www.countryflags.io/SL/flat/64.png'),
		('Somalia','SOM','AF','https://www.countryflags.io/SO/flat/64.png'),
		('South Africa','ZAF','AF','https://www.countryflags.io/ZA/flat/64.png'),
		('Zimbabwe','ZWE','AF','https://www.countryflags.io/ZW/flat/64.png'),
		('South Sudan','SSD','AF','https://www.countryflags.io/SS/flat/64.png'),
		('Western Sahara','ESH','AF','https://www.countryflags.io/EH/flat/64.png'),
		('Sudan','SDN','AF','https://www.countryflags.io/SD/flat/64.png'),
		('Swaziland','SWZ','AF','https://www.countryflags.io/SZ/flat/64.png'),
		('Togo','TGO','AF','https://www.countryflags.io/TG/flat/64.png'),
		('Tunisia','TUN','AF','https://www.countryflags.io/TN/flat/64.png'),
		('Uganda','UGA','AF','https://www.countryflags.io/UG/flat/64.png'),
		('Egypt','EGY','AF','https://www.countryflags.io/EG/flat/64.png'),
		('Tanzania','TZA','AF','https://www.countryflags.io/TZ/flat/64.png'),
		('Burkina Faso','BFA','AF','https://www.countryflags.io/BF/flat/64.png'),
		('Zambia','ZMB','AF','https://www.countryflags.io/ZM/flat/64.png');

-- INSERT Asian Countries
INSERT INTO Countries (Name, Code, ContinentCode, FlagUrl)
VALUES  ('Afghanistan','AFG','AS','https://www.countryflags.io/AF/flat/64.png'),
		('Bahrain','BHR','AS','https://www.countryflags.io/BH/flat/64.png'),
		('Bangladesh','BGD','AS','https://www.countryflags.io/BD/flat/64.png'),
		('Armenia','ARM','AS','https://www.countryflags.io/AM/flat/64.png'),
		('Bhutan','BTN','AS','https://www.countryflags.io/BT/flat/64.png'),
		('British Indian Ocean Territory','IOT','AS','https://www.countryflags.io/IO/flat/64.png'),
		('Brunei Darussalam','BRN','AS','https://www.countryflags.io/BN/flat/64.png'),
		('Myanmar','MMR','AS','https://www.countryflags.io/MM/flat/64.png'),
		('Cambodia','KHM','AS','https://www.countryflags.io/KH/flat/64.png'),
		('Sri Lanka','LKA','AS','https://www.countryflags.io/LK/flat/64.png'),
		('China','CHN','AS','https://www.countryflags.io/CN/flat/64.png'),
		('Taiwan','TWN','AS','https://www.countryflags.io/TW/flat/64.png'),
		('Christmas Island','CXR','AS','https://www.countryflags.io/CX/flat/64.png'),
		('Cocos (Keeling) Islands','CCK','AS','https://www.countryflags.io/CC/flat/64.png'),
		('Palestinian Territory','PSE','AS','https://www.countryflags.io/PS/flat/64.png'),
		('Hong Kong','HKG','AS','https://www.countryflags.io/HK/flat/64.png'),
		('India','IND','AS','https://www.countryflags.io/IN/flat/64.png'),
		('Indonesia','IDN','AS','https://www.countryflags.io/ID/flat/64.png'),
		('Iran','IRN','AS','https://www.countryflags.io/IR/flat/64.png'),
		('Iraq','IRQ','AS','https://www.countryflags.io/IQ/flat/64.png'),
		('Israel','ISR','AS','https://www.countryflags.io/IL/flat/64.png'),
		('Japan','JPN','AS','https://www.countryflags.io/JP/flat/64.png'),
		('Kazakhstan','KAZ','AS','https://www.countryflags.io/KZ/flat/64.png'),
		('Jordan','JOR','AS','https://www.countryflags.io/JO/flat/64.png'),
		('North Korea','PRK','AS','https://www.countryflags.io/KP/flat/64.png'),
		('South Korea','KOR','AS','https://www.countryflags.io/KR/flat/64.png'),
		('Kuwait','KWT','AS','https://www.countryflags.io/KW/flat/64.png'),
		('Kyrgyz Republic','KGZ','AS','https://www.countryflags.io/KG/flat/64.png'),
		('Lao Peoples Democratic Republic','LAO','AS','https://www.countryflags.io/LA/flat/64.png'),
		('Lebanon','LBN','AS','https://www.countryflags.io/LB/flat/64.png'),
		('Macao','MAC','AS','https://www.countryflags.io/MO/flat/64.png'),
		('Malaysia','MYS','AS','https://www.countryflags.io/MY/flat/64.png'),
		('Maldives','MDV','AS','https://www.countryflags.io/MV/flat/64.png'),
		('Mongolia','MNG','AS','https://www.countryflags.io/MN/flat/64.png'),
		('Oman','OMN','AS','https://www.countryflags.io/OM/flat/64.png'),
		('Nepal','NPL','AS','https://www.countryflags.io/NP/flat/64.png'),
		('Pakistan','PAK','AS','https://www.countryflags.io/PK/flat/64.png'),
		('Philippines','PHL','AS','https://www.countryflags.io/PH/flat/64.png'),
		('Timor-Leste','TLS','AS','https://www.countryflags.io/TL/flat/64.png'),
		('Qatar','QAT','AS','https://www.countryflags.io/QA/flat/64.png'),
		('Saudi Arabia','SAU','AS','https://www.countryflags.io/SA/flat/64.png'),
		('Singapore','SGP','AS','https://www.countryflags.io/SG/flat/64.png'),
		('Vietnam','VNM','AS','https://www.countryflags.io/VN/flat/64.png'),
		('Syrian Arab Republic','SYR','AS','https://www.countryflags.io/SY/flat/64.png'),
		('Tajikistan','TJK','AS','https://www.countryflags.io/TJ/flat/64.png'),
		('Thailand','THA','AS','https://www.countryflags.io/TH/flat/64.png'),
		('United Arab Emirates','ARE','AS','https://www.countryflags.io/AE/flat/64.png'),
		('Turkmenistan','TKM','AS','https://www.countryflags.io/TM/flat/64.png'),
		('Uzbekistan','UZB','AS','https://www.countryflags.io/UZ/flat/64.png'),
		('Yemen','YEM','AS','https://www.countryflags.io/YE/flat/64.png');

-- INSERT European Countries
INSERT INTO Countries (Name, Code, ContinentCode, FlagUrl)
VALUES ('Albania','ALB','EU','https://www.countryflags.io/AL/flat/64.png'),
		('Andorra','AND','EU','https://www.countryflags.io/AD/flat/64.png'),
		('Azerbaijan','AZE','EU','https://www.countryflags.io/AZ/flat/64.png'),
		('Austria','AUT','EU','https://www.countryflags.io/AT/flat/64.png'),
		('Belgium','BEL','EU','https://www.countryflags.io/BE/flat/64.png'),
		('Bosnia and Herzegovina','BIH','EU','https://www.countryflags.io/BA/flat/64.png'),
		('Bulgaria','BGR','EU','https://www.countryflags.io/BG/flat/64.png'),
		('Belarus','BLR','EU','https://www.countryflags.io/BY/flat/64.png'),
		('Croatia','HRV','EU','https://www.countryflags.io/HR/flat/64.png'),
		('Cyprus','CYP','EU','https://www.countryflags.io/CY/flat/64.png'),
		('Czech Republic','CZE','EU','https://www.countryflags.io/CZ/flat/64.png'),
		('Denmark','DNK','EU','https://www.countryflags.io/DK/flat/64.png'),
		('Estonia','EST','EU','https://www.countryflags.io/EE/flat/64.png'),
		('Faroe Islands','FRO','EU','https://www.countryflags.io/FO/flat/64.png'),
		('Finland','FIN','EU','https://www.countryflags.io/FI/flat/64.png'),
		('�land Islands','ALA','EU','https://www.countryflags.io/AX/flat/64.png'),
		('France','FRA','EU','https://www.countryflags.io/FR/flat/64.png'),
		('Georgia','GEO','EU','https://www.countryflags.io/GE/flat/64.png'),
		('Germany','DEU','EU','https://www.countryflags.io/DE/flat/64.png'),
		('Gibraltar','GIB','EU','https://www.countryflags.io/GI/flat/64.png'),
		('Greece','GRC','EU','https://www.countryflags.io/GR/flat/64.png'),
		('Vatican City State','VAT','EU','https://www.countryflags.io/VA/flat/64.png'),
		('Hungary','HUN','EU','https://www.countryflags.io/HU/flat/64.png'),
		('Iceland','ISL','EU','https://www.countryflags.io/IS/flat/64.png'),
		('Ireland','IRL','EU','https://www.countryflags.io/IE/flat/64.png'),
		('Italy','ITA','EU','https://www.countryflags.io/IT/flat/64.png'),
		('Latvia','LVA','EU','https://www.countryflags.io/LV/flat/64.png'),
		('Liechtenstein','LIE','EU','https://www.countryflags.io/LI/flat/64.png'),
		('Lithuania','LTU','EU','https://www.countryflags.io/LT/flat/64.png'),
		('Luxembourg','LUX','EU','https://www.countryflags.io/LU/flat/64.png'),
		('Malta','MLT','EU','https://www.countryflags.io/MT/flat/64.png'),
		('Monaco','MCO','EU','https://www.countryflags.io/MC/flat/64.png'),
		('Moldova','MDA','EU','https://www.countryflags.io/MD/flat/64.png'),
		('Montenegro','MNE','EU','https://www.countryflags.io/ME/flat/64.png'),
		('Netherlands','NLD','EU','https://www.countryflags.io/NL/flat/64.png'),
		('Norway','NOR','EU','https://www.countryflags.io/NO/flat/64.png'),
		('Poland','POL','EU','https://www.countryflags.io/PL/flat/64.png'),
		('Portugal','PRT','EU','https://www.countryflags.io/PT/flat/64.png'),
		('Romania','ROU','EU','https://www.countryflags.io/RO/flat/64.png'),
		('Russia','RUS','EU','https://www.countryflags.io/RU/flat/64.png'),
		('San Marino','SMR','EU','https://www.countryflags.io/SM/flat/64.png'),
		('Serbia','SRB','EU','https://www.countryflags.io/RS/flat/64.png'),
		('Slovakia','SVK','EU','https://www.countryflags.io/SK/flat/64.png'),
		('Slovenia','SVN','EU','https://www.countryflags.io/SI/flat/64.png'),
		('Spain','ESP','EU','https://www.countryflags.io/ES/flat/64.png'),
		('Svalbard & Jan Mayen Islands','SJM','EU','https://www.countryflags.io/SJ/flat/64.png'),
		('Sweden','SWE','EU','https://www.countryflags.io/SE/flat/64.png'),
		('Switzerland','CHE','EU','https://www.countryflags.io/CH/flat/64.png'),
		('Turkey','TUR','EU','https://www.countryflags.io/TR/flat/64.png'),
		('Ukraine','UKR','EU','https://www.countryflags.io/UA/flat/64.png'),
		('Macedonia','MKD','EU','https://www.countryflags.io/MK/flat/64.png'),
		('United Kingdom','GBR','EU','https://www.countryflags.io/GB/flat/64.png'),
		('Guernsey','GGY','EU','https://www.countryflags.io/GG/flat/64.png'),
		('Jersey','JEY','EU','https://www.countryflags.io/JE/flat/64.png'),
		('Isle of Man','IMN','EU','https://www.countryflags.io/IM/flat/64.png');

-- INSERT Oceania Countries
INSERT INTO Countries (Name, Code, ContinentCode, FlagUrl)
VALUES  ('American Samoa','ASM','OC','https://www.countryflags.io/AS/flat/64.png'),
		('Australia','AUS','OC','https://www.countryflags.io/AU/flat/64.png'),
		('Solomon Islands','SLB','OC','https://www.countryflags.io/SB/flat/64.png'),
		('Cook Islands','COK','OC','https://www.countryflags.io/CK/flat/64.png'),
		('Fiji','FJI','OC','https://www.countryflags.io/FJ/flat/64.png'),
		('French Polynesia','PYF','OC','https://www.countryflags.io/PF/flat/64.png'),
		('Kiribati','KIR','OC','https://www.countryflags.io/KI/flat/64.png'),
		('Guam','GUM','OC','https://www.countryflags.io/GU/flat/64.png'),
		('Nauru','NRU','OC','https://www.countryflags.io/NR/flat/64.png'),
		('New Caledonia','NCL','OC','https://www.countryflags.io/NC/flat/64.png'),
		('Vanuatu','VUT','OC','https://www.countryflags.io/VU/flat/64.png'),
		('New Zealand','NZL','OC','https://www.countryflags.io/NZ/flat/64.png'),
		('Niue','NIU','OC','https://www.countryflags.io/NU/flat/64.png'),
		('Norfolk Island','NFK','OC','https://www.countryflags.io/NF/flat/64.png'),
		('Northern Mariana Islands','MNP','OC','https://www.countryflags.io/MP/flat/64.png'),
		('Micronesia','FSM','OC','https://www.countryflags.io/FM/flat/64.png'),
		('Marshall Islands','MHL','OC','https://www.countryflags.io/MH/flat/64.png'),
		('Palau','PLW','OC','https://www.countryflags.io/PW/flat/64.png'),
		('Papua New Guinea','PNG','OC','https://www.countryflags.io/PG/flat/64.png'),
		('Pitcairn Islands','PCN','OC','https://www.countryflags.io/PN/flat/64.png'),
		('Tokelau','TKL','OC','https://www.countryflags.io/TK/flat/64.png'),
		('Tonga','TON','OC','https://www.countryflags.io/TO/flat/64.png'),
		('Tuvalu','TUV','OC','https://www.countryflags.io/TV/flat/64.png'),
		('Wallis and Futuna','WLF','OC','https://www.countryflags.io/WF/flat/64.png'),
		('Samoa','WSM','OC','https://www.countryflags.io/WS/flat/64.png');


-- INSERT North America Countries
INSERT INTO Countries (Name, Code, ContinentCode, FlagUrl)
VALUES  ('Antigua and Barbuda','ATG','NA','https://www.countryflags.io/AG/flat/64.png'),
		('Bahamas','BHS','NA','https://www.countryflags.io/BS/flat/64.png'),
		('Barbados','BRB','NA','https://www.countryflags.io/BB/flat/64.png'),
		('Bermuda','BMU','NA','https://www.countryflags.io/BM/flat/64.png'),
		('Belize','BLZ','NA','https://www.countryflags.io/BZ/flat/64.png'),
		('British Virgin Islands','VGB','NA','https://www.countryflags.io/VG/flat/64.png'),
		('Canada','CAN','NA','https://www.countryflags.io/CA/flat/64.png'),
		('Cayman Islands','CYM','NA','https://www.countryflags.io/KY/flat/64.png'),
		('Costa Rica','CRI','NA','https://www.countryflags.io/CR/flat/64.png'),
		('Cuba','CUB','NA','https://www.countryflags.io/CU/flat/64.png'),
		('Dominica','DMA','NA','https://www.countryflags.io/DM/flat/64.png'),
		('Dominican Republic','DOM','NA','https://www.countryflags.io/DO/flat/64.png'),
		('El Salvador','SLV','NA','https://www.countryflags.io/SV/flat/64.png'),
		('Greenland','GRL','NA','https://www.countryflags.io/GL/flat/64.png'),
		('Grenada','GRD','NA','https://www.countryflags.io/GD/flat/64.png'),
		('Guadeloupe','GLP','NA','https://www.countryflags.io/GP/flat/64.png'),
		('Guatemala','GTM','NA','https://www.countryflags.io/GT/flat/64.png'),
		('Haiti','HTI','NA','https://www.countryflags.io/HT/flat/64.png'),
		('Honduras','HND','NA','https://www.countryflags.io/HN/flat/64.png'),
		('Jamaica','JAM','NA','https://www.countryflags.io/JM/flat/64.png'),
		('Martinique','MTQ','NA','https://www.countryflags.io/MQ/flat/64.png'),
		('Mexico','MEX','NA','https://www.countryflags.io/MX/flat/64.png'),
		('Montserrat','MSR','NA','https://www.countryflags.io/MS/flat/64.png'),
		('Netherlands Antilles','ANT','NA','https://www.countryflags.io/AN/flat/64.png'),
		('Cura�ao','CUW','NA','https://www.countryflags.io/CW/flat/64.png'),
		('Aruba','ABW','NA','https://www.countryflags.io/AW/flat/64.png'),
		('Sint Maarten (Netherlands)','SXM','NA','https://www.countryflags.io/SX/flat/64.png'),
		('Bonaire','BES','NA','https://www.countryflags.io/BQ/flat/64.png'),
		('Nicaragua','NIC','NA','https://www.countryflags.io/NI/flat/64.png'),
		('United States Minor Outlying Islands','UMI','NA','https://www.countryflags.io/UM/flat/64.png'),
		('Panama','PAN','NA','https://www.countryflags.io/PA/flat/64.png'),
		('Puerto Rico','PRI','NA','https://www.countryflags.io/PR/flat/64.png'),
		('Saint Barthelemy','BLM','NA','https://www.countryflags.io/BL/flat/64.png'),
		('Saint Kitts and Nevis','KNA','NA','https://www.countryflags.io/KN/flat/64.png'),
		('Anguilla','AIA','NA','https://www.countryflags.io/AI/flat/64.png'),
		('Saint Lucia','LCA','NA','https://www.countryflags.io/LC/flat/64.png'),
		('Saint Martin','MAF','NA','https://www.countryflags.io/MF/flat/64.png'),
		('Saint Pierre and Miquelon','SPM','NA','https://www.countryflags.io/PM/flat/64.png'),
		('Saint Vincent and the Grenadines','VCT','NA','https://www.countryflags.io/VC/flat/64.png'),
		('Trinidad and Tobago','TTO','NA','https://www.countryflags.io/TT/flat/64.png'),
		('Turks and Caicos Islands','TCA','NA','https://www.countryflags.io/TC/flat/64.png'),
		('United States of America','USA','NA','https://www.countryflags.io/US/flat/64.png'),
		('United States Virgin Islands','VIR','NA','https://www.countryflags.io/VI/flat/64.png');


-- INSERT South America Countries
INSERT INTO Countries (Name, Code, ContinentCode, FlagUrl)
VALUES  ('Argentina','ARG','SA','https://www.countryflags.io/AR/flat/64.png'),
		('Bolivia','BOL','SA','https://www.countryflags.io/BO/flat/64.png'),
		('Brazil','BRA','SA','https://www.countryflags.io/BR/flat/64.png'),
		('Chile','CHL','SA','https://www.countryflags.io/CL/flat/64.png'),
		('Colombia','COL','SA','https://www.countryflags.io/CO/flat/64.png'),
		('Ecuador','ECU','SA','https://www.countryflags.io/EC/flat/64.png'),
		('Falkland Islands (Malvinas)','FLK','SA','https://www.countryflags.io/FK/flat/64.png'),
		('French Guiana','GUF','SA','https://www.countryflags.io/GF/flat/64.png'),
		('Guyana','GUY','SA','https://www.countryflags.io/GY/flat/64.png'),
		('Paraguay','PRY','SA','https://www.countryflags.io/PY/flat/64.png'),
		('Peru','PER','SA','https://www.countryflags.io/PE/flat/64.png'),
		('Suriname','SUR','SA','https://www.countryflags.io/SR/flat/64.png'),
		('Uruguay','URY','SA','https://www.countryflags.io/UY/flat/64.png'),
		('Venezuela','VEN','SA','https://www.countryflags.io/VE/flat/64.png');

-- INSERT Antartica Countries
INSERT INTO Countries (Name, Code, ContinentCode, FlagUrl)
VALUES  ('Antarctica (the territory South of 60 deg S)','ATA','AN','https://www.countryflags.io/AQ/flat/64.png'),
		('Bouvet Island (Bouvetoya)','BVT','AN','https://www.countryflags.io/BV/flat/64.png'),
		('South Georgia ','SGS','AN','https://www.countryflags.io/GS/flat/64.png'),
		('French Southern Territories','ATF','AN','https://www.countryflags.io/TF/flat/64.png'),
		('Heard Island and McDonald Islands','HMD','AN','https://www.countryflags.io/HM/flat/64.png');