using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{
    public class ListOfLibraryIndicators
    {
        public int Id { get; set; }

        [Display(Name = "Наименование библиотеки")]
        public string LibraryName { get; set; } //название библиотеки

        [Display(Name = "Дата создания")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataSozdania { get; set; }
        
        [Display(Name = "Общий книжный фонд")]
        public string CountOfBook { get; set; }

        [Display(Name = "Кол-во читателей")]
        public string CountOfReaders { get; set; }
        
        [Display(Name = "Кол-во работников")]
        public string CountOfEmp { get; set; }

        [Display(Name = "Книговыдача")]
        public string Knigovydacha { get; set; }

        [Display(Name = "Адресные данные БГЦБС")]
        public string AddressData { get; set; }// Адресные данные БГЦБС

        [Display(Name = "Общая площадь м.кв.")]
        public string TotalArea { get; set; }//общ пл. м кв

        [Display(Name = "Посадочные места")]
        public string SeatLanding { get; set; }//посад места

        [Display(Name = "Аварийная капитальная библиотека")]
        public string EmerCapLib { get; set; }// авар капит библиотека

        [Display(Name = "Специально-приспособленная библиотека")]
        public string SpecAdapLib { get; set; }//специальная приспособленная библиотека

        [Display(Name = "Произведен капитальный ремонт")]
        public string OverhaulMade { get; set; }//произведен капитальный ремонт

        [Display(Name = "Произведен косметический ремонт")]
        public string Redecorated { get; set; }//произведен косметический ремонт

        [Display(Name = "Компьютеры /множит. штук")]
        public string Computers { get; set; }//компьютеры

        [Display(Name = "Подключение к интернету")]
        public string InternetConnection { get; set; }//подключение к интернету

        [Display(Name = "Компьютер для пользователей")]
        public string ComputersForUsers { get; set; }//компьютеры для пользователей

        [Display(Name = "Подключение для пользователей к интернету")]
        public string UserConnection { get; set; }//подключение пользователей к интернету

        [Display(Name = "Пользователи количество человек")]
        public string UsersLib { get; set; }//пользователи

        [Display(Name = "Поступило/выбыло  всего")]
        public string RecRetTotal { get; set; }//поступило, выбыло всего

        [Display(Name = "Всего документы экземпляры")]
        public string TotalNumOfEx { get; set; }//всего док экз    

        [Display(Name = "На кыргызском языке экземпляры")]
        public string CopKyrg { get; set; }//экземпляры на кыргызском

        [Display(Name = "Мероприятий, всего")]
        public string EventsLib { get; set; }//мероприятия

        [Display(Name = "Всего библиотекарей")]
        public string Librarians { get; set; }//библиотекари

        [Display(Name = "Образование человека")]
        public string DegEducation { get; set; }//образ чел

        [Display(Name = "Права устанавливающий документы")]
        public string PravaUstanavDoc { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
