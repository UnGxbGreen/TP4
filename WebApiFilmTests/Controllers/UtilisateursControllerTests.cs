using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiFilm.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiFilm.Models.EntityFramework;

namespace WebApiFilm.Controllers.Tests
{
    [TestClass()]
    public class UtilisateursControllerTests
    {
        private FilmRatingsDBContext _context;
        private UtilisateursController controller;

        public UtilisateursController Controller
        {
            get
            {
                return controller;
            }

            set
            {
                controller = value;
            }
        }

        public FilmRatingsDBContext Context
        {
            get
            {
                return _context;
            }

            set
            {
                _context = value;
            }
        }


        public UtilisateursControllerTests()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=databasefilms; uid=postgres; password=postgres;"); // Chaine de connexion à mettre dans les ( )
            Context = new FilmRatingsDBContext(builder.Options);
            Controller = new UtilisateursController(Context);


        }

        [TestMethod]
        public void GetUtilisateurTest()
        {
            //Datas
            var filmFromDatabase = Context.Utilisateurs.ToList();
            var filmFromAPi = Controller.GetUtilisateurs().Result;

            //Assert
            CollectionAssert.AreEqual(filmFromAPi.Value.ToList(), filmFromDatabase, "Données pas identique");

        }


    }
}