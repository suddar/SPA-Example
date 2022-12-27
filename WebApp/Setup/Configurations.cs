using Application.Middlewares;
using Domain.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApp.Setup
{
    public static class Configurations
    {
        public static void UseCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddRazorPages();
            services.AddSwaggerGen();

            #region Configure JWT
            JWTConfiguration JwtConfiguration = new();
            configuration.Bind("JWTConfiguration", JwtConfiguration);
            services.AddSingleton(JwtConfiguration);

            //services
            //    .AddOptions<JWTConfiguration>()
            //    .BindConfiguration("JWTConfiguration");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                if (JwtConfiguration.AccessTokenSecret is null || JwtConfiguration.Issuer is null) return;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfiguration.AccessTokenSecret)),
                    ValidIssuer = JwtConfiguration.Issuer,
                    ValidAudience = JwtConfiguration.Audience,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion
        }

        public static void UseCommonPiplines(this WebApplication app)
        {
            //app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapRazorPages();

            #region For ClientApp
            //app.UseStaticFiles(
            //    new StaticFileOptions
            //    {
            //        FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "ClientApp/dist")),
            //        RequestPath = "/app"
            //    });

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            #endregion
        }
    }
}
