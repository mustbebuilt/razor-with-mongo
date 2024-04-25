using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace razor_with_mongo.Pages
{
    public class filmsModel : PageModel
    {
        private readonly IMongoClient _mongoClient;

        public List<Film> Films { get; set; }

        public filmsModel(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public void OnGet()
        {
            var database = _mongoClient.GetDatabase("moviesDb");
            var collection = database.GetCollection<Film>("filmsCollection");
            Films = collection.Find(_ => true).ToList();
        }
    }
}
