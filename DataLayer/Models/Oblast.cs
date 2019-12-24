using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Oblast
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Область")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Реквизит")]
        public string Rekvisit { get; set; }

        [Required]
        [Display(Name = "Юр. адрес")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Примечание")]
        public string Description { get; set; }

    }
    public class Raion
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Район")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Область")]
        public int? OblastId { get; set; }
        public Oblast Oblast { get; set; }

        [Required]
        [Display(Name = "Примечание")]
        public string Description { get; set; }
    }



}
