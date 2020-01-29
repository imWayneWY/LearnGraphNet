using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using GraphQL.Subscription;
using LearnGraph.Movies.Services;
using GraphQL.Resolvers;
using LearnGraph.Movies.Models;
using System.Reactive.Linq;

namespace LearnGraph.Movies.Schema
{
    public class MoviesScription: ObjectGraphType
    {
        private readonly IMovieEventService _movieEventService;
        public MoviesScription(IMovieEventService movieEventService)
        {
            _movieEventService = movieEventService;
            Name = "Subscription";
            AddField(new EventStreamFieldType{
                Name = "movieEvent",
                Arguments = new QueryArguments(new QueryArgument<ListGraphType<MovieRatingEnum>>
                {
                    Name = "movieRatings"
                }),
                Type = typeof(MovieEventType),
                Resolver = new FuncFieldResolver<MovieEvent>(ResolveEvent),
                Subscriber = new EventStreamResolver<MovieEvent>(Subscribe)
            });
        }

        private IObservable<MovieEvent> Subscribe(ResolveEventStreamContext context)
        {
            var ratingList = context.GetArgument<IList<MovieRating>>("movieRating", new List<MovieRating>());
            if(ratingList.Any())
            {
                MovieRating ratings = 0;
                foreach ( var rating in ratingList)
                {
                    ratings = rating | rating;
                }
                return _movieEventService.EventStream().Where(e => (e.MovieRating & ratings) == e.MovieRating);
            }
            else
            {
                return _movieEventService.EventStream();
            }
        }
        private MovieEvent ResolveEvent(ResolveFieldContext context)
        {
            var movieEvent = context.Source as MovieEvent;
            return movieEvent;
        }
    }
}