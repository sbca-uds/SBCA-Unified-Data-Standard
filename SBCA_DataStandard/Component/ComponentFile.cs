using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component.Bearings;
using SBCA.UnifiedDataStandard.Component.Connectors;
using SBCA.UnifiedDataStandard.Component.Connectors.ConnectorMaterials;
using SBCA.UnifiedDataStandard.Component.Geometry;
using SBCA.UnifiedDataStandard.Component.InstallationHardware;
using SBCA.UnifiedDataStandard.Component.InstallationHardware.HardwareMaterials;
using SBCA.UnifiedDataStandard.Component.Members;
using SBCA.UnifiedDataStandard.Component.Members.MemberMaterials;
using SBCA.UnifiedDataStandard.Serialization;

namespace SBCA.UnifiedDataStandard.Component
{
    public enum ComponentUsage
    {
        Roof,
        Floor,
        Wall,
        Beam,
        Post,
        Ledger,
        Joist,
        Other,
    }

    public partial class ComponentFile
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Version { get; set; } = new Version(0, 1, 2).ToString();

        public string CreationProgram { get; set; }
        public string CreationProgramVersion { get; set; }

        public DateTime CreationTimeStamp { get; set; }

        public DistanceUnit DistanceUnit { get; set; }

        public AngleUnit AngleUnit { get; set; }

        public int NumberOfPlies { get; set; }
        public bool PliesFieldInstalled { get; set; }

        public ComponentUsage ComponentUsage { get; set; }

        public List<Lumber> Lumbers { get; set; } = new List<Lumber>();
        public List<Member> Members { get; set; } = new List<Member>();

        public List<ConnectorPlateType> ConnectorPlateTypes { get; set; } = new List<ConnectorPlateType>();
        public List<ConnectorPlatePair> ConnectorPlatePairs { get; set; } = new List<ConnectorPlatePair>();

        public List<Bearing> Bearings { get; set; } = new List<Bearing>();

        public List<HangerType> HangerTypes { get; set; } = new List<HangerType>();
        public List<Hanger> Hangers { get; set; } = new List<Hanger>();


        public string Write()
        {
            return JsonConvert.SerializeObject(this, JsonSerialization.SerializerSettings);
        }

        public static ComponentFile Read(string fileContents)
        {
            return JsonConvert.DeserializeObject<ComponentFile>(fileContents, JsonSerialization.SerializerSettings);
        }
    }
}
