using eMojaLokacijaService.MojaLokacijaContext.Models;
using eMojaLokacijaService.MojaLokacijaService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMojaLokacijaService.MojaLokacijaService
{
    public class MyLocationService : IMyLocationService
    {
        private readonly double _boundaryDistance = 25;

        private readonly MojaLokacijaContext.MojaLokacijaContext _locationContext;
        private readonly ILogger<MyLocationService> _logger;

        public MyLocationService(
            MojaLokacijaContext.MojaLokacijaContext locationContext,
            ILogger<MyLocationService> logger)
        {
            _locationContext = locationContext ?? throw new ArgumentException(nameof(locationContext));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }

        #region IMojaLokacijaService

        public async Task<FunLocationsResponse> GetFunLocations(FunLocationsRequest request)
        {
            FunLocationsResponse retValue = new FunLocationsResponse();

            retValue.FunLocations = await GetActiveFunLocations(request.MyGeoPoint);

            await SaveFunLocationSearch(request.UserId, request.MyGeoPoint, retValue.FunLocations);

            return retValue;
        }

        #endregion

        #region Private Methods

        private async Task<IEnumerable<FunLocationDto>> GetActiveFunLocations(Geometry searchGeoPoint)
        {
            // Replace this with a call to optimised view

            var funLocations = _locationContext.FunLocation
                .Where(x => x.Active && x.GeoPoint.Distance(searchGeoPoint) <= _boundaryDistance)
                .Include(x => x.Type)
                .Select(x => new FunLocationDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    GeoPoint = x.GeoPoint,
                    LocationType = x.Type.Description
                });

            return funLocations;
        }

        private async Task SaveFunLocationSearch(int userId, Geometry myGeoPoint, IEnumerable<FunLocationDto> funLocations)
        {
            var dateTimeNow = DateTime.Now;

            var newMyLocation = new MyLocation
            {
                UserId = userId,
                Active = true,
                DateCreated = dateTimeNow,
                Description = "Fun Location Search",
                GeoPoint = myGeoPoint,
                MyFunLocation = new List<MyFunLocation>()
            };

            foreach (var funLocation in funLocations)
            {
                newMyLocation.MyFunLocation.Add(new MyFunLocation
                {
                    Active = true,
                    DateCreated = dateTimeNow,
                    MyLocationId = newMyLocation.Id,
                    FunLocationId = funLocation.Id,
                });
            }

            await _locationContext.AddAsync(newMyLocation);
            await _locationContext.SaveChangesAsync();
        }

        #endregion

    }
}
