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

        [Display(Name = "Наименов б - ки")]
        public string LibraryName { get; set; } //название библиотеки
        [Display(Name = "Дата создания")]
        public DateTime DataSozdania { get; set; }
        [Display(Name = "Общий книжный фонд")]
        public int CountOfBook { get; set; }
        [Display(Name = "Кол-во читателей")]
        public int CountOfReaders { get; set; }
        [Display(Name = "Кол-во работников")]
        public int CountOfEmp { get; set; }

        [Display(Name = "Книговыдача")]
        public int Knigovydacha { get; set; }

        [Display(Name = "Адресные данные БГЦБС")]
        public string AddressData { get; set; }// Адресные данные БГЦБС

        [Display(Name = "общ площ м кв")]
        public float TotalArea { get; set; }//общ пл. м кв

        [Display(Name = "посад места")]
        public string SeatLanding { get; set; }//посад места

        [Display(Name = "авар капит Б - ка")]
        public string EmerCapLib { get; set; }// авар капит библиотека

        [Display(Name = "спец присп Б - ка")]
        public string SpecAdapLib { get; set; }//специальная приспособленная библиотека

        [Display(Name = "Произв.капит ремонт")]
        public string OverhaulMade { get; set; }//произведен капитальный ремонт

        [Display(Name = "Произв. космет ремонт")]
        public string Redecorated { get; set; }//произведен косметический ремонт

        [Display(Name = "компьютеры /множит. шт")]
        public int Computers { get; set; }//компьютеры

        [Display(Name = "Подкл.к интернету")]
        public int InternetConnection { get; set; }//подключение к интернету

        [Display(Name = "Комп. Для пользоват")]
        public int ComputersForUsers { get; set; }//компьютеры для пользователей

        [Display(Name = "Подкл. для польз к интерн")]
        public int UserConnection { get; set; }//подключение пользователей к интернету

        [Display(Name = "Пользователи чел")]
        public int UsersLib { get; set; }//пользователи

        [Display(Name = "Поступило/ выбыло, всего")]
        public int RecRetTotal { get; set; }//поступило, выбыло всего

        [Display(Name = "всего док экз")]
        public int TotalNumOfEx { get; set; }//всего док экз    

        [Display(Name = "на кырг яз экз")]
        public int CopKyrg { get; set; }//экземпляры на кыргызском

        [Display(Name = "Мероприятий, всего")]
        public int EventsLib { get; set; }//мероприятия

        [Display(Name = "всегоб - рей чел")]
        public int Librarians { get; set; }//библиотекари

        [Display(Name = "Образ  чел")]
        public string DegEducation { get; set; }//образ чел

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
