using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{

    public class ListOfMonuments
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование (кырг.)")]
        public string NameKyrg { get; set; }
        [Display(Name = "Датировка памятника")]
        public string DatingOfMonument { get; set; }
        [Display(Name = "Район")]
        public int? DictDistrictId { get; set; }

        [Display(Name = "Район")]
        public DictDistrict DictDistrict { get; set; }
        [Display(Name = "Адрес")]
        public string LegalAddress { get; set; }
        [Display(Name = "Источник финансирования")]
        public int? DictFinSourceId { get; set; }
        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Тип объекта")]
        public int DictMonumentTypeId { get; set; }
        [Display(Name = "Тип объекта")]
        public DictMonumentType DictMonumentType { get; set; }
        [Display(Name = "Признак утраты")]
        public int DictMonumemtSignOfLossId { get; set; }
        [Display(Name = "Признак утраты")]
        public DictMonumemtSignOfLoss DictMonumemtSignOfLoss { get; set; }
        public DateTime CreateDate { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

  
    public class DictMonumemtSignOfLoss
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование")]
        public string NameRus { get; set; }
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }
    public class DictMonumentType
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование")]
        public string NameRus { get; set; }
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class ListOfMonumetnTypologicalAccessory
    {
        public int Id { get; set; }

        [Display(Name = "Памятники")]
        public int ListOfMonumentsId { get; set; }
        [Display(Name = "Памятники")]
        public ListOfMonuments ListOfMonuments { get; set; }

        [Display(Name = "Типологическая принадлежность")]
        public int DictMonumentTypologicalTypeId { get; set; }
        [Display(Name = "Типологическая принадлежность")]
        public DictMonumentTypologicalType DictMonumentTypologicalType { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }


    public class DictMonumentTypologicalType
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование")]
        public string NameRus { get; set; }
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }

}
