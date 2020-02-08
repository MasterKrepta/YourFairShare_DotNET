using Microsoft.EntityFrameworkCore.Migrations;

namespace YFS_DataAccess.Migrations
{
    public partial class removeListForTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Roommates_RoommateId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_RoommateId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "RoommateId",
                table: "Bills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoommateId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_RoommateId",
                table: "Bills",
                column: "RoommateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Roommates_RoommateId",
                table: "Bills",
                column: "RoommateId",
                principalTable: "Roommates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
