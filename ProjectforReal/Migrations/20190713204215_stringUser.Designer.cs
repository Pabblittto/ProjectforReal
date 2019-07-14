﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectforReal.Models;

namespace ProjectforReal.Migrations
{
    [DbContext(typeof(Models.AppContext))]
    [Migration("20190713204215_stringUser")]
    partial class stringUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjectforReal.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("DateOfCreated")
                        .HasColumnType("Date");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("User");

                    b.HasKey("BlogId");

                    b.HasIndex("User")
                        .IsUnique();

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("ProjectforReal.Models.BlogUserIdentity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("BlogUserIdentity");
                });

            modelBuilder.Entity("ProjectforReal.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommentId1");

                    b.Property<string>("Content")
                        .HasMaxLength(400);

                    b.Property<DateTime>("DateOfComment")
                        .HasColumnType("Date");

                    b.Property<string>("OwnerId")
                        .IsRequired();

                    b.Property<int>("PostId");

                    b.HasKey("CommentId");

                    b.HasIndex("CommentId1");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ProjectforReal.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BlogId");

                    b.Property<string>("ContentOne");

                    b.Property<string>("ContentTwo");

                    b.Property<DateTime>("DateOfPost")
                        .HasColumnType("Date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ProjectforReal.Models.PostTag", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("TagId");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("ProjectforReal.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("OwnerID");

                    b.Property<bool>("PublicTag");

                    b.HasKey("TagId");

                    b.HasIndex("OwnerID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ProjectforReal.Models.Blog", b =>
                {
                    b.HasOne("ProjectforReal.Models.BlogUserIdentity", "BlogUserIdentity")
                        .WithOne("Blog")
                        .HasForeignKey("ProjectforReal.Models.Blog", "User")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectforReal.Models.Comment", b =>
                {
                    b.HasOne("ProjectforReal.Models.Comment")
                        .WithMany("Answers")
                        .HasForeignKey("CommentId1");

                    b.HasOne("ProjectforReal.Models.BlogUserIdentity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectforReal.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectforReal.Models.Post", b =>
                {
                    b.HasOne("ProjectforReal.Models.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId");
                });

            modelBuilder.Entity("ProjectforReal.Models.PostTag", b =>
                {
                    b.HasOne("ProjectforReal.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectforReal.Models.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectforReal.Models.Tag", b =>
                {
                    b.HasOne("ProjectforReal.Models.BlogUserIdentity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerID");
                });
#pragma warning restore 612, 618
        }
    }
}
