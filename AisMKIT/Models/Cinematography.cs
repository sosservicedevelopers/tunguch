using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{

    public class ListOfCinematographyCertificates
    {
        public int Id { get; set; }

        [Display(Name = "Название фильма")]
        public string NameRus { get; set; }

        [Display(Name = "Название фильма (кырг.)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Страна")]
        public int? DictCountryId { get; set; }

        [Display(Name = "Страна")]
        public DictCountry DictCountry { get; set; }

        [Display(Name = "Год выпуска")]
        public string Years { get; set; }
        [Display(Name = "Режиссер")]
        public int? DictRegiserId { get; set; }

        [Display(Name = "Режиссер")]
        public DictRegiser DictRegiser { get; set; }

        [Display(Name = "Продолжительность")]
        public int? DictDurationId { get; set; }

        [Display(Name = "Продолжительность")]
        public DictDuration DictDuration { get; set; }

        [Display(Name = "Возрастное ограничение")]
        public int? DictAgeRestrictionsId { get; set; }

        [Display(Name = "Возрастное ограничение")]
        public DictAgeRestrictions DictAgeRestrictions { get; set; }

         
        [Display(Name = "Дата выдачи удостоверения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RegistrationDate { get; set; }
 
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }


    public class ListOfCinematography
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
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
               
        [Display(Name = "Фактический район")]
        public string FactDistrictId { get; set; }

        [Display(Name = "Юридический адрес фактически")]
        public string LegalFactAddress { get; set; }
        
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

    public class ListOfCinematographyHistory
    {
        public int Id { get; set; }
        public int ListOfCinematographyId { get; set; }
        public ListOfCinematography ListOfCinematography { get; set; }

        [Display(Name = "Наименование")]
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

        [Display(Name = "Фактический район")]
        public string FactDistrictId { get; set; }

        [Display(Name = "Юридический адрес фактически")]
        public string LegalFactAddress { get; set; }

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
    
    public class ListOfCinematographyServices
    {
        public int Id { get; set; }
        [Display(Name = "Услуги")]
        public int DictCinematographyServicesId { get; set; }
        [Display(Name = "Услуги")]
        public DictCinematographyServices DictCinematographyServices { get; set; }

        public int ListOfCinematographyId { get; set; }
        public ListOfCinematography ListOfCinematography { get; set; }
        [Display(Name = "Статус")]

        public int DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }
        [Display(Name = "Дата прекарщения услуги")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DeactivateStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    public class DictCinematographyServices
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование")]
        public string NameRus { get; set; }
        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class DictAgeRestrictions
    {
        public int Id { get; set; }

        [Display(Name = "Возрастное ограничение")]
        public string Name { get; set; }

    }

    public class DictRegiser
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronic { get; set; }

    }

    public class DictDuration
    {
        public int Id { get; set; }

        [Display(Name = "Продолжительность")]
        public string Name { get; set; }

    }
    

}
