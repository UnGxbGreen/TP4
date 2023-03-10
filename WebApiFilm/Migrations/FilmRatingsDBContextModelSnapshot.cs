// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApiFilm.Models.EntityFramework;

#nullable disable

namespace WebApiFilm.Migrations
{
    [DbContext(typeof(FilmRatingsDBContext))]
    partial class FilmRatingsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApiFilm.Models.EntityFramework.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("flm_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FilmId"));

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("flm_datesortie");

                    b.Property<decimal>("Duree")
                        .HasColumnType("numeric")
                        .HasColumnName("flm_duree");

                    b.Property<string>("Genre")
                        .HasColumnType("text")
                        .HasColumnName("flm_genre");

                    b.Property<string>("Resume")
                        .HasColumnType("text")
                        .HasColumnName("flm_resume");

                    b.Property<string>("Titre")
                        .HasColumnType("text")
                        .HasColumnName("flm_titre");

                    b.HasKey("FilmId");

                    b.ToTable("t_e_film_flm");
                });

            modelBuilder.Entity("WebApiFilm.Models.EntityFramework.Notation", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    b.Property<int>("FilmId")
                        .HasColumnType("integer")
                        .HasColumnName("flm_id");

                    b.Property<int>("Note")
                        .HasColumnType("integer")
                        .HasColumnName("not_note");

                    b.HasKey("UtilisateurId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("t_j_notation_not");

                    b.HasCheckConstraint("ck_not_note", "not_note between 0 and 5");
                });

            modelBuilder.Entity("WebApiFilm.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Property<int>("UtilisateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("utl_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UtilisateurId"));

                    b.Property<string>("CodePostal")
                        .HasColumnType("char(5)")
                        .HasColumnName("utl_cp");

                    b.Property<DateTime>("DateCreation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("utl_datecreation")
                        .HasDefaultValueSql("now()");

                    b.Property<float?>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_latitude");

                    b.Property<float?>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("utl_longitude");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("utl_mail");

                    b.Property<string>("Mobile")
                        .HasColumnType("char(10)")
                        .HasColumnName("utl_mobile");

                    b.Property<string>("Nom")
                        .HasColumnType("text")
                        .HasColumnName("utl_nom");

                    b.Property<string>("Pays")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("France")
                        .HasColumnName("utl_pays");

                    b.Property<string>("Prenom")
                        .HasColumnType("text")
                        .HasColumnName("utl_prenom");

                    b.Property<string>("Pwd")
                        .HasColumnType("text")
                        .HasColumnName("utl_pwd");

                    b.Property<string>("Rue")
                        .HasColumnType("text")
                        .HasColumnName("utl_rue");

                    b.Property<string>("Ville")
                        .HasColumnType("text")
                        .HasColumnName("utl_ville");

                    b.HasKey("UtilisateurId");

                    b.HasIndex("Mail")
                        .IsUnique()
                        .HasDatabaseName("uq_utl_mail");

                    b.ToTable("t_e_utilisateur_utl");
                });

            modelBuilder.Entity("WebApiFilm.Models.EntityFramework.Notation", b =>
                {
                    b.HasOne("WebApiFilm.Models.EntityFramework.Film", "FilmNavigation")
                        .WithMany("Notations")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiFilm.Models.EntityFramework.Utilisateur", "UtilisateurNavigation")
                        .WithMany("NotesUtilisateur")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmNavigation");

                    b.Navigation("UtilisateurNavigation");
                });

            modelBuilder.Entity("WebApiFilm.Models.EntityFramework.Film", b =>
                {
                    b.Navigation("Notations");
                });

            modelBuilder.Entity("WebApiFilm.Models.EntityFramework.Utilisateur", b =>
                {
                    b.Navigation("NotesUtilisateur");
                });
#pragma warning restore 612, 618
        }
    }
}
