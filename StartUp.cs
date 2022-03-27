using HandyMan.Business.Configuration;
using HandyMan.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HandyMan
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.HandyManConnectionStringService(AppSettings.GetHandyManConnectionString());
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(AppSettings.GetHandyManConnectionString()));

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Add other security headers


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Request.Path.StartsWithSegments("/api"))
                {
                    if (!context.HttpContext.Response.ContentLength.HasValue || context.HttpContext.Response.ContentLength == 0)
                    {
                        // You can change ContentType as json serialize
                        context.HttpContext.Response.ContentType = "text/plain";
                        await context.HttpContext.Response.WriteAsync($"Status Code: {context.HttpContext.Response.StatusCode} - {ReasonPhrases.GetReasonPhrase(context.HttpContext.Response.StatusCode)}");
                    }
                }
                else
                {
                    // You can ignore redirect
                    context.HttpContext.Response.Redirect($"/Error/{context.HttpContext.Response.StatusCode}");
                }
            });

            var localizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = new List<CultureInfo> { new CultureInfo("en-GB") },
                SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-GB") },
                DefaultRequestCulture = new RequestCulture("en-GB")
            };
            app.UseRequestLocalization(localizationOptions);

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors();
            app.UseResponseCaching();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
