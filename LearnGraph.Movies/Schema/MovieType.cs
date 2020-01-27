using System.Net.Mime;
using GraphQL.Types;
using LearnGraph.Movies.Models;
using LearnGraph.Movies.Services;

namespace LearnGraph.Movies.Schema
{
    public class MovieType: ObjectGraphType<Movie>
    {
        public MovieType(IActorService actorService)
        {
            Name = "Movie";
            Description = "";

            Field(x => x.Id);
            Field(x => x.Company);
            Field(x => x.Name);
            Field(x => x.ReleaseDate);
            Field(x => x.ActorId);

            Field<ActorType>("Actor", resolve: context => actorService.GetByIdAsync(context.Source.ActorId));
            Field<MovieRatingEnum>("MovieRatings", resolve: context => context.Source.MovieRating);
            Field<StringGraphType>("CustomString", resolve: context => "I love GraphQL");
        }
    }
}
