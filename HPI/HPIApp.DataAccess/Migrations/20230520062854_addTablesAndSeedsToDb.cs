using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HPIApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTablesAndSeedsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUsSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoBoxUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mainContentTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    mainContentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentTitle_1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contentDescription_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentTitle_2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contentDescription_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentTitle_3 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contentDescription_3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    twitterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    facebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    instagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventsSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GallerySection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GallerySection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Header2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    backgroundImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    textLogo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Religion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhyUsSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mainContentTitle = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    mainContentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentTitle_1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contentDescription_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentTitle_2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contentDescription_2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentTitle_3 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    contentDescription_3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyUsSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "Date", nullable: true),
                    MobileNo = table.Column<int>(type: "int", maxLength: 30, nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    MemberPhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    ReligionId = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Religion_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestimonialSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isAdded = table.Column<bool>(type: "bit", nullable: false),
                    Testimony = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestimonialSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestimonialSection_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentRefNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentProofUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transaction_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutUsSection",
                columns: new[] { "Id", "VideoBoxUrl", "VideoUrl", "contentDescription_1", "contentDescription_2", "contentDescription_3", "contentTitle_1", "contentTitle_2", "contentTitle_3", "mainContentDescription", "mainContentTitle" },
                values: new object[] { 1, "\\img\\aboutus\\about.png", "https://www.youtube.com/watch?v=uCPjdfCUowg&list=RDpe5H8xY2pyY&index=6", "We believe that prayer is a powerful tool for healing. We offer prayer for those who are seeking physical, emotional, or spiritual healing.", "We offer counseling to help people deal with the challenges of life. We believe that counseling can help people to heal from emotional wounds and to find hope for the future.", "We offer support groups for people who are dealing with specific challenges, such as grief, addiction, or chronic illness. We believe that support groups can provide a safe place for people to share their experiences and to find support from others who understand what they are going through.", "Prayer", "Counseling", "Support groups", "The Healing Ministry is a non-profit organization dedicated to providing healing and hope to those who are hurting. We offer a variety of services, including prayer, counseling, and support groups. We believe that everyone deserves to experience the healing power of God.", "About Us" });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nueva Ecija" },
                    { 2, "Cavite" }
                });

            migrationBuilder.InsertData(
                table: "CompanyDetails",
                columns: new[] { "Id", "Address", "Email", "PhoneNo", "facebookUrl", "instagramUrl", "linkedinUrl", "twitterUrl" },
                values: new object[] { 1, "Palo Maria, Bongabon, Nueva Ecija", "himplusinternational@gmail.com", "+63 915 4094657", null, null, null, null });

            migrationBuilder.InsertData(
                table: "EventsSection",
                columns: new[] { "Id", "EventDescription" },
                values: new object[] { 1, "Healing services: Healing services are typically held in churches or other religious settings. They involve prayer, worship, and sometimes the laying on of hands.\r\n\r\nHealing conferences: Healing conferences are typically held over a weekend or a week. They feature speakers, workshops, and other activities that focus on healing.\r\n\r\nHealing retreats: Healing retreats are typically held in a quiet setting, such as a camp or a retreat center. They offer participants the opportunity to relax, pray, and receive healing.\r\n\r\nHealing prayer groups: Healing prayer groups are typically held on a weekly or monthly basis. They provide a safe place for people to come together to pray for healing.\r\n\r\nHealing ministries: Healing ministries are typically run by individuals or organizations that are dedicated to providing healing to those who are hurting. They offer a variety of services, such as prayer, counseling, and support groups." });

            migrationBuilder.InsertData(
                table: "FAQSection",
                columns: new[] { "Id", "Answer", "Question" },
                values: new object[,]
                {
                    { 1, "oo dahil paperless and validation at online remittance lamang Ang proseso. Matagal na Ang 2 days", "Mabilis lang ba matanggap Ang assistance?" },
                    { 2, "oo subalit mag aaply muli Ng registration at magbabayad Ng registration fee na P120.00 at initial monthly fund na P150.00", "Pwede pa bang bumalik kung matagal nang huminto sa" },
                    { 3, "mag apply Ng activation status at magbayad Ng activation fee na P50 at bayaran Ang di nahulugan.", "Ano pwede Gawin kung gusto bumalik maging active?" }
                });

            migrationBuilder.InsertData(
                table: "GallerySection",
                columns: new[] { "Id", "ImgUrl" },
                values: new object[,]
                {
                    { 1, "\\img\\gallery\\\\fc039c34-b1b2-48ce-9f96-6aca220c9046.jpg" },
                    { 2, "\\img\\gallery\\\\981e6799-3e27-4e02-8a32-0ba8e50501b4.jpg" },
                    { 3, "\\img\\gallery\\\\c30e43d5-9428-4590-9e60-aef2717a484d.jpg" },
                    { 4, "\\img\\gallery\\\\128316ed-e324-4597-9eaf-40116756631f.jpg" },
                    { 5, "\\img\\gallery\\\\8e509e6a-cc97-48f8-bd16-8529e7f72e0a.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "HeroSection",
                columns: new[] { "Id", "Header1", "Header2", "backgroundImgUrl" },
                values: new object[] { 1, "HPI", "HIM Plus International", "\\img\\herosection\\2a3a35a4-4544-48b9-9066-6ac4d279ebcf.jpg" });

            migrationBuilder.InsertData(
                table: "Logo",
                columns: new[] { "Id", "logoUrl", "textLogo" },
                values: new object[] { 1, "\\img\\logo\\9d4cc6e7-4ea9-4724-8a3b-782d525c3844.png", "HIM Plus International" });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "GCash" });

            migrationBuilder.InsertData(
                table: "Religion",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Seventh Day Adventist" },
                    { 2, "Others" }
                });

            migrationBuilder.InsertData(
                table: "WhyUsSection",
                columns: new[] { "Id", "contentDescription_1", "contentDescription_2", "contentDescription_3", "contentTitle_1", "contentTitle_2", "contentTitle_3", "mainContentDescription", "mainContentTitle" },
                values: new object[] { 1, "We offer healing prayer to those who are seeking physical, emotional, or spiritual healing. We believe that God has the power to heal all kinds of sickness and disease. We invite you to come and experience the healing power of God through prayer.", "We offer healing touch to those who are seeking physical, emotional, or spiritual healing. Healing touch is a gentle, non-invasive form of energy healing that can help to promote relaxation, reduce pain, and improve overall well-being. We invite you to come and experience the healing power of God through healing touch.", "We offer laying on of hands to those who are seeking physical, emotional, or spiritual healing. Laying on of hands is a biblical practice that has been used for centuries to pray for healing. We believe that God can use this simple act to bring healing to those who are hurting. We invite you to come and experience the healing power of God through laying on of hands.", "Healing Prayer", "Healing Touch", "Laying on of Hands", "We are a ministry dedicated to providing healing and hope to those who are hurting. We offer a variety of services, including prayer, counseling, and support groups. We believe that everyone deserves to experience the healing power of God.", "Why HPI?" });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "BranchId", "Name", "Slot" },
                values: new object[,]
                {
                    { 1, 1, "Cluster A", 3000 },
                    { 2, 1, "Cluster B", 3000 },
                    { 3, 2, "Cluster A", 3000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClassId",
                table: "AspNetUsers",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ReligionId",
                table: "AspNetUsers",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Class_BranchId",
                table: "Class",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_TestimonialSection_ApplicationUserId",
                table: "TestimonialSection",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ApplicationUserId",
                table: "Transaction",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PaymentMethodId",
                table: "Transaction",
                column: "PaymentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUsSection");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "ContactSection");

            migrationBuilder.DropTable(
                name: "EventsSection");

            migrationBuilder.DropTable(
                name: "FAQSection");

            migrationBuilder.DropTable(
                name: "GallerySection");

            migrationBuilder.DropTable(
                name: "HeroSection");

            migrationBuilder.DropTable(
                name: "Logo");

            migrationBuilder.DropTable(
                name: "TestimonialSection");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "WhyUsSection");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Religion");

            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
