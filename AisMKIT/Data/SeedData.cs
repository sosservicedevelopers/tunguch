using AisMKIT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AisMKIT.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder, ApplicationDbContext context)
        {
            modelBuilder.Entity<DictRegion>().HasData(
               new DictRegion() { NameRus = "Чуй", NameKyrg = "Чуй" },
              new DictRegion() { NameRus = "Иссык-Куль", NameKyrg = "Иссык-Куль" },
              new DictRegion() { NameRus = "Ош", NameKyrg = "Ош" },
              new DictRegion() { NameRus = "Джалал-Абад", NameKyrg = "Джалал-Абад" },
              new DictRegion() { NameRus = "Талас", NameKyrg = "Талас" },
              new DictRegion() { NameRus = "Нарын", NameKyrg = "Нарын" },
              new DictRegion() { NameRus = "Баткен", NameKyrg = "Баткен" },
               new DictRegion() { NameRus = "г. Бишкек", NameKyrg = "г. Бишкек" },
            new DictRegion() { NameRus = "г. Ош", NameKyrg = "г. Ош" }
            );

        }
    }

    public class DataSeeder
    {

        public static void SeedCountries(ApplicationDbContext context)
        {

            
                if (!context.Departments.Any())
                {
                    context.Departments.Add(new Departments { Address = "", Contacts = "", Name = "IT", Phone = "XXX" });
                    context.SaveChanges();
                }
                if (!context.Roles.Any())
                {
                    IdentityRole role = new IdentityRole("Администратор");
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор", NormalizedName = "АДМИНИСТРАТОР" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-СМИ", NormalizedName = "АДМИНИСТРАТОР-СМИ" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-Памятники", NormalizedName = "АДМИНИСТРАТОР-ПАМЯТНИКИ" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-Кинематография", NormalizedName = "АДМИНИСТРАТОР-КИНЕМАТОГРАФИЯ" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-ТЗУ", NormalizedName = "АДМИНИСТРАТОР-ТЗУ" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-УчебЗаведения", NormalizedName = "АДМИНИСТРАТОР-УЧЕБЗАВЕДЕНИЯ" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-Туризм", NormalizedName = "АДМИНИСТРАТОР-ТУРИЗМ" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-Библиотека", NormalizedName = "АДМИНИСТРАТОР-БИБЛИОТЕКА" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-Культура", NormalizedName = "АДМИНИСТРАТОР-КУЛЬТУРА" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-ПредоставЗалов", NormalizedName = "АДМИНИСТРАТОР-ПРЕДОСТАВЗАЛОВ" });
                    context.Roles.Add(new IdentityRole { ConcurrencyStamp = (new Guid()).ToString(), Name = "Администратор-Награды", NormalizedName = "АДМИНИСТРАТОР-НАГРАДЫ" });
                    context.SaveChanges();
                }

                if (!context.DictRegion.Any())
                {
                    context.DictRegion.Add(new DictRegion() { NameRus = "Чуй", NameKyrg = "Чуй" });
                    context.DictRegion.Add(new DictRegion() { NameRus = "Иссык-Куль", NameKyrg = "Иссык-Куль" });
                    context.DictRegion.Add(new DictRegion() { NameRus = "Ош", NameKyrg = "Ош" });
                    context.DictRegion.Add(new DictRegion() { NameRus = "Джалал-Абад", NameKyrg = "Джалал-Абад" });
                    context.DictRegion.Add(new DictRegion() { NameRus = "Талас", NameKyrg = "Талас" });
                    context.DictRegion.Add(new DictRegion() { NameRus = "Нарын", NameKyrg = "Нарын" });
                    context.DictRegion.Add(new DictRegion() { NameRus = "Баткен", NameKyrg = "Баткен" });
                    context.DictRegion.Add(new DictRegion() { NameRus = "г. Бишкек", NameKyrg = "г. Бишкек" });
                    context.DictRegion.Add(new DictRegion() { NameRus = "г. Ош", NameKyrg = "г. Ош" });
                    context.SaveChanges();
                }

                if (!context.DictDistrict.Any())
                {
                    context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Аламедин", NameRus = "Аламедин", City = "", DictRegionId = 1 });
                    context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Сокулук", NameRus = "Сокулук", City = "", DictRegionId = 1 });
                    context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Тон", NameRus = "Тон", City = "", DictRegionId = 2 });
                    context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Иссыккульский", NameRus = "Иссыккульский", City = "", DictRegionId = 2 });
                    context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Кара-Суйский", NameRus = "Кара-Суйский", City = "", DictRegionId = 3 });
                    context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Узгенский", NameRus = "Узгенский", City = "", DictRegionId = 3 });
                    context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Сузакский", NameRus = "Сузакский", City = "", DictRegionId = 4 });
                    context.DictDistrict.Add(new DictDistrict() { NameKyrg = "Чаткальский", NameRus = "Чаткальский", City = "", DictRegionId = 4 });
                    context.SaveChanges();
                }
                if (!context.DictStatus.Any())
                {
                    context.DictStatus.Add(new DictStatus() { Name = "Активное" });
                    context.DictStatus.Add(new DictStatus() { Name = "Неактивное" });
                    context.SaveChanges();
                }

                if (!context.DictFinSource.Any())
                {
                    context.DictFinSource.Add(new DictFinSource() { NameRus = "Государственное", NameKyrg = "Государственное", CreateDate = DateTime.Now, DictStatusId = 1 });
                    context.DictFinSource.Add(new DictFinSource() { NameRus = "Коммерческое", NameKyrg = "Коммерческое", CreateDate = DateTime.Now, DictStatusId = 1 });
                    context.DictFinSource.Add(new DictFinSource() { NameRus = "Муниципиальное", NameKyrg = "Муниципиальное", CreateDate = DateTime.Now, DictStatusId = 1 });
                    context.SaveChanges();
                }
                if (!context.DictMediaLangType.Any())
                {
                    context.DictMediaLangType.Add(new DictMediaLangType() { NameRus = "Кыргызское", NameKyrg = "Кыргызское", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMediaLangType.Add(new DictMediaLangType() { NameRus = "Русское", NameKyrg = "Русское", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMediaLangType.Add(new DictMediaLangType() { NameRus = "Смешанное", NameKyrg = "Смешанное", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }
                if (!context.DictMediaControlResult.Any())
                {
                    context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "Без нарушений", NameRus = "Без нарушений", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "Вынесено предупреждение", NameRus = "Вынесено предупреждение", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "Наложен штраф", NameRus = "Наложен штраф", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "Отзыв разрешения", NameRus = "Отзыв разрешения", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }

                if (!context.DictLegalForm.Any())
                {
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Муниципальное (коммунальное) предприятие", NameKyrg = "Муниципальное (коммунальное) предприятие", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Открытое акционерное общество", NameKyrg = "Открытое акционерное общество", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Полное товарищество", NameKyrg = "Полное товарищество", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Коммандитное товарищество", NameKyrg = "Коммандитное товарищество", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Общество с ограниченной ответственностью", NameKyrg = "Общество с ограниченной ответственностью", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Общество с дополнительной ответственностью", NameKyrg = "Общество с дополнительной ответственностью", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Акционерное общество", NameKyrg = "Акционерное общество", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Крестьянское (фермерское) хозяйство", NameKyrg = "Крестьянское (фермерское) хозяйство", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Кооператив как коммерческая организация", NameKyrg = "Кооператив как коммерческая организация", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Общественное объединение", NameKyrg = "Общественное объединение", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Общественный фонд", NameKyrg = "Общественный фонд", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Религиозные организации", NameKyrg = "Религиозные организации", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Кондоминиум", NameKyrg = "Кондоминиум", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Фондовая биржа", NameKyrg = "Фондовая биржа", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Политические партии", NameKyrg = "Политические партии", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Кредитные союзы", NameKyrg = "Кредитные союзы", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Филиалы юридического лица", NameKyrg = "Филиалы юридического лица", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Представительство юридического лица", NameKyrg = "Представительство юридического лица", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Первичная профсоюзная организация", NameKyrg = "Первичная профсоюзная организация", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Объединение профсоюзных организаций", NameKyrg = "Объединение профсоюзных организаций", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Учреждение", NameKyrg = "Учреждение", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictLegalForm.Add(new DictLegalForm() { NameRus = "Государственное предприятие", NameKyrg = "Государственное предприятие", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }

                if (!context.DictMediaType.Any())
                {
                    context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Печатное периодическое издание", NameRus = "Печатное периодическое издание", CreateDate = DateTime.Now, DictStatusId = 1 });
                    context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Печатное разовое издание", NameRus = "Печатное разовое издание", CreateDate = DateTime.Now, DictStatusId = 1 });
                    context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Телеканал", NameRus = "Телеканал", CreateDate = DateTime.Now, DictStatusId = 1 });
                    context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Оператор телевещания", NameRus = "Оператор телевещания", CreateDate = DateTime.Now, DictStatusId = 1 });
                    context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Радиоканал", NameRus = "Радиоканал", CreateDate = DateTime.Now, DictStatusId = 1 });
                    context.DictMediaType.Add(new DictMediaType() { NameKyrg = "Оператор радиовещания", NameRus = "Оператор радиовещания", CreateDate = DateTime.Now, DictStatusId = 1 });
                    context.SaveChanges();
                }

                if (!context.DictMediaFreqRelease.Any())
                {
                    context.DictMediaFreqRelease.Add(new DictMediaFreqRelease() { NameKyrg = "ежедневный", NameRus = "ежедневный", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMediaFreqRelease.Add(new DictMediaFreqRelease() { NameKyrg = "еженедельный", NameRus = "еженедельный", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMediaFreqRelease.Add(new DictMediaFreqRelease() { NameKyrg = "ежемесячный", NameRus = "ежемесячный", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }
                if (!context.DictAgencyPerm.Any())
                {
                    context.DictAgencyPerm.Add(new DictAgencyPerm() { NameKyrg = "Минюст", NameRus = "Минюст", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictAgencyPerm.Add(new DictAgencyPerm() { NameKyrg = "Госагенство", NameRus = "Госагенство", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }
                if (!context.DictControlType.Any())
                {
                    context.DictControlType.Add(new DictControlType() { NameKyrg = "Плановое", NameRus = "Плановое", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictControlType.Add(new DictControlType() { NameKyrg = "Внеплановое", NameRus = "Внеплановое", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }
                if (!context.DictMediaSuitPerm.Any())
                {
                    context.DictMediaSuitPerm.Add(new DictMediaSuitPerm() { NameKyrg = "В пользу лицензиата", NameRus = "В пользу лицензиата", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMediaSuitPerm.Add(new DictMediaSuitPerm() { NameKyrg = "В пользу лицензиара", NameRus = "В пользу лицензиара", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMediaSuitPerm.Add(new DictMediaSuitPerm() { NameKyrg = "другое", NameRus = "другое", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }
                if (!context.DictTheatricalHall.Any())
                {
                    context.DictTheatricalHall.Add(new DictTheatricalHall() { NameKyrg = "Большой зал", NameRus = "Большой зал", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictTheatricalHall.Add(new DictTheatricalHall() { NameKyrg = "Малый зал", NameRus = "Малый зал", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }
                if (!context.DictTourismServices.Any())
                {
                    context.DictTourismServices.Add(new DictTourismServices() { NameKyrg = "Туристический оператор", NameRus = "Туристический оператор", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictTourismServices.Add(new DictTourismServices() { NameKyrg = "Туристический агент", NameRus = "Туристический агент", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictTourismServices.Add(new DictTourismServices() { NameKyrg = "Предоставление мест размещения", NameRus = "Предоставление мест размещения", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictTourismServices.Add(new DictTourismServices() { NameKyrg = "Предоставление питания", NameRus = "Предоставление питания", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictTourismServices.Add(new DictTourismServices() { NameKyrg = "Экскурсионные услуги", NameRus = "Экскурсионные услуги", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictTourismServices.Add(new DictTourismServices() { NameKyrg = "Услуги гида-переводчика", NameRus = "Услуги гида-переводчика", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }
                if (!context.DictCinematographyServices.Any())
                {
                    context.DictCinematographyServices.Add(new DictCinematographyServices() { NameKyrg = "Производство фильма, кинолетописи", NameRus = "Производство фильма, кинолетописи", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictCinematographyServices.Add(new DictCinematographyServices() { NameKyrg = "Прокат, показ и восстановление фильма", NameRus = "Прокат, показ и восстановление фильма", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictCinematographyServices.Add(new DictCinematographyServices() { NameKyrg = "Техническое обслуживание кинозала", NameRus = "Техническое обслуживание кинозала", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictCinematographyServices.Add(new DictCinematographyServices() { NameKyrg = "Изготовление киноматериалов и кинооборудования", NameRus = "Изготовление киноматериалов и кинооборудования", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictCinematographyServices.Add(new DictCinematographyServices() { NameKyrg = "Выполнение работ и оказание услуг по производству фильма, кинолетописи", NameRus = "Выполнение работ и оказание услуг по производству фильма, кинолетописи", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictCinematographyServices.Add(new DictCinematographyServices() { NameKyrg = "Образовательная", NameRus = "Образовательная", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictCinematographyServices.Add(new DictCinematographyServices() { NameKyrg = "Научная и/или исследовательская", NameRus = "Научная и/или исследовательская", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictCinematographyServices.Add(new DictCinematographyServices() { NameKyrg = "Издательская, рекламно-пропагандистская деятельность в области кинематографии", NameRus = "Издательская, рекламно-пропагандистская деятельность в области кинематографии", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }
                if (!context.DictMonumemtSignOfLoss.Any())
                {
                    context.DictMonumemtSignOfLoss.Add(new DictMonumemtSignOfLoss() { NameKyrg = "Не утрачен", NameRus = "Не утрачен", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMonumemtSignOfLoss.Add(new DictMonumemtSignOfLoss() { NameKyrg = "Утрачен", NameRus = "Утрачен", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }

                if (!context.DictMonumentType.Any())
                {
                    context.DictMonumentType.Add(new DictMonumentType() { NameKyrg = "Музей", NameRus = "Музей", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMonumentType.Add(new DictMonumentType() { NameKyrg = "Цирк", NameRus = "Цирк", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMonumentType.Add(new DictMonumentType() { NameKyrg = "Филармония", NameRus = "Филармония", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMonumentType.Add(new DictMonumentType() { NameKyrg = "Театр", NameRus = "Театр", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();
                }
                if (!context.DictMonumentTypologicalType.Any())
                {
                    context.DictMonumentTypologicalType.Add(new DictMonumentTypologicalType() { NameKyrg = "История", NameRus = "История", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMonumentTypologicalType.Add(new DictMonumentTypologicalType() { NameKyrg = "Искусство", NameRus = "Искусство", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMonumentTypologicalType.Add(new DictMonumentTypologicalType() { NameKyrg = "Архитектура", NameRus = "Архитектура", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMonumentTypologicalType.Add(new DictMonumentTypologicalType() { NameKyrg = "Природа", NameRus = "Природа", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMonumentTypologicalType.Add(new DictMonumentTypologicalType() { NameKyrg = "Градостроительство", NameRus = "Градостроительство", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.DictMonumentTypologicalType.Add(new DictMonumentTypologicalType() { NameKyrg = "Археология", NameRus = "Археология", DictStatusId = 1, CreateDate = DateTime.Now });
                    context.SaveChanges();

                }

                if (!context.DictCinemaAgeRestrictions.Any())
                {
                    context.DictCinemaAgeRestrictions.Add(new DictCinemaAgeRestrictions() { Name = "Д" });
                    context.DictCinemaAgeRestrictions.Add(new DictCinemaAgeRestrictions() { Name = "16+" });
                    context.DictCinemaAgeRestrictions.Add(new DictCinemaAgeRestrictions() { Name = "12" });
                    context.DictCinemaAgeRestrictions.Add(new DictCinemaAgeRestrictions() { Name = "12+" });
                    context.DictCinemaAgeRestrictions.Add(new DictCinemaAgeRestrictions() { Name = "16" });
                    context.DictCinemaAgeRestrictions.Add(new DictCinemaAgeRestrictions() { Name = "Л" });
                    context.DictCinemaAgeRestrictions.Add(new DictCinemaAgeRestrictions() { Name = "18+" });
                    context.SaveChanges();

                }

                if (!context.DictCinemaDuration.Any())
                {
                    context.DictCinemaDuration.Add(new DictCinemaDuration() { Name = "53 мин" });
                    context.DictCinemaDuration.Add(new DictCinemaDuration() { Name = "1ч 40м" });
                    context.DictCinemaDuration.Add(new DictCinemaDuration() { Name = "1 ч 30 мин" });
                    context.DictCinemaDuration.Add(new DictCinemaDuration() { Name = "60 мин" });
                    context.DictCinemaDuration.Add(new DictCinemaDuration() { Name = "15 ч 33 м" });
                    context.SaveChanges();

                }
                if (!context.DictEduInstType.Any())
                {
                    context.DictEduInstType.Add(new DictEduInstType() { NameRus = "Высшее учебное заведение", NameKyrg = "Высшее учебное заведение" });
                    context.DictEduInstType.Add(new DictEduInstType() { NameKyrg = "Cреднее профессиональное учебное заведения", NameRus = "Cреднее профессиональное учебное заведения" });
                    context.DictEduInstType.Add(new DictEduInstType() { NameKyrg = "Школа", NameRus = "Школа" });
                    context.DictEduInstType.Add(new DictEduInstType() { NameKyrg = "Студия", NameRus = "Студия" });

                    context.SaveChanges();

                }

                if (!context.DictMediaDistribTerritory.Any())
                {
                    context.DictMediaDistribTerritory.Add(new DictMediaDistribTerritory() { NameRus = "Вся республика", NameKyrg = "Вся республика" });
                    context.DictMediaDistribTerritory.Add(new DictMediaDistribTerritory() { NameRus = "Область", NameKyrg = "Область" });
                    context.DictMediaDistribTerritory.Add(new DictMediaDistribTerritory() { NameRus = "Район", NameKyrg = "Район" });

                    context.SaveChanges();
                }

                if (!context.DictCinemaRegiser.Any())
                {
                    context.DictCinemaRegiser.Add(new DictCinemaRegiser() { LastName = "Асанов ", FirstName = "Н", Patronic = "", FullName = "" });
                    context.DictCinemaRegiser.Add(new DictCinemaRegiser() { LastName = "Турдумамбетов", FirstName = "Эльдар", Patronic = "", FullName = "" });

                    context.SaveChanges();
                }
                if (!context.DictMediaDistribTerritory.Any())
                {
                    context.DictMediaDistribTerritory.Add(new DictMediaDistribTerritory() { NameRus = "", NameKyrg = "" });
                    context.DictMediaDistribTerritory.Add(new DictMediaDistribTerritory() { NameRus = "", NameKyrg = "" });

                    context.SaveChanges();
                }
                if (!context.DictCountry.Any())
                {
                    var resourceName = "AisMKIT.Data.Countries.xml";
                    var assembly = Assembly.GetExecutingAssembly();
                    var stream = assembly.GetManifestResourceStream(resourceName);
                    var xml = XDocument.Load(stream);
                    var countries = xml.Element("countries")
                                    .Elements("country")
                                    .Select(x => new DictCountry
                                    {
                                        Name = (string)x.Element("name"),
                                        FullName = (string)x.Element("fullname"),
                                        Alpha2 = (string)x.Element("alpha2"),
                                        Alpha3 = (string)x.Element("alpha3"),
                                        English = (string)x.Element("english"),
                                        ISO = (string)x.Element("iso"),
                                        Location = (string)x.Element("location"),
                                        LocationPrecise = (string)x.Element("location-precise"),
                                    }).ToArray();
                    context.DictCountry.AddRange(countries); // AddOrUpdate(c => c.Name, countries);

                    context.SaveChanges();
                }

                //DictUnitOfMeasures
                if (!context.DictUnitOfMeasure.Any())
                {
                    context.DictUnitOfMeasure.Add(new DictUnitOfMeasure() { NameRus = "кв.м.", NameKyrg = "кв.м." });
                    context.DictUnitOfMeasure.Add(new DictUnitOfMeasure() { NameRus = "шт.", NameKyrg = "шт." });
                    context.DictUnitOfMeasure.Add(new DictUnitOfMeasure() { NameRus = "время", NameKyrg = "время" });

                    context.SaveChanges();
                }

                if (!context.DictRentObjectType.Any())
                {
                    context.DictRentObjectType.Add(new DictRentObjectType() { NameRus = "Зал", NameKyrg = "Зал", DictStatusId = 1, DictUnitOfMeasureId = 1, CreateDate = DateTime.Now });
                    context.DictRentObjectType.Add(new DictRentObjectType() { NameRus = "Костюм", NameKyrg = "Костюм", DictStatusId = 1, DictUnitOfMeasureId = 2, CreateDate = DateTime.Now });
                    context.DictRentObjectType.Add(new DictRentObjectType() { NameRus = "Инвентарь", NameKyrg = "Инвентарь", DictStatusId = 1, DictUnitOfMeasureId = 2, CreateDate = DateTime.Now });
                    context.DictRentObjectType.Add(new DictRentObjectType() { NameRus = "Реквизит", NameKyrg = "Реквизит", DictStatusId = 1, DictUnitOfMeasureId = 2, CreateDate = DateTime.Now });

                    context.SaveChanges();
                }

                if (!context.DictCountry.Any())
                {
                    context.DictMediaDistribTerritory.Add(new DictMediaDistribTerritory() { NameRus = "", NameKyrg = "" });
                    context.DictMediaDistribTerritory.Add(new DictMediaDistribTerritory() { NameRus = "", NameKyrg = "" });

                    context.SaveChanges();
                }




            //if (!context.Users.Any())
            //{
            //    string user1 = "editor1@example.com";
            //    ApplicationUser editor1 = new ApplicationUser { Email = user1, UserName = user1 }; ;

            //    IdentityResult result = userManager.CreateAsync(editor1, "ASDfgh1!");

            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRoleAsync(editor1, "АДМИНИСТРАТОР");
            //    }
            //}


            //if (!context.DictMediaControlResult.Any())
            //{
            //    context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "", NameRus = "", DictStatusId = 1, CreateDate = DateTime.Now });
            //    context.DictMediaControlResult.Add(new DictMediaControlResult() { NameKyrg = "", NameRus = "", DictStatusId = 1, CreateDate = DateTime.Now });
            //}


        }
    }
}
