using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChemTrack
{
    public class EditProductModel : PageModel
    {
        public List<Product> Prod = new List<Product>();

        [BindProperty]
        public int ProductID { get; set; }
        [BindProperty]
        public string ProductName { get; set; }
        [BindProperty]
        public double SG { get; set; }
        [BindProperty]
        public string UN_Number { get; set; }
        [BindProperty]
        public string Classification { get; set; }
        [BindProperty]
        public string HazardousToEnvironment { get; set; }
        [BindProperty]
        public double Price { get; set; }


        public void OnGet(int productID)
        {
            Prod = new DataAccess().FetchProduct(productID);

        }

    }
}
