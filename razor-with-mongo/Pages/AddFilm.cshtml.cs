using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using MongoDB.Driver;

namespace razor_with_mongo.Pages
{
    public class AddFilmModel : PageModel
    {
        private readonly IMongoClient _mongoClient;

        public AddFilmModel(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        [BindProperty]
        public Film NewFilm { get; set; }

        public IActionResult OnPost()
        {

            // Ensure new document gets its own Id
            NewFilm.Id = ObjectId.GenerateNewId().ToString();

            // fails to valid when no id sent
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var database = _mongoClient.GetDatabase("moviesDb");
            var collection = database.GetCollection<Film>("filmsCollection");



            // Convert ReleaseDate to UTC
            NewFilm.ReleaseDate = NewFilm.ReleaseDate.ToUniversalTime();

            collection.InsertOne(NewFilm);

            return RedirectToPage("/Index");
        }
    }
}
