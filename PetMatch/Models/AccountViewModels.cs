using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PetMatch.Models
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(100, ErrorMessage = "La longitud mínima de la {0} debe ser mayor a {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Se requiere confirmar la contraseña.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class EditProfileViewModel
    {
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo electrónico es requerido.")]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Permanecer conectado")]
        public bool RememberMe { get; set; }
    }

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




    public class ProfileViewModel
    {
        private const string GenderMale = "male";
        private const string GenderFemale = "female";

        public string Name { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        [Required(ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "FirstNameRequired", ErrorMessage = "")]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        [Required(ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "LastNameRequired", ErrorMessage = "")]
        public string LastName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        [EmailAddress(ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "InvalidEmail", ErrorMessage = "")]
        [Required(ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "EmailRequired", ErrorMessage = "")]
        public string Email { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        [Required(ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "GenderRequired", ErrorMessage = "")]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "BirthDay", ResourceType = typeof(PetMatch.Web.Resources.Account))]
        [Required(ErrorMessageResourceType = typeof(PetMatch.Web.Resources.Account), ErrorMessageResourceName = "BirthDayRequired", ErrorMessage = "")]
        public DateTime BirthDay { get; set; }


    }

    public class LoginDetailViewMode
    {
        public string Name { get; set; }

        public Uri Picture { get; set; }

        public string Provider { get; set; }

        public string FirstName { get; set; }
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
