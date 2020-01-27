using GraphQL.Types;
using LearnGraph.Movies.Services;

namespace LearnGraph.Movies.Schema
{
    public class MoviesQuery: ObjectGraphType
    {
        public MoviesQuery(IMovieServices movieService)
        {
            Name = "Query";
            Field<ListGraphType<MovieType>>("Movies", resolve: context => movieService.GetAsync());
        }
    }
}