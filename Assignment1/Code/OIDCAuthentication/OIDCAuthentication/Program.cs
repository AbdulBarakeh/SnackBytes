namespace OIDCAuthentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication().AddCookie().AddOpenIdConnect(options =>
            {
                options.ClientId = "";
                options.ClientSecret = "";
                options.GetClaimsFromUserInfoEndpoint = true;
                options.RequireHttpsMetadata = true;
                options.ResponseType = "Code";
                options.ResponseMode = "";
                options.SaveTokens = true;
                options.SignInScheme = "https";
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}