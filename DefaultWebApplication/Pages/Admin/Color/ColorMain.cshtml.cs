using DefaultWebApplication.Extensions;
using DefaultWebApplication.Models.View_Models.Detailed_Models;
using DefaultWebApplication.Models.View_Models.Summary_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Color
{
    public class ColorMainModel : PageModel
    {
        private readonly ColorRepository _repository;

        public ColorMainModel(ColorRepository repository)
        {
            _repository = repository;
        }

        public List<ColorSummaryViewModel> ColorSummaries { get; set; } = new List<ColorSummaryViewModel>();

        public async Task OnGet(bool showDeleted)
        {
            var colors = await _repository.GetEntityCollection(c => true, true);

            if (!showDeleted)
                colors = colors.Where(c => c.Deleted == false);

            foreach (var color in colors)
                ColorSummaries.Add(
                    new ColorSummaryViewModel
                    {
                        ColorId = color.ColorId,
                        ColorName = color.Name,
                        ColorTagName = color.TagName,
                        ColorRgbCode = color.RgbCode,
                        ColorDeleted = color.Deleted,
                        ColorDetailedViewModel = new ColorDetailedViewModel
                        {
                            ColorId = color.ColorId,
                            ColorName = color.Name,
                            ColorRgbCode = color.RgbCode,
                            ColorTagName = color.TagName,
                            ItemModels = color.ItemList.ConvertToSummaryModels()
                        }
                    });
        }
    }
}
