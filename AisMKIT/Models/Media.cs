using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Models
{

    // 
    public class ListOfMassMediaTest
    {
        public int Id { get; set; }

        [Display(Name = "Наименование органа СМИ (Рус.)")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование органа СМИ (Кырг.)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public int? DictLegalFormId { get; set; }
        [Display(Name = "Организационно-правовая форма")]
        public DictLegalForm DictLegalForm { get; set; }

        [Display(Name = "ИНН")]
        public string INN { get; set; }

        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Наименование СМИ")]
        public string Name { get; set; }

        [Display(Name = "Территория распространения продукции")]
        public int? DictDistribTerritoryMediaId { get; set; }
        public DictMediaDistribTerritory DictMediaDistribTerritory { get; set; }

        [Display(Name = "Язык вещания")]
        public int? DictLangMediaTypeId { get; set; }
        [Display(Name = "Язык вещания")]
        public DictMediaLangType DictMediaLangType { get; set; }

        [Display(Name = "Вид")]
        public int? DictMediaTypeId { get; set; }
        [Display(Name = "Вид")]
        public DictMediaType DictMediaType { get; set; }

        [Display(Name = "Адрес (Руск)")]
        public string AddressRus { get; set; }

        [Display(Name = "Адрес (Кырг)")]
        public string AddressKyrg { get; set; }

        [Display(Name = "Регион")]
        public int? DictRegionId { get; set; }
        [Display(Name = "Регион")]
        public DictRegion DictRegion { get; set; }

        [Display(Name = "Район")]
        public int? DictDistrictId { get; set; }
        [Display(Name = "Район")]
        public DictDistrict DictDistrict { get; set; }

        [Display(Name = "Периодичность выпуска")]
        public int? DictMediaFreqReleaseId { get; set; }
        [Display(Name = "Периодичность выпуска")]
        public DictMediaFreqRelease DictMediaFreqRelease { get; set; }

        [Display(Name = "Источник финансирования")]
        public int? DictMediaFinSourceId { get; set; }
        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Дата перерегистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReregistrationDate { get; set; }

        [Display(Name = "Дата ликвидации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EliminationDate { get; set; }

        [Display(Name = "Номер разрешения")]
        public int? NumberOfPermission { get; set; }

        [Display(Name = "Дата разрешения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PermissionDate { get; set; }

        [Display(Name = "Орган выдавший разрешение")]
        public int? DictAgencyPermId { get; set; }
        [Display(Name = "Орган выдавший разрешение")]
        public DictAgencyPerm DictAgencyPerm { get; set; }

        [Display(Name = "Дата квитанции по оплате")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfPay { get; set; }

        [Display(Name = "Номер разрешения ГАС")]
        public string NumOfPermGas { get; set; }

        [Display(Name = "Дата разрешения ГАС")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PermGASDate { get; set; }

        [Display(Name = "Дата прекращения разрешения ГАС")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PermElimGASDate { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    // Реестр СМИ
    public class ListOfMedia
    {
        public int Id { get; set; }

        [Display(Name = "Наименование органа СМИ (Рус.)")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование органа СМИ (Кырг.)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public int? DictLegalFormId { get; set; }
        [Display(Name = "Организационно-правовая форма")]
        public DictLegalForm DictLegalForm { get; set; }

        [Display(Name = "ИНН")]
        public string INN { get; set; }

        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Наименование СМИ")]
        public string Name { get; set; }

        [Display(Name = "Территория распространения продукции")]
        public string Territoryy { get; set; }
        //public int? DictDistribTerritoryMediaId { get; set; }
        //public DictMediaDistribTerritory DictMediaDistribTerritory { get; set; }

        [Display(Name = "Язык вещания")]
        public int? DictMediaLangTypeId { get; set; }
        [Display(Name = "Язык вещания")]
        public DictMediaLangType DictMediaLangType { get; set; }

        [Display(Name = "Вид")]
        public int? DictMediaTypeId { get; set; }
        [Display(Name = "Вид")]
        public DictMediaType DictMediaType { get; set; }

        [Display(Name = "Адрес (Руск)")]
        public string AddressRus { get; set; }

        [Display(Name = "Адрес (Кырг)")]
        public string AddressKyrg { get; set; }

       
        [Display(Name = "Периодичность выпуска")]
        public int? DictMediaFreqReleaseId { get; set; }
        [Display(Name = "Периодичность выпуска")]
        public DictMediaFreqRelease DictMediaFreqRelease { get; set; }

        [Display(Name = "Источник финансирования")]
        public int? DictFinSourceId { get; set; }
        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Дата перерегистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ReregistrationDate { get; set; }

        [Display(Name = "Дата ликвидации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EliminationDate { get; set; }

        public DateTime CreateDate { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    //Реестр Телерадиоканалов
    public class ListOfTeleRadio
    {
        public int Id { get; set; }

        [Display(Name = "СМИ")]
        public int ListOfMediaId { get; set; }
        [Display(Name = "СМИ")]
        public ListOfMedia ListOfMedia { get; set; }
   
        public DateTime CreateDate { get; set; }

        [Display(Name = "Номер разрешения")]
        public int NumberOfPermission { get; set; }

        [Display(Name = "Дата разрешения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PermissionDate { get; set; }

        [Display(Name = "Орган выдавший разрешение")]
        public int? DictAgencyPermId { get; set; }
        [Display(Name = "Орган выдавший разрешение")]
        public DictAgencyPerm DictAgencyPerm { get; set; }

        [Display(Name = "Дата квитанции по оплате")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateOfPay { get; set; }

        [Display(Name = "Номер разрешения ГАС")]
        public string NumOfPermGas { get; set; }

        [Display(Name = "Дата разрешения ГАС")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? PermGASDate { get; set; }

        [Display(Name = "Дата прекращения разрешения ГАС")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? PermElimGASDate { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    //История, дата перерегистрации=дата создания записи
    public class ListOfMediaHistory    
    {
        public int Id { get; set; }

        [Display(Name = "СМИ")]
        public int ListOfMediaId { get; set; }
        [Display(Name = "СМИ")]
        public ListOfMedia ListOfMedia { get; set; }

        [Display(Name = "Наименование органа СМИ (Рус.)")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование органа СМИ (Кырг.)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public int? DictLegalFormId { get; set; }
        [Display(Name = "Организационно-правовая форма")]
        public DictLegalForm DictLegalForm { get; set; }

        [Display(Name = "ИНН")]
        public string INN { get; set; }

        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Наименование СМИ")]
        public string Name { get; set; }

        [Display(Name = "Территория распространения продукции")]
        public string Territoryy { get; set; }
    
        [Display(Name = "Язык вещания")]
        public int? DictMediaLangTypeId { get; set; }
        [Display(Name = "Язык вещания")]
        public DictMediaLangType DictMediaLangType { get; set; }

        [Display(Name = "Вид")]
        public int? DictMediaTypeId { get; set; }
        [Display(Name = "Вид")]
        public DictMediaType DictMediaType { get; set; }

        [Display(Name = "Адрес (Руск)")]
        public string AddressRus { get; set; }

        [Display(Name = "Адрес (Кырг)")]
        public string AddressKyrg { get; set; }
         [Display(Name = "Периодичность выпуска")]
        public int? DictMediaFreqReleaseId { get; set; }
        [Display(Name = "Периодичность выпуска")]
        public DictMediaFreqRelease DictMediaFreqRelease { get; set; }

        [Display(Name = "Источник финансирования")]
        public int? DictMediaFinSourceId { get; set; }
        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Дата перерегистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ReregistrationDate { get; set; }

        [Display(Name = "Дата ликвидации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EliminationDate { get; set; }

        public DateTime CreateDate { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
        

    // Проверки и вынесенные решения
    public class ListOfControlMedia
    {
        public int Id { get; set; }

        [Display(Name = "Наименование СМИ")]
        [Required(ErrorMessage = "Обязательно заполните")]
        public int ListOfMediaId { get; set; }
        [Display(Name = "Наименование СМИ")]
        public ListOfMedia ListOfMedia { get; set; }

        [Display(Name = "Вид проверки")]
        [Required(ErrorMessage = "Обязательно заполните")]
        public int DictControlTypeId { get; set; }
        [Display(Name = "Вид проверки")]
        public DictControlType DictControlType { get; set; }

        [Display(Name = "Дата начала проверки")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Дата конца проверки")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Дата начала проверяемого периода")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StartDatePeriod { get; set; }

        [Display(Name = "Дата конца проверяемого периода")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDatePeriod { get; set; }

        [Display(Name = "Фамилия (проверяющего)")]
        [Required(ErrorMessage = "Обязательно заполните")]
        public string LastName { get; set; }

        [Display(Name = "Имя (проверяющего)")]
        [Required(ErrorMessage = "Обязательно заполните")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество (проверяющего)")]
        public string PatronicName { get; set; }

        [Display(Name = "Дата Акта проверки")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? ActDateControl { get; set; }

        [Display(Name = "Номер Акта")]
        public string NumberOfAct { get; set; }

        [Display(Name = "Результаты проверки")]
        public int? DictMediaControlResultId { get; set; }
        public DictMediaControlResult DictMediaControlResult { get; set; }

        [Display(Name = "Номер предупреждения")]
        public string NumberOfWarning { get; set; }

        [Display(Name = "Дата предупреждения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WarningDate { get; set; }

        [Display(Name = "Дата конца срока предупреждения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WarningEndDate { get; set; }

        //n
        [Display(Name = "Дата снятия предупреждения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WarningRemovalDate { get; set; }

        [Display(Name = "Дата документа о наложении штрафа")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfPenalty { get; set; }

        [Display(Name = "Номер документа о наложении штрафа")]
        public string DocNumPenalty { get; set; }

        [Display(Name = "Сумма штрафа")]
        public string PenaltySum { get; set; }

        [Display(Name = "Дата оплаты штрафа")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfPenaltyPay { get; set; }

        [Display(Name = "Дата решения на аннулирование разрешения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? AnulmentDate { get; set; }

        [Display(Name = "Номер решения на аннулирование разрешения")]
        public string NumberOfAnulment { get; set; }

        [Display(Name = "Дата иска в суд")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfSuit { get; set; }

        [Display(Name = "Номер иска в суд")]
        public string NumberOfSuit { get; set; }

        [Display(Name = "Дата судебного решения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DateOfSuitPerm { get; set; }

        [Display(Name = "Номер судебного решения")]
        public string NumberOfSuitPerm { get; set; }

        [Display(Name = "Судебное решение")]
        public int? DictMediaSuitPermId { get; set; }
        public DictMediaSuitPerm DictMediaSuitPerm { get; set; }
        public DateTime CreateDate { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }


    public class Media
    {
    }
}
