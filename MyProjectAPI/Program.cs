 
using System.Xml.Serialization; 

namespace MyProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        } 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              { 
                  webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                  webBuilder.UseIISIntegration();
                  webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                  {
                      var env = hostingContext.HostingEnvironment;
 
                      var sharedFolder = Path.Combine(env.ContentRootPath, "..", "");

                      //load the SharedSettings first, so that appsettings.json overrwrites it
                      config
                        .AddJsonFile(Path.Combine(sharedFolder, "apiSettings.json"), optional: true)
                        .AddJsonFile("appsettings.json", optional: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                      config.AddEnvironmentVariables();
                  });

                  webBuilder.UseStartup<Startup>();
              });

   
    }
}
