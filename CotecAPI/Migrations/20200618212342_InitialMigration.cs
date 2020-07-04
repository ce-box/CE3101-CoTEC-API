using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CotecAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContainmentMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainmentMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(2)", nullable: false),
                    Name = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Pathologies",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Symptoms = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false),
                    Treatment = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pathologies", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "PatientStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaceuticalCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaceuticalCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanitaryMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanitaryMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(3)", nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", nullable: false),
                    FlagUrl = table.Column<string>(type: "varchar(45)", nullable: true),
                    ContinentCode = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentCode",
                        column: x => x.ContinentCode,
                        principalTable: "Continents",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(60)", nullable: false),
                    PharmaceuticCo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medications_PharmaceuticalCompanies_PharmaceuticCo",
                        column: x => x.PharmaceuticCo,
                        principalTable: "PharmaceuticalCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Admins_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryContainmentMeasures",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "varchar(3)", nullable: false),
                    MeasureId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryContainmentMeasures", x => new { x.CountryCode, x.MeasureId });
                    table.ForeignKey(
                        name: "FK_CountryContainmentMeasures_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_CountryContainmentMeasures_ContainmentMeasures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "ContainmentMeasures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CountrySanitaryMeasures",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "varchar(3)", nullable: false),
                    MeasureId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountrySanitaryMeasures", x => new { x.CountryCode, x.MeasureId });
                    table.ForeignKey(
                        name: "FK_CountrySanitaryMeasures_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_CountrySanitaryMeasures_SanitaryMeasures_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "SanitaryMeasures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(20)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => new { x.Name, x.CountryCode });
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactedPersons",
                columns: table => new
                {
                    Dni = table.Column<string>(type: "varchar(30)", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    DoB = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", nullable: false),
                    Region = table.Column<string>(type: "varchar(50)", nullable: false),
                    Country = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactedPersons", x => x.Dni);
                    table.ForeignKey(
                        name: "FK_ContactedPersons_Regions_Region_Country",
                        columns: x => new { x.Region, x.Country },
                        principalTable: "Regions",
                        principalColumns: new[] { "Name", "CountryCode" });
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    ManagerName = table.Column<string>(type: "varchar(60)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    ICU_Capacity = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "varchar(50)", nullable: false),
                    Country = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Regions_Region_Country",
                        columns: x => new { x.Region, x.Country },
                        principalTable: "Regions",
                        principalColumns: new[] { "Name", "CountryCode" });
                });

            migrationBuilder.CreateTable(
                name: "PersonPathologies",
                columns: table => new
                {
                    PersonDni = table.Column<string>(type: "varchar(30)", nullable: false),
                    PathologyName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPathologies", x => new { x.PathologyName, x.PersonDni });
                    table.ForeignKey(
                        name: "FK_PersonPathologies_Pathologies_PathologyName",
                        column: x => x.PathologyName,
                        principalTable: "Pathologies",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_PersonPathologies_ContactedPersons_PersonDni",
                        column: x => x.PersonDni,
                        principalTable: "ContactedPersons",
                        principalColumn: "Dni");
                });

            migrationBuilder.CreateTable(
                name: "HospitalEmployees",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    Hospital_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalEmployees", x => x.Username);
                    table.ForeignKey(
                        name: "FK_HospitalEmployees_Hospitals_Hospital_Id",
                        column: x => x.Hospital_Id,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Dni = table.Column<string>(type: "varchar(30)", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    DoB = table.Column<DateTime>(type: "date", nullable: false),
                    Hospitalized = table.Column<bool>(type: "bit", nullable: false),
                    ICU = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Hospital_Id = table.Column<int>(type: "int", nullable: false),
                    Region = table.Column<string>(type: "varchar(50)", nullable: false),
                    Country = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Dni);
                    table.ForeignKey(
                        name: "FK_Patients_Hospitals_Hospital_Id",
                        column: x => x.Hospital_Id,
                        principalTable: "Hospitals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_PatientStatus_Status",
                        column: x => x.Status,
                        principalTable: "PatientStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Regions_Region_Country",
                        columns: x => new { x.Region, x.Country },
                        principalTable: "Regions",
                        principalColumns: new[] { "Name", "CountryCode" });
                });

            migrationBuilder.CreateTable(
                name: "PatientMedications",
                columns: table => new
                {
                    PatientDni = table.Column<string>(type: "varchar(30)", nullable: false),
                    MedicationId = table.Column<int>(type: "int", nullable: false),
                    Prescription = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedications", x => new { x.MedicationId, x.PatientDni });
                    table.ForeignKey(
                        name: "FK_PatientMedications_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientMedications_Patients_PatientDni",
                        column: x => x.PatientDni,
                        principalTable: "Patients",
                        principalColumn: "Dni");
                });

            migrationBuilder.CreateTable(
                name: "PatientPathologies",
                columns: table => new
                {
                    PatientDni = table.Column<string>(type: "varchar(30)", nullable: false),
                    PathologyName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPathologies", x => new { x.PathologyName, x.PatientDni });
                    table.ForeignKey(
                        name: "FK_PatientPathologies_Pathologies_PathologyName",
                        column: x => x.PathologyName,
                        principalTable: "Pathologies",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_PatientPathologies_Patients_PatientDni",
                        column: x => x.PatientDni,
                        principalTable: "Patients",
                        principalColumn: "Dni");
                });

            migrationBuilder.CreateTable(
                name: "PersonsContactedByPatient",
                columns: table => new
                {
                    PatientDni = table.Column<string>(type: "varchar(30)", nullable: false),
                    ContactDni = table.Column<string>(type: "varchar(30)", nullable: false),
                    MeetingDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonsContactedByPatient", x => new { x.ContactDni, x.PatientDni });
                    table.ForeignKey(
                        name: "FK_PersonsContactedByPatient_ContactedPersons_ContactDni",
                        column: x => x.ContactDni,
                        principalTable: "ContactedPersons",
                        principalColumn: "Dni");
                    table.ForeignKey(
                        name: "FK_PersonsContactedByPatient_Patients_PatientDni",
                        column: x => x.PatientDni,
                        principalTable: "Patients",
                        principalColumn: "Dni");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_CountryCode",
                table: "Admins",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_ContactedPersons_Region_Country",
                table: "ContactedPersons",
                columns: new[] { "Region", "Country" });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentCode",
                table: "Countries",
                column: "ContinentCode");

            migrationBuilder.CreateIndex(
                name: "IX_CountryContainmentMeasures_MeasureId",
                table: "CountryContainmentMeasures",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySanitaryMeasures_MeasureId",
                table: "CountrySanitaryMeasures",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CountryCode",
                table: "Events",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalEmployees_Hospital_Id",
                table: "HospitalEmployees",
                column: "Hospital_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_Region_Country",
                table: "Hospitals",
                columns: new[] { "Region", "Country" });

            migrationBuilder.CreateIndex(
                name: "IX_Medications_PharmaceuticCo",
                table: "Medications",
                column: "PharmaceuticCo");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedications_PatientDni",
                table: "PatientMedications",
                column: "PatientDni");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPathologies_PatientDni",
                table: "PatientPathologies",
                column: "PatientDni");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Hospital_Id",
                table: "Patients",
                column: "Hospital_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Status",
                table: "Patients",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Region_Country",
                table: "Patients",
                columns: new[] { "Region", "Country" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPathologies_PersonDni",
                table: "PersonPathologies",
                column: "PersonDni");

            migrationBuilder.CreateIndex(
                name: "IX_PersonsContactedByPatient_PatientDni",
                table: "PersonsContactedByPatient",
                column: "PatientDni");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryCode",
                table: "Regions",
                column: "CountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CountryContainmentMeasures");

            migrationBuilder.DropTable(
                name: "CountrySanitaryMeasures");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "HospitalEmployees");

            migrationBuilder.DropTable(
                name: "PatientMedications");

            migrationBuilder.DropTable(
                name: "PatientPathologies");

            migrationBuilder.DropTable(
                name: "PersonPathologies");

            migrationBuilder.DropTable(
                name: "PersonsContactedByPatient");

            migrationBuilder.DropTable(
                name: "ContainmentMeasures");

            migrationBuilder.DropTable(
                name: "SanitaryMeasures");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Pathologies");

            migrationBuilder.DropTable(
                name: "ContactedPersons");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "PharmaceuticalCompanies");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "PatientStatus");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Continents");
        }
    }
}
