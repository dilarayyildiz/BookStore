using System.Reflection;
using BookStoreApi.DBOperations;
using BookStoreApi.Middlewares;
using BookStoreApi.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi;

public class Startup
{
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddSwaggerGen();
        services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSingleton<ILoggerService, DbLogger>();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        
        app.UseRouting();
        
        app.UseAuthorization();

        app.UseCustomExceptionMiddleware();
        
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
