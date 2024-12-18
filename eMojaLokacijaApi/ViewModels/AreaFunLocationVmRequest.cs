using NetTopologySuite.Features;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace eMojaLokacijaApi.ViewModels
{
    public class AreaFunLocationVmRequest
    {
        [DataMember]
        [Required]
        public FeatureCollection GeoLocation { get; set; } = new FeatureCollection();
    }
}
