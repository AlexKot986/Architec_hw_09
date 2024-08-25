﻿// <auto-generated />
using CloudOrderApi.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CloudOrderApi.Migrations
{
    [DbContext(typeof(CloudDBContext))]
    partial class CloudDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CloudOrderApi.Contexts.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("character varying(26)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("character varying(26)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("client_pkey");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("CloudOrderApi.Contexts.Models.Cloud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<int>("CoresNumber")
                        .HasColumnType("integer")
                        .HasColumnName("cores_number");

                    b.Property<int>("HddVolume")
                        .HasColumnType("integer")
                        .HasColumnName("hdd_volume");

                    b.Property<int>("OSId")
                        .HasColumnType("integer")
                        .HasColumnName("os");

                    b.Property<int>("OrederId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<int>("RamVolume")
                        .HasColumnType("integer")
                        .HasColumnName("ram_volume");

                    b.HasKey("Id")
                        .HasName("cloud_pkey");

                    b.HasIndex("OSId");

                    b.HasIndex("OrederId")
                        .IsUnique();

                    b.ToTable("clouds", (string)null);
                });

            modelBuilder.Entity("CloudOrderApi.Contexts.Models.OS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(26)
                        .HasColumnType("character varying(26)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("os_pkey");

                    b.ToTable("os", (string)null);
                });

            modelBuilder.Entity("CloudOrderApi.Contexts.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer")
                        .HasColumnName("client_id");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean")
                        .HasColumnName("is_paid");

                    b.HasKey("Id")
                        .HasName("orser_pkey");

                    b.HasIndex("ClientId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("CloudOrderApi.Contexts.Models.Cloud", b =>
                {
                    b.HasOne("CloudOrderApi.Contexts.Models.OS", "OS")
                        .WithMany("Clouds")
                        .HasForeignKey("OSId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloudOrderApi.Contexts.Models.Order", "Order")
                        .WithOne("Cloud")
                        .HasForeignKey("CloudOrderApi.Contexts.Models.Cloud", "OrederId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OS");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("CloudOrderApi.Contexts.Models.Order", b =>
                {
                    b.HasOne("CloudOrderApi.Contexts.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CloudOrderApi.Contexts.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CloudOrderApi.Contexts.Models.OS", b =>
                {
                    b.Navigation("Clouds");
                });

            modelBuilder.Entity("CloudOrderApi.Contexts.Models.Order", b =>
                {
                    b.Navigation("Cloud")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
