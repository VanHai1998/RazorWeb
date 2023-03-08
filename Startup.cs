using ASP_RAZORWEB.models;
using Microsoft.EntityFrameworkCore;

namespace ASP_RAZORWEB
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
            /*
                Phương thức ConfigureServices cho phép truy cập đến các dịch vụ, dependency được Inject vào
                Webhost. Hoặc bạn cũng có thể đưa thêm các dependency tại đây.
            */
            services.AddRazorPages();
            services.AddDbContext<MyBlogContext>(options =>
            {
                string ConnectString = Configuration.GetConnectionString("MyBlogContext");
                options.UseSqlServer(ConnectString);
            });
        }

        // IHostingEnvironment  env cho phép truy cập các biến môi trường, thư mục nguồn, thư mục file.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });
                endpoints.MapRazorPages();
            });
        }
    }
}

/*
CREATE READ UPDATE DELETE (CRUD)
dotnet aspnet-codegenerator razorpage -m ASP_RAZORWEB.models.Article -dc ASP_RAZORWEB.models.MyBlogContext -outDir Pages/Blog -udl --referenceScriptLibraries
*/