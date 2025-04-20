using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi;

public class Startup
{
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddSwaggerGen();
        services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
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
        
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
