using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyLand.Persistence.Migrations
{
    public partial class CreatePaymentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 524, DateTimeKind.Local).AddTicks(2668),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 567, DateTimeKind.Local).AddTicks(4654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Types",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 523, DateTimeKind.Local).AddTicks(3050),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 565, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 523, DateTimeKind.Local).AddTicks(5772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 566, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 523, DateTimeKind.Local).AddTicks(9628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 567, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Items",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(9904),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 565, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Images",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(7199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 564, DateTimeKind.Local).AddTicks(6806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Features",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(5377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 564, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(3436),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 563, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 509, DateTimeKind.Local).AddTicks(57),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 536, DateTimeKind.Local).AddTicks(6447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(280),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 562, DateTimeKind.Local).AddTicks(9600));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "UserAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 567, DateTimeKind.Local).AddTicks(4654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 524, DateTimeKind.Local).AddTicks(2668));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Types",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 565, DateTimeKind.Local).AddTicks(9238),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 523, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 566, DateTimeKind.Local).AddTicks(5468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 523, DateTimeKind.Local).AddTicks(5772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 567, DateTimeKind.Local).AddTicks(575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 523, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Items",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 565, DateTimeKind.Local).AddTicks(1951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(9904));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Images",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 564, DateTimeKind.Local).AddTicks(6806),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(7199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Features",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 564, DateTimeKind.Local).AddTicks(2311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 563, DateTimeKind.Local).AddTicks(7496),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 536, DateTimeKind.Local).AddTicks(6447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 509, DateTimeKind.Local).AddTicks(57));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 8, 23, 17, 13, 22, 562, DateTimeKind.Local).AddTicks(9600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 8, 24, 15, 5, 5, 522, DateTimeKind.Local).AddTicks(280));
        }
    }
}
