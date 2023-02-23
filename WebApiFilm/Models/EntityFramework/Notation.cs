using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiFilm.Models.EntityFramework
{
    [Table("t_j_notation_not")]
    public partial class Notation
    {

        [Key,ForeignKey("fk_not_utl")]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Key, ForeignKey("fk_not_flm")]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Column("not_note")]
        [Required]
        [Range(0, 5, ErrorMessage = "La note doit être comprise entre 0 et 5")]
        public int Note { get; set; }

        
        [InverseProperty("UtilisateurNotant")]
        public virtual Utilisateur UtilisateurNavisation { get; set; } = null!;

        
        [InverseProperty("FilmNote")]
        public virtual Film FilmNavigation { get; set; } = null!;


       


    }
}
