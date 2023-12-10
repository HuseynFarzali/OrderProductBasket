using DefaultWebApplication.Models.Command_Models.Bridge_Models;
using DefaultWebApplication.Models.Domain_Models;
using DefaultWebApplication.Models.View_Models.Detailed_Models;
using DefaultWebApplication.Services.Repositories;
using DefaultWebApplication.Services.Repositories.Bridge_Model_Repositories;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Item
{
    public class ItemUpdateModel : PageModel
    {
        private readonly ItemRepository _itemRepository;
        private readonly ProductRepository _productRepository;
        private readonly SizeRepository _sizeRepository;
        private readonly ColorRepository _colorRepository;
        private readonly CategoryRepository _categoryRepository;

        public ItemUpdateModel(ItemRepository itemRepository, ProductRepository productRepository, SizeRepository sizeRepository, ColorRepository colorRepository, CategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
            _colorRepository = colorRepository;
            _categoryRepository = categoryRepository;
        }

        public OutputModel ShowModel { get; set; }

        [BindProperty]
        public InputModel BoundInputModel { get; set; }
        public ItemCommandModel UpdateCommand { get; set; }

        public SelectList AvailableProducts { get; set; }
        public SelectList AvailableSizes { get; set; }
        public SelectList AvailableColors { get; set; }
        public SelectList AvailableCategories { get; set; }

        public class InputModel
        {
            public string ProductName { get; set; }
            public string ColorName { get; set; }
            public string SizeName { get; set; }
            public string CategoryName { get; set; }
            public string ItemName { get; set; }
        }

        public class OutputModel
        {
            public string ProductName { get; set; }
            public string ColorName { get; set; }
            public string SizeName { get; set; }
            public string CategoryName { get; set; }
            public string ItemName { get; set; }
        }

        public async void OnGet([FromRoute] int id)
        {
            await PopulateSelectListItems();
            await PopulateShowModel(id);
        }

        public async Task<IActionResult> OnPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectListItems();
                await PopulateShowModel(id);
                return Page();
            }

            await ConstructCommandModel();
            await _itemRepository.UpdateItemById(id, UpdateCommand);
            return RedirectToPage("itemmain");
        }

        private async Task<SelectList> GetPopulateSelectListFromRepository<TEntity, TCommandModel>(
            IRepository<TEntity, TCommandModel> repository) where TEntity : DomainModel
        {
            var entities = await repository.GetEntityCollection(e => e.Deleted is false);
            return new SelectList(entities, "Name", "Name");
        }

        private async Task ConstructCommandModel()
        {
            UpdateCommand = new ItemCommandModel();

            UpdateCommand.ItemProduct
                = (await _productRepository.GetEntityCollection(
                    p => p.Name == BoundInputModel.ProductName)).Single();

            UpdateCommand.ItemColor
                = (await _colorRepository.GetEntityCollection(
                    p => p.Name == BoundInputModel.ColorName)).Single();

            UpdateCommand.ItemSize
                = (await _sizeRepository.GetEntityCollection(
                    p => p.Name == BoundInputModel.SizeName)).Single();

            UpdateCommand.ItemCategory
                = (await _categoryRepository.GetEntityCollection(
                    p => p.Name == BoundInputModel.CategoryName)).Single();
        }

        private async Task PopulateSelectListItems()
        {
            AvailableProducts = await GetPopulateSelectListFromRepository(_productRepository);
            AvailableSizes = await GetPopulateSelectListFromRepository(_sizeRepository);
            AvailableColors = await GetPopulateSelectListFromRepository(_colorRepository);
            AvailableCategories = await GetPopulateSelectListFromRepository(_categoryRepository);
        }

        private async Task PopulateShowModel(int itemId)
        {
            var item = await _itemRepository.GetItemById(itemId);
            ShowModel = new OutputModel();

            ShowModel.ProductName = (await _productRepository.GetProductById(item.ProductId)).Name;
            ShowModel.ColorName = (await _colorRepository.GetColorById(item.ColorId)).Name;
            ShowModel.SizeName = (await _sizeRepository.GetSizeById(item.SizeId)).Name;
            ShowModel.CategoryName = (await _categoryRepository.GetCategoryById(item.CategoryId)).Name;
            ShowModel.ItemName = item.Name;
        }
    }
}
