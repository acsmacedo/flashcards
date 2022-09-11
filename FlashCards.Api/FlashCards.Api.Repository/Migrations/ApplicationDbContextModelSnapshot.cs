﻿// <auto-generated />
using System;
using FlashCards.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlashCards.Api.Core.Accounts.Account", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("account_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("password");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasName("pk_account_id");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.Categories.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_category_id");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.Denunciations.Denunciation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("denunciation_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AccuserID")
                        .HasColumnType("int")
                        .HasColumnName("accuser_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("description");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<int>("SuspectID")
                        .HasColumnType("int")
                        .HasColumnName("suspect_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("title");

                    b.HasKey("ID")
                        .HasName("pk_denunciation_id");

                    b.HasIndex("AccuserID");

                    b.HasIndex("SuspectID");

                    b.ToTable("denunciations", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.Directories.UserDirectory", b =>
                {
                    b.Property<int>("UserDirectoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_directory_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserDirectoryID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.Property<int?>("UserDirectoryParentID")
                        .HasColumnType("int")
                        .HasColumnName("user_directory_parent_id");

                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("UserDirectoryID")
                        .HasName("pk_user_directory_id");

                    b.HasIndex("UserDirectoryParentID");

                    b.HasIndex("UserID");

                    b.ToTable("user_directories", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardCollection", b =>
                {
                    b.Property<int>("FlashCardCollectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlashCardCollectionID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserDirectoryID")
                        .HasColumnType("int");

                    b.HasKey("FlashCardCollectionID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserDirectoryID");

                    b.ToTable("FlashCardCollection");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardItem", b =>
                {
                    b.Property<int>("FlashCardItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlashCardItemID"), 1L, 1);

                    b.Property<int>("CollectionFlashCardCollectionID")
                        .HasColumnType("int");

                    b.Property<string>("FrontDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VerseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlashCardItemID");

                    b.HasIndex("CollectionFlashCardCollectionID");

                    b.ToTable("FlashCardItem");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardRating", b =>
                {
                    b.Property<int>("FlashCardRatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlashCardRatingID"), 1L, 1);

                    b.Property<int>("CollectionFlashCardCollectionID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("FlashCardRatingID");

                    b.HasIndex("CollectionFlashCardCollectionID");

                    b.ToTable("FlashCardRating");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardTag", b =>
                {
                    b.Property<int>("FlashCardTagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlashCardTagID"), 1L, 1);

                    b.Property<int>("CollectionFlashCardCollectionID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlashCardTagID");

                    b.HasIndex("CollectionFlashCardCollectionID");

                    b.ToTable("FlashCardTag");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Notifications.Notification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("notification_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("message");

                    b.Property<DateTime>("NotificationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("notification_date");

                    b.Property<DateTime?>("ReadDate")
                        .HasColumnType("datetime")
                        .HasColumnName("read_date");

                    b.Property<DateTime?>("SentDate")
                        .HasColumnType("datetime")
                        .HasColumnName("sent_date");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("title");

                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("ID")
                        .HasName("pk_notification_id");

                    b.HasIndex("UserID");

                    b.ToTable("notifications", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.Users.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AccountID")
                        .HasColumnType("int")
                        .HasColumnName("account_id");

                    b.Property<string>("Instagram")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("instagram");

                    b.Property<string>("Interests")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("interests");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_user_id");

                    b.HasIndex("AccountID")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.Users.UserRelationship", b =>
                {
                    b.Property<int>("FollowedID")
                        .HasColumnType("int")
                        .HasColumnName("followed_id");

                    b.Property<int>("FollowerID")
                        .HasColumnType("int")
                        .HasColumnName("follower_id");

                    b.Property<bool>("EnableNotification")
                        .HasColumnType("bit")
                        .HasColumnName("enable_notification");

                    b.HasKey("FollowedID", "FollowerID")
                        .HasName("pk_user_relationship");

                    b.HasIndex("FollowerID");

                    b.ToTable("user_relationships", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.Denunciations.Denunciation", b =>
                {
                    b.HasOne("FlashCards.Api.Core.Users.User", "Accuser")
                        .WithMany()
                        .HasForeignKey("AccuserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FlashCards.Api.Core.Users.User", "Suspect")
                        .WithMany()
                        .HasForeignKey("SuspectID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Accuser");

                    b.Navigation("Suspect");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Directories.UserDirectory", b =>
                {
                    b.HasOne("FlashCards.Api.Core.Directories.UserDirectory", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("UserDirectoryParentID");

                    b.HasOne("FlashCards.Api.Core.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardCollection", b =>
                {
                    b.HasOne("FlashCards.Api.Core.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlashCards.Api.Core.Directories.UserDirectory", "UserDirectory")
                        .WithMany("FlashCardCollections")
                        .HasForeignKey("UserDirectoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("UserDirectory");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardItem", b =>
                {
                    b.HasOne("FlashCards.Api.Core.FlashCards.FlashCardCollection", "Collection")
                        .WithMany("Cards")
                        .HasForeignKey("CollectionFlashCardCollectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardRating", b =>
                {
                    b.HasOne("FlashCards.Api.Core.FlashCards.FlashCardCollection", "Collection")
                        .WithMany("Ratings")
                        .HasForeignKey("CollectionFlashCardCollectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardTag", b =>
                {
                    b.HasOne("FlashCards.Api.Core.FlashCards.FlashCardCollection", "Collection")
                        .WithMany("Tags")
                        .HasForeignKey("CollectionFlashCardCollectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Notifications.Notification", b =>
                {
                    b.HasOne("FlashCards.Api.Core.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Users.User", b =>
                {
                    b.HasOne("FlashCards.Api.Core.Accounts.Account", "Account")
                        .WithOne()
                        .HasForeignKey("FlashCards.Api.Core.Users.User", "AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Users.UserRelationship", b =>
                {
                    b.HasOne("FlashCards.Api.Core.Users.User", "Followed")
                        .WithMany("Followers")
                        .HasForeignKey("FollowedID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FlashCards.Api.Core.Users.User", "Follower")
                        .WithMany("Following")
                        .HasForeignKey("FollowerID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Followed");

                    b.Navigation("Follower");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Directories.UserDirectory", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("FlashCardCollections");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardCollection", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("Ratings");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Users.User", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Following");
                });
#pragma warning restore 612, 618
        }
    }
}
