using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using Swashbuckle.AspNetCore.Swagger;

namespace books_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Books API", Version = "v1" });
            });

            var author1 = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe"
            };

            var author2 = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = "Jane",
                LastName = "Langton"
            };

            var author3 = new Author
            {
                Id = Guid.NewGuid(),
                FirstName = "Peter",
                LastName = "Hagman"
            };

            var books = new List<Book>
            {
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "A Life Changed",
                    Author = author1,
                    Description = "Nulla sunt sunt pariatur officia et esse fugiat proident est. Ad laboris ullamco adipisicing nisi in ex. Magna voluptate culpa velit exercitation nisi ipsum est do.",
                    Price = 10.0,
                    IsInStock = true,
                    Preview = "https://images.unsplash.com/photo-1496484805162-42c00f79cdce?dpr=1&auto=format&fit=crop&w=568&h=379&q=60&cs=tinysrgb&ixid=dW5zcGxhc2guY29tOzs7Ozs%3D"
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "The Math Behind React",
                    Author = author2,
                    Description = "Nulla sunt sunt pariatur officia et esse fugiat proident est. Ad laboris ullamco adipisicing nisi in ex. Magna voluptate culpa velit exercitation nisi ipsum est do.",
                    Price = 48,
                    IsInStock = true,
                    Preview = "https://images.unsplash.com/photo-1453733190371-0a9bedd82893?dpr=1&auto=format&fit=crop&w=568&h=426&q=60&cs=tinysrgb&ixid=dW5zcGxhc2guY29tOzs7Ozs%3D"
                }
                ,
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "A Journey of Discovery",
                    Author = author3,
                    Description = "Nulla sunt sunt pariatur officia et esse fugiat proident est. Ad laboris ullamco adipisicing nisi in ex. Magna voluptate culpa velit exercitation nisi ipsum est do.",
                    Price = 22,
                    IsInStock = false,
                    Preview = "https://images.unsplash.com/photo-1453733190371-0a9bedd82893?dpr=1&auto=format&fit=crop&w=568&h=426&q=60&cs=tinysrgb&ixid=dW5zcGxhc2guY29tOzs7Ozs%3D"
                }
            };

            services.AddSingleton<IRepository>(new Repository(books));

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
