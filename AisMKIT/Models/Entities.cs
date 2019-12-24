using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Models
{
    public class ListOfKinomotografie
    {
        public int Id { get; set; }
        [Display(Name = "ИНН")]
        [Required(ErrorMessage = "ИНН обязательна")]
        public string INN { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Наименование категории обязательна")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Адрес обязательна")]
        public string Address { get; set; }
        [Display(Name = "Доменое имя")]
        public string DomenNames { get; set; }
        [Display(Name = "Дата основания")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfCreated { get; set; }
        [Display(Name = "Категория")]
        public int ClUchZavedCategoryId { get; set; }
        public ClUchZavedCategory ClUchZavedCategory { get; set; }

    }
    public class ListOfEducations
    {
        public int Id { get; set; }
        [Display(Name = "ИНН")]
        [Required(ErrorMessage = "ИНН обязательна")]
        public string INN { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Наименование категории обязательна")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Адрес обязательна")]
        public string Address { get; set; }
        [Display(Name = "Доменое имя")]
        public string DomenNames { get; set; }
        [Display(Name = "Дата основания")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfCreated { get; set; }
        [Display(Name = "Категория")]
        public int ClUchZavedCategoryId { get; set; }
        public ClUchZavedCategory ClUchZavedCategory { get; set; }

    }
}
