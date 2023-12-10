using DefaultWebApplication.Models.Command_Models.Bridge_Models;
using DefaultWebApplication.Models.Domain_Models;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using DefaultWebApplication.Services.Repositories;
using DefaultWebApplication.Services.Repositories.Bridge_Model_Repositories;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Item
{
    public class ItemAddModel : PageModel
    {
        private readonly ItemRepository _itemRepository;
        private readonly ProductRepository _productRepository;
        private readonly SizeRepository _sizeRepository;
        private readonly ColorRepository _colorRepository;
        private readonly CategoryRepository _categoryRepository;

        public ItemAddModel(ItemRepository itemRepository, ProductRepository productRepository, SizeRepository sizeRepository, ColorRepository colorRepository, CategoryRepository categoryRepository)
        {
            _itemRepository = itemRepository;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
            _colorRepository = colorRepository;
            _categoryRepository = categoryRepository;
        }

        [BindProperty]
        public InputModel BoundInputModel { get; set; }
        public ItemCommandModel CreateCommand { get; set; }

        public SelectList AvailableProducts { get; set; }
        public SelectList AvailableSizes { get; set; }
        public SelectList AvailableColors { get; set; }
        public SelectList AvailableCategories { get; set; }

        public class InputModel
        {
            public string ProductName { get; set; }
            public string ColorName { get; set; }
            public string CategoryName { get; set; }
            public string SizeName { get; set; }
            public string ItemName { get; set; }
        }

        public async Task OnGet()
        {
            await PopulateSelectListItems();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectListItems();
                return Page();
            }
                
            await ConstructCommandModel();
            await _itemRepository.CreateItem(CreateCommand);

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
            CreateCommand = new ItemCommandModel();

            CreateCommand.ItemProduct
                = (await _productRepository.GetEntityCollection(
                    p => p.Name == BoundInputModel.ProductName)).Single();

            CreateCommand.ItemColor
                = (await _colorRepository.GetEntityCollection(
                    p => p.Name == BoundInputModel.ColorName)).Single();

            CreateCommand.ItemSize
                = (await _sizeRepository.GetEntityCollection(
                    p => p.Name == BoundInputModel.SizeName)).Single();

            CreateCommand.ItemCategory
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
    }
}
