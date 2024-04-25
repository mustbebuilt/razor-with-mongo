using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace razor_with_mongo.Pages
{
    public class FilmsApiModel : PageModel
    {
        private readonly IMongoClient _mongoClient;

        public FilmsApiModel(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public IActionResult OnGet()
        {
            var database = _mongoClient.GetDatabase("moviesDb");
            var collection = database.GetCollection<Film>("filmsCollection");

            var films = collection.Find(_ => true).ToList();

            return new JsonResult(films);
        }
    }
}
