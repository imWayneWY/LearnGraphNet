using GraphQL;

namespace LearnGraph.Movies.Schema
{
    public class MoviesSchema: GraphQL.Types.Schema
    {
        public MoviesSchema(
            IDependencyResolver dependencyResolver,
            MoviesQuery moviesQuery
        )
        {
            DependencyResolver = dependencyResolver;
            Query = moviesQuery;
        }
    }
}