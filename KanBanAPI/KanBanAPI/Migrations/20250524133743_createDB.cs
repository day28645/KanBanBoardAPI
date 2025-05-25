using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanBanAPI.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_Card = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    passwords = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_Card);
                });

            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Board_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    boardName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    createDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Card = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId_Card = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Board_Id);
                    table.ForeignKey(
                        name: "FK_Boards_Users_Id_Card",
                        column: x => x.Id_Card,
                        principalTable: "Users",
                        principalColumn: "Id_Card",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boards_Users_UserId_Card",
                        column: x => x.UserId_Card,
                        principalTable: "Users",
                        principalColumn: "Id_Card");
                });

            migrationBuilder.CreateTable(
                name: "KanbanTasks",
                columns: table => new
                {
                    Task_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    createDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Card = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId_Card = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanTasks", x => x.Task_Id);
                    table.ForeignKey(
                        name: "FK_KanbanTasks_Users_Id_Card",
                        column: x => x.Id_Card,
                        principalTable: "Users",
                        principalColumn: "Id_Card",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KanbanTasks_Users_UserId_Card",
                        column: x => x.UserId_Card,
                        principalTable: "Users",
                        principalColumn: "Id_Card");
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Card = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_Logins_Users_Id_Card",
                        column: x => x.Id_Card,
                        principalTable: "Users",
                        principalColumn: "Id_Card",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditBoards",
                columns: table => new
                {
                    editId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    editDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Card = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Board_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditBoards", x => x.editId);
                    table.ForeignKey(
                        name: "FK_EditBoards_Boards_Board_Id",
                        column: x => x.Board_Id,
                        principalTable: "Boards",
                        principalColumn: "Board_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EditBoards_Users_Id_Card",
                        column: x => x.Id_Card,
                        principalTable: "Users",
                        principalColumn: "Id_Card",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EditTasks",
                columns: table => new
                {
                    editTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    editDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Card = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Task_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditTasks", x => x.editTaskId);
                    table.ForeignKey(
                        name: "FK_EditTasks_KanbanTasks_Task_Id",
                        column: x => x.Task_Id,
                        principalTable: "KanbanTasks",
                        principalColumn: "Task_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EditTasks_Users_Id_Card",
                        column: x => x.Id_Card,
                        principalTable: "Users",
                        principalColumn: "Id_Card",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boards_Id_Card",
                table: "Boards",
                column: "Id_Card");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_UserId_Card",
                table: "Boards",
                column: "UserId_Card");

            migrationBuilder.CreateIndex(
                name: "IX_EditBoards_Board_Id",
                table: "EditBoards",
                column: "Board_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EditBoards_Id_Card",
                table: "EditBoards",
                column: "Id_Card");

            migrationBuilder.CreateIndex(
                name: "IX_EditTasks_Id_Card",
                table: "EditTasks",
                column: "Id_Card");

            migrationBuilder.CreateIndex(
                name: "IX_EditTasks_Task_Id",
                table: "EditTasks",
                column: "Task_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanTasks_Id_Card",
                table: "KanbanTasks",
                column: "Id_Card");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanTasks_UserId_Card",
                table: "KanbanTasks",
                column: "UserId_Card");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_Id_Card",
                table: "Logins",
                column: "Id_Card");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditBoards");

            migrationBuilder.DropTable(
                name: "EditTasks");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DropTable(
                name: "KanbanTasks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
