using HumanCapitalManagement.Models;
using HumanCapitalManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Import Entity Framework related namespaces


namespace HumanCapitalManagement.Controllers

{

   
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly PasswordServices _passwordService;

        public LoginController(ApplicationDBContext dbContext, PasswordServices passwordService)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
        }

        // Action to display the login form
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Index(Login model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the hashed password associated with the user's username from the database
                string storedHashedPassword = _dbContext.Logins
                    .Where(u => u.Username == model.Username)
                    .Select(u => u.PasswordHash)
                    .FirstOrDefault();

                if (storedHashedPassword != null)
                {
                    // Verify the entered password using _passwordService
                    bool isPasswordCorrect = _passwordService.VerifyPassword(model.PasswordHash, storedHashedPassword);

                    if (isPasswordCorrect)
                    {
                        string role = _dbContext.Logins
                    .Where(u => u.Username == model.Username)
                    .Select(u => u.RoleName.RoleName)
                    .FirstOrDefault();

                        if (role == "Admin")
                        {
                            return RedirectToAction("~/Views/Dashboard/AdminDashboard.cshtml");
                        }
                        else if (role == "User")
                        {
                            return RedirectToAction("Dashboard/UserDashboard");
                        }
                        // Successful login; redirect to the user's dashboard or desired page
                        // return RedirectToAction("Dashboard");
                    }
                }

                // Password is incorrect or user not found; handle login failure
                ModelState.AddModelError("PasswordHash", "Incorrect password");
            }

            // Handle login validation errors
            return View(model);
        }

    //    public IActionResult Dashboard()
    //    {
    //        // Display the user's dashboard
    //        return View();
    //    }
    }

}