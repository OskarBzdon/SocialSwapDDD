﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialSwap.Infrastructure.DataSources;

#nullable disable

namespace SocialSwap.Api.Migrations
{
    [DbContext(typeof(SocialSwapContext))]
    [Migration("20220612163335_TitleItemAdeed")]
    partial class TitleItemAdeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConversationUser", b =>
                {
                    b.Property<int>("ConversationsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("ConversationsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ConversationUser");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ConversationAggregate.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ConversationAggregate.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("ConversationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReadDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ConversationId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ItemAggregate.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.OpinionAggregate.Opinion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOpinionPositive")
                        .HasColumnType("bit");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TargetItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TargetItemId");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ReportAggregate.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AssignedModeratorId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedModeratorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ItemId");

                    b.ToTable("Reports");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Report");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.TransactionAggregate.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompleteReportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompleteReportId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.UserAggregate.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.UserAggregate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ItemAggregate.DisplayedItem", b =>
                {
                    b.HasBaseType("SocialSwap.Domain.AggregatesModel.ItemAggregate.Item");

                    b.Property<DateTime>("DisplayDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("DisplayedItem");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ItemAggregate.SwapItem", b =>
                {
                    b.HasBaseType("SocialSwap.Domain.AggregatesModel.ItemAggregate.Item");

                    b.Property<DateTime>("SwapDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("SwapItem");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ReportAggregate.CompleteReport", b =>
                {
                    b.HasBaseType("SocialSwap.Domain.AggregatesModel.ReportAggregate.Report");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsReportAccepted")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("CompleteReport");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.UserAggregate.Client", b =>
                {
                    b.HasBaseType("SocialSwap.Domain.AggregatesModel.UserAggregate.User");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("Reputation")
                        .HasColumnType("int");

                    b.HasIndex("AddressId");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.UserAggregate.Moderator", b =>
                {
                    b.HasBaseType("SocialSwap.Domain.AggregatesModel.UserAggregate.User");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Moderator");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.UserAggregate.Administrator", b =>
                {
                    b.HasBaseType("SocialSwap.Domain.AggregatesModel.UserAggregate.Moderator");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("ConversationUser", b =>
                {
                    b.HasOne("SocialSwap.Domain.AggregatesModel.ConversationAggregate.Conversation", null)
                        .WithMany()
                        .HasForeignKey("ConversationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialSwap.Domain.AggregatesModel.UserAggregate.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ConversationAggregate.Message", b =>
                {
                    b.HasOne("SocialSwap.Domain.AggregatesModel.UserAggregate.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialSwap.Domain.AggregatesModel.ConversationAggregate.Conversation", "Conversation")
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Conversation");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ItemAggregate.Item", b =>
                {
                    b.HasOne("SocialSwap.Domain.AggregatesModel.UserAggregate.Client", "Owner")
                        .WithMany("Items")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.OpinionAggregate.Opinion", b =>
                {
                    b.HasOne("SocialSwap.Domain.AggregatesModel.UserAggregate.Client", "Author")
                        .WithMany("WrotedOpinions")
                        .HasForeignKey("AuthorId")
                        .IsRequired();

                    b.HasOne("SocialSwap.Domain.AggregatesModel.UserAggregate.Client", "Subject")
                        .WithMany("Opinions")
                        .HasForeignKey("SubjectId")
                        .IsRequired();

                    b.HasOne("SocialSwap.Domain.AggregatesModel.ItemAggregate.Item", "TargetItem")
                        .WithMany("Opinions")
                        .HasForeignKey("TargetItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Subject");

                    b.Navigation("TargetItem");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ReportAggregate.Report", b =>
                {
                    b.HasOne("SocialSwap.Domain.AggregatesModel.UserAggregate.Moderator", "AssignedModerator")
                        .WithMany("Reports")
                        .HasForeignKey("AssignedModeratorId")
                        .IsRequired();

                    b.HasOne("SocialSwap.Domain.AggregatesModel.UserAggregate.Client", "Author")
                        .WithMany("WrotedReports")
                        .HasForeignKey("AuthorId")
                        .IsRequired();

                    b.HasOne("SocialSwap.Domain.AggregatesModel.ItemAggregate.Item", null)
                        .WithMany("Reports")
                        .HasForeignKey("ItemId");

                    b.Navigation("AssignedModerator");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.TransactionAggregate.Transaction", b =>
                {
                    b.HasOne("SocialSwap.Domain.AggregatesModel.ReportAggregate.CompleteReport", null)
                        .WithMany("Transactions")
                        .HasForeignKey("CompleteReportId");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.UserAggregate.Client", b =>
                {
                    b.HasOne("SocialSwap.Domain.AggregatesModel.UserAggregate.Address", "Address")
                        .WithMany("Residents")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ConversationAggregate.Conversation", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ItemAggregate.Item", b =>
                {
                    b.Navigation("Opinions");

                    b.Navigation("Reports");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.UserAggregate.Address", b =>
                {
                    b.Navigation("Residents");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.ReportAggregate.CompleteReport", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.UserAggregate.Client", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Opinions");

                    b.Navigation("WrotedOpinions");

                    b.Navigation("WrotedReports");
                });

            modelBuilder.Entity("SocialSwap.Domain.AggregatesModel.UserAggregate.Moderator", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
