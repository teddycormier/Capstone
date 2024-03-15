using System.ComponentModel.DataAnnotations;

namespace Capstone.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "The FirstName field is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The LastName field is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        public string Email { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Display(Name = "Weight")]
        public string Weight { get; set; }

        [Display(Name = "Height")]
        public string Height { get; set; }

        [Display(Name = "Workouts/Week")]
        public int WorkoutsPerWeek { get; set; }

        [Display(Name = "Squat PR")]
        public string SquatPR { get; set; }

        [Display(Name = "Bench Press PR")]
        public string BenchPressPR { get; set; }

        [Display(Name = "Deadlift PR")]
        public string DeadliftPR { get; set; }

        [Display(Name = "Overhead Press PR")]
        public string OverheadPressPR { get; set; }
    }
}
