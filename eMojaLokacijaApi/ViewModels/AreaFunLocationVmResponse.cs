using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using System.Runtime.Serialization;

namespace eMojaLokacijaApi.ViewModels
{
    public class AreaFunLocationVmResponse
    {
        [DataMember]
        public ICollection<AreaFunLocation> Locations { get; set; } = new List<AreaFunLocation>();
    }

    public class AreaFunLocation
    {
        [DataMember]
        public string LocationType { get; set; } = String.Empty;
        [DataMember]
        public string Description { get; set; } = String.Empty;
        [DataMember]
        public FeatureCollection GeoData { get; set; } = new FeatureCollection();
    }
}
