using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiFilm.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    public partial class Utilisateur
    {

        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Key]
        [Column("utl_nom")]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        public string? Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        public string? Mobile { get; set; }

        [Column("utl_mail")]
        public string? Mail { get; set; }

        [Column("utl_pwd")]
        public string? Pwd { get; set; }

        [Column("utl_rue")]
        public string? Rue { get; set; }

        [Column("utl_cp", TypeName = "char(5)")]
        public string? CodePostal { get; set; }

        [Column("utl_ville")]
        public string? Ville { get; set; }

        [Column("utl_pays")]
        public string? Pays { get; set; }

        [Column("utl_latitude")]
        public float? Latitude { get; set; }

        [Column("utl_longitude")]
        public float? Longitude { get; set; }

        [Column("utl_datecreation")]
        [Required]
        [DefaultValue(typeof(DateTime), "")]
        public DateTime DateCreation { get; set; } = DateTime.Now;


        [InverseProperty("NotesUtilisateur")]
        public virtual ICollection<Notation> Notations { get;} = new List<Notation>();

       

    }
}
