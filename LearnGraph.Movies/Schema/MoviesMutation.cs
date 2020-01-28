using GraphQL.Types;
using LearnGraph.Movies.Services;
using LearnGraph.Movies.Models;
using System.Linq;

namespace LearnGraph.Movies.Schema
{
    public class MoviesMutation: ObjectGraphType
    {
        public MoviesMutation(IMovieServices movieService)
        {
            Name = "Mutation";

            FieldAsync<MovieType>("createMovie",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<MovieInputType>> { Name = "movie" }),
            resolve: async context => 
            {
                var movieInput = context.GetArgument<MovieInput>("movie");

                var movies = await movieService.GetAsync();
                var maxId = movies.Select(x => x.Id).Max();

                var movie = new Movie
                {
                    Id = ++maxId,
                    Name = movieInput.Name,
                    Company = movieInput.Company,
                    ActorId = movieInput.ActorId,
                    MovieRating = movieInput.MovieRating,
                    ReleaseDate = movieInput.ReleaseDate
                };

                var result = await movieService.CreateAsync(movie);
                return result;
            });
        }
    }
}