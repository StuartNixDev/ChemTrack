using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ChemTrack
{
    [BindProperties]
    public class EditProductModel : PageModel
    {
        public List<Product> Prod = new List<Product>();

     
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }

        [Required]
        public double SG { get; set; }
        public string? UN_Number { get; set; }
        public string Classification { get; set; }
        public string MarinePollutant { get; set; }

        [Required(ErrorMessage = "Please Enter A Price Per Litre")]
        public double Price { get; set; }
       


        public IActionResult OnGet(int productID)
        {
            Prod = new DataAccess().FetchProduct(productID);
            return Page();

        }
        public IActionResult OnPostSubmitButton(DataAccess dataAccess)

        {
            if (!ModelState.IsValid)
            {
                return OnGet(ProductID);

            }
            else { 
                dataAccess.UpdateProduct(ProductID, ProductName, SG, UN_Number, Classification, MarinePollutant, Price);
                return new RedirectToPageResult("/ProductManagement");
            }
            
                
            
        }
        public IActionResult OnPostUndoButton()

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
