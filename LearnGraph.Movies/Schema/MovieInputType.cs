using GraphQL.Types;
using LearnGraph.Movies.Models;

namespace LearnGraph.Movies.Schema
{
    public class MovieInputType: InputObjectGraphType<MovieInput>
    {
        public MovieInputType()
        {
            Name = "MovieInput";

            Field(x => x.Name);
            Field(x => x.ReleaseDate);
            Field(x => x.Company);
            Field(x => x.ActorId);
            Field(x => x.MovieRating, type: typeof(MovieRatingEnum));
            
        }
    }
}