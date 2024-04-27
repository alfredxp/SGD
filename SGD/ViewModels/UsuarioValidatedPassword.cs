using System.ComponentModel.DataAnnotations;

namespace SGD.ViewModels
{
    public class UsuarioValidatedPassword
    {
        public int Id { get; set; }

        [DataType(DataType.Password)]
        [StringLength(70)]
        [MinLength(5, ErrorMessage = "Este campo tiene que tener minimo {1}")]
        [Required(ErrorMessage = "Este campo debe ser llenado")]
        [Display(Name = "Contraseña Nueva")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [StringLength(70)]
        [MinLength(5, ErrorMessage = "Este campo tiene que tener minimo {1}")]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string PasswordConfirm { get; set; }
    }
}
