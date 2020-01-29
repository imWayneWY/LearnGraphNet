using GraphQL;

namespace LearnGraph.Movies.Schema
{
    public class MoviesSchema: GraphQL.Types.Schema
    {
        public MoviesSchema(
            IDependencyResolver dependencyResolver,
            MoviesQuery moviesQuery,
            MoviesMutation moviesMutation,
            MoviesScription moviesScription
        )
        {
            DependencyResolver = dependencyResolver;
            Query = moviesQuery;
            Mutation = moviesMutation;
            Subscription = moviesScription;
        }
    }
}