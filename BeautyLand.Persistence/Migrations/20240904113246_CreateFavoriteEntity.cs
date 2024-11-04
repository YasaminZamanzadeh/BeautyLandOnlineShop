using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyLand.Persistence.Migrations
{
    public partial class CreateFavoriteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 429, DateTimeKind.Local).AddTicks(2913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 314, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Types",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 425, DateTimeKind.Local).AddTicks(4456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 309, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 428, DateTimeKind.Local).AddTicks(9610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 313, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 427, DateTimeKind.Local).AddTicks(4481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 312, DateTimeKind.Local).AddTicks(3698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 428, DateTimeKind.Local).AddTicks(5526),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 313, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Items",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(8251),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 309, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Images",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(3868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 308, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Features",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(474),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 308, DateTimeKind.Local).AddTicks(2564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Discounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 425, DateTimeKind.Local).AddTicks(9882),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 310, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 422, DateTimeKind.Local).AddTicks(5815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 307, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 410, DateTimeKind.Local).AddTicks(6808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 296, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 422, DateTimeKind.Local).AddTicks(1615),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 307, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 426, DateTimeKind.Local).AddTicks(5657)),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ItemId",
                table: "Favorites",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 314, DateTimeKind.Local).AddTicks(3167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 429, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Types",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 309, DateTimeKind.Local).AddTicks(8941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 425, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 313, DateTimeKind.Local).AddTicks(9187),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 428, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 312, DateTimeKind.Local).AddTicks(3698),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 427, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 313, DateTimeKind.Local).AddTicks(4707),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 428, DateTimeKind.Local).AddTicks(5526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Items",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 309, DateTimeKind.Local).AddTicks(1571),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Images",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 308, DateTimeKind.Local).AddTicks(6054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Features",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 308, DateTimeKind.Local).AddTicks(2564),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Discounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 310, DateTimeKind.Local).AddTicks(4665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 425, DateTimeKind.Local).AddTicks(9882));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 307, DateTimeKind.Local).AddTicks(8697),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 422, DateTimeKind.Local).AddTicks(5815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 296, DateTimeKind.Local).AddTicks(7431),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 410, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 3, 13, 47, 20, 307, DateTimeKind.Local).AddTicks(3976),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 422, DateTimeKind.Local).AddTicks(1615));
        }
    }
}
