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

        [TestMethod]
        public void GetUtilisateurByIdTest()
        {
            //Datas
            var filmFromDatabase = Context.Utilisateurs.Where(x => x.UtilisateurId == 1).FirstOrDefault();
            var filmFromAPi = Controller.GetUtilisateurById(1).Result;

            //Assert
            Assert.AreEqual(filmFromAPi.Value, filmFromDatabase, "Données pas identique");

        }

        [TestMethod]
        public void GetUtilisateurByIdTest_Failed()
        {
            //Datas
            var filmFromDatabase = Context.Utilisateurs.Where(x => x.UtilisateurId == 1).FirstOrDefault();
            var filmFromAPi = Controller.GetUtilisateurById(10).Result;

            //Assert
            Assert.AreEqual(filmFromAPi.Value, filmFromDatabase, "Données pas identique");

        }

        [TestMethod]
        public void GetUtilisateurByEmailTest()
        {
            //Datas
            var filmFromDatabase = Context.Utilisateurs.Where(x => x.Mail == "gdominguez0@washingtonpost.com").FirstOrDefault();
            var filmFromAPi = Controller.GetUtilisateurByMail("gdominguez0@washingtonpost.com").Result;

            //Assert
            Assert.AreEqual(filmFromAPi.Value, filmFromDatabase, "Données pas identique");

        }

        [TestMethod]
        public void GetUtilisateurByEmailTest_Failed()
        {
            //Datas
            var filmFromDatabase = Context.Utilisateurs.Where(x => x.Mail == "gdominguez0@washingtonpost.com").FirstOrDefault();
            var filmFromAPi = Controller.GetUtilisateurByMail("gdominguez0@washingtonpost1.com").Result;

            //Assert
            Assert.AreEqual(filmFromAPi.Value, filmFromDatabase, "Données pas identique");

        }

        [TestMethod]
        public void Postutilisateur_ModelValidated_CreationOK()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou un timestamp
            // 2. On supprime le user après l'avoir créé. Dans ce cas, nous avons besoin d'appeler la méthode DELETE de l’API ou remove du DbSet.
            Utilisateur userAtester = new Utilisateur()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                Mobile = "0606070809",
                Mail = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var result = controller.PostUtilisateur(userAtester).Result; // .Result pour appeler la méthode async de manière synchrone, afin d'attendre l’ajout
            // Assert
            Utilisateur? userRecupere = Context.Utilisateurs.Where(u => u.Mail.ToUpper() == userAtester.Mail.ToUpper()).FirstOrDefault(); // On récupère l'utilisateur créé directement dans la BD grace à son mail unique
            // On ne connait pas l'ID de l’utilisateur envoyé car numéro automatique.
            // Du coup, on récupère l'ID de celui récupéré et on compare ensuite les 2 users
            userAtester.UtilisateurId = userRecupere.UtilisateurId;
            Assert.AreEqual(userRecupere, userAtester, "Utilisateurs pas identiques");
        }


    }
}