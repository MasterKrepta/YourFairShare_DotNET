using Microsoft.EntityFrameworkCore.Migrations;

namespace YFS_DataAccess.Migrations
{
    public partial class AddListBackIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoommateId",
                table: "Bills",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
