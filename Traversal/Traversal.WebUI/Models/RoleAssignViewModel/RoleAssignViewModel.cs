using Traversal.WebUI.Models.RoleCheckItemViewModel;

namespace Traversal.WebUI.Models.RoleAssignViewModel
{
    public class RoleAssignViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<RoleCheckViewModel> roleChecks { get; set; }
    }
}
