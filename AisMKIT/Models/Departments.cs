using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Models
{
    public class Departments
    {
        public int Id { get; set; }
        [Display(Name="Наименование")]
        [Required(ErrorMessage ="Наименование департамента обязательна")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Наименование Адрес обязательна")]
        public string Address { get; set; }
        [Display(Name = "Контактное лицо")]
        public string Contacts { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
