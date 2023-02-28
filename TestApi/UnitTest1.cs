using Microsoft.EntityFrameworkCore;
using WebApiFilm.Controllers;
using WebApiFilm.Models.EntityFramework;

namespace TestApi
{
    [TestClass]
    public class UnitTest1
    {
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

        [TestMethod]
        public void UtilisateurTest()
        {
            var builder = new DbContextOptionsBuilder<FilmRatingsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=databasefilms; uid=postgres; password=postgres;"); // Chaine de connexion à mettre dans les ( )
            FilmRatingsDBContext context = new FilmRatingsDBContext(builder.Options);
            Controller = new UtilisateursController(context);


        }

        [TestMethod]
        public void GetUtilisateurTest()
        {


        }
    }
}