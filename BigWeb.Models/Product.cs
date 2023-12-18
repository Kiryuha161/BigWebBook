using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BigWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле \"Название\" обязательно")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        [Required]
        public string ISBN { get; set; }
        
        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Цена по прейскуранту")]
        [Range(0, 30000, ErrorMessage = "Цена не может превышать 30000")]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Цена за 1-50 книг")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Цена за 50+ книг")]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Цена за 100+ книг")]
        public double Price100 { get; set; }

        [Display(Name = "Id категории")]
        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        [ForeignKey("CategoryId")]

        [ValidateNever]
        public Category CategoryName { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
