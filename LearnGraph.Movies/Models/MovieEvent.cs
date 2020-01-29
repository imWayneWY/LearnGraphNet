using System;

namespace LearnGraph.Movies.Models
{
    public class MovieEvent
    {
        public MovieEvent()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public int MovieId { get; set; }
        public string Name { get; set;}
        public DateTime TimeStamp { get; set; }
        public MovieRating MovieRating { get; set; }
    }
}