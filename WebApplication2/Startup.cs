using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Mvc.AutoMapper.Profiles;
using ProgrammersBlog.Mvc.Helpers.Abstarct;
using ProgrammersBlog.Mvc.Helpers.Concrete;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.ServiceCollectionExtemsions;
using System.Text.Json.Serialization;

namespace ProgrammersBlog.Mvc
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                // mvc projemiz icersinde heryerde gecerli olacak, Controller icersinden frontend tarafina gonderilen modelerin javascript tarafindan  analasilabilmesi icin  Json formatina donusturmek 
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                // JsonSerializerOptions dosyasinda bir bug mevcut controller icinde kullanilmaz bu sekilde yazip birakirsak eger, o yuzden asgadaki satiri yaziyoruz ama duzletilirse yukardakini tekbasina kullanabiliriz
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            services.AddSession();// kullanicinin giris yapttigi anda server'da  olusturlan oturum  (global bir degisken) kullanci ile ilgi bilgiler saklayabiliyoruz
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile));
            services.LoadMyServices(connectionString: Configuration.GetConnectionString("LocalDB"));// bu satir calisttigi zaman identiityler de eklenmis olur 
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(option =>
            {

                option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Admin/User/Login"); // login yapmadan kullanc sayfasina gitmek istersem otomatik olarak buraya yonlendirilecek
                option.LogoutPath = new Microsoft.AspNetCore.Http.PathString("" +
                    "/Admin/User/Logout");
                option.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
                {
                    Name = "ProgrammersBlog",
                    HttpOnly = true,// cookie islemlerini sedece http uzerinden gondermesini sagliyoruz (Server side) front tarafinda cooki islermize ulasmayi engellemis oluyoruz 
                    SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict, // cookie bilgileri yanilzca kendi sitemizden geldigi takidirde isleniyor (CSRF saldirisina onlu) 
                    SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest// always olmali
                };
                option.SlidingExpiration = true;// ne zamandan sonra cikis yapilcak kullnici aktif degilse 
                option.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Admin/User/AccessDenied");

                {

                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();// once hangi rout uzerinden islem yapacagimiz biliyor olamamiz gerekiyor  
            app.UseAuthentication(); // sonra who are you kontrolu gerceklestiriyoruz 
            app.UseAuthorization();// sonra what are your validities 
            // admin area'ye mi gideceksin? alttaki kod calisir 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    "Admin",
                    "Admin",
                    "Admin/{controller=Home}/{action=Index}/{id?}"


                   );
                // normal bir sayfa mi ? altteki kod 
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            }



            );
        }
    }
}
