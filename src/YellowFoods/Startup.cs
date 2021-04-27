using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YellowFoods.Data.Data;
using YellowFoods.Data.Services;
using YellowFoods.Data.Services.Abstractions;
using YellowFoods.Links.Generators;
using YellowFoods.Links.Generators.Abstractions;
using YellowFoods.Links.Services;
using YellowFoods.Links.Services.Abstractions;
using YellowFoods.Resources;

namespace YellowFoods
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<YellowFoodsContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString(
                        "YellowFoodsContext")));

            services.AddScoped<IFoodsDataService, FoodsDataService>();
            services.AddScoped<INutrientsDataService, NutrientsDataService>();
            services.AddScoped<INutrientEntriesDataService,
                NutrientEntriesDataService>();
            services.AddScoped<IUnitsDataService, UnitsDataService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IFoodsGenerator, FoodsGenerator>();
            services.AddScoped<INutrientsGenerator, NutrientsGenerator>();
            services.AddScoped<INutrientEntriesGenerator,
                NutrientEntriesGenerator>();
            services.AddScoped<IUnitsGenerator, UnitsGenerator>();

            services.AddScoped<ILinkService<FoodResource>, FoodLinkService>();
            services.AddScoped<ILinkService<NutrientResource>,
                NutrientLinkService>();
            services.AddScoped<ILinkService<NutrientEntryResource>,
                NutrientEntryLinkService>();
            services.AddScoped<ILinkService<UnitResource>, UnitLinkService>();

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
