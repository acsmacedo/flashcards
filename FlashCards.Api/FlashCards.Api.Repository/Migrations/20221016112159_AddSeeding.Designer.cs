﻿// <auto-generated />
using System;
using FlashCards.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221016112159_AddSeeding")]
    partial class AddSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Email = "anderson@flashcard.com.br",
                            Password = "23011993",
                            Status = 0
                        },
                        new
                        {
                            ID = -2,
                            Email = "maria@flashcard.com.br",
                            Password = "23011993",
                            Status = 0
                        },
                        new
                        {
                            ID = -3,
                            Email = "gustavo@flashcard.com.br",
                            Password = "23011993",
                            Status = 0
                        },
                        new
                        {
                            ID = -4,
                            Email = "paulo@flashcard.com.br",
                            Password = "23011993",
                            Status = 0
                        },
                        new
                        {
                            ID = -5,
                            Email = "ana@flashcard.com.br",
                            Password = "23011993",
                            Status = 0
                        },
                        new
                        {
                            ID = -6,
                            Email = "patricia@flashcard.com.br",
                            Password = "23011993",
                            Status = 0
                        },
                        new
                        {
                            ID = -7,
                            Email = "fernanda@flashcard.com.br",
                            Password = "23011993",
                            Status = 0
                        },
                        new
                        {
                            ID = -8,
                            Email = "otavio@flashcard.com.br",
                            Password = "23011993",
                            Status = 0
                        },
                        new
                        {
                            ID = -9,
                            Email = "bruno@flashcard.com.br",
                            Password = "23011993",
                            Status = 0
                        },
                        new
                        {
                            ID = -10,
                            Email = "teste@flashcard.com.br",
                            Password = "123456",
                            Status = 0
                        });
                });

            modelBuilder.Entity("FlashCards.Api.Core.Categories.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("image");

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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_directory_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

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

                    b.HasKey("ID")
                        .HasName("pk_user_directory_id");

                    b.HasIndex("UserDirectoryParentID");

                    b.HasIndex("UserID");

                    b.ToTable("user_directories", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardCollection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flash_card_collection_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.Property<int>("UserDirectoryID")
                        .HasColumnType("int")
                        .HasColumnName("user_directory_id");

                    b.HasKey("ID")
                        .HasName("pk_flash_card_collection_id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserDirectoryID");

                    b.ToTable("flash_card_collections", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardItem", b =>
                {
                    b.Property<int>("FlashCardItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flash_card_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlashCardItemID"), 1L, 1);

                    b.Property<int>("FlashCardCollectionID")
                        .HasColumnType("int")
                        .HasColumnName("flash_card_collection_id");

                    b.Property<string>("FrontDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("front_description");

                    b.Property<string>("VerseDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("verse_description");

                    b.HasKey("FlashCardItemID")
                        .HasName("pk_flash_card_id");

                    b.HasIndex("FlashCardCollectionID");

                    b.ToTable("flash_card_items", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardRating", b =>
                {
                    b.Property<int>("FlashCardRatingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flash_card_rating_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlashCardRatingID"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("comment");

                    b.Property<int>("FlashCardCollectionID")
                        .HasColumnType("int")
                        .HasColumnName("flash_card_collection_id");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("FlashCardRatingID")
                        .HasName("pk_flash_card_rating_id");

                    b.HasIndex("FlashCardCollectionID");

                    b.HasIndex("UserID");

                    b.ToTable("flash_card_ratings", (string)null);
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardTag", b =>
                {
                    b.Property<int>("FlashCardCollectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("flash_card_tag_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.HasKey("FlashCardCollectionID")
                        .HasName("pk_flash_card_tag_id");

                    b.ToTable("flash_card_tags", (string)null);
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

            modelBuilder.Entity("FlashCards.Api.Core.NotificationSettings.NotificationSetting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("notification_setting_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.HasKey("ID")
                        .HasName("pk_notification_setting_id");

                    b.ToTable("notification_settings", (string)null);

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                            Name = "Promoções e novidades"
                        },
                        new
                        {
                            ID = -2,
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                            Name = "Novo seguidor"
                        },
                        new
                        {
                            ID = -3,
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                            Name = "Atualizações de conteúdo"
                        },
                        new
                        {
                            ID = -4,
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                            Name = "Sugestões de conteúdo"
                        },
                        new
                        {
                            ID = -5,
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                            Name = "Avaliações e comentários"
                        });
                });

            modelBuilder.Entity("FlashCards.Api.Core.SubscriptionTypes.SubscriptionType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subscription_type_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("smallmoney")
                        .HasColumnName("price");

                    b.HasKey("ID")
                        .HasName("pk_subscription_type_id");

                    b.ToTable("subscription_types", (string)null);

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Name = "Plano Free"
                        },
                        new
                        {
                            ID = -2,
                            Name = "Plano Essencial",
                            Price = 9.99m
                        },
                        new
                        {
                            ID = -3,
                            Name = "Plano Premium",
                            Price = 29.99m
                        });
                });

            modelBuilder.Entity("FlashCards.Api.Core.SubscriptionTypes.SubscriptionTypeBenefit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subscription_type_benefit_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Benefit")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("benefit");

                    b.Property<int>("SubsriptionTypeID")
                        .HasColumnType("int")
                        .HasColumnName("subscription_type_id");

                    b.HasKey("ID")
                        .HasName("pk_subscription_type_benefit_id");

                    b.HasIndex("SubsriptionTypeID");

                    b.ToTable("subscription_type_benefits", (string)null);

                    b.HasData(
                        new
                        {
                            ID = -1,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -1
                        },
                        new
                        {
                            ID = -2,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -1
                        },
                        new
                        {
                            ID = -3,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -1
                        },
                        new
                        {
                            ID = -4,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -2
                        },
                        new
                        {
                            ID = -5,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -2
                        },
                        new
                        {
                            ID = -6,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -2
                        },
                        new
                        {
                            ID = -7,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -2
                        },
                        new
                        {
                            ID = -8,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -3
                        },
                        new
                        {
                            ID = -9,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -3
                        },
                        new
                        {
                            ID = -10,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -3
                        },
                        new
                        {
                            ID = -11,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -3
                        },
                        new
                        {
                            ID = -12,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -3
                        },
                        new
                        {
                            ID = -13,
                            Benefit = "Lorem ipsum is simply dummy",
                            SubsriptionTypeID = -3
                        });
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

                    b.Property<string>("Photo")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("photo");

                    b.Property<int?>("SubscriptionTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasName("pk_user_id");

                    b.HasIndex("AccountID")
                        .IsUnique();

                    b.HasIndex("SubscriptionTypeID");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            ID = -1,
                            AccountID = -1,
                            Name = "Anderson Macedo"
                        },
                        new
                        {
                            ID = -2,
                            AccountID = -2,
                            Name = "Maria Souza"
                        },
                        new
                        {
                            ID = -3,
                            AccountID = -3,
                            Name = "Gustavo Oliveira"
                        },
                        new
                        {
                            ID = -4,
                            AccountID = -4,
                            Name = "Paulo Pereira"
                        },
                        new
                        {
                            ID = -5,
                            AccountID = -5,
                            Name = "Ana Ferreira"
                        },
                        new
                        {
                            ID = -6,
                            AccountID = -6,
                            Name = "Patrícia Castro"
                        },
                        new
                        {
                            ID = -7,
                            AccountID = -7,
                            Name = "Fernanda Albuquerque"
                        },
                        new
                        {
                            ID = -8,
                            AccountID = -8,
                            Name = "Otávio Santos"
                        },
                        new
                        {
                            ID = -9,
                            AccountID = -9,
                            Name = "Bruno Gomes"
                        },
                        new
                        {
                            ID = -10,
                            AccountID = -10,
                            Name = "Usuário Teste"
                        });
                });

            modelBuilder.Entity("FlashCards.Api.Core.Users.UserNotificationSetting", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("NotificationSettingID")
                        .HasColumnType("int")
                        .HasColumnName("notification_setting_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("UserID", "NotificationSettingID")
                        .HasName("pk_user_notification_setting_id");

                    b.HasIndex("NotificationSettingID");

                    b.ToTable("user_notification_settings", (string)null);
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
                        .WithMany("Directories")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardCollection", b =>
                {
                    b.HasOne("FlashCards.Api.Core.Categories.Category", "Category")
                        .WithMany("FlashCardCollections")
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
                        .HasForeignKey("FlashCardCollectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardRating", b =>
                {
                    b.HasOne("FlashCards.Api.Core.FlashCards.FlashCardCollection", "Collection")
                        .WithMany("Ratings")
                        .HasForeignKey("FlashCardCollectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlashCards.Api.Core.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlashCards.Api.Core.FlashCards.FlashCardTag", b =>
                {
                    b.HasOne("FlashCards.Api.Core.FlashCards.FlashCardCollection", "Collection")
                        .WithMany("Tags")
                        .HasForeignKey("FlashCardCollectionID")
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

            modelBuilder.Entity("FlashCards.Api.Core.SubscriptionTypes.SubscriptionTypeBenefit", b =>
                {
                    b.HasOne("FlashCards.Api.Core.SubscriptionTypes.SubscriptionType", "SubsriptionType")
                        .WithMany("Benefits")
                        .HasForeignKey("SubsriptionTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubsriptionType");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Users.User", b =>
                {
                    b.HasOne("FlashCards.Api.Core.Accounts.Account", "Account")
                        .WithOne()
                        .HasForeignKey("FlashCards.Api.Core.Users.User", "AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlashCards.Api.Core.SubscriptionTypes.SubscriptionType", "SubscriptionType")
                        .WithMany("Users")
                        .HasForeignKey("SubscriptionTypeID");

                    b.Navigation("Account");

                    b.Navigation("SubscriptionType");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Users.UserNotificationSetting", b =>
                {
                    b.HasOne("FlashCards.Api.Core.NotificationSettings.NotificationSetting", "NotificationSetting")
                        .WithMany()
                        .HasForeignKey("NotificationSettingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlashCards.Api.Core.Users.User", "User")
                        .WithMany("NotiicationSettings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotificationSetting");

                    b.Navigation("User");
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

            modelBuilder.Entity("FlashCards.Api.Core.Categories.Category", b =>
                {
                    b.Navigation("FlashCardCollections");
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

            modelBuilder.Entity("FlashCards.Api.Core.SubscriptionTypes.SubscriptionType", b =>
                {
                    b.Navigation("Benefits");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FlashCards.Api.Core.Users.User", b =>
                {
                    b.Navigation("Directories");

                    b.Navigation("Followers");

                    b.Navigation("Following");

                    b.Navigation("NotiicationSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
