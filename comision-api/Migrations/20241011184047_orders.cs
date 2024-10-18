using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ComisionQA.Migrations
{
    /// <inheritdoc />
    public partial class orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderDate = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "NOW()"),
                    orderStatus = table.Column<int>(type: "int", nullable: false),
                    profileId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NOW()"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NOW()"),
                    deletedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey("FK_Orders_Profiles_profileId",
                        x => x.profileId, "profiles","Id");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
