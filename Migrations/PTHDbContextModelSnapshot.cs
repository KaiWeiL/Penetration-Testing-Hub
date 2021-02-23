﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Penetration_Testing_Hub.Data;

namespace Penetration_Testing_Hub.Migrations
{
    [DbContext(typeof(PTHDbContext))]
    partial class PTHDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Penetration_Testing_Hub.Models.StageTechnique_Reconnaissance_Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifyTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OP")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("StageTechnique_Reconnaissance_Tools");
                });

            modelBuilder.Entity("Penetration_Testing_Hub.Models.StageTechnique_Reconnaissance_Tool_Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OP")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PostFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StageTechnique_Reconnaissance_ToolId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("StageTechnique_Reconnaissance_ToolId");

                    b.ToTable("StageTechnique_Reconnaissance_Tool_Posts");
                });

            modelBuilder.Entity("Penetration_Testing_Hub.Models.StageTechnique_Reconnaissance_Tool_Post", b =>
                {
                    b.HasOne("Penetration_Testing_Hub.Models.StageTechnique_Reconnaissance_Tool", "StageTechnique_Reconnaissance_Tool")
                        .WithMany("StageTechnique_Reconnaissance_Tool_Posts")
                        .HasForeignKey("StageTechnique_Reconnaissance_ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StageTechnique_Reconnaissance_Tool");
                });

            modelBuilder.Entity("Penetration_Testing_Hub.Models.StageTechnique_Reconnaissance_Tool", b =>
                {
                    b.Navigation("StageTechnique_Reconnaissance_Tool_Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
