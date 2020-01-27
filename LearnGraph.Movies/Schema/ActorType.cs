using GraphQL.Types;
using LearnGraph.Movies.Models;

namespace LearnGraph.Movies.Schema
{
    public class ActorType: ObjectGraphType<Actor>
    {
        public ActorType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}