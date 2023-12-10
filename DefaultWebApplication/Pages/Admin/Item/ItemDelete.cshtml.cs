using DefaultWebApplication.Services.Repositories.Bridge_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Item
{
    public class ItemDeleteModel : PageModel
    {
        private readonly ItemRepository _repository;

        public ItemDeleteModel(ItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> OnGet([FromRoute] int id)
        {
            await _repository.DeleteItemById(id);
            return RedirectToPage("itemmain");
        }
    }
}
