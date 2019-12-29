using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{

    public class ListOfEvents
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

        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }


    //public class DictTypeOfKMM
    //{
    //    public int Id { get; set; }
    //    [Display(Name = "Тип МКК")]
    //    public string Name { get; set; }
    //}

    //public class DictLoc
    //{
    //    public int Id { get; set; }
    //    [Display(Name = "Место проведения")]
    //    public string Name { get; set; }
    //}
    //public class DictInitiatorOfProj
    //{
    //    public int Id { get; set; }
    //    [Display(Name = "Инициатор проекта")]
    //    public string Name { get; set; }
    //}

}
