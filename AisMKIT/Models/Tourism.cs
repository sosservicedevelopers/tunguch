using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{ 

    public class ListOfTourism
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

    public class ListOfTourismHistory
    {
        public int Id { get; set; }

        public int ListOfTourismId { get; set; }
        public ListOfTourism ListOfTourism { get; set; }

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

    public class ListOfTourismServices
    {
        public int Id { get; set; }
        [Display(Name = "Услуги")]
        public int DictTourismServicesId { get; set; }
        [Display(Name = "Услуги")]
        public DictTourismServices DictTourismServices { get; set; }

        public int ListOfTourismId { get; set; }
        public ListOfTourism ListOfTourism { get; set; }
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

    public class DictTourismServices
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

    public class ListOfTourismIndicator
    {
        public int Id { get; set; }

        [Display(Name = "Год")]
        public string Year { get; set; }

        [Display(Name = "Объём ВВП")]
        public double GDP { get; set; }

        //новый
        [Display(Name = "Валовая добавленная стоимость в сфере туристической деятельности (млн. cомов)")]
        public double GrossValueAdded { get; set; }

        //новый
        [Display(Name = "Доля сферы туристической деятельности в ВВП (в процентах)")]
        public double ShareOfTourismInGDP { get; set; }

        //новый
        [Display(Name = "Поступления налоговых платежей в бюджет республики от туристической деятельности и деятельности гостиниц и ресторанов")]
        public double TaxRevenue { get; set; }

        //новый
        [Display(Name = "Общее число прибывших граждан из стран дальнего и ближнего зарубежья")]
        public double TheNumCitizensfromNearAndFar { get; set; }

        //новый
        [Display(Name = "в том числе из стран СНГ")]
        public double FromCIS { get; set; }

        //новый
        [Display(Name = "и из стран дальнего зарубежья")]
        public double FromForeign { get; set; }


        [Display(Name = "Общее число прибывших граждан в Кыргызскую Республику, на которых распространяется Закон 'О безвизовом режиме'")]
        public double InTurist { get; set; }

        [Display(Name = "количество выехавших туристов")]
        public double OutTurist { get; set; }

        [Display(Name = "Экспорт туристских услуг (доходы от приема иностранных граждан), млн. долларов США")]
        public double VolumeOfServicesForExport { get; set; }

        [Display(Name = "объем услуг на импорт")]
        public double VolumeOfServicesForImport { get; set; }

        //новый
        [Display(Name = "Инвестиции в основной капитал в сфере туризма, млн. сом ")]
        public double InvestmentsTourismSector { get; set; }


        [Display(Name = "сумма инвестиций из бюджета")]
        public double SummOfInvestFromBudget { get; set; }

        [Display(Name = "сумма частных внутренних  инвестиций")]
        public double SummOfPrivateDomesticInvest { get; set; }

        [Display(Name = "сумма   иностранных инвестиций")]
        public double SummOfForeignInvest { get; set; }

        [Display(Name = "среднемесячная зарплата по отрасли")]
        public double AverageMonthSalary { get; set; }

        //новый
        [Display(Name = "Доходы, полученные от перевозок туристов всеми видами транспорта, млн. сом")]
        public double RevenuesFromTransportTourists { get; set; }


        //новый
        [Display(Name = "Оборот розничной торговли в сфере туризма, млн. сом")]
        public double TourismTetailSales { get; set; }


        //новый
        [Display(Name = "Оборот ресторанов, баров, столовых и др. предприятий по поставке готовой пищи, млн. сом")]
        public double TurnoverPreparedFood { get; set; }


        //новый
        [Display(Name = "Услуги деятельности туристических агентств, млн. сом")]
        public double TravelAgencyServices { get; set; }


        //новый
        [Display(Name = "Услуги санаторно-курортной деятельности, млн. сом")]
        public double SanatoriumResortActivities { get; set; }

        //новый
        [Display(Name = "Услуги гостиниц и прочих мест краткосрочного проживания, млн. сом")]
        public double ServicesShortTermResidence { get; set; }

        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

}
