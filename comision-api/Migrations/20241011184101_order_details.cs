using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ComisionQA.Migrations
{
    /// <inheritdoc />
    public partial class order_details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<float>(type: "float", nullable: false),
                    detailStatus = table.Column<int>(type: "integer", nullable: false),
                    deleveryDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    vehicleModelId = table.Column<int>(type: "integer", nullable: false),
                    orderId = table.Column<int>(type: "integer", nullable: false),
                    createdAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NOW()"),
                    updatedAt = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NOW()"),
                    deletedAt = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.orderId, "orders", "Id");
                    table.ForeignKey("FK_OrderDetails_VehicleModels_VehicleModelId",
                        column: x => x.vehicleModelId, "vehicle_models", "Id");


                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_details");
        }
    }
}
