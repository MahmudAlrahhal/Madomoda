using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MadoDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Billy Spark", "Embark on a timeless adventure with 'Eternal Journey.' This captivating tale weaves through the tapestry of existence, offering a mesmerizing blend of mystery and introspection.\r\n\r\nJourney into the unknown as you explore the depths of the human soul.", "EJ2023001", 120.0, 110.0, 100.0, 105.0, "Eternal Journey" },
                    { 2, "Nancy Hoover", "Step into the enigmatic world of 'Whispers in the Shadows,' where every page holds secrets untold. Unravel the mysteries that linger in the darkest corners of the mind, and let the shadows reveal their hidden truths.\r\n\r\nDare to uncover the secrets within.", "WIS987654321", 50.0, 40.0, 30.0, 35.0, "Whispers in the Shadows" },
                    { 3, "Julian Button", "Find solace in the pages of 'Serenity's Embrace,' a tale that unfolds like a gentle breeze. Allow the words to carry you to a world of tranquility and self-discovery, where every moment is a step towards inner peace.\r\n\r\nEmbrace the serenity within.", "SE20231234", 65.0, 60.0, 45.0, 50.0, "Serenity's Embrace" },
                    { 4, "Abby Muscles", "Indulge in the delightful notes of 'Sweet Symphony,' a harmonious blend of emotions and flavors. Let the story unfold like a sugary melody, leaving a lingering taste of joy and wonder on your literary palate.\r\n\r\nExperience the sweetness of life.", "SS123456789", 90.0, 85.0, 75.0, 80.0, "Sweet Symphony" },
                    { 5, "Ron Parker", "Plunge into the depths of 'Echoes of the Abyss,' where echoes of forgotten realms resonate. Navigate the mysterious currents of the ocean of time, and let the waves of the narrative carry you to uncharted territories.\r\n\r\nDiscover the echoes that linger beyond the horizon.", "EOTA5678901", 40.0, 37.0, 30.0, 35.0, "Echoes of the Abyss" },
                    { 6, "Laura Phantom", "Listen to the 'Whispers Among the Leaves,' where nature's secrets are revealed. The rustle of leaves tells tales of ancient wonders and timeless beauty. Immerse yourself in the delicate dance of life that unfolds beneath the leafy canopy.\r\n\r\nExperience the magic of nature's whispers.", "WAL987654321", 35.0, 33.0, 30.0, 32.0, "Whispers Among the Leaves" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
