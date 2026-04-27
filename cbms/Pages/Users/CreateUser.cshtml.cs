using cbms.Models;
using cbms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cbms.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateUserModel : PageModel
    {
        private IRepository<User> _userRepository;

        [BindProperty]
        public User User { get; set; }

        public SelectList Roles { get; set; } = new SelectList(new List<string> { "Admin"});

        public CreateUserModel(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _userRepository.Create(User);
            return RedirectToPage("/Index");
        }
    }
}
