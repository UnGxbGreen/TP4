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

        [Column("utl_nom")]
        public string? Nom { get; set; }

        [Column("utl_prenom")]
        public string? Prenom { get; set; }
        
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "…")]
        [Column("utl_mobile", TypeName = "char(10)")]

        public string? Mobile { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
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
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;


        [InverseProperty(nameof(Notation.UtilisateurNavigation))]
        public virtual ICollection<Notation> NotesUtilisateur { get;} = new List<Notation>();

       

    }
}
