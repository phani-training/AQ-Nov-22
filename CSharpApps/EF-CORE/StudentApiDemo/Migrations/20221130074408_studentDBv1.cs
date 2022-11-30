using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApiDemo.Migrations
{
    public partial class studentDBv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchTable",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTable", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "StudentTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTable_BranchTable_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BranchTable",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BranchTable",
                columns: new[] { "BranchId", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Computer Science" },
                    { 3, "Mechanical" },
                    { 4, "Electrical" },
                    { 5, "Civil" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTable_BranchId",
                table: "StudentTable",
                column: "BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTable");

            migrationBuilder.DropTable(
                name: "BranchTable");
        }
    }
}
