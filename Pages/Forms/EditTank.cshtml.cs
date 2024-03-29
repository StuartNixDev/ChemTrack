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
        [Required(ErrorMessage = "Capacity Required")]   
        public int? Capacity { get; set; }
        [Required(ErrorMessage = "Dimensions Required")]       
        public string? Dimensions { get; set; }
        [Required(ErrorMessage = "Tare Weight Required")]      
        public int? TareWeight { get; set; }
        [Required(ErrorMessage = "Max Gross Weight Required")]     
        public int? MaxGrossWeight { get; set; }
        [Required(ErrorMessage = "On Hire Information Required")]      
        public int? OnHire { get; set; }

     
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
                dataAccess.UpdateTank(TankID, (int)Capacity, Dimensions, (int)TareWeight, (int)MaxGrossWeight, (int)OnHire);
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
