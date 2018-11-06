﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizMaster.API.Data;

namespace QuizMaster.API.Data.Migrations
{
    [DbContext(typeof(QuizContext))]
    [Migration("20181030203241_initial_migration")]
    partial class initial_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("QuizMaster.Shared.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCorrect");

                    b.Property<int?>("QuestionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentQuestion");

                    b.Property<int>("CurrentRound");

                    b.Property<int?>("QuizId");

                    b.Property<int?>("QuizMasterId");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("QuizMasterId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerMustContain");

                    b.Property<bool>("IsMultipleChoice");

                    b.Property<int?>("RoundId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Password");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Quizes");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("QuizId");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GameId");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.Answer", b =>
                {
                    b.HasOne("QuizMaster.Shared.Models.Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.Game", b =>
                {
                    b.HasOne("QuizMaster.Shared.Models.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId");

                    b.HasOne("QuizMaster.Shared.Models.User", "QuizMaster")
                        .WithMany()
                        .HasForeignKey("QuizMasterId");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.Question", b =>
                {
                    b.HasOne("QuizMaster.Shared.Models.Round")
                        .WithMany("Questions")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.Round", b =>
                {
                    b.HasOne("QuizMaster.Shared.Models.Quiz")
                        .WithMany("Rounds")
                        .HasForeignKey("QuizId");
                });

            modelBuilder.Entity("QuizMaster.Shared.Models.User", b =>
                {
                    b.HasOne("QuizMaster.Shared.Models.Game")
                        .WithMany("Participants")
                        .HasForeignKey("GameId");
                });
#pragma warning restore 612, 618
        }
    }
}
