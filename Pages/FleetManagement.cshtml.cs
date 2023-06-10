using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Diagnostics;

namespace ChemTrack.Pages
{
    public class FleetManagementModel : PageModel
    {
        public List<Tank> Tanks = new List<Tank>();

        public List<Tank> SCTTanks = new List<Tank>();
        public List<Tank> STTanks = new List<Tank>();
        public List<Tank> NQTanks = new List<Tank>();
        public List<Tank> STMTanks = new List<Tank>();

        public void OnGet()
        {
            Tanks = new DataAccess().GetTanks();
            foreach(Tank T in Tanks)
            {
                if (T.TankID.Contains("SCT"))
                {
                    SCTTanks.Add(T);
                }
                else if (T.TankID.Contains("STM"))
                {
                    STMTanks.Add(T);
                }
                else if (T.TankID.Contains("NQ"))
                {
                    NQTanks.Add(T);
                }
                else if (T.TankID.Contains("ST"))
                {
                    STTanks.Add(T);
                }

            }

        }
    }
}
