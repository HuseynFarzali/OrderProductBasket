using DefaultWebApplication.Models.View_Models.Detailed_Models;
using System.Diagnostics;

namespace DefaultWebApplication.Models.View_Models.Summary_Models
{
    public class UserSummaryViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserTagName { get; set; }
        public string UserEmail { get; set; }
        public bool UserDeleted { get; set; }
        public UserDetailedViewModel UserDetailedViewModel { get; set; }
    }
}
