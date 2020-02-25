using System;
using Newtonsoft.Json;
using SBCA.UnifiedDataStandard.Component.Members;

namespace SBCA.UnifiedDataStandard.QualityControl
{
    public class PlateMemberContactArea
    {
        public Guid MemberGuid { get; set; }
        [JsonIgnore]
        public Member Member { get; set; }
        public string MemberName { get; set; }
        public int RequiredTeeth { get; set; }
        public double RequiredArea { get; set; }
        public double JointStressIndex { get; set; }
    }
}
