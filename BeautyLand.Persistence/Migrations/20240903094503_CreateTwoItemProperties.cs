using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyLand.Persistence.Migrations
{
    public partial class CreateTwoItemProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 589, DateTimeKind.Local).AddTicks(6195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 576, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "User",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 589, DateTimeKind.Local).AddTicks(1607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 575, DateTimeKind.Local).AddTicks(7928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Types",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 586, DateTimeKind.Local).AddTicks(3143),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 574, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 588, DateTimeKind.Local).AddTicks(5921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 575, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 587, DateTimeKind.Local).AddTicks(6816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 574, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 588, DateTimeKind.Local).AddTicks(2619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 575, DateTimeKind.Local).AddTicks(3247));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Items",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 585, DateTimeKind.Local).AddTicks(7028),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 573, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentage",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OldPrice",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Images",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 585, DateTimeKind.Local).AddTicks(3026),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 573, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Features",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 584, DateTimeKind.Local).AddTicks(9872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 573, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Discounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 586, DateTimeKind.Local).AddTicks(8888),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 574, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 584, DateTimeKind.Local).AddTicks(5261),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 572, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 569, DateTimeKind.Local).AddTicks(7959),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 565, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 584, DateTimeKind.Local).AddTicks(984),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 572, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.CreateTable(
                name: "DiscountHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountHistories_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountHistories_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountHistories_DiscountId",
                table: "DiscountHistories",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountHistories_OrderId",
                table: "DiscountHistories",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountHistories");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "Items");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 576, DateTimeKind.Local).AddTicks(2350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 589, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "User",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 575, DateTimeKind.Local).AddTicks(7928),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 589, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Types",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 574, DateTimeKind.Local).AddTicks(688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 586, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 575, DateTimeKind.Local).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 588, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 574, DateTimeKind.Local).AddTicks(9353),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 587, DateTimeKind.Local).AddTicks(6816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 575, DateTimeKind.Local).AddTicks(3247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 588, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Items",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 573, DateTimeKind.Local).AddTicks(6598),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 585, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Images",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 573, DateTimeKind.Local).AddTicks(4019),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 585, DateTimeKind.Local).AddTicks(3026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Features",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 573, DateTimeKind.Local).AddTicks(2058),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 584, DateTimeKind.Local).AddTicks(9872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Discounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 574, DateTimeKind.Local).AddTicks(4543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 586, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 572, DateTimeKind.Local).AddTicks(9381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 584, DateTimeKind.Local).AddTicks(5261));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 565, DateTimeKind.Local).AddTicks(7635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 569, DateTimeKind.Local).AddTicks(7959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 30, 12, 35, 14, 572, DateTimeKind.Local).AddTicks(6540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 11, 45, 2, 584, DateTimeKind.Local).AddTicks(984));
        }
    }
}
