using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeremetBank.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

             migrationBuilder.InsertData(
          table: "Clients",
          columns: new[] { "Id", "Name", "BirthDate", "PhoneNumber", "Address", "SocialNumber" },
          values: new object[] { 1, "Тестовый клиент1", "1991-03-08", "123", "г.Баткен", "12345678901234" });

            migrationBuilder.InsertData(
          table: "Clients",
          columns: new[] { "Id", "Name", "BirthDate", "PhoneNumber", "Address", "SocialNumber" },
          values: new object[] { 2, "Тестовый клиент2", "1996-04-20", "456", "г.Бишкек", "98765432101234" });

            migrationBuilder.InsertData(
          table: "Clients",
          columns: new[] { "Id", "Name", "BirthDate", "PhoneNumber", "Address", "SocialNumber" },
          values: new object[] { 3, "Тестовый клиент3", "1995-08-04	", "789", "г.Нарын", "12345543211234" });

            migrationBuilder.InsertData(
          table: "Clients",
          columns: new[] { "Id", "Name", "BirthDate", "PhoneNumber", "Address", "SocialNumber" },
          values: new object[] { 4, "Тестовый клиент4", "1989-02-25	", "012", "с.Комсомольское	", "12345671234567" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
