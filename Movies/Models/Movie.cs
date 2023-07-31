using System.ComponentModel.DataAnnotations;
using Movies.Validators;

namespace Movies.Models
{
    [EightiesMovieRatings]
    public class Movie
    {
        private static int nextID = 0;
        public int? Id { get; set; }

        [Required(ErrorMessage = "I didn't know someone could be so unbelievably fucking stupid, but then i met you and i've lost hope for humanity."), MaxLength(40)]
        public string Title { get; set; }
        [Required, Range(1888, 2023)]
        public int? Year { get; set; }
        [Required, Range(1, 5)]
        public float? Rating { get; set; }
        public DateTime? ReleaseDate { get; set;}
        public string? Image { get; set; }
        public string? Genre { get; set; }
        public string? UserID { get; set; }

        public Movie()
        {

        }

        public Movie (string title, int year, float rating)
        {
            Title = title;
            Year = year;
            Rating = rating;
        }

        public Movie(int? id, string title, int? year, float? rating, DateTime? releaseDate, string image, string genre)
        {
            Id = id;
            Title = title;
            Year = year;
            Rating = rating;
            ReleaseDate = releaseDate;
            Image = image;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} - {Year} - {Rating} stars";
        }
    }
}
