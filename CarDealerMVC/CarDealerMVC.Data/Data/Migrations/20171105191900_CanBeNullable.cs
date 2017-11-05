using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarDealerMVC.Data.Migrations
{
    public partial class CanBeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Sales_SaleId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_SuplierId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Cars_SaleId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SuplierId",
                table: "Parts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "Cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SaleId",
                table: "Cars",
                column: "SaleId",
                unique: true,
                filter: "[SaleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Sales_SaleId",
                table: "Cars",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_SuplierId",
                table: "Parts",
                column: "SuplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Sales_SaleId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_SuplierId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Cars_SaleId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Sales",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SuplierId",
                table: "Parts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SaleId",
                table: "Cars",
                column: "SaleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Sales_SaleId",
                table: "Cars",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_SuplierId",
                table: "Parts",
                column: "SuplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
