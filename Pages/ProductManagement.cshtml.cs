using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ChemTrack.Pages
{
    public class ProductManagementModel : PageModel
    {
        public List<Product> Chemicals = new List<Product>();
        public void OnGet()
        {
            Chemicals = new DataAccess().GetChems();
        }
    }
}

    

