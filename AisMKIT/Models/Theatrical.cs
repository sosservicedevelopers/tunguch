using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{
    #region TZY
    // Реестр и схожие таблицы
    // Реестр ТЗУ
    public class ListOfTheatrical
    {
        public int Id { get; set; }

        [Display(Name = "Наименование ТЗУ (рус.)")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование ТЗУ (кырг.)")]
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

        [Display(Name = "Фамилия худ. руков.")]
        public string LastNameOfArtsDirector { get; set; }

        [Display(Name = "Имя худ. руков.")]
        public string FirstNameOfArtsDirector { get; set; }

        [Display(Name = "Отчество худ. руков.")]
        public string PatronicNameOfArtsDirector { get; set; }

        [Display(Name = "Количество штатных единиц")]
        public int NumEmployees { get; set; }

        [Display(Name = "Источник финансирования")]
        public int? DictFinSourceId { get; set; }

        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Дата перерегистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReregistrationDate { get; set; }

        [Display(Name = "Дата ликвидации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }

        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    public class ListOfTheatricalHistory
    {

        public int Id { get; set; }
        [Display(Name = "ТЗУ")]
        [Required(ErrorMessage = "Обязательно заполните")]
        public int ListOfTheatricalId { get; set; }

        [Display(Name = "Наименование ТЗУ (рус.)")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование ТЗУ (кырг.)")]
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

        [Display(Name = "Фамилия худ. руков.")]
        public string LastNameOfArtsDirector { get; set; }

        [Display(Name = "Имя худ. руков.")]
        public string FirstNameOfArtsDirector { get; set; }

        [Display(Name = "Отчество худ. руков.")]
        public string PatronicNameOfArtsDirector { get; set; }

        [Display(Name = "Количество штатных единиц")]
        public int NumEmployees { get; set; }

        [Display(Name = "Источник финансирования")]
        public int? DictFinSourceId { get; set; }

        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Дата перерегистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReregistrationDate { get; set; }

        [Display(Name = "Дата ликвидации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    // Таблица Членов художественного совета
    public class ListOfCouncilTheatrical
    {
        public int Id { get; set; }

        [Display(Name = "ТЗУ")]
        [Required(ErrorMessage = "Обязательно заполните")]
        public int ListOfTheatricalId { get; set; }
        [Display(Name = "ТЗУ")]
        public ListOfTheatrical ListOfTheatrical { get; set; }


        [Display(Name = "Фамилия")]
        public string LastNameOfArts { get; set; }

        [Display(Name = "Имя")]
        public string FirstNameOfArts { get; set; }

        [Display(Name = "Отчество")]
        public string PatronicNameOfArts { get; set; }

        [Display(Name = "Дата включения в худ. совет ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateInArtCouncil { get; set; }

        [Display(Name = "Дата выхода из худ. совета")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ? DateOutArtCouncil { get; set; }

        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
 

    // Репертуары
    public class ListOfEventsTheatrical
    {
        public int Id { get; set; }
        [Display(Name = "ТЗУ")]
        [Required(ErrorMessage = "Обязательно заполните")]
        public int ListOfTheatricalId { get; set; }
        [Display(Name = "ТЗУ")]
        public ListOfTheatrical ListOfTheatrical { get; set; }

        [Display(Name = "Год")]
        public string Year { get; set; }

        [Display(Name = "Месяц")]
        public string Month { get; set; }

        [Display(Name = "День")]
        public string DayOfMonth { get; set; }

        [Display(Name = "Время")]
        public string Time { get; set; }

        [Display(Name = "Наименование мероприятия")]
        public string NameOfEvent { get; set; }

        [Display(Name = "Наименование зала")]
        public int DictTheatricalHallId { get; set; }
        public DictTheatricalHall DictTheatricalHall { get; set; }

        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

 
    public class DictTheatricalHall
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование (Русск)")]
        public string NameRus { get; set; }
        public int DictStatusId { get; set; }
        public DictStatus DictStatus { get; set; }
        public DateTime CreateDate { get; set; }

    }

    #endregion


    public class ListOfEduInstituts
    {
        public int Id { get; set; }

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

        [Display(Name = "Вид учебного заведения")]
        public int DictEduInstTypeId { get; set; }
        [Display(Name = "Вид учебного заведения")]
        public DictEduInstType DictEduInstType { get; set; }
 
        [Display(Name = "Источник финансирования")]
        public int? DictFinSourceId { get; set; }

        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Дата перерегистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReregistrationDate { get; set; }

        [Display(Name = "Дата ликвидации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }

        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    public class DictEduInstType
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование (Русск)")]
        public string NameRus { get; set; }

    }

}
