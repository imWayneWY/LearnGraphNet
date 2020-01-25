using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearnGraph.Movies.Models;

namespace LearnGraph.Movies.Services
{
    public interface IMovieServices
    {
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAsync();
        Task<Movie> CreateAsync(Movie movie);
    }
}