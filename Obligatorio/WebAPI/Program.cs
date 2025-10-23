
using LogicaAccesoDatos.Repositorios;
using LogicaAccesoDatos;
using LogicaAplicacion.ImplementacionCasosUso.EnvioCU;
using LogicaAplicacion.ImplementacionCasosUso.UsuarioCU;
using LogicaAplicacion.InterfaceCasosUso.EnvioCU;
using LogicaAplicacion.InterfaceCasosUso.UsuarioCU;
using LogicaNegocio.InterfaceRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvioEF>();

            builder.Services.AddScoped<IMostrarEnvioEmail, MostrarEnvioEmail>();
            builder.Services.AddScoped<IEnvioComentarios, EnvioComentarios>();
            builder.Services.AddScoped<IBuscarEnvioNumeroTracking, BuscarEnvioNumeroTracking>();
            builder.Services.AddScoped<IEnviosPorFechas, EnviosPorFechas>();
            builder.Services.AddScoped<IEnviosPorTexto,EnviosPorTexto>();

            builder.Services.AddScoped<IEditarUsuario, EditarUsuario>();
            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();

            string cadenaConexion = builder.Configuration.GetConnectionString("CadenaConexion");
            builder.Services.AddDbContext<ObligatorioContext>
                (opt => opt.UseSqlServer(cadenaConexion));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt => opt.IncludeXmlComments("WebAPI.xml"));

            ////Comienza JWT////
            var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

            builder.Services.AddAuthentication(aut =>
            {
                aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(aut =>
            {
                aut.RequireHttpsMetadata = false;
                aut.SaveToken = true;
                aut.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
