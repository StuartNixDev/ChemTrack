using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ChemTrack
{
    public class Tank
    {
        public string TankID { get; set; }
        public int Capacity { get; set; }
        public string Dimensions { get; set; }
        public int TareWeight {get;set;}
        public int MaxGrossWeight { get;set;}
        public int OnHire { get;set;}
         
    }
}
