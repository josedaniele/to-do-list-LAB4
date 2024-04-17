using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace to_do_list.Migrations
{
    /// <inheritdoc />
    public partial class eliminacionICollectionUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItems_Users_Userid_user",
                table: "ToDoItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_Userid_user",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Userid_user",
                table: "ToDoItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Userid_user",
                table: "ToDoItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_Userid_user",
                table: "ToDoItems",
                column: "Userid_user");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItems_Users_Userid_user",
                table: "ToDoItems",
                column: "Userid_user",
                principalTable: "Users",
                principalColumn: "id_user");
        }
    }
}
