using System;
using System.Collections.Concurrent;
using LearnGraph.Movies.Models;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace LearnGraph.Movies.Services
{
    public class MovieEventService: IMovieEventService
    {
        private readonly ISubject<MovieEvent> _eventStream = new ReplaySubject<MovieEvent>();

        public ConcurrentStack<MovieEvent> AllEvents {get;}
        public MovieEventService()
        {
            AllEvents = new ConcurrentStack<MovieEvent>();
        }
        public void AddError(Exception ex)
        {
            _eventStream.OnError(ex);
        }
        public MovieEvent AddEvent(MovieEvent e)
        {
            AllEvents.Push(e);
            _eventStream.OnNext(e);
            return e;
        }
        public IObservable<MovieEvent> EventStream()
        {
            return _eventStream.AsObservable();
        }
    }
}