using LearnGraph.Movies.Models;
using System;
using System.Collections.Concurrent;

namespace LearnGraph.Movies.Services
{
    public interface IMovieEventService
    {
        ConcurrentStack<MovieEvent> AllEvents { get; }
        void AddError(Exception ex);
        MovieEvent AddEvent(MovieEvent e);
        IObservable<MovieEvent> EventStream();

    }
}