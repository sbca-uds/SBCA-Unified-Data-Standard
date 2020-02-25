using System;
using System.Collections.Generic;

namespace SBCA.UnifiedDataStandard.Component.Connectors
{
    public interface IConnectorSet
    {
        string Name { get; }
        Guid Guid { get; }
        List<IConnector> Connectors { get; }
        ConnectorSetOrientation Orientation { get; }
    }
}
