using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ParkNet.Pages.Shared
{
    public class PageModelBase :PageModel
    {

        public string UserId =>User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
