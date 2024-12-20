﻿using eMojaLokacijaService.MojaLokacijaContext;
using eMojaLokacijaService.MojaLokacijaService;
using Microsoft.AspNetCore.Cors.Infrastructure;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eMojaLokacijaApi
{
	public static class ServiceConfiguration
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			ConfigureApplicationServices(services, configuration);
			ConfigureAuthentication(services, configuration);
		}

		private static void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IMyLocationService, MyLocationService>();

			NetTopologySuite.NtsGeometryServices.Instance = new NetTopologySuite.NtsGeometryServices(
				NetTopologySuite.Geometries.Implementation.CoordinateArraySequenceFactory.Instance,
				new NetTopologySuite.Geometries.PrecisionModel(100000000000d),
				3765);
			services.AddSingleton(NetTopologySuite.NtsGeometryServices.Instance);

			// Add GeoJSON serialization for Geometry objects
			services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.Converters.Add(new NetTopologySuite.IO.Converters.GeoJsonConverterFactory());
				});

			services.AddDbContext<MojaLokacijaContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("Default"), x => x.UseNetTopologySuite());
#if !DEBUG
							options.UseModel(MojaLokacijaContextModel.Instance);
#endif
				options.EnableSensitiveDataLogging();
			});

			services.AddSignalR();

		}

		private static void ConfigureAuthentication(IServiceCollection services, IConfiguration configuration)
		{
			//services
			//	.AddKeycloakAuthenticationSettings()
			//	.AddAuthentication(options =>
			//	{
			//		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			//		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			//	})
			//	.AddKeycloakAuthenticationPolicy()
			//	.AddKeycloakCeresAuthenticationSchemes(configuration);
			//services.AddCeresAuthentication();
		}
	}
}
