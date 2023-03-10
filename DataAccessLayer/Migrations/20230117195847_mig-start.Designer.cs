// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230117195847_mig-start")]
    partial class migstart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"), 1L, 1);

                    b.Property<string>("CommentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentPersonNickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CommentStatus")
                        .HasColumnType("bit");

                    b.Property<int?>("EntryID")
                        .HasColumnType("int");

                    b.Property<int>("EntryScore")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("EntryID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Departmant", b =>
                {
                    b.Property<int>("DepartmantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmantID"), 1L, 1);

                    b.Property<string>("DepartmantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DepartmantStatus")
                        .HasColumnType("bit");

                    b.Property<int?>("UniversityID")
                        .HasColumnType("int");

                    b.HasKey("DepartmantID");

                    b.HasIndex("UniversityID");

                    b.ToTable("Departmants");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Entry", b =>
                {
                    b.Property<int>("EntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntryID"), 1L, 1);

                    b.Property<int?>("DepartmantID")
                        .HasColumnType("int");

                    b.Property<string>("EntryContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EntryStatus")
                        .HasColumnType("bit");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("EntryID");

                    b.HasIndex("DepartmantID");

                    b.HasIndex("PersonID");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("EntityLayer.Concrete.EntryLike", b =>
                {
                    b.Property<int>("EntryLikeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EntryLikeID"), 1L, 1);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("EntryID")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("EntryLikeID");

                    b.ToTable("EntryLikes");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"), 1L, 1);

                    b.Property<int?>("DepartmantID")
                        .HasColumnType("int");

                    b.Property<string>("PersonFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonNickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PersonStatus")
                        .HasColumnType("bit");

                    b.Property<string>("PersonTelNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.HasIndex("DepartmantID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EntityLayer.Concrete.University", b =>
                {
                    b.Property<int>("UniversityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniversityID"), 1L, 1);

                    b.Property<string>("UniversityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UniversityStatus")
                        .HasColumnType("bit");

                    b.HasKey("UniversityID");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Entry", "Entry")
                        .WithMany("Comments")
                        .HasForeignKey("EntryID");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Departmant", b =>
                {
                    b.HasOne("EntityLayer.Concrete.University", "University")
                        .WithMany("Departmants")
                        .HasForeignKey("UniversityID");

                    b.Navigation("University");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Entry", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Departmant", "Departmant")
                        .WithMany("Entries")
                        .HasForeignKey("DepartmantID");

                    b.HasOne("EntityLayer.Concrete.Person", "Persons")
                        .WithMany("Entrys")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departmant");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Person", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Departmant", "Departmant")
                        .WithMany("Persons")
                        .HasForeignKey("DepartmantID");

                    b.Navigation("Departmant");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Departmant", b =>
                {
                    b.Navigation("Entries");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Entry", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Person", b =>
                {
                    b.Navigation("Entrys");
                });

            modelBuilder.Entity("EntityLayer.Concrete.University", b =>
                {
                    b.Navigation("Departmants");
                });
#pragma warning restore 612, 618
        }
    }
}
