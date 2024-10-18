using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComisionQA.Migrations
{
    /// <inheritdoc />
    public partial class sale_histories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sale_histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    saleDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    totalAmount = table.Column<float>(type: "float", nullable: false),
                    vehicleId = table.Column<int>(type: "integer", nullable: false),
                    detailId = table.Column<int>(type: "integer", nullable: false),
                    profileId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NOW()"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NOW()"),
                    deletedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleHistories", x => x.Id);
                    table.ForeignKey("FK_SaleHistories_Profiles_profile_id", x => x.profileId, "profiles", "Id");
                    table.ForeignKey("FK_SaleHistories_Vehicles_vehicle_id", x => x.vehicleId, "vehicle_models", "Id");
                    table.ForeignKey("FK_SaleHistories_Details_detail_id", x => x.detailId, "order_details", "Id");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sale_histories");
        }
    }
}
