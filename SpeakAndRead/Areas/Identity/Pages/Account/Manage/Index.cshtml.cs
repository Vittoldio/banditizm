using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeakAndRead.Models;
using SpeakAndRead.Data;
namespace SpeakAndRead.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [MaxLength(40, ErrorMessage ="Name is maximum 40 characters long")]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [MaxLength(40, ErrorMessage = "Name is maximum 40 characters long")]
            [Display(Name = "SurnameName")]
            public string Surname { get; set; }
            [Display(Name = "Birth Date")]
            [DataType(DataType.Date)]
            [BindProperty]
            public DateTime BirthDate { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var name = user.Name;
            var surname = user.Surname;
            var date = user.BirthDate;

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Name = name,
                Surname = surname,
                BirthDate = date,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            ViewData["date"] = user.BirthDate.ToString();
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var userName = user.Name;
            var userSurname = user.Surname;
            var date = user.BirthDate;
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (Input.Name != userName)
            {
                user.Name = Input.Name;
                _context.Update(user);
                await _context.SaveChangesAsync();
                var newuser = await _userManager.GetUserAsync(User);
                if (newuser.Name != Input.Name)
                {
                    StatusMessage = "Unexpected error when trying to set name.";
                    return RedirectToPage();
                }
            }
            if (Input.Surname != userSurname)
            {
                user.Surname = Input.Surname;
                _context.Update(user);
                await _context.SaveChangesAsync();
                var newuser = await _userManager.GetUserAsync(User);
                if (newuser.Surname != Input.Surname)
                {
                    StatusMessage = "Unexpected error when trying to set surname.";
                    return RedirectToPage();
                }
            }
            if (Input.BirthDate != date)
            {
                user.BirthDate= Input.BirthDate;
                _context.Update(user);
                await _context.SaveChangesAsync();
                var newuser = await _userManager.GetUserAsync(User);
                if (newuser.Surname != Input.Surname)
                {
                    StatusMessage = "Unexpected error when trying to set birth date.";
                    return RedirectToPage();
                }
            }



            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
