using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    TrainingId = table.Column<int>(type: "integer", nullable: false),
                    TrainingType = table.Column<string>(type: "text", nullable: false),
                    MovementName = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Set1_kg = table.Column<double>(type: "double precision", nullable: false),
                    Set1_reps = table.Column<double>(type: "double precision", nullable: false),
                    Set2_kg = table.Column<double>(type: "double precision", nullable: false),
                    Set2_reps = table.Column<double>(type: "double precision", nullable: false),
                    Set3_kg = table.Column<double>(type: "double precision", nullable: false),
                    Set3_reps = table.Column<double>(type: "double precision", nullable: false),
                    Set4_kg = table.Column<double>(type: "double precision", nullable: true),
                    Set4_reps = table.Column<double>(type: "double precision", nullable: true),
                    Set5_kg = table.Column<double>(type: "double precision", nullable: true),
                    Set5_reps = table.Column<double>(type: "double precision", nullable: true),
                    Set6_kg = table.Column<double>(type: "double precision", nullable: true),
                    Set6_reps = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingMovements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Date = table.Column<string>(type: "text", nullable: false),
                    TrainingType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingMovements");

            migrationBuilder.DropTable(
                name: "Trainings");
        }
    }
}
