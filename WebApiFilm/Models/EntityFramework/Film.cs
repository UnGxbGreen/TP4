using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiFilm.Models.EntityFramework
{
    [Table("t_e_film_flm")]
    public partial class Film
    {

        [Key]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Column("flm_titre")]
        public string? Titre { get; set; }

        [Column("flm_resume")]
        public string? Resume { get; set; }

        [Column("flm_datesortie")]
        public DateTime DateSortie { get; set; }

        [Column("flm_duree")]
        public decimal Duree { get; set; }

        [Column("flm_genre")]
        public string? Genre { get; set; }


        [InverseProperty("NotesFilm")]
        public virtual ICollection<Notation> Notations { get;} = new List<Notation>();

       
    }
}
