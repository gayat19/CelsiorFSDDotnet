namespace FirstWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);//Create a new builder instance that is going to build our web appilcation.

            // Add services to the container.
            builder.Services.AddControllersWithViews();//using the builder object we are adding the MVC service.

            var app = builder.Build();//construct the application object using the builder object that we configured above.

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())//check if the environment is not development - will explain later
            {
                app.UseExceptionHandler("/Home/Error");//use the exception handler middleware to handle exceptions.
            }
            {
                app.UseExceptionHandler("/Home/Error");//use the exception handler middleware to handle exceptions.
            }
            app.UseStaticFiles(); //add the static files to the appplication- they are insid eteh wwwroot folder in the project

            app.UseRouting();//add the routing to the application

            app.UseAuthorization();//add security to the application

            app.MapControllerRoute(//add the default controller route to the application
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");

            app.Run();
        }
    }
}