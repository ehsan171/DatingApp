using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class InitialResourceAll4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basic",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BasicDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Parent = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occasions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occasions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgStructures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    IsInner = table.Column<bool>(nullable: false),
                    OrgId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgStructures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    IdCode = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PMDSPSItem",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    CleanTitle = table.Column<string>(nullable: true),
                    Sys_Title_FirstAscii = table.Column<int>(nullable: true),
                    Sys_Title_Lenght = table.Column<int>(nullable: true),
                    TypeID = table.Column<int>(nullable: false),
                    ParentID = table.Column<int>(nullable: true),
                    MyProperty = table.Column<string>(nullable: true),
                    IsSys = table.Column<bool>(nullable: true),
                    Order = table.Column<int>(nullable: true),
                    Value = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    RUserID = table.Column<int>(nullable: false),
                    RDate = table.Column<DateTime>(nullable: true),
                    EDate = table.Column<DateTime>(nullable: true),
                    EUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PMDSPSItem", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectDetail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "RecordTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "TimeSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Hour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    photoUrl = table.Column<string>(nullable: true),
                    OrgId = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ImgPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    BasicDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resources_BasicDatas_BasicDataId",
                        column: x => x.BasicDataId,
                        principalTable: "BasicDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barname",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    BaravordNo = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barname", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barname_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Screenplays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    TotalNumberEpisodes = table.Column<int>(nullable: true),
                    BaravordNo = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenplays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenplays_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessDataRegs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ScreenplayId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessDataRegs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessDataRegs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceOccasions",
                columns: table => new
                {
                    ResourceId = table.Column<int>(nullable: false),
                    OccasionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceOccasions", x => new { x.ResourceId, x.OccasionId });
                    table.ForeignKey(
                        name: "FK_ResourceOccasions_Occasions_OccasionId",
                        column: x => x.OccasionId,
                        principalTable: "Occasions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceOccasions_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Hour = table.Column<int>(nullable: false),
                    UsedUnit = table.Column<int>(nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: true),
                    ResourceId = table.Column<int>(nullable: false),
                    BarnameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allocations_Barname_BarnameId",
                        column: x => x.BarnameId,
                        principalTable: "Barname",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Allocations_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarnameGroups",
                columns: table => new
                {
                    BarnameId = table.Column<int>(nullable: false),
                    BasicDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarnameGroups", x => new { x.BarnameId, x.BasicDataId });
                    table.ForeignKey(
                        name: "FK_BarnameGroups_Barname_BarnameId",
                        column: x => x.BarnameId,
                        principalTable: "Barname",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarnameGroups_BasicDatas_BasicDataId",
                        column: x => x.BasicDataId,
                        principalTable: "BasicDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarnameNetworks",
                columns: table => new
                {
                    BarnameId = table.Column<int>(nullable: false),
                    BasicDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarnameNetworks", x => new { x.BarnameId, x.BasicDataId });
                    table.ForeignKey(
                        name: "FK_BarnameNetworks_Barname_BarnameId",
                        column: x => x.BarnameId,
                        principalTable: "Barname",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarnameNetworks_BasicDatas_BasicDataId",
                        column: x => x.BasicDataId,
                        principalTable: "BasicDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarnameProducers",
                columns: table => new
                {
                    BarnameId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarnameProducers", x => new { x.BarnameId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_BarnameProducers_Barname_BarnameId",
                        column: x => x.BarnameId,
                        principalTable: "Barname",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarnameProducers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    BarnameId = table.Column<int>(nullable: true),
                    RecordTypeId = table.Column<int>(nullable: true),
                    OccasionId = table.Column<int>(nullable: true),
                    RegDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RRequests_Barname_BarnameId",
                        column: x => x.BarnameId,
                        principalTable: "Barname",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RRequests_Occasions_OccasionId",
                        column: x => x.OccasionId,
                        principalTable: "Occasions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RRequests_RecordTypes_RecordTypeId",
                        column: x => x.RecordTypeId,
                        principalTable: "RecordTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    EpisodeNumber = table.Column<int>(nullable: false),
                    EpisodeTitle = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ScreenplayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Screenplays_ScreenplayId",
                        column: x => x.ScreenplayId,
                        principalTable: "Screenplays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreenplayFormats",
                columns: table => new
                {
                    ScreenplayId = table.Column<int>(nullable: false),
                    PMDSPSItemItemID = table.Column<int>(nullable: false),
                    BarnameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenplayFormats", x => new { x.ScreenplayId, x.PMDSPSItemItemID });
                    table.ForeignKey(
                        name: "FK_ScreenplayFormats_Barname_BarnameId",
                        column: x => x.BarnameId,
                        principalTable: "Barname",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScreenplayFormats_PMDSPSItem_PMDSPSItemItemID",
                        column: x => x.PMDSPSItemItemID,
                        principalTable: "PMDSPSItem",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenplayFormats_Screenplays_ScreenplayId",
                        column: x => x.ScreenplayId,
                        principalTable: "Screenplays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreenplayGenres",
                columns: table => new
                {
                    ScreenplayId = table.Column<int>(nullable: false),
                    PMDSPSItemItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenplayGenres", x => new { x.ScreenplayId, x.PMDSPSItemItemID });
                    table.ForeignKey(
                        name: "FK_ScreenplayGenres_PMDSPSItem_PMDSPSItemItemID",
                        column: x => x.PMDSPSItemItemID,
                        principalTable: "PMDSPSItem",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenplayGenres_Screenplays_ScreenplayId",
                        column: x => x.ScreenplayId,
                        principalTable: "Screenplays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreenplayOrgStructures",
                columns: table => new
                {
                    ScreenplayId = table.Column<int>(nullable: false),
                    PMDSPSItemItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenplayOrgStructures", x => new { x.ScreenplayId, x.PMDSPSItemItemID });
                    table.ForeignKey(
                        name: "FK_ScreenplayOrgStructures_PMDSPSItem_PMDSPSItemItemID",
                        column: x => x.PMDSPSItemItemID,
                        principalTable: "PMDSPSItem",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenplayOrgStructures_Screenplays_ScreenplayId",
                        column: x => x.ScreenplayId,
                        principalTable: "Screenplays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScreenplayProducers",
                columns: table => new
                {
                    ScreenplayId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenplayProducers", x => new { x.ScreenplayId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_ScreenplayProducers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScreenplayProducers_Screenplays_ScreenplayId",
                        column: x => x.ScreenplayId,
                        principalTable: "Screenplays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RRequestResources",
                columns: table => new
                {
                    RRequestId = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RRequestResources", x => new { x.ResourceId, x.RRequestId });
                    table.ForeignKey(
                        name: "FK_RRequestResources_RRequests_RRequestId",
                        column: x => x.RRequestId,
                        principalTable: "RRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RRequestResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeConcepts",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false),
                    PMDSPSItemItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeConcepts", x => new { x.EpisodeId, x.PMDSPSItemItemID });
                    table.ForeignKey(
                        name: "FK_EpisodeConcepts_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeConcepts_PMDSPSItem_PMDSPSItemItemID",
                        column: x => x.PMDSPSItemItemID,
                        principalTable: "PMDSPSItem",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeWriters",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeWriters", x => new { x.EpisodeId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_EpisodeWriters_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodeWriters_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_BarnameId",
                table: "Allocations",
                column: "BarnameId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_ResourceId",
                table: "Allocations",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Barname_StatusId",
                table: "Barname",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BarnameGroups_BasicDataId",
                table: "BarnameGroups",
                column: "BasicDataId");

            migrationBuilder.CreateIndex(
                name: "IX_BarnameNetworks_BasicDataId",
                table: "BarnameNetworks",
                column: "BasicDataId");

            migrationBuilder.CreateIndex(
                name: "IX_BarnameProducers_PersonId",
                table: "BarnameProducers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectId",
                table: "EmployeeProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeConcepts_PMDSPSItemItemID",
                table: "EpisodeConcepts",
                column: "PMDSPSItemItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_ScreenplayId",
                table: "Episodes",
                column: "ScreenplayId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeWriters_PersonId",
                table: "EpisodeWriters",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_UserId",
                table: "Photo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDataRegs_UserId",
                table: "ProcessDataRegs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceOccasions_OccasionId",
                table: "ResourceOccasions",
                column: "OccasionId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_BasicDataId",
                table: "Resources",
                column: "BasicDataId");

            migrationBuilder.CreateIndex(
                name: "IX_RRequestResources_RRequestId",
                table: "RRequestResources",
                column: "RRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RRequests_BarnameId",
                table: "RRequests",
                column: "BarnameId");

            migrationBuilder.CreateIndex(
                name: "IX_RRequests_OccasionId",
                table: "RRequests",
                column: "OccasionId");

            migrationBuilder.CreateIndex(
                name: "IX_RRequests_RecordTypeId",
                table: "RRequests",
                column: "RecordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenplayFormats_BarnameId",
                table: "ScreenplayFormats",
                column: "BarnameId");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenplayFormats_PMDSPSItemItemID",
                table: "ScreenplayFormats",
                column: "PMDSPSItemItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenplayGenres_PMDSPSItemItemID",
                table: "ScreenplayGenres",
                column: "PMDSPSItemItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenplayOrgStructures_PMDSPSItemItemID",
                table: "ScreenplayOrgStructures",
                column: "PMDSPSItemItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ScreenplayProducers_PersonId",
                table: "ScreenplayProducers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenplays_StatusId",
                table: "Screenplays",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allocations");

            migrationBuilder.DropTable(
                name: "BarnameGroups");

            migrationBuilder.DropTable(
                name: "BarnameNetworks");

            migrationBuilder.DropTable(
                name: "BarnameProducers");

            migrationBuilder.DropTable(
                name: "Basic");

            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "EpisodeConcepts");

            migrationBuilder.DropTable(
                name: "EpisodeWriters");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "OrgStructures");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "ProcessDataRegs");

            migrationBuilder.DropTable(
                name: "ResourceOccasions");

            migrationBuilder.DropTable(
                name: "RRequestResources");

            migrationBuilder.DropTable(
                name: "ScreenplayFormats");

            migrationBuilder.DropTable(
                name: "ScreenplayGenres");

            migrationBuilder.DropTable(
                name: "ScreenplayOrgStructures");

            migrationBuilder.DropTable(
                name: "ScreenplayProducers");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "TimeSections");

            migrationBuilder.DropTable(
                name: "UserTests");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RRequests");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "PMDSPSItem");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Screenplays");

            migrationBuilder.DropTable(
                name: "Barname");

            migrationBuilder.DropTable(
                name: "Occasions");

            migrationBuilder.DropTable(
                name: "RecordTypes");

            migrationBuilder.DropTable(
                name: "BasicDatas");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
