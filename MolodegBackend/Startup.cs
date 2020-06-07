using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MolodegBackend.Domain.Repositories;
using MolodegBackend.Domain.Services;
using MolodegBackend.Models;
using MolodegBackend.Repositories;
using MolodegBackend.Services;

namespace MolodegBackend
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.AllowedUserNameCharacters = opts.User.AllowedUserNameCharacters + "ајбЅв¬г√дƒе≈Є®ж∆з«≥≤и»й…к лЋмћнЌоќпѕр–с—т“у”ф‘х’ц÷ч„шЎщўъЏыџь№эЁюё€я ";
                opts.Password.RequiredLength = 6;   // минимальна€ длина
                opts.Password.RequireNonAlphanumeric = false;   // требуютс€ ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуютс€ ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуютс€ ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуютс€ ли цифры
            }).AddEntityFrameworkStores<AppDbContext>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"]))
                    };
                });
            services.AddControllers();
            services.AddScoped<IPlacardRepository, PlacardRepository>();
            services.AddScoped<IPlacardService, PlacardService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
