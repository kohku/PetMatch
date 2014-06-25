using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PetMatch.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string Action { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "FirstName", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        [Required(ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "FirstNameRequired", ErrorMessage = "")]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        [Required(ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "LastNameRequired", ErrorMessage = "")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        [Required(ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "EmailRequired", ErrorMessage = "")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CellPhone", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        public string CellPhone { get; set; }

        [Display(Name = "State", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        public string State { get; set; }

        [Display(Name = "City", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        public string City { get; set; }

        [Display(Name = "Neighborhood", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        public string Neighborhood { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "PasswordLength", ErrorMessage = "", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        [Compare("Password", ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "PasswordDoesNotMatch", ErrorMessage = "")]
        public string ConfirmPassword { get; set; }

        public System.Web.Mvc.SelectList States
        {
            get
            {
                var all = Rainbow.Web.StateEntity.GetAll();

                var query = from s in all
                            where s.Visible
                            select new
                            {
                                ID = s.ID,
                                Name = s.Name
                            };

                return new System.Web.Mvc.SelectList(query.ToArray(), "ID", "Name");
            }
        }

        [Display(Name = "State", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        public System.Guid StateID { get; set; }

        [Display(Name = "City", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        public System.Guid CityID { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
