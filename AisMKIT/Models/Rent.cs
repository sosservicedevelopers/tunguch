using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{

    public class ListOfRentsHistory
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string LastNameDirector { get; set; }

        [Display(Name = "Имя")]
        public string FirstNameDirector { get; set; }

        [Display(Name = "Отчество")]
        public string PatronicNameDirector { get; set; }


        [Display(Name = "Наименование награды")]
        public int DictStateAwardsTypeId { get; set; }
        [Display(Name = "Наименование награды")]
        public DictStateAwardsType DictStateAwardsType { get; set; }


        [Display(Name = "Должность награжденного")]
        public int? DictAwardsPositionId { get; set; }

        [Display(Name = "Основание")]
        public DictAwardsPosition DictAwardsPosition { get; set; }

        [Display(Name = "Основание")]
        public int? DictAwardsReasonId { get; set; }

        [Display(Name = "Должность награжденного")]
        public DictAwardsReason DictAwardsReason { get; set; }


        [Display(Name = "Дата присуждения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? RegistrationDate { get; set; }


        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
    public class ListOfRents
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (рус.)")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование (кырг.)")]
        public string NameKyrg { get; set; }

        
        [Display(Name = "Тип объекта")]
        public int? DictRentObjectTypeId { get; set; }

        [Display(Name = "Тип объекта")]
        public DictRentObjectType DictRentObjectType { get; set; }
       
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    public class DictRentObjectType
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование (Русск)")]
        public string NameRus { get; set; }

        [Display(Name = "Единица измерения")]
        public int? DictUnitOfMeasureId { get; set; }

        [Display(Name = "Единица измерения")]
        public DictUnitOfMeasure DictUnitOfMeasure { get; set; }

        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class DictUnitOfMeasure
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование (Русск)")]
        public string NameRus { get; set; }


        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }

    

}
