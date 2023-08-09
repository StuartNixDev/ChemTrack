using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace ChemTrack.Pages.Forms
{
    [BindProperties]

    public class EditTankModel : PageModel
    {
        public List<Tank> Tank = new List<Tank>();
        public string TargetID;


        [Required(ErrorMessage = "Tank ID Required")]
        public string? TankID { get; set; }
        [Required]   
        public int Capacity { get; set; }
        [Required]       
        public string Dimensions { get; set; }
        [Required]      
        public int TareWeight { get; set; }
        [Required]     
        public int MaxGrossWeight { get; set; }
        [Required]      
        public int OnHire { get; set; }

     
        public IActionResult OnGet(string TankID)
        {
            Tank = new DataAccess().FetchTank(TankID); 
                
            return Page();
        }

        public IActionResult OnPostSubmitButton(DataAccess dataAccess)

        {
            if (!ModelState.IsValid)
            {
                Tank = new DataAccess().FetchTank(TankID);
                return OnGet(TankID);

            }
            else
            {
                dataAccess.UpdateTank(TankID, Capacity, Dimensions, TareWeight, MaxGrossWeight, OnHire);
                return new RedirectToPageResult("/FleetManagement");
            }
        }
        public IActionResult OnPostUndoButton()

        {
            return new RedirectToPageResult("/Forms/EditTank");
        }

        public IActionResult OnPostDeleteButton(DataAccess dataAccess)

        {
            dataAccess.DeleteTank(TankID);
            return new RedirectToPageResult("/FleetManagement");
        }
    }
}
