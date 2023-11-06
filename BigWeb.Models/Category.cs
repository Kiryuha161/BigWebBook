using System.ComponentModel.DataAnnotations;

namespace BigWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Имя\" обязательно")]
        [Display(Name = "Название")]
        [MaxLength(30, ErrorMessage = "Имя не может состоять из более чем 30 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вы не указали порядковый номер")]
        [Display(Name = "Порядковый номер")]
        [Range(0, 200, ErrorMessage = "Порядковый номер не может быть меньше 1 и больше 200")]
        public int DisplayOrder { get; set; }
    }
}
