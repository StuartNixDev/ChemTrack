using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Http;
using System.ComponentModel.DataAnnotations;

namespace ChemTrack.Pages.Forms
{
    [BindProperties]
    public class AddProductModel : PageModel
    {
        public List <Product> Product = new List<Product> ();

        [Required(ErrorMessage = "Product Name Required")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Specific Gravity Required")]
        public double? SG { get; set; }
        public string? UN_Number { get; set; }
        public string Classification { get; set; }
        public string MarinePollutant { get; set; }

        [Required(ErrorMessage = "Price Required")]
        public double? Price { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostUndoButton()

        {
            return new RedirectToPageResult("/Forms/AddProduct");
        }

        public IActionResult OnPostCancelButton()

        {
            return new RedirectToPageResult("/ProductManagement");
        }

        public IActionResult OnPostSubmitButton(DataAccess dataAccess)

        {
            if (!ModelState.IsValid)
            {
                return OnGet();
                
            }
            else
            {

                dataAccess.AddProduct(ProductName, (double)SG, UN_Number, Classification, MarinePollutant, (double)Price);
                return new RedirectToPageResult("/ProductManagement");
            }
        }
        }
    }

