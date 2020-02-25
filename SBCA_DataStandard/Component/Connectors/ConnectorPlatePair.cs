using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace SBCA.UnifiedDataStandard.Component.Connectors
{
    public enum ConnectorSetOrientation
    {
        FrontBack,
        TopBottom,
        Other,
    }

    public class ConnectorPlatePair: IConnectorSet
    {
        public string Name { get; set; }

        public Guid Guid { get; set; }

        public ConnectorSetOrientation Orientation { get; set; }

        public List<ConnectorPlate> ConnectorPlates { get; set; } = new List<ConnectorPlate>();
        
        [JsonIgnore]
        public List<IConnector> Connectors => ConnectorPlates.ToList<IConnector>();
    }
}
