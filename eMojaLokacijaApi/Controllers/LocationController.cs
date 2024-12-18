using eMojaLokacijaApi.Api.Models;
using eMojaLokacijaApi.Extensions;
using eMojaLokacijaApi.Extensions.Hub;
using eMojaLokacijaApi.ViewModels;
using eMojaLokacijaService.Common;
using eMojaLokacijaService.MojaLokacijaContext.Models;
using eMojaLokacijaService.MojaLokacijaService;
using eMojaLokacijaService.MojaLokacijaService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using System.Runtime.InteropServices;

namespace eMojaLokacijaApi.Controllers
{
	[ApiVersion("1")]
	[Produces("application/json")]
	[Authorize]
	public class LocationController : Controller
	{
		private readonly IMyLocationService _myLocationService;
		private IHubContext<MessageHub, IMessageHubClient> _messageHub;
		private readonly ILogger<LocationController> _logger;

		public LocationController(
			IMyLocationService myLocationService,
			IHubContext<MessageHub, IMessageHubClient> messageHub,
			ILogger<LocationController> logger)
		{
			_myLocationService = myLocationService ?? throw new ArgumentException(nameof(myLocationService));
			_messageHub = messageHub ?? throw new ArgumentException(nameof(messageHub));
			_logger = logger ?? throw new ArgumentException(nameof(logger));
		}

		[HttpPost("SearchAreaFunLocations", Name = "SearchAreaFunLocations", Order = 1)]
		// [Authorize(Policy = "LocatonApiUser")]
		[ProducesResponseType(typeof(AreaFunLocationVmResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
		[ProducesResponseType(typeof(ResponseBaseVm), StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ResponseBaseVm), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<AreaFunLocationVmResponse>> SearchAreaFunLocations([FromBody] AreaFunLocationVmRequest searchRequest)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (searchRequest.GeoLocation.Count == 0)
				return BadRequest(ModelState);

			var firstGeoLocation = searchRequest.GeoLocation.FirstOrDefault();
			if (firstGeoLocation == null || firstGeoLocation.Geometry == null || firstGeoLocation.Geometry.OgcGeometryType != OgcGeometryType.Point)
				return BadRequest("Invalid GeoLocation data.");

			AreaFunLocationVmResponse retValue = new AreaFunLocationVmResponse();

			try
			{
				FunLocationsRequest myLocationSearchRequest = new FunLocationsRequest
				{
					MyGeoPoint = firstGeoLocation.Geometry,
					UserId = User.Claims.GetUserId()
				};

				FunLocationsResponse myLocationSearchResponse = await _myLocationService.GetFunLocations(myLocationSearchRequest);

				if (myLocationSearchResponse.FunLocations != null)
				{
					List<string> locationSearchInfoData = new List<string>();

					foreach (var funLocation in myLocationSearchResponse.FunLocations)
					{
						// Create a new valid GeoJson object with attributes

						AreaFunLocation funLocationVm = new AreaFunLocation
						{
							Description = funLocation.Description,
							LocationType = funLocation.LocationType,
							GeoData = new FeatureCollection
							{
								new Feature
								{
									Geometry = funLocation.GeoPoint,
									Attributes = new AttributesTable
									{
								        // by default, an attribute with this property name
								        // will be written as the Feature's "id", instead of
								        // storing it in the "properties" of the Feature.
								        // you can change the name of the "special" property by
								        // using a different GeoJsonConverterFactory constructor
								        // (remember to update other code that uses it, though)
								        { NetTopologySuite.IO.Converters.GeoJsonConverterFactory.DefaultIdPropertyName, Guid.NewGuid() },
									},
								}
							}
						};

						locationSearchInfoData.Add($"Uspješna pretraga - Lokacija {funLocation.Description} na X:{funLocation.GeoPoint.Coordinate.X} i Y:{funLocation.GeoPoint.Coordinate.Y}");

						retValue.Locations.Add(funLocationVm);
					}

					await _messageHub.Clients.All.SendLocationSearchInfoToUser(locationSearchInfoData);
				}

				return retValue;
			}
			catch (Exception ex)
			{
				_logger.LogError(LoggingEvents.GetItem, ex, "LocationController - GetAreaFunLocations() exception.");
				return StatusCode(500, ResponseBaseVm.BaseVmError($"Greška prilikom pretrage lokacija !"));
			}
		}
	}
}
