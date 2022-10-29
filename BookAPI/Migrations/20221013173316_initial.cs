using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", unicode: false, maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 128, nullable: false),
                    price = table.Column<decimal>(type: "TEXT", unicode: false, maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "TEXT", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "description", "name", "price" },
                values: new object[] { new Guid("0797bde0-8d73-4727-ab4f-4bccf80dbac9"), "Сказка о царе Салта́не, о сыне его славном и могучем богатыре князе \r\n                    Гвидо́не Салта́новиче и о прекрасной царевне Лебеди» — сказка в стихах Александра Пушкина, \r\n                    написанная в 1831 году и впервые изданная в следующем году в собрании стихотворений", "Сказка о царе Салтане", 127m });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "description", "name", "price" },
                values: new object[] { new Guid("dab6a59a-aa04-4590-ab2a-0facab0f0b73"), "Ска́зка о рыбаке́ и ры́бке» — сказка А. С. Пушкина. Написана 2 октября 1833 года.\r\n                                Впервые напечатана в 1835 году в журнале «Библиотека для чтения»", "Сказка о золотой рыбке", 201m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
