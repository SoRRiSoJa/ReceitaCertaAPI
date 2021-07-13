using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Globalization;

namespace ReceitaCertaAPI
{
    using ReceitaCertaAPI.Domain.Interfaces;
    using ReceitaCertaAPI.Domain.Repositories;
    using ReceitaCertaAPI.Persistence.Data;
    using ReceitaCertaAPI.Persistence.Repositories;
    using ReceitaCertaAPI.Services;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReceitaCertaAPI", Version = "v1" });
            });

            services.AddSingleton(_ => Configuration);
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddDbContext<ReceitaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ReceitaWS")));
            AddIoCRepositories(services);
            AddIoCServices(services);
            AddIocValidations(services);
            services.AddHttpContextAccessor();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReceitaCertaAPI v1"));
            }

            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void AddIoCRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
        }
        private void AddIocValidations(IServiceCollection services)
        {
            //services.AddTransient<IValidator<Agenda>, AgendaValidator>();
        }
        private void AddIoCServices(IServiceCollection services)
        {
            services.AddTransient<IProdutoService, ProdutoService>();
        }
    }
}
