using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using LearnGraph.Movies.Services;
using LearnGraph.Movies.Schema;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

namespace LearnGraph.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMovieServices, MovieServices>();
            services.AddSingleton<IActorService, ActorService>();
            services.AddSingleton<MovieType>();
            services.AddSingleton<ActorType>();
            services.AddSingleton<MovieRatingEnum>();
            services.AddSingleton<MoviesQuery>();
            services.AddSingleton<MoviesSchema>();

            services.AddSingleton<MovieInputType>();
            services.AddSingleton<MoviesMutation>();

            services.AddSingleton<MovieEventType>();
            services.AddSingleton<IMovieEventService, MovieEventService>();
            services.AddSingleton<MoviesScription>();
            
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddGraphQL(option => {
                option.EnableMetrics = true;
                option.ExposeExceptions = true;
            })
            .AddWebSockets()
            .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseGraphQLWebSockets<MoviesSchema>("/graphql");
            app.UseGraphQL<MoviesSchema>("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
