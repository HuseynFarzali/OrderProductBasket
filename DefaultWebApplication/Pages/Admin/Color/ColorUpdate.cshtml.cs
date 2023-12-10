using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.View_Models.Detailed_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Color
{
    public class ColorUpdateModel : PageModel
    {
        private readonly ColorRepository _repository;

        public ColorUpdateModel(ColorRepository repository)
        {
            _repository = repository;
        }

        public ColorDetailedViewModel ShowModel { get; set; }

        [BindProperty]
        public ColorCommandModel UpdateCommand { get; set; }

        public async Task OnGet([FromRoute] int id)
            => await PopulateShowModel(id);

        public async Task<IActionResult> OnPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                await PopulateShowModel(id);
                return Page();
            }

            await _repository.UpdateColorById(id, UpdateCommand);
            return RedirectToPage("colormain");
        }

        private async Task PopulateShowModel(int colorId)
        {
            var color = await _repository.GetColorById(colorId);
            ShowModel = new ColorDetailedViewModel
            {
                ColorId = color.ColorId,
                ColorName = color.Name,
                ColorRgbCode = color.RgbCode,
                ColorTagName = color.TagName
            };
        }
    }
}
