using Atelier1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Atelier1.Controllers
{
    public class MovieController : Controller
    {

        public IActionResult Index()
        {
            Movie movie = new Movie() {  Name =  "movie 1"  };
            List<Movie> movies = new List<Movie>() {new Movie{Name= "WISH", Id = 2}   ,new Movie{Name= "Critics Consensus",  Id = 3},  };

            return View(movies);
        }

        // ceci est un autre exemple de routage des attribut  (question 3) 
        [Route("/Home/{id}")] 
        public IActionResult Edit(int id)
        {
            return Content("Test Id" + id);
        }

        public IActionResult ByRelease(int month , int year)
        {
            return Content(" this movie was created in  "+ month + " / " + year );
        }

        public ActionResult MovieDetails(int Id)
        { 
             List<MovieViewModel> details = new List<MovieViewModel>(3)
        {
            new MovieViewModel{ Movie =  new Movie{Name="WISH", Id =  2} ,
                                Customers = new List<Customer>(4){
                                    new Customer { Id = 1 , Name = "ali "},
                                    new Customer { Id = 3 , Name = "sadek "},
                                    new Customer { Id = 5 , Name = "ela "},
                                    new Customer { Id = 5 , Name = "ela "},
                                 },
                                },
            new MovieViewModel { Movie =  new Movie{Name="Critics Consensus", Id = 3 },
                                 Customers = new List<Customer>(4){
                                     new Customer { Id = 2 , Name = "ahmed "},
                                     new Customer { Id = 4 , Name = "mohamed "},
                                     new Customer { Id = 6 , Name = "ferdaws "},
                                 },
                                },


        };

            
            foreach (var d in details)
            {
                if (d.Movie.Id == Id)
                {
                    var viewModel = new MovieViewModel { Movie = d.Movie, Customers = d.Customers };
                    return View(viewModel);

                }
            }
            return Content("wrong movie ID"); 
        }


    }
}
