using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Models
{

    #region GolobalDictionay
    // Регионы (области)
    public class DictRegion
    {
        public int Id { get; set; }

        [Display(Name = "Регион (кырг.)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Регион (рус.)")]
        public string NameRus { get; set; }

    }

    // Район
    public class DictDistrict
    {

        public int Id { get; set; }

        [Display(Name = "Район (кырг.)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Район (рус.)")]
        public string NameRus { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Регион")]
        public int DictRegionId { get; set; }

        [Display(Name = "Регион")]
        public DictRegion DictRegion { get; set; }

    }

    // Организационно-правовая форма
    public class DictLegalForm
    {
        public int Id { get; set; }

        [Display(Name = "Организационно-правовая форма (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Организационно-правовая форма (Русск)")]
        public string NameRus { get; set; }

        [Display(Name = "Дата ввода записи")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }

        [Display(Name = "Дата, с которой запись признана неактуальной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DeactiveDate { get; set; }


    }


    // статус
    public class DictStatus
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    // Источник финансирования
    public class DictFinSource
    {
        public int Id { get; set; }

        [Display(Name = "Источник финансирования (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Источник финансирования (Русск)")]
        public string NameRus { get; set; }

        [Display(Name = "Дата ввода записи")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }

        [Display(Name = "Дата, с которой запись признана неактуальной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ? DeactiveDate { get; set; }

    }

    #endregion
    #region DictForSMI

    // Типы СМИ
    public class DictMediaType
    {
        public int Id { get; set; }

        [Display(Name = "Наименование вида СМИ (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование вида СМИ (Русск)")]
        public string NameRus { get; set; }

        [Display(Name = "Дата ввода записи")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }

        [Display(Name = "Дата, с которой запись признана неактуальной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }

    }

    public class DictMediaDistribTerritory
    {
        public int Id { get; set; }

        [Display(Name = "Административная территория (руск.)")]
        public string NameRus { get; set; }

        [Display(Name = "Административная территория (кырг.)")]
        public string NameKyrg { get; set; }
    }

    // Язык вещания СМИ
    public class DictMediaLangType
    {
        public int Id { get; set; }

        [Display(Name = "Язык вещания СМИ (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Язык вещания СМИ (Русск)")]
        public string NameRus { get; set; }

        [Display(Name = "Дата ввода записи")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }

        [Display(Name = "Дата, с которой запись признана неактуальной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }

    }


    // Периодичность выпуска СМИ
    public class DictMediaFreqRelease
    {
        public int Id { get; set; }

        [Display(Name = "Периодичность выпуска (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Периодичность выпуска (Русск)")]
        public string NameRus { get; set; }

        [Display(Name = "Дата ввода записи")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }

        [Display(Name = "Дата, с которой запись признана неактуальной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }

    }


    // Орган выдающий разрещения
    public class DictAgencyPerm
    {
        public int Id { get; set; }

        [Display(Name = "Орган выдающий разрещения (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Орган выдающий разрещения (Русск)")]
        public string NameRus { get; set; }


        [Display(Name = "Дата ввода записи")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }

        [Display(Name = "Дата, с которой запись признана неактуальной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }

    }


    // Вид проверки СМИ
    public class DictControlType
    {
        public int Id { get; set; }

        [Display(Name = "Вид проверки СМИ (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Вид проверки СМИ (Русск)")]
        public string NameRus { get; set; }

        [Display(Name = "Дата ввода записи")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }

        [Display(Name = "Дата, с которой запись признана неактуальной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }


    }

    // Результаты проверки СМИ
    public class DictMediaControlResult
    {
        public int Id { get; set; }

        [Display(Name = "Результаты проверки СМИ (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Результаты проверки СМИ (Русск)")]
        public string NameRus { get; set; }

        [Display(Name = "Дата ввода записи")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }

        [Display(Name = "Дата, с которой запись признана неактуальной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }

    }

    // Судебное решение
    public class DictMediaSuitPerm
    {
        public int Id { get; set; }

        [Display(Name = "Судебное решение (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Судебное решение (Русск)")]
        public string NameRus { get; set; }

        [Display(Name = "Дата ввода записи")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreateDate { get; set; }


        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }

        [Display(Name = "Дата, с которой запись признана неактуальной")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeactiveDate { get; set; }

    }

    #endregion

    public class DictCountry
    {
        public int Id { get; set; }

        [Display(Name = "Страна")]
        public string Name { get; set; }

    }
    
    public class Dictionaries
    {
    }
}
