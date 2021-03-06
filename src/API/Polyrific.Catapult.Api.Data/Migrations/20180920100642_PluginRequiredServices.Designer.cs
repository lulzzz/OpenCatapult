﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Polyrific.Catapult.Api.Data;

namespace Polyrific.Catapult.Api.Data.Migrations
{
    [DbContext(typeof(CatapultDbContext))]
    [Migration("20180920100642_PluginRequiredServices")]
    partial class PluginRequiredServices
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ExternalService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<int?>("ExternalServiceTypeId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("Updated");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ExternalServiceTypeId");

                    b.ToTable("ExternalServices");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ExternalServiceProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllowedValues");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<int?>("ExternalServiceTypeId");

                    b.Property<bool>("IsRequired");

                    b.Property<bool>("IsSecret");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("ExternalServiceTypeId");

                    b.ToTable("ExternalServiceProperties");

                    b.HasData(
                        new { Id = 1, ConcurrencyStamp = "bb36270b-654f-42bc-8508-c8bd0acafb5b", Created = new DateTime(2018, 9, 19, 8, 14, 52, 52, DateTimeKind.Utc), Description = "Remote Url", ExternalServiceTypeId = 1, IsRequired = true, IsSecret = false, Name = "RemoteUrl" },
                        new { Id = 2, AllowedValues = "userPassword,authToken", ConcurrencyStamp = "504200ee-f48a-4efa-be48-e09d16ee8d65", Created = new DateTime(2018, 9, 19, 8, 14, 52, 52, DateTimeKind.Utc), Description = "Remote Credential Type (\"userPassword\" or \"authToken\")", ExternalServiceTypeId = 1, IsRequired = true, IsSecret = false, Name = "RemoteCredentialType" },
                        new { Id = 3, ConcurrencyStamp = "4bd86c55-ffc1-4c49-a4e4-c1ee809f311d", Created = new DateTime(2018, 9, 19, 8, 14, 52, 52, DateTimeKind.Utc), Description = "Remote Username", ExternalServiceTypeId = 1, IsRequired = false, IsSecret = false, Name = "RemoteUsername" },
                        new { Id = 4, ConcurrencyStamp = "c1eeaa4b-bdc2-4ef9-a52d-393fe9dca59a", Created = new DateTime(2018, 9, 19, 8, 14, 52, 52, DateTimeKind.Utc), Description = "Remote Password", ExternalServiceTypeId = 1, IsRequired = false, IsSecret = true, Name = "RemotePassword" },
                        new { Id = 5, ConcurrencyStamp = "416fcf67-35cf-4ea3-b534-dade4a81da88", Created = new DateTime(2018, 9, 19, 8, 14, 52, 52, DateTimeKind.Utc), Description = "Repository Auth Token", ExternalServiceTypeId = 1, IsRequired = false, IsSecret = true, Name = "RepoAuthToken" }
                    );
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ExternalServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("ExternalServiceTypes");

                    b.HasData(
                        new { Id = 1, ConcurrencyStamp = "2425fe0d-4e3e-4549-a9a7-60056097ce96", Created = new DateTime(2018, 9, 19, 8, 14, 52, 51, DateTimeKind.Utc), Name = "GitHub" }
                    );
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.JobCounter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("Count");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("JobCounters");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.JobDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name");

                    b.Property<int>("ProjectId");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("JobDefinitions");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.JobQueue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CatapultEngineIPAddress");

                    b.Property<string>("CatapultEngineId");

                    b.Property<string>("CatapultEngineMachineName");

                    b.Property<string>("CatapultEngineVersion");

                    b.Property<string>("Code");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<int?>("JobDefinitionId");

                    b.Property<string>("JobTasksStatus");

                    b.Property<string>("JobType");

                    b.Property<string>("OriginUrl");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Status");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("JobQueues");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.JobTaskDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("ConfigString");

                    b.Property<bool?>("ContinueWhenError");

                    b.Property<DateTime>("Created");

                    b.Property<int>("JobDefinitionId");

                    b.Property<string>("Name");

                    b.Property<int?>("Sequence");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("JobDefinitionId");

                    b.ToTable("JobTaskDefinitions");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.Plugin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name");

                    b.Property<string>("RequiredServicesString");

                    b.Property<string>("Type");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("Version");

                    b.HasKey("Id");

                    b.ToTable("Plugins");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Client");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("ConfigString");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsArchived");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ProjectDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("Label");

                    b.Property<string>("Name");

                    b.Property<int>("ProjectId");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectDataModels");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ProjectDataModelProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("ControlType");

                    b.Property<DateTime>("Created");

                    b.Property<string>("DataType");

                    b.Property<bool>("IsRequired");

                    b.Property<string>("Label");

                    b.Property<string>("Name");

                    b.Property<int>("ProjectDataModelId");

                    b.Property<int?>("RelatedProjectDataModelId");

                    b.Property<string>("RelationalType");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("ProjectDataModelId");

                    b.HasIndex("RelatedProjectDataModelId");

                    b.ToTable("ProjectDataModelProperties");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ProjectMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<int>("ProjectId");

                    b.Property<int>("ProjectMemberRoleId");

                    b.Property<DateTime?>("Updated");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ProjectMemberRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ProjectMemberRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("ProjectMemberRoles");

                    b.HasData(
                        new { Id = 1, ConcurrencyStamp = "ebe3a797-1758-4782-a77b-a78cd08433ea", Created = new DateTime(2018, 8, 15, 13, 38, 58, 310, DateTimeKind.Utc), Name = "Owner" },
                        new { Id = 2, ConcurrencyStamp = "49db1ab1-9f16-4db0-b32d-5a916c2d39cd", Created = new DateTime(2018, 8, 15, 13, 38, 58, 310, DateTimeKind.Utc), Name = "Maintainer" },
                        new { Id = 3, ConcurrencyStamp = "82dcaf01-bc5f-4964-b665-56074560861f", Created = new DateTime(2018, 8, 15, 13, 38, 58, 310, DateTimeKind.Utc), Name = "Contributor" },
                        new { Id = 4, ConcurrencyStamp = "d25d2b9c-b2dc-4a36-99af-0622de434e83", Created = new DateTime(2018, 8, 15, 13, 38, 58, 310, DateTimeKind.Utc), Name = "Member" }
                    );
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = 1, ConcurrencyStamp = "f8025fee-dec6-4528-9514-58339adc3383", Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                        new { Id = 2, ConcurrencyStamp = "c7cbed51-e910-4c2d-ab17-b27d3001ea47", Name = "Basic", NormalizedName = "BASIC" },
                        new { Id = 3, ConcurrencyStamp = "18f44ef4-86b2-4ebb-a400-b2615c9715e0", Name = "Guest", NormalizedName = "GUEST" },
                        new { Id = 4, ConcurrencyStamp = "0c810611-1e85-47cc-a7a1-7c57ff3e29bb", Name = "Engine", NormalizedName = "ENGINE" }
                    );
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool?>("IsCatapultEngine");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, AccessFailedCount = 0, ConcurrencyStamp = "6e60fade-1c1f-4f6a-ab7e-768358780783", Email = "admin@opencatapult.net", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "ADMIN@OPENCATAPULT.NET", NormalizedUserName = "ADMIN@OPENCATAPULT.NET", PasswordHash = "AQAAAAEAACcQAAAAEKBBPo49hQnfSTCnZPTPvpdvqOA5YKXoS8XT6S4hbX9vVTzjKzgXGmUUKWnpOvyjhA==", PhoneNumberConfirmed = false, SecurityStamp = "D4ZMGAXVOVP33V5FMDWVCZ7ZMH5R2JCK", TwoFactorEnabled = false, UserName = "admin@opencatapult.net" }
                    );
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationUserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new { UserId = 1, RoleId = 1 }
                    );
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationUserToken", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.CatapultEngineProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CatapultEngineId");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("LastSeen");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("CatapultEngineId")
                        .IsUnique()
                        .HasFilter("[CatapultEngineId] IS NOT NULL");

                    b.ToTable("CatapultEngineProfile");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationUserId");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.ToTable("UserProfile");

                    b.HasData(
                        new { Id = 1, ApplicationUserId = 1, ConcurrencyStamp = "99aa6fde-2675-4aa9-a60d-e45ba72fb9d0", Created = new DateTime(2018, 8, 23, 10, 4, 6, 797, DateTimeKind.Utc), IsActive = true }
                    );
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ExternalService", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.ExternalServiceType", "ExternalServiceType")
                        .WithMany()
                        .HasForeignKey("ExternalServiceTypeId");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ExternalServiceProperty", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.ExternalServiceType")
                        .WithMany("ExternalServiceProperties")
                        .HasForeignKey("ExternalServiceTypeId");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.JobDefinition", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.Project", "Project")
                        .WithMany("Jobs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.JobQueue", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.JobTaskDefinition", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.JobDefinition", "JobDefinition")
                        .WithMany("Tasks")
                        .HasForeignKey("JobDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ProjectDataModel", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.Project", "Project")
                        .WithMany("Models")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ProjectDataModelProperty", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.ProjectDataModel", "ProjectDataModel")
                        .WithMany("Properties")
                        .HasForeignKey("ProjectDataModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.ProjectDataModel", "RelatedProjectDataModel")
                        .WithMany()
                        .HasForeignKey("RelatedProjectDataModelId");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Core.Entities.ProjectMember", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.Project", "Project")
                        .WithMany("Members")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Polyrific.Catapult.Api.Core.Entities.ProjectMemberRole", "ProjectMemberRole")
                        .WithMany()
                        .HasForeignKey("ProjectMemberRoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Polyrific.Catapult.Api.Data.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationRoleClaim", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Data.Identity.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationUserClaim", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Data.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationUserLogin", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Data.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationUserRole", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Data.Identity.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Polyrific.Catapult.Api.Data.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.ApplicationUserToken", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Data.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.CatapultEngineProfile", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Data.Identity.ApplicationUser", "CatapultEngine")
                        .WithOne("CatapultEngineProfile")
                        .HasForeignKey("Polyrific.Catapult.Api.Data.Identity.CatapultEngineProfile", "CatapultEngineId");
                });

            modelBuilder.Entity("Polyrific.Catapult.Api.Data.Identity.UserProfile", b =>
                {
                    b.HasOne("Polyrific.Catapult.Api.Data.Identity.ApplicationUser", "ApplicationUser")
                        .WithOne("UserProfile")
                        .HasForeignKey("Polyrific.Catapult.Api.Data.Identity.UserProfile", "ApplicationUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
