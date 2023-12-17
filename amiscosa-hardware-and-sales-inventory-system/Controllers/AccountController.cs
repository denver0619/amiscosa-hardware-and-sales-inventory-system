using amiscosa_hardware_and_sales_inventory_system.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace amiscosa_hardware_and_sales_inventory_system.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View("Views/Account/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(String Manager)
        {
            bool isManager = !string.IsNullOrEmpty(Manager);

            return RedirectToAction("LoginForm", "Account", new { isManager });
        }

        public IActionResult LoginForm(bool isManager)
        {
            ViewData["isManager"] = isManager;
            return View("Views/Account/LoginForm.cshtml");
        }

        [HttpPost]
        public IActionResult LoginForm(LoginFormModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
