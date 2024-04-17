using System.ComponentModel.DataAnnotations;

namespace to_do_list.Models
{
    public class UserDto
    {

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        public string name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string email { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "El campo no debe contener símbolos ni caracteres especiales.")]
        public string address { get; set; }

    }
}
