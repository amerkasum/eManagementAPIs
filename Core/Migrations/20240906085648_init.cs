
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsenceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbsenceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Iso = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Subtitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    EventStatusId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    TimeFrom = table.Column<DateTime>(nullable: false),
                    TimeTo = table.Column<DateTime>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskPriorities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    PttCode = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogger",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(nullable: true),
                    AccessCode = table.Column<string>(nullable: true),
                    IsAccessCodeSent = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AccessType = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogger_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ContractTypeCode = table.Column<string>(nullable: true),
                    ContractExpireDate = table.Column<DateTime>(nullable: true),
                    PositionId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPositions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingAbsences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    AbsenceTypeId = table.Column<int>(nullable: false),
                    AbsenceStatusId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingAbsences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingAbsences_AbsenceStatuses_AbsenceStatusId",
                        column: x => x.AbsenceStatusId,
                        principalTable: "AbsenceStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingAbsences_AbsenceTypes_AbsenceTypeId",
                        column: x => x.AbsenceTypeId,
                        principalTable: "AbsenceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingAbsences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Day = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ShiftId = table.Column<int>(nullable: false),
                    RepeatState = table.Column<int>(nullable: false),
                    IsWorking = table.Column<bool>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingDays_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingDays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserResidence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResidence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResidence_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserResidence_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTaskId = table.Column<int>(nullable: false),
                    Review = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: true),
                    DeletedDateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskReviews_UserTasks_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "UserTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AbsenceStatuses",
                columns: new[] { "Id", "Code", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "REQUEST" },
                    { 2, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "APPROVED" },
                    { 3, "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "REJECTED" },
                    { 4, "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "CANCELLED" }
                });

            migrationBuilder.InsertData(
                table: "AbsenceTypes",
                columns: new[] { "Id", "Code", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { 20, "20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "RELIGIOUS LEAVE" },
                    { 19, "19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "FLOATING HOLIDAY" },
                    { 18, "18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "ADMINISTRATIVE LEAVE" },
                    { 17, "17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "CASUAL LEAVE" },
                    { 16, "16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "EMERGENCY LEAVE" },
                    { 15, "15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "HALF DAY LEAVE" },
                    { 14, "14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "FAMILY AND MEDICAL LEAVE" },
                    { 13, "13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "VOLUNTEER LEAVE" },
                    { 12, "12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "COMPENSATORY LEAVE" },
                    { 11, "11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "SABBATICAL" },
                    { 9, "9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "PUBLIC HOLIDAY" },
                    { 8, "8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "UNPAID LEAVE" },
                    { 7, "7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "MILITARY LEAVE" },
                    { 6, "6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "JURY DUTY" },
                    { 5, "5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "BEREAVEMENT LEAVE" },
                    { 4, "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "PARENTAL LEAVE" },
                    { 3, "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "PERSONAL LEAVE" },
                    { 2, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "VACATION LEAVE" },
                    { 1, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "SICK LEAVE" },
                    { 10, "10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "STUDY LEAVE" }
                });

            migrationBuilder.InsertData(
                table: "ContractTypes",
                columns: new[] { "Id", "Code", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { 8, "8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "ZERO HOUR" },
                    { 12, "12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "ON CALL" },
                    { 11, "11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "REMOTE" },
                    { 10, "10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "PROBATIONARY" },
                    { 9, "9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "SEASONAL" },
                    { 7, "7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "FIXED TERM" },
                    { 5, "5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "INTERNSHIP" },
                    { 4, "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "CONTRACTOR" },
                    { 3, "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "TEMPORARY" },
                    { 2, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "PART TIME" },
                    { 1, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "FULL TIME" },
                    { 6, "6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "Iso", "ModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NI", null, "Nicaragua" },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NE", null, "Niger" },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NG", null, "Nigeria" },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MK", null, "North Macedonia" },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NO", null, "Norway" },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "OM", null, "Oman" },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "PK", null, "Pakistan" },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "PW", null, "Palau" },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "PA", null, "Panama" },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "PG", null, "Papua New Guinea" },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "PH", null, "Philippines" },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "PE", null, "Peru" },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "PL", null, "Poland" },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "PT", null, "Portugal" },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "QA", null, "Qatar" },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "RO", null, "Romania" },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "RU", null, "Russia" },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "RW", null, "Rwanda" },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KN", null, "Saint Kitts and Nevis" },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LC", null, "Saint Lucia" },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "PY", null, "Paraguay" },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NZ", null, "New Zealand" },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ML", null, "Mali" },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NP", null, "Nepal" },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LT", null, "Lithuania" },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MG", null, "Madagascar" },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MW", null, "Malawi" },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MY", null, "Malaysia" },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MV", null, "Maldives" },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "VC", null, "Saint Vincent and the Grenadines" },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MT", null, "Malta" },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MH", null, "Marshall Islands" },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MR", null, "Mauritania" },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MU", null, "Mauritius" },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MX", null, "Mexico" },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "FM", null, "Micronesia" },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MD", null, "Moldova" },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MC", null, "Monaco" },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MN", null, "Mongolia" },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ME", null, "Montenegro" },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MA", null, "Morocco" },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MZ", null, "Mozambique" },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "MM", null, "Myanmar" },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NA", null, "Namibia" },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NR", null, "Nauru" },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "NL", null, "Netherlands" },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "WS", null, "Samoa" },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SR", null, "Suriname" },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ST", null, "Sao Tome and Principe" },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TO", null, "Tonga" },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TT", null, "Trinidad and Tobago" },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TN", null, "Tunisia" },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TR", null, "Turkey" },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TM", null, "Turkmenistan" },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TV", null, "Tuvalu" },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "UG", null, "Uganda" },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "UA", null, "Ukraine" },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AE", null, "United Arab Emirates" },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TG", null, "Togo" },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GB", null, "United Kingdom" },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "UY", null, "Uruguay" },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "UZ", null, "Uzbekistan" },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "VU", null, "Vanuatu" },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "VA", null, "Vatican City" },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "VE", null, "Venezuela" },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "VN", null, "Vietnam" },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "YE", null, "Yemen" },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ZM", null, "Zambia" },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ZW", null, "Zimbabwe" },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "US", null, "United States" },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TL", null, "Timor-Leste" },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TH", null, "Thailand" },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TZ", null, "Tanzania" },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SA", null, "Saudi Arabia" },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SN", null, "Senegal" },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "RS", null, "Serbia" },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SC", null, "Seychelles" },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SL", null, "Sierra Leone" },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SG", null, "Singapore" },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SK", null, "Slovakia" },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SI", null, "Slovenia" },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SB", null, "Solomon Islands" },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SO", null, "Somalia" },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ZA", null, "South Africa" },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SS", null, "South Sudan" },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ES", null, "Spain" },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LK", null, "Sri Lanka" },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SD", null, "Sudan" },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LI", null, "Liechtenstein" },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SE", null, "Sweden" },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CH", null, "Switzerland" },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SY", null, "Syria" },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TW", null, "Taiwan" },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TJ", null, "Tajikistan" },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SM", null, "San Marino" },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LY", null, "Libya" },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LU", null, "Luxembourg" },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LS", null, "Lesotho" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BG", null, "Bulgaria" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BF", null, "Burkina Faso" },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LR", null, "Liberia" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CV", null, "Cabo Verde" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KH", null, "Cambodia" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CM", null, "Cameroon" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CA", null, "Canada" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CF", null, "Central African Republic" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "TD", null, "Chad" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CL", null, "Chile" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CN", null, "China" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CO", null, "Colombia" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KM", null, "Comoros" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CG", null, "Congo" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CD", null, "Congo (Democratic Republic)" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CR", null, "Costa Rica" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "HR", null, "Croatia" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CU", null, "Cuba" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CY", null, "Cyprus" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "CZ", null, "Czech Republic" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "DK", null, "Denmark" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BN", null, "Brunei Darussalam" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "DJ", null, "Djibouti" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BR", null, "Brazil" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BA", null, "Bosnia and Herzegovina" },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AF", null, "Afghanistan" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AL", null, "Albania" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "DZ", null, "Algeria" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AD", null, "Andorra" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AO", null, "Angola" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AG", null, "Antigua and Barbuda" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AR", null, "Argentina" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AM", null, "Armenia" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AU", null, "Australia" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AT", null, "Austria" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "AZ", null, "Azerbaijan" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BS", null, "Bahamas" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BH", null, "Bahrain" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BD", null, "Bangladesh" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BB", null, "Barbados" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BY", null, "Belarus" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BE", null, "Belgium" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BZ", null, "Belize" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BJ", null, "Benin" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BT", null, "Bhutan" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BO", null, "Bolivia" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BW", null, "Botswana" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "DM", null, "Dominica" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "BI", null, "Burundi" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "EC", null, "Ecuador" },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "IN", null, "India" },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ID", null, "Indonesia" },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "IR", null, "Iran" },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "IQ", null, "Iraq" },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "IE", null, "Ireland" },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "IL", null, "Israel" },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "IT", null, "Italy" },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "JM", null, "Jamaica" },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "JP", null, "Japan" },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "IS", null, "Iceland" },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "JO", null, "Jordan" },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KE", null, "Kenya" },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KI", null, "Kiribati" },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KP", null, "Korea (North)" },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KR", null, "Korea (South)" },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KW", null, "Kuwait" },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KG", null, "Kyrgyzstan" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "DO", null, "Dominican Republic" },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LV", null, "Latvia" },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LB", null, "Lebanon" },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "KZ", null, "Kazakhstan" },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "HU", null, "Hungary" },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "LA", null, "Laos" },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "HT", null, "Haiti" },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "HN", null, "Honduras" },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "EG", null, "Egypt" },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SV", null, "El Salvador" },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ER", null, "Eritrea" },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "EE", null, "Estonia" },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "SZ", null, "Eswatini" },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "ET", null, "Ethiopia" },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "FJ", null, "Fiji" },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "FI", null, "Finland" },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "FR", null, "France" },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GQ", null, "Equatorial Guinea" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GM", null, "Gambia" },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GE", null, "Georgia" },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "DE", null, "Germany" },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GH", null, "Ghana" },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GR", null, "Greece" },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GD", null, "Grenada" },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GT", null, "Guatemala" },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GY", null, "Guyana" },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GA", null, "Gabon" },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GN", null, "Guinea" },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "GW", null, "Guinea-Bissau" }
                });

            migrationBuilder.InsertData(
                table: "EventStatuses",
                columns: new[] { "Id", "Code", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { 3, "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "FINISHED" },
                    { 4, "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "CANCELLED" },
                    { 1, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "UPCOMING" },
                    { 2, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "ONGOING" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedById", "CreatedDateTime", "Date", "DeletedDateTime", "Description", "EventStatusId", "ImageUrl", "IsDeleted", "ModifiedDateTime", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 6, 10, 56, 47, 402, DateTimeKind.Local).AddTicks(8379), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A weekend retreat for team building and relaxation.", 1, null, false, null, "Annual team building", "Company Retreat" },
                    { 2, 2, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(327), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kickoff meeting for the new project launch.", 1, null, false, null, "New project initiation", "Project Kickoff" },
                    { 3, 1, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(382), new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A conference featuring industry leaders and insightful sessions.", 3, null, false, null, "Industry insights", "Annual Conference" },
                    { 4, 1, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(387), new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Celebrate the end of the year with food, fun, and festivities.", 4, null, false, null, "End of year celebration", "Holiday Party" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Code", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { 12, "12", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "FRONTEND DEVELOPER" },
                    { 20, "20", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "WEB DESIGNER" },
                    { 19, "19", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "IT CONSULTANT" },
                    { 18, "18", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "CONTENT CREATOR" },
                    { 17, "17", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "HUMAN RESOURCES MANAGER" },
                    { 16, "16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "TECHNICAL SUPPORT SPECIALIST" },
                    { 15, "15", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "QUALITY ASSURANCE TESTER" },
                    { 14, "14", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "DEVOPS ENGINEER" },
                    { 13, "13", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "BACKEND DEVELOPER" },
                    { 11, "11", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "DATABASE ADMINISTRATOR" },
                    { 1, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "SOFTWARE DEVELOPER" },
                    { 9, "9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "BUSINESS ANALYST" },
                    { 8, "8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "SALES MANAGER" },
                    { 7, "7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "UX RESEARCHER" },
                    { 6, "6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "MARKETING SPECIALIST" },
                    { 5, "5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "SYSTEM ADMINISTRATOR" },
                    { 4, "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "GRAPHIC DESIGNER" },
                    { 3, "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "PRODUCT MANAGER" },
                    { 2, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "DATA SCIENTIST" },
                    { 10, "10", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "NETWORK ENGINEER" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "CreatedDateTime", "DeletedDateTime", "Description", "IsDeleted", "ModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { 2, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, "EMPLOYEE" },
                    { 1, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "Code", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Name", "TimeFrom", "TimeTo" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "FIRST", new DateTime(2000, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "SECOND", new DateTime(2000, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "THIRD", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TaskPriorities",
                columns: new[] { "Id", "Code", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "LOW" },
                    { 2, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "MEDIUM" },
                    { 3, "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "HIGH" }
                });

            migrationBuilder.InsertData(
                table: "TaskStatuses",
                columns: new[] { "Id", "Code", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Name" },
                values: new object[,]
                {
                    { 3, "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "FINISHED" },
                    { 1, "1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "PENDING" },
                    { 2, "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "IN PROGRESS" },
                    { 4, "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "CANCELLED" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "CreatedDateTime", "DateOfBirth", "DeletedDateTime", "Email", "FirstName", "ImageUrl", "IsActive", "IsDeleted", "LastName", "ModifiedDateTime", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 2, "A brief description about Emplo Yee.", new DateTime(2024, 9, 6, 8, 56, 47, 391, DateTimeKind.Utc).AddTicks(8520), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "employee@example.com", "Emplo", null, true, false, "Yee", null, "test", "123-456-7890", "employee" },
                    { 1, "A brief description about Admin Istrator.", new DateTime(2024, 9, 6, 8, 56, 47, 391, DateTimeKind.Utc).AddTicks(6350), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "administrator@example.com", "Admin", null, true, false, "Istrator", null, "test", "123-456-7890", "administrator" },
                    { 3, "A brief description about John Doe.", new DateTime(2024, 9, 6, 8, 56, 47, 391, DateTimeKind.Utc).AddTicks(8674), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "johndoe@example.com", "John", null, true, false, "Doe", null, "test", "123-456-7890", "john.doe" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Name", "PttCode" },
                values: new object[,]
                {
                    { 1, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(5894), null, false, null, "Sarajevo", "71000" },
                    { 30, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7347), null, false, null, "Vitez", "72250" },
                    { 29, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7344), null, false, null, "Tomislavgrad", "80240" },
                    { 28, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7342), null, false, null, "Srebrenica", "75430" },
                    { 27, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7338), null, false, null, "Široki Brijeg", "88220" },
                    { 26, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7336), null, false, null, "Posušje", "88240" },
                    { 25, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7334), null, false, null, "Neum", "88390" },
                    { 24, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7331), null, false, null, "Livno", "80101" },
                    { 23, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7329), null, false, null, "Konjic", "88400" },
                    { 22, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7327), null, false, null, "Goražde", "73000" },
                    { 20, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7322), null, false, null, "Lukavac", "75300" },
                    { 19, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7319), null, false, null, "Živinice", "75270" },
                    { 18, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7316), null, false, null, "Bugojno", "70230" },
                    { 17, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7314), null, false, null, "Sanski Most", "79260" },
                    { 16, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7311), null, false, null, "Visoko", "71300" },
                    { 21, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7324), null, false, null, "Foča", "73300" },
                    { 14, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7304), null, false, null, "Travnik", "72270" },
                    { 2, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7237), null, false, null, "Banja Luka", "78000" },
                    { 15, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7309), null, false, null, "Tešanj", "74260" },
                    { 4, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7278), null, false, null, "Tuzla", "75000" },
                    { 5, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7280), null, false, null, "Zenica", "72000" },
                    { 6, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7283), null, false, null, "Bijeljina", "76300" },
                    { 7, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7286), null, false, null, "Prijedor", "79101" },
                    { 3, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7273), null, false, null, "Mostar", "88000" },
                    { 9, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7291), null, false, null, "Cazin", "77220" },
                    { 10, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7294), null, false, null, "Doboj", "74000" },
                    { 11, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7296), null, false, null, "Bihać", "77000" },
                    { 12, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7299), null, false, null, "Gradiška", "78400" },
                    { 13, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7301), null, false, null, "Trebinje", "89101" },
                    { 8, 22, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(7288), null, false, null, "Brčko", "76100" }
                });

            migrationBuilder.InsertData(
                table: "UserPositions",
                columns: new[] { "Id", "ContractExpireDate", "ContractTypeCode", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "PositionId", "UserId" },
                values: new object[,]
                {
                    { 4, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "6", new DateTime(2024, 9, 6, 8, 56, 47, 394, DateTimeKind.Utc).AddTicks(4367), null, false, null, 2, 3 },
                    { 1, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", new DateTime(2024, 9, 6, 8, 56, 47, 394, DateTimeKind.Utc).AddTicks(2709), null, false, null, 1, 1 },
                    { 3, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "6", new DateTime(2024, 9, 6, 8, 56, 47, 394, DateTimeKind.Utc).AddTicks(4327), null, false, null, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(2293), null, false, null, 2, 2 },
                    { 3, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(2334), null, false, null, 2, 3 },
                    { 1, new DateTime(2024, 9, 6, 8, 56, 47, 392, DateTimeKind.Utc).AddTicks(451), null, false, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkingAbsences",
                columns: new[] { "Id", "AbsenceStatusId", "AbsenceTypeId", "CreatedDateTime", "DeletedDateTime", "EndDate", "IsDeleted", "ModifiedDateTime", "Note", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 3, 1, 3, new DateTime(2024, 9, 6, 10, 56, 47, 402, DateTimeKind.Local).AddTicks(4148), null, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Personal leave", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, 2, new DateTime(2024, 9, 6, 10, 56, 47, 402, DateTimeKind.Local).AddTicks(3993), null, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Sick leave", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 1, 4, new DateTime(2024, 9, 6, 10, 56, 47, 402, DateTimeKind.Local).AddTicks(4158), null, null, false, null, "Parental leave", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 1, 5, new DateTime(2024, 9, 6, 10, 56, 47, 402, DateTimeKind.Local).AddTicks(4165), null, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Bereavement leave", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, 1, 1, new DateTime(2024, 9, 6, 10, 56, 47, 394, DateTimeKind.Local).AddTicks(7874), null, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Vacation leave", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CityId", "CreatedDateTime", "DeletedDateTime", "Description", "DueDate", "IsDeleted", "ModifiedDateTime", "Name", "Priority", "StatusCode" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(647), null, "Description for Task 1", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 1", 3, 3 },
                    { 2, 2, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(2439), null, "Description for Task 2", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 2", 3, 3 },
                    { 4, 2, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(2484), null, "Description for Task 4", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 4", 3, 3 },
                    { 5, 2, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(2486), null, "Description for Task 5", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 5", 3, 3 },
                    { 6, 2, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(2673), null, "Description for Task 6", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 6", 3, 3 },
                    { 7, 2, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(2683), null, "Description for Task 7", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 7", 3, 3 },
                    { 8, 2, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(2689), null, "Description for Task 8", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 8", 3, 3 },
                    { 9, 2, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(2694), null, "Description for Task 9", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 9", 3, 3 },
                    { 10, 2, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(2700), null, "Description for Task 10", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 10", 3, 3 },
                    { 3, 3, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(2480), null, "Description for Task 3", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Task 3", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserResidence",
                columns: new[] { "Id", "CityId", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(7955), null, false, null, 1 },
                    { 3, 3, new DateTime(2024, 9, 6, 8, 56, 47, 394, DateTimeKind.Utc).AddTicks(233), null, false, null, 2 },
                    { 4, 3, new DateTime(2024, 9, 6, 8, 56, 47, 394, DateTimeKind.Utc).AddTicks(283), null, false, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserTasks",
                columns: new[] { "Id", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "TaskId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(4442), null, false, null, 1, 1 },
                    { 20, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6492), null, false, null, 10, 3 },
                    { 19, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6490), null, false, null, 10, 2 },
                    { 18, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6489), null, false, null, 9, 3 },
                    { 17, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6487), null, false, null, 9, 2 },
                    { 16, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6485), null, false, null, 8, 3 },
                    { 15, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6484), null, false, null, 8, 2 },
                    { 14, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6482), null, false, null, 7, 3 },
                    { 13, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6481), null, false, null, 7, 1 },
                    { 12, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6479), null, false, null, 6, 3 },
                    { 11, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6478), null, false, null, 6, 1 },
                    { 10, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6476), null, false, null, 5, 3 },
                    { 9, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6474), null, false, null, 5, 1 },
                    { 8, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6473), null, false, null, 4, 3 },
                    { 7, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6470), null, false, null, 4, 1 },
                    { 4, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6464), null, false, null, 2, 2 },
                    { 3, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6460), null, false, null, 2, 1 },
                    { 2, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6359), null, false, null, 1, 2 },
                    { 5, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6466), null, false, null, 3, 1 },
                    { 6, new DateTime(2024, 9, 6, 8, 56, 47, 393, DateTimeKind.Utc).AddTicks(6468), null, false, null, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "TaskReviews",
                columns: new[] { "Id", "CreatedDateTime", "DeletedDateTime", "IsDeleted", "ModifiedDateTime", "Review", "UserTaskId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(2001), null, false, null, 5, 1 },
                    { 20, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3934), null, false, null, 3, 20 },
                    { 19, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3930), null, false, null, 4, 19 },
                    { 18, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3926), null, false, null, 5, 18 },
                    { 17, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3922), null, false, null, 2, 17 },
                    { 16, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3917), null, false, null, 4, 16 },
                    { 15, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3912), null, false, null, 5, 15 },
                    { 14, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3908), null, false, null, 3, 14 },
                    { 13, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3904), null, false, null, 4, 13 },
                    { 12, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3900), null, false, null, 2, 12 },
                    { 11, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3896), null, false, null, 5, 11 },
                    { 10, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3891), null, false, null, 3, 10 },
                    { 9, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3887), null, false, null, 4, 9 },
                    { 8, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3883), null, false, null, 5, 8 },
                    { 7, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3879), null, false, null, 3, 7 },
                    { 4, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3866), null, false, null, 5, 4 },
                    { 3, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3860), null, false, null, 3, 3 },
                    { 2, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3807), null, false, null, 4, 2 },
                    { 5, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3870), null, false, null, 2, 5 },
                    { 6, new DateTime(2024, 9, 6, 10, 56, 47, 403, DateTimeKind.Local).AddTicks(3874), null, false, null, 4, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskReviews_UserTaskId",
                table: "TaskReviews",
                column: "UserTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CityId",
                table: "Tasks",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogger_UserId",
                table: "UserLogger",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_PositionId",
                table: "UserPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_UserId",
                table: "UserPositions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResidence_CityId",
                table: "UserResidence",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResidence_UserId",
                table: "UserResidence",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_TaskId",
                table: "UserTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_UserId",
                table: "UserTasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingAbsences_AbsenceStatusId",
                table: "WorkingAbsences",
                column: "AbsenceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingAbsences_AbsenceTypeId",
                table: "WorkingAbsences",
                column: "AbsenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingAbsences_UserId",
                table: "WorkingAbsences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDays_ShiftId",
                table: "WorkingDays",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDays_UserId",
                table: "WorkingDays",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventStatuses");

            migrationBuilder.DropTable(
                name: "TaskPriorities");

            migrationBuilder.DropTable(
                name: "TaskReviews");

            migrationBuilder.DropTable(
                name: "TaskStatuses");

            migrationBuilder.DropTable(
                name: "UserLogger");

            migrationBuilder.DropTable(
                name: "UserPositions");

            migrationBuilder.DropTable(
                name: "UserResidence");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "WorkingAbsences");

            migrationBuilder.DropTable(
                name: "WorkingDays");

            migrationBuilder.DropTable(
                name: "UserTasks");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AbsenceStatuses");

            migrationBuilder.DropTable(
                name: "AbsenceTypes");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
