using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using static Slapper.AutoMapper;
using System.Xml.Linq;

namespace ChemTrack
{
    [BindProperties]
    public class EditProductModel : PageModel
    {
        public List<Product> Prod = new List<Product>();

        
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double SG { get; set; }
        public string UN_Number { get; set; }
        public string Classification { get; set; }
        public string MarinePollutant { get; set; }
        public double Price { get; set; }


        public void OnGet(int productID)
        {
            Prod = new DataAccess().FetchProduct(productID);

        }
        public IActionResult OnPostSubmitButton(DataAccess dataAccess)

        {
            
            dataAccess.UpdateProduct(ProductID, ProductName, SG, UN_Number, Classification, MarinePollutant, Price);
            return new RedirectToPageResult("/ProductManagement");
        }
        public IActionResult OnPostUndoButton(DataAccess dataAccess)

        {
            return new RedirectToPageResult("/Forms/EditProduct");
        }

        public IActionResult OnPostDeleteButton(DataAccess dataAccess)

        {
            dataAccess.DeleteProduct(ProductID);
            return new RedirectToPageResult("/ProductManagement");
        }
    }
}
