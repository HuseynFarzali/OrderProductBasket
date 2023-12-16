using DefaultWebApplication.Models.View_Models.Summary_Models;
using System.Collections;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.View_Models.Detailed_Models
{
    public class UserDetailedViewModel : DetailedViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int UserAge { get; set; }
        public string UserTagName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public List<ItemSummaryViewModel> ItemModels { get; set; }
    }
}
