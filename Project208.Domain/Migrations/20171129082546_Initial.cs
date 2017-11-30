using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project208.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractStatuses",
                columns: table => new
                {
                    ContractStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true),
                    Vnese = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStatuses", x => x.ContractStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                });

            migrationBuilder.CreateTable(
                name: "SlowlyReturnTypes",
                columns: table => new
                {
                    SlowlyReturnTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlowlyReturnTypes", x => x.SlowlyReturnTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T1Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualLendMoney = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    AmountPerDay = table.Column<int>(nullable: false),
                    BorrowDate = table.Column<DateTime>(nullable: false),
                    CheckoutDate = table.Column<DateTime>(nullable: true),
                    ContractNote = table.Column<string>(nullable: true),
                    ContractStatusId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Interest = table.Column<int>(nullable: false),
                    Items = table.Column<string>(nullable: true),
                    LastReturnDate = table.Column<DateTime>(nullable: true),
                    RenewDate = table.Column<DateTime>(nullable: true),
                    RenewFrom = table.Column<int>(nullable: true),
                    RenewTo = table.Column<int>(nullable: true),
                    SlowlyReturnAmountPerDay = table.Column<int>(nullable: true),
                    SlowlyReturnStartDate = table.Column<DateTime>(nullable: true),
                    TotalDays = table.Column<int>(nullable: false),
                    TotalLeft = table.Column<int>(nullable: false),
                    UnableToPayStartDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_T1Contracts_ContractStatuses_ContractStatusId",
                        column: x => x.ContractStatusId,
                        principalTable: "ContractStatuses",
                        principalColumn: "ContractStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T1Contracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T2Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualLendMoney = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    AmountPerPeriod = table.Column<int>(nullable: false),
                    BorrowDate = table.Column<DateTime>(nullable: false),
                    CheckoutDate = table.Column<DateTime>(nullable: true),
                    ContractNote = table.Column<string>(nullable: true),
                    ContractStatusId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    InterestRate = table.Column<int>(nullable: false),
                    Items = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    ReturnAfterCheckout = table.Column<int>(nullable: true),
                    SlowlyReturnDate = table.Column<DateTime>(nullable: true),
                    SlowlyReturnStartDate = table.Column<DateTime>(nullable: true),
                    SlowlyReturnTypeId = table.Column<int>(nullable: false),
                    TotalLeft = table.Column<int>(nullable: false),
                    UnableToPayStartDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T2Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_T2Contracts_ContractStatuses_ContractStatusId",
                        column: x => x.ContractStatusId,
                        principalTable: "ContractStatuses",
                        principalColumn: "ContractStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T2Contracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T2Contracts_SlowlyReturnTypes_SlowlyReturnTypeId",
                        column: x => x.SlowlyReturnTypeId,
                        principalTable: "SlowlyReturnTypes",
                        principalColumn: "SlowlyReturnTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T1PaymentDetails",
                columns: table => new
                {
                    PaymentDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualPayDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ContractId = table.Column<int>(nullable: false),
                    ExtraMoney = table.Column<int>(nullable: false),
                    NeedToPayDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T1PaymentDetails", x => x.PaymentDetailId);
                    table.ForeignKey(
                        name: "FK_T1PaymentDetails_T1Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "T1Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T2PaymentDetails",
                columns: table => new
                {
                    PaymentDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualPayDate = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ContractID = table.Column<int>(nullable: false),
                    ExtraMoney = table.Column<int>(nullable: false),
                    NeedToPayDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T2PaymentDetails", x => x.PaymentDetailID);
                    table.ForeignKey(
                        name: "FK_T2PaymentDetails_T2Contracts_ContractID",
                        column: x => x.ContractID,
                        principalTable: "T2Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationId",
                table: "Customers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_T1Contracts_ContractStatusId",
                table: "T1Contracts",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_T1Contracts_CustomerId",
                table: "T1Contracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_T1PaymentDetails_ContractId",
                table: "T1PaymentDetails",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_T2Contracts_ContractStatusId",
                table: "T2Contracts",
                column: "ContractStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_T2Contracts_CustomerId",
                table: "T2Contracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_T2Contracts_SlowlyReturnTypeId",
                table: "T2Contracts",
                column: "SlowlyReturnTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_T2PaymentDetails_ContractID",
                table: "T2PaymentDetails",
                column: "ContractID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "T1PaymentDetails");

            migrationBuilder.DropTable(
                name: "T2PaymentDetails");

            migrationBuilder.DropTable(
                name: "T1Contracts");

            migrationBuilder.DropTable(
                name: "T2Contracts");

            migrationBuilder.DropTable(
                name: "ContractStatuses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SlowlyReturnTypes");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
