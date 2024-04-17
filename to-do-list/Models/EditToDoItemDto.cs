using System.ComponentModel.DataAnnotations;

namespace to_do_list.Models
{
    public class EditToDoItemDto
    {

        [Required]
        [RegularExpression(@"^[\w\s]{1,20}$", ErrorMessage = "El título no puede contener mas de 20 caracteres")]
        public string title { get; set; }

        [Required]
        [RegularExpression(@"^[\w\s]{1,255}$", ErrorMessage = "La descripción no puede tener mas de 255 caracteres")]
        public string description { get; set; }
    }
}
