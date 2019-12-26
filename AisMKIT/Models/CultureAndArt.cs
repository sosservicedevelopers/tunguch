using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{ 

    public class ListOfCultAndArt
    {
        public int Id { get; set; }
        [Display(Name = "Тип объекта")]
        public int DictCultAndArtTypeId { get; set; }
        [Display(Name = "Тип объекта")]
        public DictCultAndArtType DictCultAndArtType { get; set; }
        [Display(Name = "Наименование (рус.)")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование (кырг.)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public int? DictLegalFormId { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public DictLegalForm DictLegalForm { get; set; }

        [Display(Name = "ИНН")]
        public string INN { get; set; }

        [Display(Name = "Фамилия директора")]
        public string LastNameDirector { get; set; }

        [Display(Name = "Имя директора")]
        public string FirstNameDirector { get; set; }

        [Display(Name = "Отчество директора")]
        public string PatronicNameDirector { get; set; }
        [Display(Name = "Источник финансирования")]
        public int? DictFinSourceId { get; set; }

        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Район")]
        public int? DictDistrictId { get; set; }

        [Display(Name = "Район")]
        public DictDistrict DictDistrict { get; set; }

        [Display(Name = "Юридический адрес")]
        public string LegalAddress { get; set; }
        
        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Дата перерегистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ReregistrationDate { get; set; }

        [Display(Name = "Дата ликвидации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DeactiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

      

    public class DictCultAndArtType
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

    public class ListOfCultEvents
    {
        public int Id { get; set; }

        [Display(Name = "Тип МКК")]
        public int DictTypeOfKMMId { get; set; }
        public DictTypeOfKMM DictTypeOfKMM { get; set; }

        [Display(Name = "Место проведения")]
        public int DistLocId { get; set; }
        [Display(Name = "Место проведения")]
        public DictLoc DistLoc { get; set; }

        [Display(Name = "Тема мероприятия")]
        public string EventTopic { get; set; } //Тема мероприятия

        [Display(Name = "Дата и время начало")]
        public string StartDateTime { get; set; } //дата и время начала

        [Display(Name = "Дата и время конец")]
        public string EndDateTime { get; set; } //дата и время конец

        [Display(Name = "Инициатор проекта")]
        public int DictInitiatorOfProjId { get; set; }
        [Display(Name = "Инициатор проекта")]
        public DictInitiatorOfProj DictInitiatorOfProj { get; set; }
    }

    public class DictTypeOfKMM
    {
        public int Id { get; set; }
        [Display(Name = "Тип МКК")]
        public string Name { get; set; }
    }

    public class DictLoc
    {
        public int Id { get; set; }
        [Display(Name = "Место проведения")]
        public string Name { get; set; }
    }
    public class DictInitiatorOfProj
    {
        public int Id { get; set; }
        [Display(Name = "Инициатор проекта")]
        public string Name { get; set; }
    }

}
