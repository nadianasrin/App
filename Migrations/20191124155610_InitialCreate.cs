using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Student_VarsityId = table.Column<string>(nullable: true),
                    Student_FullName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    BatchId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BatchName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.BatchId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoginUserId = table.Column<string>(nullable: false),
                    LoginUserPassword = table.Column<string>(nullable: false),
                    RememberMe = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "OfficerReg",
                columns: table => new
                {
                    OfficerId = table.Column<string>(nullable: false),
                    OfficerEmail = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    OfficerPassword = table.Column<string>(nullable: false),
                    OfficerConfirmPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficerReg", x => x.OfficerId);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationId = table.Column<string>(nullable: false),
                    StudentVarsityId = table.Column<string>(nullable: false),
                    StudentFullName = table.Column<string>(maxLength: 25, nullable: false),
                    RegUserEmail = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    RegUserPassword = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SectionName = table.Column<string>(nullable: true),
                    SectionCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    SemesterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SemesterName = table.Column<string>(nullable: true),
                    IsActiveForm = table.Column<bool>(nullable: false),
                    IsActiveCourseSuggestion = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatchSection",
                columns: table => new
                {
                    BatchId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    BatchSectioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchSection", x => new { x.BatchId, x.SectionId });
                    table.UniqueConstraint("AK_BatchSection_BatchSectioId", x => x.BatchSectioId);
                    table.ForeignKey(
                        name: "FK_BatchSection_Batch_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batch",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchSection_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseCode = table.Column<string>(nullable: true),
                    SemesterNumber = table.Column<string>(nullable: true),
                    CourseTitle = table.Column<string>(nullable: true),
                    CourseCredit = table.Column<int>(nullable: false),
                    SemesterNoSemesterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_Semester_SemesterNoSemesterId",
                        column: x => x.SemesterNoSemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Officer",
                columns: table => new
                {
                    SerialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OfficerRegOfficerId = table.Column<string>(nullable: true),
                    OfficerSemesterSemesterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officer", x => x.SerialId);
                    table.ForeignKey(
                        name: "FK_Officer_OfficerReg_OfficerRegOfficerId",
                        column: x => x.OfficerRegOfficerId,
                        principalTable: "OfficerReg",
                        principalColumn: "OfficerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Officer_Semester_OfficerSemesterSemesterId",
                        column: x => x.OfficerSemesterSemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegistrationId = table.Column<string>(nullable: true),
                    SemesterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    OfferId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DesiredCourseCourseId = table.Column<int>(nullable: true),
                    OfferedCourseCourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offer_Course_DesiredCourseCourseId",
                        column: x => x.DesiredCourseCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offer_Course_OfferedCourseCourseId",
                        column: x => x.OfferedCourseCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollStudentId = table.Column<int>(nullable: false),
                    EnrollCourseId = table.Column<int>(nullable: false),
                    EnrollmentId = table.Column<int>(nullable: false),
                    SemesterId = table.Column<int>(nullable: true),
                    IsRetakeCourse = table.Column<bool>(nullable: false),
                    OfficerSerialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.EnrollStudentId, x.EnrollCourseId });
                    table.UniqueConstraint("AK_Enrollment_EnrollmentId", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_EnrollCourseId",
                        column: x => x.EnrollCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_EnrollStudentId",
                        column: x => x.EnrollStudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Officer_OfficerSerialId",
                        column: x => x.OfficerSerialId,
                        principalTable: "Officer",
                        principalColumn: "SerialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BatchSection_SectionId",
                table: "BatchSection",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SemesterNoSemesterId",
                table: "Course",
                column: "SemesterNoSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_EnrollCourseId",
                table: "Enrollment",
                column: "EnrollCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_OfficerSerialId",
                table: "Enrollment",
                column: "OfficerSerialId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_SemesterId",
                table: "Enrollment",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_DesiredCourseCourseId",
                table: "Offer",
                column: "DesiredCourseCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_OfferedCourseCourseId",
                table: "Offer",
                column: "OfferedCourseCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Officer_OfficerRegOfficerId",
                table: "Officer",
                column: "OfficerRegOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Officer_OfficerSemesterSemesterId",
                table: "Officer",
                column: "OfficerSemesterSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_RegistrationId",
                table: "Student",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SemesterId",
                table: "Student",
                column: "SemesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BatchSection");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Officer");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "OfficerReg");

            migrationBuilder.DropTable(
                name: "Semester");
        }
    }
}
