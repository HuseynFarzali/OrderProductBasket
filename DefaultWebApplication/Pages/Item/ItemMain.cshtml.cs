using DefaultWebApplication.Models.View_Models.Summary_Models;
using DefaultWebApplication.Services.Repositories.Bridge_Model_Repositories;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Item
{
    public class ItemMainModel : PageModel
    {
        private readonly ItemRepository _repository;
        private readonly ProductRepository _productRepository;
        private readonly SizeRepository _sizeRepository;
        private readonly ColorRepository _colorRepository;
        private readonly CategoryRepository _categoryRepository;

        public ItemMainModel(ItemRepository repository, ProductRepository productRepository, SizeRepository sizeRepository, ColorRepository colorRepository, CategoryRepository categoryRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
            _colorRepository = colorRepository;
            _categoryRepository = categoryRepository;
        }

        public List<ItemSummaryViewModel> ItemSummaries { get; set; } = new List<ItemSummaryViewModel>();

        public async Task OnGet([FromRoute] bool showDeleted)
        {
            var items = await _repository.GetEntityCollection(i => true);

            if (!showDeleted)
                items = items.Where(i => i.Deleted == false);

            foreach (var item in items)
            {
                ItemSummaries.Add(
                    //new ItemSummaryViewModel
                    //{
                    //    ItemId = item.ItemId,
                    //    ItemName = item.Name,
                    //    CategoryName = item.Category.Name,
                    //    ColorName = item.Color.Name,
                    //    SizeName = item.Size.Name,
                    //    ItemDeleted = item.Deleted,
                    //});
                    new ItemSummaryViewModel
                    {
                        ItemId = item.ItemId,
                        ItemName = item.Name,
                        CategoryName = (await _categoryRepository.GetCategoryById(item.CategoryId)).Name,
                        SizeName = (await _sizeRepository.GetSizeById(item.SizeId)).Name,
                        ColorName = (await _colorRepository.GetColorById(item.ColorId)).Name,
                        ProductName = (await _productRepository.GetProductById(item.ProductId)).Name,
                        ItemDeleted = item.Deleted,
                    });
            }
        }
    }
}
