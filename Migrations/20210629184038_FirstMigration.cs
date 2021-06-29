using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RMCB.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bootcamps",
                columns: table => new
                {
                    BootcampID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Flex = table.Column<bool>(nullable: false),
                    GIBill = table.Column<bool>(nullable: false),
                    Facility = table.Column<bool>(nullable: false),
                    Online = table.Column<bool>(nullable: false),
                    Subjects = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bootcamps", x => x.BootcampID);
                });

            migrationBuilder.CreateTable(
                name: "CourseCats",
                columns: table => new
                {
                    CourseCatID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCats", x => x.CourseCatID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ConfirmEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BootcampID = table.Column<int>(nullable: false),
                    CourseCatID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Bootcamps_BootcampID",
                        column: x => x.BootcampID,
                        principalTable: "Bootcamps",
                        principalColumn: "BootcampID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCats_CourseCatID",
                        column: x => x.CourseCatID,
                        principalTable: "CourseCats",
                        principalColumn: "CourseCatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BootcampID = table.Column<int>(nullable: false),
                    StateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_Locations_Bootcamps_BootcampID",
                        column: x => x.BootcampID,
                        principalTable: "Bootcamps",
                        principalColumn: "BootcampID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Recommend = table.Column<string>(nullable: false),
                    Cohort = table.Column<string>(nullable: false),
                    Course = table.Column<string>(nullable: false),
                    Curriculum = table.Column<int>(nullable: false),
                    Instructors = table.Column<int>(nullable: false),
                    Difficulty = table.Column<int>(nullable: false),
                    JobSupport = table.Column<int>(nullable: false),
                    Facility = table.Column<int>(nullable: false),
                    Online = table.Column<bool>(nullable: false),
                    Textbook = table.Column<string>(nullable: false),
                    Pros = table.Column<string>(nullable: false),
                    Cons = table.Column<string>(nullable: false),
                    Comments = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    BootcampID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Bootcamps_BootcampID",
                        column: x => x.BootcampID,
                        principalTable: "Bootcamps",
                        principalColumn: "BootcampID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_BootcampID",
                table: "Courses",
                column: "BootcampID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCatID",
                table: "Courses",
                column: "CourseCatID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_BootcampID",
                table: "Locations",
                column: "BootcampID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_StateID",
                table: "Locations",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BootcampID",
                table: "Reviews",
                column: "BootcampID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserID",
                table: "Reviews",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "CourseCats");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Bootcamps");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
