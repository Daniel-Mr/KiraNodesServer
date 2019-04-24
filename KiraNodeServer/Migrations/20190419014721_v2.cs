using Microsoft.EntityFrameworkCore.Migrations;

namespace KiraNodeServer.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicIpAddress",
                table: "Nodes",
                newName: "SocketId");

            migrationBuilder.RenameColumn(
                name: "IpAddress",
                table: "Nodes",
                newName: "Owner");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Devices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Devices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "SocketId",
                table: "Nodes",
                newName: "PublicIpAddress");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Nodes",
                newName: "IpAddress");
        }
    }
}
