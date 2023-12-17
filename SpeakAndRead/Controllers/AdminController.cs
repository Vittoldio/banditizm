using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpeakAndRead.Data;
using SpeakAndRead.Models;
using SpeakAndRead.ViewModels;

namespace SpeakAndRead.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _context;
        UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public AdminController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        [Authorize(Roles = "Admin,Director")]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();

            return View(users);
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddRole()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole([Bind("UserId,RoleId")] UserRoleViewModel userRole)
        {
            try
            {
                User user = _userManager.FindByIdAsync(userRole.UserId).Result;
                IdentityRole role = _roleManager.FindByIdAsync(userRole.RoleId).Result;
                bool isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                if (ModelState.IsValid)
                {
                    if (user != null)
                    {
                        if(role != null)
                        {
                            if (!isInRole)
                            {
                                await _userManager.AddToRoleAsync(user, role.Name);
                            }
                            else {
                                TempData["Error"] = $"User already has {role.Name} role!";
                                return RedirectToAction(nameof(AddRole));
                            }
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index));
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "User already has this role!";
                return RedirectToAction(nameof(AddRole));
            }
        }

        [Authorize(Roles = "Admin, Director, Teacher")]
        public IActionResult CreateEnroll()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View();
        }

        [Authorize(Roles = "Admin, Director, Teacher")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEnroll([Bind("UserId,CourseId")] CourseUser courseUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.CourseUsers.Add(courseUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index));
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "Duplicate enrollment";
                return RedirectToAction(nameof(CreateEnroll));
            }
        }
    }
}
