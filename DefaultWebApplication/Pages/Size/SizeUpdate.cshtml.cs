using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.View_Models.Detailed_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Size
{
    public class SizeUpdateModel : PageModel
    {
        private readonly SizeRepository _repository;

        public SizeUpdateModel(SizeRepository repository)
        {
            _repository = repository;
        }

        public SizeDetailedViewModel ShowModel { get; set; }

        [BindProperty]
        public SizeCommandModel UpdateModel { get; set; }

        public async Task OnGet([FromRoute] int id)
        {
            var size = await _repository.GetSizeById(id);
            ShowModel = new SizeDetailedViewModel
            {
                SizeId = size.SizeId,
                SizeName = size.Name,
                SizeTagName = size.TagName
            };
        }

        public async Task<IActionResult> OnPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return Page();

            await _repository.UpdateSizeById(id, UpdateModel);

            return RedirectToPage("sizemain");
        }
    }
}
