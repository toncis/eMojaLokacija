using eMojaLokacijaService.MojaLokacijaContext.Models;
using eMojaLokacijaService.MojaLokacijaService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMojaLokacijaService.MojaLokacijaService
{
    public interface IMyLocationService
    {
        Task<FunLocationsResponse> GetFunLocations(FunLocationsRequest request);
    }
}
