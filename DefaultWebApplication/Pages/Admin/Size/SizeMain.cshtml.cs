using DefaultWebApplication.Models.View_Models.Summary_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Sizes
{
    public class SizeMainModel : PageModel
    {
        private readonly SizeRepository _repository;

        public SizeMainModel(SizeRepository repository)
        {
            _repository = repository;
        }

        public List<SizeSummaryViewModel> SizeSummaries { get; set; } = new List<SizeSummaryViewModel>();

        public async Task OnGet(bool showDeleted)
        {
            var sizes = await _repository.GetEntityCollection(s => true);

            if (!showDeleted)
                sizes = sizes.Where(s => s.Deleted == false);

            foreach (var size in sizes)
                SizeSummaries.Add(
                    new SizeSummaryViewModel
                    {
                        SizeId = size.SizeId,
                        SizeName = size.Name,
                        SizeTagName = size.TagName,
                        SizeDeleted = size.Deleted,
                    });
        }
    }
}
