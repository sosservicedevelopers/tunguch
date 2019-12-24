using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AisMKIT.Areas.Media.Models
{
    public class PermissionMediaModel
    {    //[,System.Nullable`1[System.DateTime],System.Nullable`1[System.DateTime]]]
        [Display(Name = "Наименование/ФИО органа СМИ")]
        public string Name { get; set; }
        [Display(Name = "Организационно-правовая форма")]
        public string LegalForm { get; set; }
        [Display(Name = "ИНН органа СМИ")]
        public string INN { get; set; }
        [Display(Name = "Дата регистрации органа СМИ в МЮ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? RegisterDate { get; set; }
        [Display(Name = "Вид СМИ")]
        public string MediaType { get; set; }
        [Display(Name = "Номер разрешения")]
        public int PermissionNo { get; set; }
        [Display(Name = "Дата разрешения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime PermissionDate { get; set; }
        [Display(Name = "Орган выдавший разрешение")]
        public string DepPermGive { get; set; }
        [Display(Name = "Приостановлено c")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? WarningDate { get; set; }
        [Display(Name = "Приостановлено по")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? WarningEndDate { get; set; }
        /*
         *  Name = l.NameRus,
                        LegalForm = lf.NameRus,
                        INN=l.INN,
                        RegisterDate=l.RegistrationDate,
                        MediaType=mt.NameRus,
                        PermisionNo=ltr.NumberOfPermission,
                        PermisionDate=ltr.PermissionDate,
                        DepPermGive=ag.NameRus,
                        WarningDate=lcm.WarningDate,
                        WarningEndDate=lcm.WarningEndDate
         */

    }
}
