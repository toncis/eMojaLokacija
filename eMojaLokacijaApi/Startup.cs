using eMojaLokacijaApi.Extensions.Hub;

namespace eMojaLokacijaApi
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
			services.AddHttpClient();

			services.AddHttpContextAccessor();

			services.AddControllers();

			services.AddEndpointsApiExplorer();

			services.AddSwaggerGen();

			//services.AddCustomVersioning(1, 0);

			//services.AddCustomKestrelOptions();

			//services.AddCustomCors(Configuration);

			services.AddAuthorization();

			//services.AddCustomHealthChecks();

			//services.ConfigureServices(Configuration);

			//services.ConfigureRedis(Configuration);

			//services.AddCeresFeatureManagement();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//app.UseAllElasticApm(Configuration);

			//app.UseExceptionHandler(err => err.UseCeresExceptionHandler(env));

			//app.UsePathBase("/api/crop");

			//app.UseSerilogRequestLogging();

			//app.UseCustomForwaredHeaders();

			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			//app.UseCors(x => x
			//	.WithOrigins(CropAppSettings.AllowOrigins)
			//	.AllowAnyMethod()
			//	.AllowAnyHeader());

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapHub<MessageHub>("/locationsearch");
				//endpoints.MapHealthChecks("/health");
			});

			//app.UseOpenApi(env);
		}
	}
}
