using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyLand.Persistence.Migrations
{
    public partial class UpdateBasketntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 115, DateTimeKind.Local).AddTicks(304),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 429, DateTimeKind.Local).AddTicks(2913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Types",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 113, DateTimeKind.Local).AddTicks(1289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 425, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 114, DateTimeKind.Local).AddTicks(7511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 428, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 114, DateTimeKind.Local).AddTicks(1074),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 427, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 114, DateTimeKind.Local).AddTicks(5260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 428, DateTimeKind.Local).AddTicks(5526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Items",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 112, DateTimeKind.Local).AddTicks(6833),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(8251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Images",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 112, DateTimeKind.Local).AddTicks(4005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(3868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Features",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 112, DateTimeKind.Local).AddTicks(1705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Favorites",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 113, DateTimeKind.Local).AddTicks(8182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 426, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Discounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 113, DateTimeKind.Local).AddTicks(4593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 425, DateTimeKind.Local).AddTicks(9882));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 111, DateTimeKind.Local).AddTicks(9403),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 422, DateTimeKind.Local).AddTicks(5815));

            migrationBuilder.AlterColumn<int>(
                name: "DiscountAmount",
                table: "Baskets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 103, DateTimeKind.Local).AddTicks(5485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 410, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 111, DateTimeKind.Local).AddTicks(6419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 422, DateTimeKind.Local).AddTicks(1615));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 115, DateTimeKind.Local).AddTicks(304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Types",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 425, DateTimeKind.Local).AddTicks(4456),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 113, DateTimeKind.Local).AddTicks(1289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 428, DateTimeKind.Local).AddTicks(9610),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 114, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 427, DateTimeKind.Local).AddTicks(4481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 114, DateTimeKind.Local).AddTicks(1074));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 428, DateTimeKind.Local).AddTicks(5526),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 114, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Items",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(8251),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 112, DateTimeKind.Local).AddTicks(6833));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Images",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(3868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 112, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Features",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 424, DateTimeKind.Local).AddTicks(474),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 112, DateTimeKind.Local).AddTicks(1705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Favorites",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 426, DateTimeKind.Local).AddTicks(5657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 113, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Discounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 425, DateTimeKind.Local).AddTicks(9882),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 113, DateTimeKind.Local).AddTicks(4593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 422, DateTimeKind.Local).AddTicks(5815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 111, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.AlterColumn<int>(
                name: "DiscountAmount",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 410, DateTimeKind.Local).AddTicks(6808),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 103, DateTimeKind.Local).AddTicks(5485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 9, 4, 13, 32, 45, 422, DateTimeKind.Local).AddTicks(1615),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 9, 4, 16, 35, 27, 111, DateTimeKind.Local).AddTicks(6419));
        }
    }
}
