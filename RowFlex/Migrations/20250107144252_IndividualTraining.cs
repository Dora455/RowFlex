using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RowFlex.Migrations
{
    /// <inheritdoc />
    public partial class IndividualTraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndividualTrainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Watts = table.Column<double>(type: "float", nullable: false),
                    WattsPer500m = table.Column<double>(type: "float", nullable: false),
                    TrainingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Cart = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualTrainings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualTrainings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualTrainings_TrainingId",
                table: "IndividualTrainings",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualTrainings_UserId",
                table: "IndividualTrainings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualTrainings");
        }
    }
}
