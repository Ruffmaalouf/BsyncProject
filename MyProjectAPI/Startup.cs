  
using MyProjectBusinessRules.Interfaces;
using MyProjectBusinessRules.Services;
using MyProjectBusinessRules;
using System.Data.SqlClient;
using MyProjectDataAccess.Interfaces;
using MyProjectDataAccess.Repositories;

namespace MyProjectAPI
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

             
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false; 
            }) ;

           
            string connectionString = Configuration.GetConnectionString("ConnectionString");
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddSingleton<string>(connectionString);
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAccountService, AccountService>();
          
            services.AddSingleton(Configuration);
            services.AddControllers();
        }
         
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
         
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "api/{controller}/{action}");
            });
 
        }
    } 
}
