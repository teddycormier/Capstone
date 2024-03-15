using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.ViewModels;

namespace Capstone.Controllers
{
    public class UserController : Controller
    {
        // GET: /User
        public IActionResult Index()
        {
            // Logic to retrieve and display user data
            return View();
        }

        // GET: /User/Details/{id}
        public IActionResult Details(int id)
        {
            // Logic to retrieve and display user details based on the provided ID
            return View();
        }

        // GET: /User/Edit/{id}
        public IActionResult Edit(int id)
        {
            var user = _userRepository.GetUserById(id); // need to link to SQL database
            if (user == null)
            {
                return NotFound();
            }
            var userViewModel = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
                // Map other user properties as needed
            };
            return View(userViewModel);
        }


        // POST: /User/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserById(id);  // need to link to SQL database
                user.FirstName = userViewModel.FirstName;
                user.LastName = userViewModel.LastName;
                user.Email = userViewModel.Email;
                // Update other user properties as needed

                _userRepository.UpdateUser(user);  // need to link to SQL database
                return RedirectToAction("Details", new { id = id });
            }
            return View(userViewModel);
        }

        // GET: /User/Delete/{id}
        public IActionResult Delete(int id)
        {
            // Logic to retrieve user details for deletion based on the provided ID
            return View();
        }

        // POST: /User/Delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            // Logic to delete user based on the provided ID
            return RedirectToAction("Index");
        }
    }
}
