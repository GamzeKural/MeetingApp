using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAASweHyKGDbkqvtu9AhjVY6wAAAAACAAAAAAAQZgAAAAEAACAAAACF7rogA6ujnBsb8tKibaNV+IvqQlk+d6qsSJpzJsUKmQAAAAAOgAAAAAIAACAAAABsviFWZ9273T2x5dED3A5zJ1ACbPqoVQCR8xaY6f9IkxAAAAB5tHhSe+zQv9bt953hZs3SQAAAANA2ek7bKl1Q6moMQZASCbZOIqUTiRlXDNL9c3by7YWP1z5IqlR9C0B88NDf60r+QT/WVHF5RxF0iaTwaxNsJpI=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "123");
        }
    }
}
