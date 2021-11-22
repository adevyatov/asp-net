using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApi.Exceptions;
using WebApi.Middleware;
using WebApi.Models.Context;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApi", Version = "v1"}); });

            // #2 - 2.4 - Получать строку подключения к базе данных из файла конфигурации
            services.AddDbContext<AppContext>(options =>
                options.UseNpgsql(Configuration["Db:AppContext:ConnectionString"])
            );

            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ILibraryCardRepository, LibraryCardRepository>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ILibraryCardService, LibraryCardService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                var response = new {error = exception.Message};

                if (exception is HttpStatusException httpStatusException)
                {
                    context.Response.StatusCode = (int) httpStatusException.Status;
                }

                await context.Response.WriteAsJsonAsync(response);
                await context.Response.CompleteAsync();
            }));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<RequestExecutionMiddleware>();
            app.UseMiddleware<BasicAuthMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
