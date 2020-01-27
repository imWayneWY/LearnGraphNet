using GraphQL.Types;
using LearnGraph.Movies.Models;

namespace LearnGraph.Movies.Schema
{
    public class MovieRatingEnum: EnumerationGraphType<MovieRating>
    {
        public MovieRatingEnum()
        {
            Name = "MovieRatings";
            Description = "";

            AddValue(MovieRating.Unrated.ToString(), MovieRating.Unrated.ToString(), MovieRating.Unrated);
            AddValue(MovieRating.PG13.ToString(), MovieRating.PG13.ToString(), MovieRating.PG13);
            AddValue(MovieRating.G.ToString(), MovieRating.G.ToString(), MovieRating.G);
            AddValue(MovieRating.PG.ToString(), MovieRating.PG.ToString(), MovieRating.PG);
            AddValue(MovieRating.R.ToString(), MovieRating.R.ToString(), MovieRating.R);
            AddValue(MovieRating.NC17.ToString(), MovieRating.NC17.ToString(), MovieRating.NC17);
        }
    }
}