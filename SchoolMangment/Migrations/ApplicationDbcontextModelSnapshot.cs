﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolMangment.dbContext;

#nullable disable

namespace SchoolMangment.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    partial class ApplicationDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SchoolMangment.Models.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SchoolMangment.Models.Exams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOnly")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.Property<int>("Term")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectsId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("SchoolMangment.Models.StudentMarks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExamsId")
                        .HasColumnType("int");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("StudenstId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("StudentMarks");
                });

            modelBuilder.Entity("SchoolMangment.Models.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentsId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentsId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolMangment.Models.SubjectLectures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectsId");

                    b.ToTable("SubjectLectures");
                });

            modelBuilder.Entity("SchoolMangment.Models.Subjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentsId")
                        .HasColumnType("int");

                    b.Property<int>("MinimumDegree")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentsId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SchoolMangment.Models.Exams", b =>
                {
                    b.HasOne("SchoolMangment.Models.Subjects", "Subjects")
                        .WithMany("Exams")
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SchoolMangment.Models.StudentMarks", b =>
                {
                    b.HasOne("SchoolMangment.Models.Exams", "Exams")
                        .WithMany("StudentMarks")
                        .HasForeignKey("ExamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolMangment.Models.Students", "Students")
                        .WithMany("StudentMarks")
                        .HasForeignKey("StudentsId");

                    b.Navigation("Exams");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolMangment.Models.Students", b =>
                {
                    b.HasOne("SchoolMangment.Models.Departments", "Departments")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("SchoolMangment.Models.SubjectLectures", b =>
                {
                    b.HasOne("SchoolMangment.Models.Subjects", "Subjects")
                        .WithMany("SubjectLectures")
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SchoolMangment.Models.Subjects", b =>
                {
                    b.HasOne("SchoolMangment.Models.Departments", "Departments")
                        .WithMany("Subjects")
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("SchoolMangment.Models.Departments", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SchoolMangment.Models.Exams", b =>
                {
                    b.Navigation("StudentMarks");
                });

            modelBuilder.Entity("SchoolMangment.Models.Students", b =>
                {
                    b.Navigation("StudentMarks");
                });

            modelBuilder.Entity("SchoolMangment.Models.Subjects", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("SubjectLectures");
                });
#pragma warning restore 612, 618
        }
    }
}
