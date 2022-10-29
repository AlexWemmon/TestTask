using System;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Название книги обязательно для заполнения")]
        [Display(Name = "Название книги")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Любая цена")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
