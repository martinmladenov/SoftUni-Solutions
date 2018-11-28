using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eventures.Web.Areas.Identity.Pages.Account
{
    using Eventures.Models;

    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<EventuresUser> signInManager;
        private readonly UserManager<EventuresUser> userManager;

        public ExternalLoginModel(
            SignInManager<EventuresUser> signInManager,
            UserManager<EventuresUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string LoginProvider { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 3)]
            [RegularExpression(@"^[\w_\-.*~]{3,}$")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 3)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 3)]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "UCN")]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 10)]
            [RegularExpression(@"\d{10}")]
            public string UniqueCitizenNumber { get; set; }
        }

        public IActionResult OnGetAsync()
        {
            return this.RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            var redirectUrl = this.Url.Page("./ExternalLogin", pageHandler: "Callback", values: new {returnUrl});
            var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/");
            if (remoteError != null)
            {
                this.ErrorMessage = $"Error from external provider: {remoteError}";
                return this.RedirectToPage("./Login", new {ReturnUrl = returnUrl});
            }

            var info = await this.signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                this.ErrorMessage = "Error loading external login information.";
                return this.RedirectToPage("./Login", new {ReturnUrl = returnUrl});
            }

            var result = await this.signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                isPersistent: true, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                return this.LocalRedirect(returnUrl);
            }

            this.ReturnUrl = returnUrl;
            this.LoginProvider = info.LoginProvider;
            this.Input = new InputModel();

            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                this.Input.Email = info.Principal.FindFirstValue(ClaimTypes.Email);
            }

            if (info.Principal.HasClaim(c => c.Type == "urn:github:login"))
            {
                this.Input.Username = info.Principal.FindFirstValue("urn:github:login");
            }

            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Name))
            {
                var name = info.Principal.FindFirstValue(ClaimTypes.Name);

                var split = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (split.Length >= 2)
                {
                    this.Input.FirstName = split[0];
                    this.Input.LastName = split[split.Length - 1];
                }
                else
                {
                    this.Input.FirstName = name;
                }
            }

            return this.Page();
        }

        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("~/");
            var info = await this.signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                this.ErrorMessage = "Error loading external login information during confirmation.";
                return this.RedirectToPage("./Login", new {ReturnUrl = returnUrl});
            }

            if (this.ModelState.IsValid)
            {
                var user = new EventuresUser
                {
                    UserName = this.Input.Username,
                    Email = this.Input.Email,
                    FirstName = this.Input.FirstName,
                    LastName = this.Input.LastName,
                    UniqueCitizenNumber = this.Input.UniqueCitizenNumber
                };
                var result = await this.userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await this.userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        return this.LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            this.LoginProvider = info.LoginProvider;
            this.ReturnUrl = returnUrl;
            return this.Page();
        }
    }
}