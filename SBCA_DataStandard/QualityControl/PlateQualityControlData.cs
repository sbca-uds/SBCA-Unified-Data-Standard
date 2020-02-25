using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component.Connectors;
using SBCA.UnifiedDataStandard.Component.Geometry;

namespace SBCA.UnifiedDataStandard.QualityControl
{
    public enum AreaMethod
    {
        Gross,
        Net
    }

    public class PlateQualityControlData
    {
        public Guid PlatePairGuid { get; set; }
        [JsonIgnore]
        public ConnectorPlatePair ConnectorPlatePair { get; set; }
        public AreaMethod AreaMethod { get; set; }
        public Polygon2D ZeroTolerancePolygon { get; set; } = new Polygon2D();
        public double JointStressIndex { get; set; }
        public double RotationToleranceMin { get; set; }
        public double RotationToleranceMax { get; set; }
        public List<PlateMemberContactArea> ContactAreas { get; set; } = new List<PlateMemberContactArea>();
    }
}
