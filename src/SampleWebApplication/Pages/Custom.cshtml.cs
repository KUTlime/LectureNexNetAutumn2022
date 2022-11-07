using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleWebApplication.Pages
{
    public class CustomModel : PageModel
    {
        public string Title { get; set; } = "Custom";

        public void OnGet()
        {
        }
    }
}
