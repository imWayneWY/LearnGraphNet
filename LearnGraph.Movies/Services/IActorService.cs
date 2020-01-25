using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearnGraph.Movies.Models;

namespace LearnGraph.Movies.Services
{
    public interface IActorService
    {
        Task<Actor> GetByIdAsync(int id);
        Task<IEnumerable<Actor>> GetAsync();
    }
}