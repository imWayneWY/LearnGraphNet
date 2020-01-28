using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearnGraph.Movies.Models;
using System.Linq;

namespace LearnGraph.Movies.Services
{
    public class MovieServices: IMovieServices    
    {
        private readonly IList<Movie> _movies;
        public MovieServices()
        {
            #region Movies
            _movies = new List<Movie>
            {
                new Movie{
                    Id = 1,
                    Name = "Forrest Gump",
                    ActorId = 1,
                    Company = "Paramount Pictures",
                    MovieRating = MovieRating.PG13,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
                new Movie{
                    Id = 2,
                    Name = "Se7en",
                    ActorId = 2,
                    Company = "New Line Cinema",
                    MovieRating = MovieRating.R,
                    ReleaseDate = new DateTime(1995, 9, 22)
                },
                new Movie{
                    Id = 3,
                    Name = "Top Gun",
                    ActorId = 3,
                    Company = "Paramount Pictures",
                    MovieRating = MovieRating.PG,
                    ReleaseDate = new DateTime(1986, 7, 6)
                },
                new Movie{
                    Id = 4,
                    Name = "Movie4",
                    ActorId = 4,
                    Company = "Paramount Pictures",
                    MovieRating = MovieRating.PG13,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
                new Movie{
                    Id = 5,
                    Name = "Movie5",
                    ActorId = 5,
                    Company = "Paramount Pictures",
                    MovieRating = MovieRating.PG13,
                    ReleaseDate = new DateTime(1994, 7, 6)
                },
            };
            #endregion
        }
        public Task<Movie> GetByIdAsync(int id)
        {
            var movie = _movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                throw new ArgumentException(String.Format("Movie ID {0} is not correct", id));
            }
            return Task.FromResult(movie);
        }

        public Task<IEnumerable<Movie>> GetAsync()
        {
            return Task.FromResult(_movies.AsEnumerable());
        }

        public Task<Movie> CreateAsync(Movie movie)
        {
            _movies.Add(movie);
            return Task.FromResult(movie);
        }
    }
}