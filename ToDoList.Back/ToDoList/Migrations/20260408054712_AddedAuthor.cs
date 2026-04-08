using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "TodoItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuthorEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_AuthorId",
                table: "TodoItems",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_AuthorEntity_AuthorId",
                table: "TodoItems",
                column: "AuthorId",
                principalTable: "AuthorEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_AuthorEntity_AuthorId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "AuthorEntity");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_AuthorId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "TodoItems");
        }
    }
}
