using cbms.Models;
using cbms.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace cbms.Pages.Users
{
    public class LoginModel : PageModel
    {
        private IUserRepository _userRepository;

        [BindProperty]
        public string Name { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> OnPost()
        {
            var user = _userRepository.VerifyUser(Name, Password);
            if (user == null)
            {
                ErrorMessage = "Could not log in";
                return Page();
            }

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                BuildClaimsPrincipal(user));

            return RedirectToPage("/Index");
        }

        // Don't know if this is the best way to do this, but it works for now. P.S. took it form the lecture slides, so it should be fine.
        private ClaimsPrincipal BuildClaimsPrincipal(User user)
        {
            // Opbyg Claims-liste
            List<Claim> claims = [new Claim(ClaimTypes.Name, user.Name),
                              new Claim(ClaimTypes.Role, user.Role)];

            // Opret ClaimsIdentity (claims plus Authentication-strategi)
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Opret endeligt ClaimsPrincipal-objekt
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
