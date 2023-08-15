using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HPIApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeDatatypeOfMobileNoFromIntToStringApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GallerySection",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GallerySection",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "MobileNo",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AboutUsSection",
                keyColumn: "Id",
                keyValue: 1,
                column: "VideoBoxUrl",
                value: "https://placehold.co/1024x692/png");

            migrationBuilder.UpdateData(
                table: "GallerySection",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "https://placehold.co/800x600/png");

            migrationBuilder.UpdateData(
                table: "GallerySection",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "https://placehold.co/800x600/png");

            migrationBuilder.UpdateData(
                table: "GallerySection",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "https://placehold.co/800x600/png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MobileNo",
                table: "AspNetUsers",
                type: "int",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AboutUsSection",
                keyColumn: "Id",
                keyValue: 1,
                column: "VideoBoxUrl",
                value: "\\img\\aboutus\\about.png");

            migrationBuilder.UpdateData(
                table: "GallerySection",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImgUrl",
                value: "\\img\\gallery\\\\fc039c34-b1b2-48ce-9f96-6aca220c9046.jpg");

            migrationBuilder.UpdateData(
                table: "GallerySection",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImgUrl",
                value: "\\img\\gallery\\\\981e6799-3e27-4e02-8a32-0ba8e50501b4.jpg");

            migrationBuilder.UpdateData(
                table: "GallerySection",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImgUrl",
                value: "\\img\\gallery\\\\c30e43d5-9428-4590-9e60-aef2717a484d.jpg");

            migrationBuilder.InsertData(
                table: "GallerySection",
                columns: new[] { "Id", "ImgUrl" },
                values: new object[,]
                {
                    { 4, "\\img\\gallery\\\\128316ed-e324-4597-9eaf-40116756631f.jpg" },
                    { 5, "\\img\\gallery\\\\8e509e6a-cc97-48f8-bd16-8529e7f72e0a.jpg" }
                });
        }
    }
}
