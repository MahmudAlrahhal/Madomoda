﻿// <auto-generated />
using MadoDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MadoDataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231124121449_addingaForiegnKeyForCategoryProductRelation")]
    partial class addingaForiegnKeyForCategoryProductRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MadoModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 2,
                            Name = "FirstCat"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 1,
                            Name = "SecondCat"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "ThirdCat"
                        });
                });

            modelBuilder.Entity("MadoModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Billy Spark",
                            CategoryId = 4,
                            Description = "Embark on a timeless adventure with 'Eternal Journey.' This captivating tale weaves through the tapestry of existence, offering a mesmerizing blend of mystery and introspection.\r\n\r\nJourney into the unknown as you explore the depths of the human soul.",
                            ISBN = "EJ2023001",
                            ListPrice = 120.0,
                            Price = 110.0,
                            Price100 = 100.0,
                            Price50 = 105.0,
                            Title = "Eternal Journey"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Nancy Hoover",
                            CategoryId = 5,
                            Description = "Step into the enigmatic world of 'Whispers in the Shadows,' where every page holds secrets untold. Unravel the mysteries that linger in the darkest corners of the mind, and let the shadows reveal their hidden truths.\r\n\r\nDare to uncover the secrets within.",
                            ISBN = "WIS987654321",
                            ListPrice = 50.0,
                            Price = 40.0,
                            Price100 = 30.0,
                            Price50 = 35.0,
                            Title = "Whispers in the Shadows"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Julian Button",
                            CategoryId = 6,
                            Description = "Find solace in the pages of 'Serenity's Embrace,' a tale that unfolds like a gentle breeze. Allow the words to carry you to a world of tranquility and self-discovery, where every moment is a step towards inner peace.\r\n\r\nEmbrace the serenity within.",
                            ISBN = "SE20231234",
                            ListPrice = 65.0,
                            Price = 60.0,
                            Price100 = 45.0,
                            Price50 = 50.0,
                            Title = "Serenity's Embrace"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Abby Muscles",
                            CategoryId = 5,
                            Description = "Indulge in the delightful notes of 'Sweet Symphony,' a harmonious blend of emotions and flavors. Let the story unfold like a sugary melody, leaving a lingering taste of joy and wonder on your literary palate.\r\n\r\nExperience the sweetness of life.",
                            ISBN = "SS123456789",
                            ListPrice = 90.0,
                            Price = 85.0,
                            Price100 = 75.0,
                            Price50 = 80.0,
                            Title = "Sweet Symphony"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Ron Parker",
                            CategoryId = 5,
                            Description = "Plunge into the depths of 'Echoes of the Abyss,' where echoes of forgotten realms resonate. Navigate the mysterious currents of the ocean of time, and let the waves of the narrative carry you to uncharted territories.\r\n\r\nDiscover the echoes that linger beyond the horizon.",
                            ISBN = "EOTA5678901",
                            ListPrice = 40.0,
                            Price = 37.0,
                            Price100 = 30.0,
                            Price50 = 35.0,
                            Title = "Echoes of the Abyss"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Laura Phantom",
                            CategoryId = 5,
                            Description = "Listen to the 'Whispers Among the Leaves,' where nature's secrets are revealed. The rustle of leaves tells tales of ancient wonders and timeless beauty. Immerse yourself in the delicate dance of life that unfolds beneath the leafy canopy.\r\n\r\nExperience the magic of nature's whispers.",
                            ISBN = "WAL987654321",
                            ListPrice = 35.0,
                            Price = 33.0,
                            Price100 = 30.0,
                            Price50 = 32.0,
                            Title = "Whispers Among the Leaves"
                        });
                });

            modelBuilder.Entity("MadoModels.Product", b =>
                {
                    b.HasOne("MadoModels.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
