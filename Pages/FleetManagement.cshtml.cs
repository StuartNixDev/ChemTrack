using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Diagnostics;

namespace ChemTrack.Pages
{
    public class FleetManagementModel : PageModel
    {
        public List<Tank> Tanks = new List<Tank>();

        public List<Tank> KLMTanks = new List<Tank>();
        public List<Tank> MHVTanks = new List<Tank>();
        public List<Tank> PBTTanks = new List<Tank>();
        public List<Tank> HLMTanks = new List<Tank>();

        public void OnGet()
        {
            Tanks = new DataAccess().GetTanks();
            foreach(Tank T in Tanks)
            {
                if (T.TankID.Contains("KLM"))
                {
                    KLMTanks.Add(T);
                }
                else if (T.TankID.Contains("MHV"))
                {
                    MHVTanks.Add(T);
                }
                else if (T.TankID.Contains("PBT"))
                {
                    PBTTanks.Add(T);
                }
                else if (T.TankID.Contains("HLM"))
                {
                    HLMTanks.Add(T);
                }

            }

        }
    }
}
